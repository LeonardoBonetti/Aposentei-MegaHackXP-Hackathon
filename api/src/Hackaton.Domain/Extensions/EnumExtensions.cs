using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hackaton.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayAttributeFrom(this Enum enumValue, Type enumType)
        {
            string displayName = "";
            MemberInfo info = enumType.GetMember(enumValue.ToString()).First();

            if (info != null && info.CustomAttributes.Any())
            {
                DisplayAttribute nameAttr = info.GetCustomAttribute<DisplayAttribute>();
                displayName = nameAttr != null ? nameAttr.Name : enumValue.ToString();
            }
            else
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}