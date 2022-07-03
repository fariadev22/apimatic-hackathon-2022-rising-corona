using System;
using System.Collections.Generic;
using DiseaseShAPI.Standard.Controllers;
using RisingCorona.Models;

namespace RisingCorona
{
    public class ApiClient
    {
        public List<RisingCoronaCountry> GetRisingCoronaCountries()
        {
            //list from Worldometers
            //https://www.worldometers.info/geography/alphabetical-list-of-countries/
            var countries = new List<string>
            {
                "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Argentina",
                "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain",
                "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin",
                "Bhutan", "Bolivia", "Botswana", "Brazil", "Bulgaria", "Burundi",
                "Cambodia", "Cameroon", "Canada", "Chad", "Chile", "China", "Colombia",
                "Comoros", "Croatia", "Cuba", "Cyprus", "Denmark", "Djibouti", "Dominica",
                "Ecuador", "Egypt", "Eritrea", "Estonia", "Ethiopia", "Fiji", "Finland",
                "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece",
                "Grenada", "Guatemala", "Guinea", "Guyana", "Haiti", "Honduras", "Hungary",
                "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy",
                "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Kuwait",
                "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya",
                "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar", "Malawi", "Malaysia",
                "Maldives", "Mali", "Malta", "Mauritania", "Mauritius", "Mexico", "Micronesia",
                "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique",
                "Namibia", "Nauru", "Nepal", "Netherlands", "Nicaragua", "Niger", "Nigeria",
                "Norway", "Oman", "Pakistan", "Palau", "Panama", "Paraguay", "Peru", "Philippines",
                "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Samoa", "Senegal",
                "Serbia", "Seychelles", "Singapore", "Slovakia", "Slovenia", "Somalia", "Spain",
                "Sudan", "Suriname", "Sweden", "Switzerland", "Syria", "Tajikistan", "Tanzania",
                "Thailand", "Togo", "Tonga", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu",
                "Uganda", "Ukraine", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela",
                "Vietnam", "Yemen", "Zambia", "Zimbabwe"
            };

            DiseaseShAPI.Standard.DiseaseShAPIClient client =
                new DiseaseShAPI.Standard.DiseaseShAPIClient.Builder().Build();
            COVID19WorldometersController cOVID19WorldometersController =
                client.COVID19WorldometersController;

            var countriesListString = string.Join(',', countries);
            var countriesDataToday =
                cOVID19WorldometersController.COVID19TotalsForASetOfCountries(
                    countriesListString);

            var countriesDataYesterday =
                cOVID19WorldometersController.COVID19TotalsForASetOfCountries(
                    countriesListString, "true");

            var countriesDataDayBeforeYesterday =
                cOVID19WorldometersController.COVID19TotalsForASetOfCountries(
                    countriesListString, twoDaysAgo: "true");

            List<RisingCoronaCountry> risingCoronaCountries = new List<RisingCoronaCountry>();

            if (countriesDataToday != null &&
               countriesDataYesterday != null &&
               countriesDataDayBeforeYesterday != null &&
               countriesDataToday.Count == countriesDataYesterday.Count &&
               countriesDataYesterday.Count == countriesDataDayBeforeYesterday.Count)
            {
                for (int index = 0; index < countriesDataToday.Count; index++)
                {
                    var countryDataToday = countriesDataToday[index];
                    var countryDataYesterday = countriesDataYesterday[index];
                    var countryDataDayBeforeYesterday = countriesDataDayBeforeYesterday[index];
                    bool allZeroes = countryDataToday.TodayCases == 0 &&
                                     countryDataYesterday.TodayCases == 0 &&
                                     countryDataDayBeforeYesterday.TodayCases == 0;

                    if (!allZeroes)
                    {
                        double todayCases = countryDataToday.TodayCases ?? 0;
                        double yesterdayCases = countryDataYesterday.TodayCases ?? 0;
                        double dayBeforeYesterdayCases =
                            countryDataDayBeforeYesterday.TodayCases ?? 0;
                        double percentageIncreaseForYesterdayDayBeforeYesterday =
                            dayBeforeYesterdayCases == 0 ? 0 :
                            (
                                (yesterdayCases - dayBeforeYesterdayCases) / 
                                dayBeforeYesterdayCases
                            ) * 100;
                        double percentageIncreaseForTodayYesterday =
                            yesterdayCases == 0 ? 0 :
                            (
                                (todayCases - yesterdayCases) /
                                yesterdayCases
                            ) * 100;
                        double percentageScoreAverage =
                            Math.Round(
                                (percentageIncreaseForTodayYesterday +
                                 percentageIncreaseForYesterdayDayBeforeYesterday) / 2);

                        if (percentageScoreAverage > 0)
                        {
                            risingCoronaCountries.Add(new RisingCoronaCountry
                            {
                                CountryName = countryDataToday.Country,
                                TodayCases = todayCases,
                                YesterdayCases = yesterdayCases,
                                DayBeforeYesterdayCases = dayBeforeYesterdayCases,
                                PercentageIncrease = percentageScoreAverage
                            });
                        }
                        
                    }
                }
            }

            return risingCoronaCountries;
        }
    }
}
