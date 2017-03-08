using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Azavar.Sitefinity.Modules.PageSpeed.Model
{
    public class PageSpeedService
    {
        private readonly string _apiKey;
        private readonly Uri _pageSpeedUrl;

        public event EventHandler<PageScannedEventArgs> PageScanned;

        public PageSpeedService(string apiKey, Uri pageSpeedUrl)
        {
            if (string.IsNullOrEmpty(apiKey) || pageSpeedUrl == null)
                throw new ArgumentException();

            _apiKey = apiKey;
            _pageSpeedUrl = pageSpeedUrl;
        }

        public async Task<List<PageSpeedResult>> RunPageSpeedAsync(IEnumerable<Uri> uris, string ruleName = "")
        {
            var pageSpeedResults = new List<PageSpeedResult>();

            int current = 1;
            int total = uris.Count();

            foreach (var uri in uris)
            {
                using (var client = new HttpClient())
                {
                    var nameValueCollection = new Dictionary<string, string>
                    {
                        {"url", uri.ToString()},
                        { "key", _apiKey}
                    };

                    if (!string.IsNullOrEmpty(ruleName))
                        nameValueCollection.Add("rule", ruleName);

                    var queryStringParams = await new FormUrlEncodedContent(nameValueCollection).ReadAsStringAsync();

                    var builder = new UriBuilder(_pageSpeedUrl)
                    {
                        Query = queryStringParams
                    };

                    HttpResponseMessage response = await client.GetAsync(builder.Uri);

                    if (response.StatusCode != HttpStatusCode.InternalServerError)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        var serializer = new JavaScriptSerializer();

                        pageSpeedResults.Add(serializer.Deserialize<PageSpeedResult>(json));

                        OnPageScanned(new PageScannedEventArgs { PagesComplete = current, TotalPages = total });

                        current++;
                    }

                }
            }

            return pageSpeedResults;
        }

        private void OnPageScanned(PageScannedEventArgs e)
        {
            var handler = PageScanned;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
