using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public class WebApiSender : ISender
    {
        HttpClient Client = new HttpClient();

        public WebApiSender(string baseUrl)
        {
            Client.BaseAddress = new Uri(baseUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        async Task<T> GetAsync<T>(string path) where T : class, new()
        {
            T ret = default(T);
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                ret = await response.Content.ReadAsAsync(ret.GetType()) as T;
            }
            return ret;
        }

        async Task<T> ISender.PostAsync<T, K>(string path, K obj)
        {
            T ret = default(T);
            HttpResponseMessage response = await Client.PostAsJsonAsync(path, obj);
            if (response.IsSuccessStatusCode)
            {
                ret = await response.Content.ReadAsAsync(ret.GetType()) as T;
            }
            return ret;
        }
    }
}
