using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ARSWinForm.HelperClass;
using Newtonsoft.Json.Linq;

namespace ARSWinForm.HelperClass.ModelHelper
{
    abstract class AbstractModelWrapper<T>
    {
        protected APIWrapper<T>.ARSAPI MODEL_API = 0;
        private string errorMessage;

        public async Task<List<T>> List()
        {
            APIWrapper<T> apiWrapper = new APIWrapper<T>(MODEL_API);
            HttpResponseMessage response = await apiWrapper.GET();

            if (response.IsSuccessStatusCode)
            {
                List<T> lstResult = new List<T>();
                var responseData = response.Content.ReadAsStringAsync().Result;
                JArray parsed = JArray.Parse(responseData.ToString());

                foreach (var pair in parsed)
                {
                    T obj = ARSUtilities.JsonToObject<T>(pair.ToString());
                    lstResult.Add(obj);
                }

                return lstResult;
            }

            SaveErrorMessage(response);
            return null;
        }

        public async Task<T> Get(string id)
        {
            APIWrapper<T> apiWrapper = new APIWrapper<T>(MODEL_API, id);
            HttpResponseMessage response = await apiWrapper.GET();

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                T lstResult = ARSUtilities.JsonToObject<T>(responseData.ToString());

                return lstResult;
            }

            SaveErrorMessage(response);
            return default(T);
        }

        public async Task<T> Get(int id)
        {
            return await Get(id.ToString());
        }

        public async Task<bool> Put(string id, T data)
        {
            APIWrapper<T> apiWrapper = new APIWrapper<T>(MODEL_API, id);
            HttpResponseMessage response = await apiWrapper.PUT(data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            SaveErrorMessage(response);
            return false;
        }

        public async Task<bool> Put(int id, T data)
        {
            return await Put(id.ToString(), data);
        }

        public async Task<bool> Post(T data)
        {
            APIWrapper<T> apiWrapper = new APIWrapper<T>(MODEL_API);
            HttpResponseMessage response = await apiWrapper.POST(data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            SaveErrorMessage(response);
            return false;
        }


        public async Task<bool> Delete(string id)
        {
            APIWrapper<T> apiWrapper = new APIWrapper<T>(MODEL_API, id);
            HttpResponseMessage response = await apiWrapper.DELETE();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            SaveErrorMessage(response);
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            return await Delete(id.ToString());
        }

        private void SaveErrorMessage(HttpResponseMessage response)
        {
            string res = response.Content.ReadAsStringAsync().Result;
            JObject jObject = JObject.Parse(res);
            errorMessage = jObject["ExceptionMessage"].ToString();
        }

        public string GetErrorMessage()
        {
            return errorMessage;
        }
    }
}
