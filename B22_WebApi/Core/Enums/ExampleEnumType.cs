using System.Text.Json.Serialization;

namespace Core.Enums
{
    // this annotation is used for swagger to be able to parse enums as JSON strings
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExamplEnumType
    {
        // this annotation is a custom created annotation that allows us to set string values to the Enums
        // as C# does not allow enums to have values other than numbers ex: Value1=0 ( default behavior )
        // EnumStringValue Implementation Can Be Found At the EnumStringValueAttribute Class in the same directory
        // Usage Ex: Value1.GetStringValue(), returns "GenericVal1"
        [EnumStringValue("GenericVal1")]
        Value1,
        [EnumStringValue("GenericVal2")]
        Value2,
        [EnumStringValue("GenericVal3")]
        Value3
    }
}
