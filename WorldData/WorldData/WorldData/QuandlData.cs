using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WorldData
{
    public class QuandlData
    {
        //[JsonProperty("name")]
        //public string Name { get; set; }

        //[JsonProperty("column_names")]
        //public string[] ColumnNames { get; set; }

        //[JsonProperty("data")]
        //public string[][] Data { get; set; }

        [JsonProperty("errors")]
        public Errors Errors { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("source_name")]
        public string SourceName { get; set; }

        [JsonProperty("source_code")]
        public string SourceCode { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("urlize_name")]
        public string UrlizeName { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("from_date")]
        public string FromDate { get; set; }

        [JsonProperty("to_date")]
        public string ToDate { get; set; }

        [JsonProperty("column_names")]
        public IList<string> ColumnNames { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }

        [JsonProperty("type")]
        public object Type { get; set; }

        [JsonProperty("premium")]
        public bool Premium { get; set; }

        [JsonProperty("data")]
        public IList<IList<object>> Data { get; set; }

        private static string quandlBaseUri =
            @"https://www.quandl.com/api/v1/datasets/WORLDBANK/{0}_{1}.json";

        public async static Task<QuandlData> GetQuandlDataAsync(string authToken, string countryCode, string indicator, string transformation = null, string collapse = null)
        {

            if (string.IsNullOrEmpty(countryCode))
                throw new ArgumentNullException("countryCode");

            if (string.IsNullOrEmpty(indicator))
                throw new ArgumentNullException("indicator");

            var uri = string.Format(quandlBaseUri, countryCode, indicator);

            if (!String.IsNullOrEmpty(authToken))
            {
                uri = uri + "?auth_token=" + authToken;
            }
            if (!string.IsNullOrEmpty(transformation))
                uri = uri + "&transformation=" + transformation;

            if (!string.IsNullOrEmpty(collapse))
                uri = uri + "&collapse=" + collapse;

            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync(uri);

            var data = JsonConvert.DeserializeObject<QuandlData>(result);

            return data;
        }

        public static async Task<PopulationData> GetPopulationDataAsync(string authToken, string countryCode, string indicator,
            string transformation = null, string collapse = null)
        {
            var data = await GetQuandlDataAsync(authToken, countryCode, indicator, transformation, collapse);
            if (data == null)
                return null;
            var populationData = new PopulationData {Country = data.Name};
            populationData.AddRange(data.Data.Select(item => new PopulationDataItem() { Date = item[0].ToString(), Value = item[1].ToString().ToDouble() }));
            return populationData;
        }

    }

    public class Errors
    {
    }

    public class PopulationData
        : List<PopulationDataItem>
    {
        public string Country { get; set; }
    }

    public class PopulationDataItem
    {
        public string Date { get; set; }
        public double Value { get; set; }


    }
}
