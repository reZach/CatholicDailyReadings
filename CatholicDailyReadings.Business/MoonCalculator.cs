using CatholicDailyReadings.Models;

namespace CatholicDailyReadings.Business
{
    public class MoonCalculator
    {
        /* Astronomical constants */
        private readonly double _epoch = 2444238.5;                // 1980 January 0.0

        /* Constants defining the Sun's apparent orbit */
        private readonly double _elonge = 278.833540;              // Ecliptic longitude of the Sun at epoch 1980.0
        private readonly double _elongp = 282.596403;              // Ecliptic longitude of the Sun at perigee
        private readonly double _eccent = 0.016718;                // Eccentricity of Earth's orbit
        private readonly double _sunsmax = 1.495985e8;             // Semi-major axis of Earth's orbit, km
        private readonly double _sunangsiz = 0.533128;             // Sun's angular size, degrees, at semi-major axis distance

        /* Elements of the Moon's orbit, epoch 1980.0 */
        private readonly double _mmlong = 64.975464;               // Moon's mean longitude at the epoch
        private readonly double _mmlongp = 349.383063;             // Mean longitude of the perigee at the epoch
        private readonly double _mlnode = 151.950429;              // Mean longitude of the node at the epoch
        private readonly double _minc = 5.145396;                  // Inclination of the Moon's orbit
        private readonly double _mecc = 0.054900;                  // Eccentricity of the Moon's orbit
        private readonly double _mangsiz = 0.5181;                 // Moon's angular size at distance a from Earth
        private readonly double _msmax = 384401.0;                 // Semi-major axis of Moon's orbit in km
        private readonly double _mparallax = 0.9507;               // Parallax at distance a from Earth
        private readonly double _synmonth = 29.53058868;           // Synodic month (new Moon to new Moon)
        private readonly double _lunatbase = 2423436.0;            // Base date for E. W. Brown's numbered series of lunations (1923 January 16)

        /*  Properties of the Earth  */
        private readonly double _earthrad = 6378.16;               // Radius of Earth in kilometres
        private readonly double _PI = 3.14159265358979323846;      // Assume not near black hole nor in Tennessee

        /* More consts */
        private readonly double _epsilon = 0.000001;

        private double Sgn(double x) => (x < 0) ? -1 : (x > 0 ? 1 : 0);                 // Extract sign
        private double Abs(double x) => x < 0 ? (-x) : x;                               // Absolute value
        private double FixAngle(double a) => (a) - 360.0 * Math.Floor(a / 360.0);       // Fix angle
        private double ToRad(double d) => d * (_PI / 180.0);                            // Deg->Rad
        private double ToDeg(double d) => d * (180.0 / _PI);                            // Rad->Deg
        private double DSin(double x) => Math.Sin(ToRad(x));                            // Sin from deg
        private double DCos(double x) => Math.Cos(ToRad(x));                            // Cos from deg

        /// <summary>
        /// Convert a Date to astronomica Julian time 
        /// (i.e. Julian date plus day fraction, expressed as a double).
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private double ToJulianTime(DateTime date)
        {
            // Algorithm as given in Meeus, Astronomical Algorithms
            int year = date.Year,
                month = date.Month,
                day = date.Day,
                hour = date.Hour,
                minute = date.Minute,
                second = date.Second,
                millisecond = date.Millisecond;

            bool isJulian = IsJulianDate(year, month, day);
            int m = month > 2 ? month : month + 12;
            int y = month > 2 ? year : year - 1;
            int d = day + hour / 24 + minute / 1440 + (second + millisecond / 1000) / 86400;
            int b = isJulian ? 0 : 2 - y / 100 + y / 100 / 4;

            return Math.Floor((365.25 * (y + 4716)) + Math.Floor(30.6001 * (m + 1)) + d + b - 1524.5);
        }

        /// <summary>
        /// Returns whether a given date is a Julian date or not.
        /// https://stackoverflow.com/a/14554483/1837080
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool IsJulianDate(int year, int month, int day)
        {
            // All dates prior to 1582 are in the Julian calendar
            if (year < 1582)
                return true;
            // All dates after 1582 are in the Gregorian calendar
            else if (year > 1582)
                return false;
            else
            {
                // If 1582, check before October 4 (Julian) or after October 15 (Gregorian)
                if (month < 10)
                    return true;
                else if (month > 10)
                    return false;
                else
                {
                    if (day < 5)
                        return true;
                    else if (day > 14)
                        return false;
                    else
                        throw new Exception("Any date in the range 10/5/1582 to 10/14/1582 is invalid!");
                }
            }
        }

