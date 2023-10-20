﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace OgrenciTakipMuh.Tools
{
    public static class EnumFunctions
    {
        private static T GetAttiribute<T>(this Enum value) where T : Attribute
        {
            if (value == null) return null;
            var memberInfo = value.GetType().GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];

        }

        public static string ToName(this Enum value)
        {
            if (value == null) return null;
            var attribute = value.GetAttiribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }


        public static ICollection GetEnumsDescriptionList<T>()
        {
            return typeof(T).GetMembers().SelectMany(x => x.GetCustomAttributes(typeof(DescriptionAttribute), true)
            .Cast<DescriptionAttribute>())
            .Select(x => x.Description).ToList();
        }

        public static T GetEnum<T>(this string description)
        {
            var enumName = Enum.GetNames(typeof(T));
            foreach (var e in enumName.Select(x => Enum.Parse(typeof(T), x)).Where(y => description == ToName((Enum)y)))
                return (T)e;
            return default(T);
        }




    }
}