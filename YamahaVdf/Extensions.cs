using System;
using System.Linq;
using System.Reflection;

namespace YamahaVdf
{
    public static class Extensions
    {
        /// <summary>
        /// Gets the enumeration value equivalent of the string using the Code attribute of the enumeration value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">T must be an enumerated type</exception>
        public static T EnumValue<T>(this string value, T defaultValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            var values =
                typeof(T)
                    .GetMembers(BindingFlags.Public | BindingFlags.Static)
                    .Select(item =>
                        new
                        {
                            Name = (T) Enum.Parse(typeof(T), item.Name),
                            Code = ((CodeAttribute) item.GetCustomAttributes(typeof(CodeAttribute), false).FirstOrDefault())?.Code,
                        }
                    );

            return values.FirstOrDefault(item => item.Code == value)?.Name ?? defaultValue;
        }
    }
}