        /// <summary>
        /// Solve the equation of Kepler.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="ecc"></param>
        /// <returns></returns>
        private double Kepler(double m, double ecc)
        {
            double e, delta = 0;

            m = ToRad(m);
            e = m;

            do
            {
                delta = e - ecc * Math.Sin(e) - m;
                e -= delta / (1 - ecc * Math.Cos(e));
            } while (Abs(delta) > _epsilon);

            return e;
        }

        /// <summary>
        /// Calculate phase of moon as a fraction.
        /// The argument is the time for which the phase is requested,
        /// expressed as a Julian date and fraction.Returns the terminator
        /// phase angle as a percentage of a full circle(i.e., 0 to 1), and
        /// stores into pointer arguments the illuminated fraction of the
        /// Moon's disc, the Moon's age in days and fraction, the distance of
        /// the Moon from the centre of the Earth, and the angular diameter
        /// subtended by the Moon as seen by an observer at the centre of the
        /// Earth.        
        /// </summary>
        /// <param name="julianDate"></param>
        /// <returns></returns>
        private PhaseResult GetMoonPhase(double julianDate)
        {
            double day,
                n,
                m,
                ec,
                lambdaSun,
                ml,
                mm,
                mn,
                ev,
                ae,
                a3,
                mmp,
                mec,
                a4,
                lp,
                v,
                lpp,
                np,
                y,
                x,
                lambdaMoon,
                betaM,
                moonAge,
                moonPhase,
                moonDist,
                moonDFrac,
                moonAng,
                moonPar,
                f,
                sunDist,
                sunAng;

            /* Calculation of the Sun's position */
            day = julianDate - _epoch;                                              // Date within epoch
            n = FixAngle((360 / 365.2422) * day);                                   // Mean anomaly of the Sun
            m = FixAngle(n + _elonge - _elongp);                                    // Convert from perigee co-ordinates to epoch 1980.0

            ec = Kepler(m, _eccent);                                                // Solve equation of Kepler
            ec = Math.Sqrt((1 + _eccent) / (1 - _eccent)) * Math.Tan(ec / 2);
            ec = 2 * ToDeg(Math.Atan(ec));                                          // True anomaly
            lambdaSun = FixAngle(ec + _elongp);                                     // Sun's geocentric ecliptic longitude

            /* Orbital distance factor */
            f = ((1 + _eccent * Math.Cos(ToRad(ec))) / (1 - _eccent * _eccent));
            sunDist = _sunsmax / f;                                                 // Distance to Sun in km
            sunAng = f * _sunangsiz;                                                // Sun's angular size in degrees

            /* Calculation of the Moon's position */

            /* Moon's mean longitude */
            ml = FixAngle(13.1763966 * day + _mmlong);

            /* Moon's mean anomaly */
            mm = FixAngle(ml - 0.1114041 * day - _mmlongp);

            /* Moon's ascending node mean longitude */
            mn = FixAngle(_mlnode - 0.0529539 * day);

            /* Evection */
            ev = 1.2739 * Math.Sin(ToRad(2 * (ml - lambdaSun) - mm));

            /* Annual equation */
            ae = 0.1858 * Math.Sin(ToRad(m));

            /* Correction term */
            a3 = 0.37 * Math.Sin(ToRad(m));

            /* Corrected anomaly */
            mmp = mm + ev - ae - a3;

            /* Correction for the equation of the centre */
            mec = 6.2886 * Math.Sin(ToRad(mmp));

            /* Another correction term */
            a4 = 0.214 * Math.Sin(ToRad(2 * mmp));

            /* Corrected longitude */
            lp = ml + ev + mec - ae + a4;

            /* Variation */
            v = 0.6583 * Math.Sin(ToRad(2 * (lp - lambdaSun)));

            /* True longitude */
            lpp = lp + v;

            /* Corrected longitude of the node */
            np = mn - 0.16 * Math.Sin(ToRad(m));

            /* Y inclination coordinate */
            y = Math.Sin(ToRad(lpp - np)) * Math.Cos(ToRad(_minc));

            /* X inclination coordinate */
            x = Math.Cos(ToRad(lpp - np));

            /* Ecliptic longitude */
            lambdaMoon = ToDeg(Math.Atan2(y, x));
            lambdaMoon += np;

            /* Ecliptic latitude */
            betaM = ToDeg(Math.Asin(Math.Sin(ToRad(lpp - np)) * Math.Sin(ToRad(_minc))));

            /* Calculation of the phase of the Moon */

            /* Age of the Moon in degrees */
            moonAge = lpp - lambdaSun;

            /* Phase of the Moon */
            moonPhase = (1 - Math.Cos(ToRad(moonAge))) / 2;

            /* Calculate distance of moon from the centre of the Earth */
            moonDist = (_msmax * (1 - _mecc * _mecc)) /
                (1 + _mecc * Math.Cos(ToRad(mmp + mec)));

            /* Calculate Moon's angular diameter */
            moonDFrac = moonDist / _msmax;
            moonAng = _mangsiz / moonDFrac;

            /* Calculate Moon's parallax */
            moonPar = _mparallax / moonDFrac;

            return new PhaseResult
            {
                MoonIllumination = moonPhase,
                MoonAgeInDays = _synmonth * (FixAngle(moonAge) / 360.0),
                DistanceInKm = moonDist,
                AngularDiameterInDeg = moonAng,
                DistanceToSun = sunDist,
                SunAngularDiameter = sunAng,
                MoonPhase = FixAngle(moonAge) / 360.0
            };
        }

