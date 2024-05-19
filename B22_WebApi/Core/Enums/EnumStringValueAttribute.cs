
using System.Reflection;

namespace Core.Enums;

[AttributeUsage(AttributeTargets.Field)]
public class EnumStringValueAttribute : Attribute
{
    public string Value { get; }

    public EnumStringValueAttribute(string value)
    {
        Value = value;
    }
}

public static class EnumExtensions
{
    public static string GetStringValue(this Enum value)
    {
        Type type = value.GetType();
        FieldInfo fieldInfo = type.GetField(value.ToString());

        EnumStringValueAttribute[] attributes =
            (EnumStringValueAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumStringValueAttribute), false);

        return attributes.Length > 0 ? attributes[0].Value : value.ToString();
    }
}
