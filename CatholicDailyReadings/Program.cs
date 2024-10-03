// See https://aka.ms/new-console-template for more information
using CatholicDailyReadings.Business;
using CatholicDailyReadings.Models;
using CatholicDailyReadings.Utils;
using System.Text;



void GenerateFilesForELectionary()
{
    ChristmasCalculator christmasCalculator = new ChristmasCalculator();
    AdventCalculator adventCalculator = new AdventCalculator();
    MoonCalculator moonCalculator = new MoonCalculator();
    CycleCalculator cycleCalculator = new CycleCalculator();
    BibleProvider bibleProvider = new BibleProvider();

    StringBuilder sb = null;
    Dictionary<string, int> map = new Dictionary<string, int>();

    for (int i = DateTime.Today.Year; i <= DateTime.Today.Year + 100; i++)
    {
        DateTime d = new DateTime(i, 1, 1);

        // Start the loop on the current day when this code runs
        if (d.Year == DateTime.Today.Year)
        {
            d = DateTime.Today;
        }

        while (d.Year == i)
        {
            DailyReading? reading = bibleProvider.GetDailyReading(d);

            if (reading != null)
            {
                if (sb == null)
                {
                    sb = new StringBuilder();
                    sb.AppendLine($"\"{d.ToString("yyyy-MM-dd")}&{reading.FirstReading}&{reading.SecondReading}&{reading.Gospel}\"");
                }
                else
                {
                    sb.AppendLine($",\"{d.ToString("yyyy-MM-dd")}&{reading.FirstReading}&{reading.SecondReading}&{reading.Gospel}\"");
                }
            }
            else
                throw new Exception();

            if (!map.ContainsKey(reading.FirstReading))
                map.Add(reading.FirstReading, 1);
            else
            {
                int existing = (map[reading.FirstReading]) += 1;
                map.Remove(reading.FirstReading);
                map.Add(reading.FirstReading, existing);
            }

            if (reading.SecondReading != null)
            {
                if (!map.ContainsKey(reading.SecondReading))
                    map.Add(reading.SecondReading, 1);
                else
                {
                    int existing = (map[reading.SecondReading]) += 1;
                    map.Remove(reading.SecondReading);
                    map.Add(reading.SecondReading, existing);
                }
            }

            if (!map.ContainsKey(reading.Gospel))
                map.Add(reading.Gospel, 1);
            else
            {
                int existing = (map[reading.Gospel]) += 1;
                map.Remove(reading.Gospel);
                map.Add(reading.Gospel, existing);
            }

            d = d.AddDays(1);
        }
    }

    // We want more frequent readings to be earlier in the list, so these
    // more frequent readings get smaller numbers in the data file. Smaller numbers
    // can potentially save us more bytes of space
    List<string> sortedKeys = map.Keys.OrderByDescending(k => map[k]).ToList();

    // Since some less frequent readings are longer versions of more frequent
    // readings, we need to move the less frequent readings in-front-of (earlier)
    // in the list so that the code below can correctly map the readings to numbered values
    for (int i = 0; i < sortedKeys.Count; i++)
    {
        for (int j = i + 1; j < sortedKeys.Count; j++)
        {
            if (sortedKeys[i].Length < sortedKeys[j].Length &&
                sortedKeys[j].Contains(sortedKeys[i]))
            {
                // Slide the longer version of the reading from the position in the
                // list where it was, to just before the shorter version of the reading
                for (int k = j; k > i; k--)
                {
                    string temp = sortedKeys[k];
                    sortedKeys[k] = sortedKeys[k - 1];
                    sortedKeys[k - 1] = temp;
                }

                break;
            }
        }
    }

    int index = 0;
    int lastYear = -1;
    string[] toUpdate = sb.ToString().Split(Environment.NewLine);
    StringBuilder readingsIndex = new StringBuilder();
    StringBuilder yearsIndex = new StringBuilder();
    readingsIndex.AppendLine("const char *readingsIndex[] = {");
    yearsIndex.AppendLine("const char *yearsIndex[] = {");

    for (int p = 0; p < sortedKeys.Count; p++)
    {
        if (p == sortedKeys.Count - 1)
            readingsIndex.AppendLine($"\"{sortedKeys[p]}\"");
        else
            readingsIndex.AppendLine($"\"{sortedKeys[p]}\",");

        for (int j = 0; j < toUpdate.Length; j++)
        {
            if (string.IsNullOrEmpty(toUpdate[j]))
                continue;

            string[] lineSplit = toUpdate[j].Split('&');
            lineSplit[0] = lineSplit[0].Replace("-", string.Empty);

            // Keep track of the years to build an index of when each
            // year begins so it's faster on the electionary to find
            // the corresponding readings
            int year = int.Parse(lineSplit[0].Substring(2, 4));
            if (lastYear == -1)
            {
                yearsIndex.Append($"\"{year}&0\"");
                lastYear = year;
            }
            else if (year != lastYear && year > lastYear)
            {
                yearsIndex.Append($",\"{year}&{j}\"");
                lastYear = year;
            }

            // Replace hard-coded bible verse with a number (saves space if we do this)
            for (int i = 1; i < lineSplit.Length; i++)
            {
                if (lineSplit[i].Contains(sortedKeys[p]))
                {
                    lineSplit[i] = lineSplit[i].Replace(sortedKeys[p], index.ToString());
                }
            }

            toUpdate[j] = string.Join('&', lineSplit);

            // Remove last trailing comma
            if (j == toUpdate.Length - 2 && toUpdate[j][toUpdate[j].Length - 2] == ',')
                toUpdate[j] = toUpdate[j].Remove(toUpdate[j].Length - 1, 1);
        }

        index++;
    }
    readingsIndex.AppendLine("};");
    yearsIndex.AppendLine("};");

    File.WriteAllText("C:\\Users\\zacha\\source\\repos\\CatholicDailyReadings\\data_indexed.h", ("const char* dataIndexed[] = {" + string.Join(Environment.NewLine, toUpdate) + "};"));
    File.WriteAllText("C:\\Users\\zacha\\source\\repos\\CatholicDailyReadings\\reading_index.h", readingsIndex.ToString());
    File.WriteAllText("C:\\Users\\zacha\\source\\repos\\CatholicDailyReadings\\years_index.h", yearsIndex.ToString());

    Console.WriteLine(map.Keys.Count);
    StringBuilder sb2 = new StringBuilder();
    foreach (string key in map.Keys.OrderByDescending(k => map[k]))
    {
        Console.WriteLine($"{key} __ {map[key]}");
    }
}


GenerateFilesForELectionary();

