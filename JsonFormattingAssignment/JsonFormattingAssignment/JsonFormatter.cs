using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System;

namespace JsonFormattingAssignment
{
    // এই ক্লাসটি যেকোনো C# object কে JSON string এ convert করে
    public static class JsonFormatter
    {
        // বাহির থেকে কল করার জন্য public method
        public static string Convert(object obj)
        {
            return MySerialize(obj);
        }

        // আসল serialization logic এখানে করা হয়েছে
        private static string MySerialize(object obj)
        {
            // যদি object null হয় → JSON এ "null" রিটার্ন করবে
            if (obj == null)
            {
                return "null";
            }

            // object এর type বের করা হচ্ছে
            Type type = obj.GetType();

            // যদি string বা char হয় → ডাবল কোটেশনের মধ্যে রাখবে
            if (type == typeof(string) || type == typeof(char))
            {
                return $"\"{obj.ToString()}\"";
            }

            // যদি DateTime হয় → সেটাও string হিসেবে return করবে
            if (type == typeof(DateTime))
            {
                return $"\"{obj.ToString()}\"";
            }

            // যদি bool হয় → true/false lowercase এ return করবে
            if (type == typeof(bool))
            {
                return obj.ToString().ToLower();
            }

            // যদি primitive type (int, float, double ইত্যাদি) বা decimal হয়
            if (type.IsPrimitive || type == typeof(decimal) || type == typeof(double))
            {
                return obj.ToString();
            }

            // যদি object টি collection হয় (List, Array ইত্যাদি)
            if (typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("["); // JSON array শুরু

                IEnumerable items = (IEnumerable)obj;
                bool first = true;

                // প্রতিটা item কে আলাদা করে serialize করা হচ্ছে
                foreach (var item in items)
                {
                    if (!first)
                    {
                        stringBuilder.Append(",");
                    }

                    stringBuilder.Append(MySerialize(item));
                    first = false;
                }

                stringBuilder.Append("]"); // JSON array শেষ
                return stringBuilder.ToString();
            }

            // যদি object হয় (class/complex type)
            StringBuilder builder = new StringBuilder();
            builder.Append("{"); // JSON object শুরু

            // object এর সব properties বের করা হচ্ছে
            PropertyInfo[] properties = type.GetProperties();

            // nullable property detect করার জন্য helper
            NullabilityInfoContext nullabilityContext = new NullabilityInfoContext();

            bool flag = true;

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];

                // property এর value নেওয়া হচ্ছে
                object value = property.GetValue(obj);

                // property nullable কিনা সেটা detect করা হচ্ছে
                NullabilityInfo nullabilityInfo = nullabilityContext.Create(property);
                bool isNullable = nullabilityInfo.WriteState is NullabilityState.Nullable;

                // যদি value null হয় এবং property nullable হয় → skip করা হবে
                if (value == null && isNullable)
                {
                    continue;
                }

                // comma বসানোর logic (প্রথম item এর আগে comma না)
                if (!flag)
                {
                    builder.Append(",");
                }

                // property name JSON key হিসেবে লেখা হচ্ছে
                builder.Append($"\"{property.Name}\":");

                // value null হলে "null" লিখবে
                if (value == null)
                {
                    builder.Append("null");
                }
                else
                {
                    // না হলে আবার recursive ভাবে serialize করবে
                    builder.Append(MySerialize(value));
                }

                flag = false;
            }

            builder.Append("}"); // JSON object শেষ
            return builder.ToString();
        }
    }
}