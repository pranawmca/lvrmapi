using LVRMWebAPI.Models.Datashake;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;

namespace LVRMWebAPI.Infrastructure
{
    public static class DataShakeClientCall
    {
        public static object GetDataShakeAPIPlaceidResponse(string PlaceId, string datashakeapiKey)
        {
            var client = new RestClient("https://app.datashake.com/api/v2/profiles/add?place_id=" + PlaceId + "");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("spiderman-token", datashakeapiKey);
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static DataShakeApiResponseModel GetDataShakeAPIResponse(int Jobid, string datashakeapiKey)
        {
            DataShakeApiResponseModel reviewresult = new DataShakeApiResponseModel();
            DataShakeApiResponseModel Totalreview = new DataShakeApiResponseModel();
            using (HttpClient httpClient = NewHttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("spiderman-token", datashakeapiKey);
                string endpoint = String.Empty;
                for (int i = 1; i <= 1000; i++)
                {
                    endpoint = "https://app.datashake.com/api/v2/profiles/reviews?per_page=500&page=" + i + "&job_id=" + Jobid;
                    HttpResponseMessage objrespons = httpClient.GetAsync(endpoint).Result;
                    string data = objrespons.Content.ReadAsStringAsync().Result;
                    if (data != null)
                    {
                        reviewresult = JsonConvert.DeserializeObject<DataShakeApiResponseModel>(data);
                        if (reviewresult.crawl_status == "complete")
                        {
                            if (reviewresult.reviews.Count == 0)
                            {
                                break;
                            }
                            if (i == 1)
                            {
                                Totalreview = reviewresult;
                            }
                            else
                            {
                                Totalreview.reviews.AddRange(reviewresult.reviews);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                return Totalreview;
            }
        }
        public static HttpClient NewHttpClient()
        {
            return new HttpClient() { MaxResponseContentBufferSize = int.MaxValue, Timeout = TimeSpan.FromMinutes(10) };
        }
    }
}
