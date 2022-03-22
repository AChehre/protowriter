namespace ProtoWriter
{
    public class ProtoInt32Converter
    {
        public string BaseType => "int32";
        public string[] SupportedTypes = new[] { nameof(SByte), nameof(Byte), nameof(Int16), nameof(Int32) };

        public string ConvertFrom(string type)
        {
            return BaseType;
        }

        public bool CanHandle(string type)
        {
            return true;
        }
    }
}