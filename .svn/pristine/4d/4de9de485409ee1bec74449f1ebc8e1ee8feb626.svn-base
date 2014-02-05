using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace ITA.Utility
{
    public class EnumMapHelper
    {
        public static Dictionary<Type, EnumMap> maps;

        public static string GetStringFromEnum(Enum item)
        {
            if (maps == null)
            {
                maps = new Dictionary<Type, EnumMap>();
            }

            Type enumType = item.GetType();

            EnumMap mapper = null;
            if (maps.ContainsKey(enumType))
            {
                mapper = maps[enumType];
            }
            else
            {
                mapper = new EnumMap(enumType);
                maps.Add(enumType, mapper);
            }
            return mapper[item];
        }

        public class EnumMap
        {
            private Type internalEnumType;
            private Dictionary<Enum, string> map;

            public EnumMap(Type enumType)
            {
                if (!enumType.IsSubclassOf(typeof(Enum)))
                {
                    throw new InvalidCastException();
                }
                internalEnumType = enumType;
                FieldInfo[] staticFiles = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

                map = new Dictionary<Enum, string>(staticFiles.Length);

                for (int i = 0; i < staticFiles.Length; i++)
                {
                    if (staticFiles[i].FieldType == enumType)
                    {
                        string description = "";
                        object[] attrs = staticFiles[i].GetCustomAttributes(typeof(DescriptionAttribute), true);
                        description = attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : staticFiles[i].Name;

                        map.Add((Enum)staticFiles[i].GetValue(enumType), description);
                    }
                }
            }

            public string this[Enum item]
            {
                get
                {
                    if (item.GetType() != internalEnumType)
                    {
                        throw new ArgumentException();
                    }
                    return map[item];
                }
            }
        }
    }
}
