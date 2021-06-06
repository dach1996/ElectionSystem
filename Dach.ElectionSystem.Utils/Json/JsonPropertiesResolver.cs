using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;

namespace Dach.ElectionSystem.Utils.Json
{
    public class JsonPropertiesResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var test = objectType.GetProperties()
                .Where(pi => !Attribute.IsDefined(pi, typeof(JsonIgnoreAttribute)))
                .ToList<MemberInfo>();
            return test;
        }
    }
}