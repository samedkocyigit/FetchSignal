using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.ApplicationDbContext;
using Newtonsoft.Json.Linq;

namespace FetchSignal.Application.Services.SignalServices
{
    public class SignalService:ISignalService
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<string, List<string>> _tagMappings = new()
        {
            {"Title", new List<string> {"title","productName","name","plant","currency"} },
            {"Price", new List<string> {"cost","amount","price","forexBuying" } }
        };

        public SignalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task FetchDataFromUrl(List<string> urls)
        {
            foreach (var url in urls)
            {
                string fetchedData = await FetchDataAsync(url);
                SaveRawData(url, fetchedData);

                var processedData = ExtractRelevantData(url, fetchedData);
                SaveProcessedData(processedData, url);
            }
        }

        private async Task<string> FetchDataAsync(string url)
        {
            using var client = new HttpClient();
            return await client.GetStringAsync(url);
        }

        private List<Dictionary<string, string>> ExtractRelevantData(string url, string data)
        {
            var result = new List<Dictionary<string, string>>();

            if (url.EndsWith(".xml"))
            {
                var xDoc = XDocument.Parse(data);

                var titleElements = xDoc.Descendants()
                    .Where(e => _tagMappings["Title"].Contains(e.Name.LocalName, StringComparer.OrdinalIgnoreCase));

                foreach (var titleElement in titleElements)
                {
                    var itemData = new Dictionary<string, string>();

                    itemData["Title"] = titleElement.Value.Trim();

                    var priceElement = titleElement.Descendants()
                        .FirstOrDefault(e => _tagMappings["Price"].Contains(e.Name.LocalName, StringComparer.OrdinalIgnoreCase));

                    if (priceElement != null && !string.IsNullOrEmpty(priceElement.Value))
                    {
                        itemData["Price"] = priceElement.Value.Trim();
                    }

                    if (itemData.ContainsKey("Price"))
                    {
                        result.Add(itemData);
                    }
                }
                return result;
            }
            else if (url.EndsWith(".json"))
            {
                var json = JObject.Parse(data);

                var titleElements = json.Properties()
                    .Where(e => _tagMappings["Title"].Contains(e.Name, StringComparer.OrdinalIgnoreCase));

                foreach (var titleElement in titleElements)
                {
                    var itemData = new Dictionary<string, string>();

                    itemData["Title"] = titleElement.Value.ToString().Trim();

                    var priceElement = json.Properties()
                        .FirstOrDefault(e => _tagMappings["Price"].Contains(e.Name, StringComparer.OrdinalIgnoreCase));

                    if (priceElement != null && !string.IsNullOrEmpty(priceElement.Value.ToString()))
                    {
                        itemData["Price"] = priceElement.Value.ToString().Trim();
                    }

                    if (itemData.ContainsKey("Price"))
                    {
                        result.Add(itemData);
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("Invalid Format for extraction");
            }
        }



        private void SaveRawData(string url, string data)
        {
            _context.RawDatas.Add(new RawData
            {
                Url = url,
                FetchedData = data
            });
            _context.SaveChanges();
        }

        private void SaveProcessedData(List<Dictionary<string, string>> processedDatas, string url)
        {
            foreach (var processedData in processedDatas)
            {
                if (processedData.ContainsKey("Price"))
                {
                    _context.ProcessedDatas.Add(new ProcessedData
                    {
                        Key = "Price",
                        Value = processedData["Price"],
                        SourceUrl = url
                    });
                }
            }
            _context.SaveChanges();
        }
    }
}