        /// <summary>
        /// Get moon information on a given date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private PhaseResult GetMoonInfo(DateTime date)
        {
            if (date == DateTime.MinValue)
                return new PhaseResult();

            return GetMoonPhase(ToJulianTime(date));
        }

        /// <summary>
        /// Return the date of Easter for a given <paramref name="year"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime GetEaster(int year)
        {
            // Easter is on the first Sunday following a full
            // moon after the vernal equinox

            // Church recognizes the vernal equinox on March 21st            
            DateTime start = new DateTime(year, 3, 21);

            // Continue to calculate moon info, until we find the 
            // first full moon after the vernal equinox
            DateTime fullMoon = start;
            PhaseResult previousMoonInfo;
            PhaseResult moonInfo;
            bool? gettingDarker = null;

            do
            {
                previousMoonInfo = GetMoonInfo(fullMoon);
                fullMoon = fullMoon.AddDays(1);
                moonInfo = GetMoonInfo(fullMoon);

                // Initially set if we must currently wait for the moon to grow dimmer,
                // before it grows bright again for a full moon
                if (gettingDarker == null)
                {
                    gettingDarker = moonInfo.MoonIllumination < previousMoonInfo.MoonIllumination;
                }
                else if (gettingDarker.Value && moonInfo.MoonIllumination > previousMoonInfo.MoonIllumination)
                {

                    // Once the moon has finished getting darker,
                    // change this variable so we can check that it continues to grow
                    // brighter (so we know when we've found our full moon)
                    gettingDarker = false;
                }
            } while (gettingDarker.Value && moonInfo.MoonIllumination < previousMoonInfo.MoonIllumination ||
                    !gettingDarker.Value && moonInfo.MoonIllumination > previousMoonInfo.MoonIllumination);

            // We found a full moon, go back a day since
            // we've gone 1 day too far
            fullMoon = fullMoon.AddDays(-1);

            // Find the next Sunday (Easter)
            while (fullMoon.DayOfWeek != DayOfWeek.Sunday)
            {
                fullMoon = fullMoon.AddDays(1);
            }

            return fullMoon;
        }

        /// <summary>
        /// Return the date of the beginning of Lent for a given <paramref name="year"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime GetLent(int year)
        {
            // Lent is dependent on the Easter date
            DateTime easter = GetEaster(year);

            // 6 weeks (6 * 7 = 42);
            // + Saturday, Friday, Thursday, Wednesday to walk back to Ash Wednesday
            return easter.AddDays(-46);
        }
    }
}