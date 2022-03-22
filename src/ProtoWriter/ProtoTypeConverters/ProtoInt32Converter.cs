namespace ProtoWriter
{
    public class ProtoInt32Converter : ProtoTypeConverterBase
    {
        public const string BaseType = "int32";
        public string[] SupportedTypes = {nameof(SByte), nameof(Byte), nameof(Int16), nameof(Int32)};

        public ProtoInt32Converter(ProtoTypeConverterBase nextConvertor) : base(nextConvertor)
        {
        }

        protected override string ConvertFrom(string type)
        {
            return BaseType;
        }

        protected override bool CanHandle(string type)
        {
            return SupportedTypes.Contains(type);
        }
    }
}