namespace ProtoWriter
{
    public class ProtoTimestampConverter : ProtoTypeConverterBase
    {
        public const string BaseType = "google.protobuf.Timestamp";
        public string[] SupportedTypes = {nameof(DateTime), nameof(DateTimeOffset)};

        public ProtoTimestampConverter(ProtoTypeConverterBase nextConvertor) : base(nextConvertor)
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