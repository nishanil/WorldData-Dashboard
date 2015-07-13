using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WorldData
{
    public class QuandlData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("column_names")]
        public string[] ColumnNames { get; set; }

        [JsonProperty("data")]
        public string[][] Data { get; set; }

        public async static Task<QuandlData> GetQuandlDataAsync(string uri, string authToken)
        {
            if (!String.IsNullOrEmpty(authToken))
            {
                uri = uri + "?auth_token=" + authToken;
            }
            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync(uri);

            var data = JsonConvert.DeserializeObject<QuandlData>(result);

            return data;
        }

        public async static Task<FinancialData> GetFinancialData(string uri, string authToken)
        {
            var data = await GetQuandlDataAsync(uri, authToken);

            var columns = data.ColumnNames.ToList();

            var dateIndex = columns.IndexOf("Date");
            var openIndex = columns.IndexOf("Open");
            var highIndex = columns.IndexOf("High");
            var lowIndex = columns.IndexOf("Low");
            var closeIndex = columns.IndexOf("Close");

            var finData = new FinancialData();
            for (var i = data.Data.Length - 1; i >= 0; i--)
            {
                var item = new FinancialDataItem();
                if (dateIndex >= 0)
                {
                    item.Date = (string)data.Data[i][dateIndex];
                }
                if (openIndex >= 0)
                {
                    item.Open = double.Parse(data.Data[i][openIndex]);
                }
                if (highIndex >= 0)
                {
                    item.High = double.Parse(data.Data[i][highIndex]);
                }
                if (lowIndex >= 0)
                {
                    item.Low = double.Parse(data.Data[i][lowIndex]);
                }
                if (closeIndex >= 0)
                {
                    item.Close = double.Parse(data.Data[i][closeIndex]);
                }
                finData.Add(item);
            }

            return finData;
        }
    }

    public class FinancialData
        : List<FinancialDataItem>
    {

    }

    public class FinancialDataItem
    {
        public string Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }

    }
}
