
using Newtonsoft.Json;

namespace mobile_api.Core
{
    public static class ObjectComparer
    {
         public static bool ObjectsAreEqual<T>(T obj1, T obj2)
        {
        var obj1Serialized = JsonConvert.SerializeObject(obj1);
        var obj2Serialized = JsonConvert.SerializeObject(obj2);

        return obj1Serialized == obj2Serialized;
        }
    }
}