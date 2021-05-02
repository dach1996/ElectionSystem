using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Dach.ElectionSystem.Utils.Extension
{
    public static class EnumExtension
    {
        public static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static string GetEnumMember(this Enum @enum)
        {
            var attr = @enum.GetType().GetMember(@enum.ToString()).FirstOrDefault()?
                                      .GetCustomAttributes(false).OfType<EnumMemberAttribute>()
                                      .FirstOrDefault();
            return attr == null ? @enum.ToString() : attr.Value;
        }
    }
}
