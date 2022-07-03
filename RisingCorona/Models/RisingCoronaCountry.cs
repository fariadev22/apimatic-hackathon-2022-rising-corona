namespace RisingCorona.Models
{
    public class RisingCoronaCountry
    {
        public string CountryName { get; set; }

        public double TodayCases { get; set; }

        public double YesterdayCases { get; set; }

        public double DayBeforeYesterdayCases { get; set; }

        public double PercentageIncrease { get; set; }
    }
}
