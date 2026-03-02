namespace Timer.Backend
{
    public class Time
    {
        // Fields
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        // Constructors
        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }
        public Time(int hour)
        {
            _hour = ValidHour(hour);
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }
        public Time(int hour, int minute)
        {
            _hour = ValidHour(hour);
            _minute = ValidMinute(minute);
            _second = 0;
            _millisecond = 0;
        }
        public Time(int hour, int minute, int second)
        {
            _hour = ValidHour(hour);
            _minute = ValidMinute(minute);
            _second = ValidSecond(second);
            _millisecond = 0;
        }
        public Time(int hour, int minute, int second, int millisecond)
        {
            _hour = ValidHour(hour);
            _minute = ValidMinute(minute);
            _second = ValidSecond(second);
            _millisecond = ValidMillisecond(millisecond);
        }
        // Properties
        public int Hour
        {
            get => _hour;
            set => _hour = ValidHour(value);
        }
        public int Minute
        {
            get => _minute;
            set => _minute = ValidMinute(value);
        }
        public int Second
        {
            get => _second;
            set => _second = ValidSecond(value);
        }
        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = ValidMillisecond(value);
        }

        // Methods
        public override string ToString()
        {
            if (Hour >= 0 && Hour <= 11)
            {
                return $"{Hour:00}:{Minute:00}:{Second:00}.{Millisecond:000} AM";
            }
            if (Hour == 12)
            {
                return $"{Hour:00}:{Minute:00}:{Second:00}.{Millisecond:000} PM";
            }
            if (Hour >= 13 && Hour <= 23)
            {
                return $"{Hour - 12:00}:{Minute:00}:{Second:00}.{Millisecond:000} PM";
            }
            return $"{Hour:00}:{Minute:00}:{Second:00}.{Millisecond:000} AM";
        }
        public bool IsOtherDay(Time time)
        {
            var h1 = _hour + time._hour;
            var m1 = _minute + time._minute;
            var s1 = _second + time._second;
            var ms1 = _millisecond + time._millisecond;
            if (ms1 > 999)
            {
                ms1 = ms1 - 1000;
                s1 = s1 + 1;
            }
            if (s1 > 59)
            {
                s1 = s1 - 60;
                m1 = m1 + 1;
            }
            if (m1 > 59)
            {
                m1 = m1 - 60;
                h1 = h1 + 1;
            }
            if (h1 > 23)
            {
                h1 = h1 - 24;
                return true;
            }
            return false;
        }
        public Time Add(Time time)
        {
            var h2 = _hour + time._hour;
            var m2 = _minute + time._minute;
            var s2 = _second + time._second;
            var ms2 = _millisecond + time._millisecond;
            if (ms2 > 999)
            {
                ms2 = ms2 - 1000;
                s2 = ms2 + 1;
            }
            if (s2 > 59)
            {
                s2 = s2 - 60;
                m2 = m2 + 1;
            }
            if (m2 > 59)
            { 
                m2 = m2 - 60;
                h2 = h2 + 1;
            }
            if (h2 > 23)
            {  
                h2 = h2 - 24;
                return new Time(h2, m2, s2, ms2);
            }
            return new Time(h2, m2, s2, ms2);
        }
        public int ToMilliseconds() => (_hour * 3600000) + (_minute * 60000) + (_second * 1000) + _millisecond;
        public int ToSeconds() => (_hour * 3600) + (_minute * 60) + _second;
        public int ToMinutes() => (_hour * 60) + _minute;
        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour),$"The hour: {hour}, is not valid.");
            }
            return hour;
        }
        private int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minute), $"The minute: {minute}, is not valid.");
            }
            return minute;
        }
        private int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(second), $"The second: {second}, is not valid.");
            }
            return second;
        }
        private int ValidMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentOutOfRangeException(nameof(millisecond), $"The millisecond: {millisecond}, is not valid.");
            }
            return millisecond;
        }
    }
}
