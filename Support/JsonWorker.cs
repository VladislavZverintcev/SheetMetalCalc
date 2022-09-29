using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetMetalCalc.Support
{
    public class JsonWorker
    {
        public static string GetSerializedObj(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static List<Models.Material> GetDeserializedListString(string jString)
        {
            if (jString == null)
            {
                return new List<Models.Material>();
            }
            try
            {
                return JsonConvert.DeserializeObject<List<Models.Material>>(jString);
            }
            catch
            {
                return new List<Models.Material>();
            }
        }
    }
}
