using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldData.Models;

namespace WorldData.Repository
{
    public class WorldDataRepository
    {

        public Dictionary<string, List<Country>> CountriesByRegion { get; set; }
        public WorldDataRepository()
        {
                
        }

        public async Task<List<Country>> GetCountries()
        {
           return await Task.Run(() =>
            {
                List<Country> countries = new List<Country>();
                CountriesByRegion = new Dictionary<string, List<Country>>();
                var csv = DataProvider.GetResourceCsvFileData(@"WorldData.Data.world-stats-quandl.csv");
                for (var i = 1; i < csv.Rows.Count; i++)
                {
                    var country = new Country
                    {
                        Name = csv[i, "Country"],
                        AreaCode = csv[i, "Area Code"],
                        RegionName = csv[i, "Region"],
                        Level = csv[i, "Level"],
                        Units = (csv[i, "Units"]).ToInteger(),
                        AsOf = csv[i, "As Of"],
                        Chg1Y = csv[i, "1Y Chg"],
                        Year5 = csv[i, "5Y Ago"],
                        Year10 = csv[i, "10Y Ago"],
                        Year25 = csv[i, "25Y Ago"],
                        LifeExpectancy = csv[i, "Life Expectancy"],
                        HealthExpenditure = csv[i, "Health Expenditure"],
                        AdultLiteracyRate = csv[i, "Adult Literacy Rate"],
                         
                    };

                    countries.Add(country);
                    if(CountriesByRegion.ContainsKey(country.RegionName))
                        CountriesByRegion[country.RegionName].Add(country);
                    else
                    {
                        CountriesByRegion.Add(country.RegionName, new List<Country>{country});
                    }
                }

                return countries;
            });


        }
    }
}
