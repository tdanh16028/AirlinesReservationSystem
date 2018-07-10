using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ARSWinForm.HelperClass
{
    class APIWrapper<T>
    {
        public enum ARSAPI
        {
            AIRPLANE_CLASSES
        }

        private const string HOST_NAME = "http://localhost:49261";
        private const string ROOT_API = HOST_NAME + "/api";
        private Dictionary<ARSAPI, string> API_URL = new Dictionary<ARSAPI, string>()
        {
            { ARSAPI.AIRPLANE_CLASSES, "/AirplaneClasses" }
        };

        private HttpClient client;

        public APIWrapper(ARSAPI api, int id) : this(api, id.ToString())
        {
            
        }

        public APIWrapper(ARSAPI api, string id = "")
        {
            string url = ROOT_API + API_URL[api] + "/" + id;
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Retrieve data
        /// </summary>
        /// <returns></returns>
        public Task<HttpResponseMessage> GET()
        {
            return client.GetAsync(client.BaseAddress);
        }

        /// <summary>
        /// Edit object data
        /// </summary>
        /// <returns></returns>
        public Task<HttpResponseMessage> PUT(T data)
        {
            return client.PutAsJsonAsync(client.BaseAddress, data);
        }

        /// <summary>
        /// Create new object
        /// </summary>
        /// <returns></returns>
        public Task<HttpResponseMessage> POST(T data)
        {
            return client.PostAsJsonAsync(client.BaseAddress, data);
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <returns></returns>
        public Task<HttpResponseMessage> DELETE()
        {
            return client.DeleteAsync(client.BaseAddress);
        }
    }
}
