using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// Web Api implementation. It uses HttpClient under the hood.
    /// Json data is sent and recieved
    /// </summary>
    public class WebApiSender : ISender, IDisposable
    {
        HttpClient Client = new HttpClient();

        public WebApiSender(string baseUrl)
        {
            Client.BaseAddress = new Uri(baseUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Disposes HttpClient object
        /// </summary>
        public void Dispose()
        {
            if (Client != null)
                Client.Dispose();
        }

        /// <summary>
        /// Not used. Private method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        private async Task<T> GetAsync<T>(string path) where T : class, new()
        {
            T ret = default(T);
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                ret = await response.Content.ReadAsAsync(typeof(T)) as T;
            }
            else
            {
                string str = await response.Content.ReadAsStringAsync();
                throw new ApplicationException("Response status code is not successful. Content: " + str);
            }
            return ret;
        }

        /// <summary>
        /// Post method. For more info see ISender.cs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        async Task<T> ISender.PostAsync<T, K>(string path, K obj)
        {
            T ret = default(T);
            HttpResponseMessage response = await Client.PostAsJsonAsync(path, obj);
            if (response.IsSuccessStatusCode)
            {
                ret = await response.Content.ReadAsAsync(typeof(T)) as T;
            }
            else
            {
                string str = await response.Content.ReadAsStringAsync();
                throw new ApplicationException("Response status code is not successful. Content: " + str);
            }
            return ret;
        }
    }
}
