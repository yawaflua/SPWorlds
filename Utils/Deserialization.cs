using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SPWorldsApi.Utils
{
    internal static class Deserialization
    {
        public static TClass Deserialize<TClass>(this string body) where TClass : class
        {
            TClass? objectToReturn = JsonSerializer.Deserialize<TClass>(body);
            if (objectToReturn == null)
                throw new Exception($"Error with deserializing object");
            else
                return objectToReturn;
        }
    }
}
