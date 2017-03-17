using Newtonsoft.Json;

namespace Iasset.Service.Extensions
{
    public static class JsonExtenstions
    {
        public static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}
