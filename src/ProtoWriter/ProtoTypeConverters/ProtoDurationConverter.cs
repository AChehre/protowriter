namespace ProtoWriter
{
    public class ProtoDurationConverter : ProtoTypeConverterBase
    {
        public const string BaseType = "google.protobuf.Duration";
        public string[] SupportedTypes = {nameof(TimeSpan)};

        public ProtoDurationConverter(ProtoTypeConverterBase nextConvertor) : base(nextConvertor)
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