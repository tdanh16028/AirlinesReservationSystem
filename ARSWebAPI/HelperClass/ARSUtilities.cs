using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace ARSWebAPI.HelperClass
{
    public class ARSUtilities
    {
        public static T JsonToObject<T>(string json)
        {
            // Convert string to stream
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            MemoryStream memStream = new MemoryStream(byteArray);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            return (T)serializer.ReadObject(memStream);
        }
    }
}