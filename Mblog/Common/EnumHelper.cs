using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EnumHelper
    {

        public static string GetName<T>(int value)
        {
            string result = Enum.GetName(typeof(T), value);
            return result;
        }
        public static T GetEnum<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }
        public static bool Incloud<T>(int value)
        {
            return Enum.IsDefined(typeof(T), value);
        }
        public static T GetEnum<T>(int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
        /// <summary>
        /// 返回对象包含 Value/Text/Description
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static List<dynamic> GetAllItems(Type enumName)
        {
            List<dynamic> list = new List<dynamic>();
            FieldInfo[] fields = enumName.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (!field.FieldType.IsEnum)
                {
                    continue;
                }
                int value = (int)enumName.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                string text = field.Name;
                string description = string.Empty;
                object[] array = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (array.Length > 0)
                {
                    description = ((DescriptionAttribute)array[0]).Description;
                }
                else
                {
                    description = "";
                }
                dynamic obj = new ExpandoObject();
                obj.Value = value;
                obj.Text = text;
                obj.Description = description;
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        public static string GetDescription<T>(T enumItem)
        {
            FieldInfo fi = enumItem.GetType().GetField(enumItem.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return enumItem.ToString();
            }
        }
    }
}
