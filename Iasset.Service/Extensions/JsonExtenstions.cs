using System;
using Newtonsoft.Json;

namespace Iasset.Service.Extensions
{
    public static class JsonExtenstions
    {
        public static string ToJson(this object o)
        {
            if (o == null) throw new ArgumentNullException(nameof(o));
            return JsonConvert.SerializeObject(o);
        }
    }
}
