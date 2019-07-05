using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Pharmacy.Extensions
{
    public static class TempDataExtensions
    {
        public static void Set<T>(this ITempDataDictionary tempData, string key, T value) => tempData.Add(key, JsonConvert.SerializeObject(value));

        public static T Get<T>(this ITempDataDictionary tempData, string key) => !tempData.ContainsKey(key) ? default(T) :
            !(tempData[key] is string value) ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}