# CatholicDailyReadings




## To get code coverage
https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows#integrate-with-net-test
> dotnet test --collect:"XPlat Code Coverage"

```
reportgenerator
-reports:"C:\Users\{user}\source\repos\CatholicDailyReadings\CatholicDailyReadings.BusinessTests\TestResults\{guid}\coverage.cobertura.xml"
-targetdir:"coveragereport"
-reporttypes:Html
```

```
reportgenerator
-reports:"C:\Users\{user}\source\repos\CatholicDailyReadings\CatholicDailyReadings.UtilsTests\TestResults\{guid}\coverage.cobertura.xml"
-targetdir:"coveragereport"
-reporttypes:Html
```