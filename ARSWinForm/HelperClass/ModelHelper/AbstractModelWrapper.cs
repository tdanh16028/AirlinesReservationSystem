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
        private APIWrapper<T>.ARSAPI LIST;

        public async Task<List<T>> List()
        {
            APIWrapper<T> apiWrapper = new APIWrapper<T>(LIST);
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

            return null;
        }
    }
}
