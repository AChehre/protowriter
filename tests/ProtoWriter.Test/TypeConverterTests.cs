using FluentAssertions;

namespace ProtoWriter.Test
{
 public class TypeConverterTests
    {
        [Fact]
        public void Convert_should_throw_exception_when_type_is_not_supported()
        {
            ProtoTypeConverter converter = new ProtoTypeConverter();

            string randomString = Guid.NewGuid().ToString();
            Action act = () => converter.ConvertFrom(randomString);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }




        [Theory]
        [InlineData(nameof(SByte))]
        [InlineData(nameof(Byte))]
        [InlineData(nameof(Int16))]
        [InlineData(nameof(Int32))]
        public void Convert_should_convert_to_int32(string type)
        {
            ProtoTypeConverter converter = new ProtoTypeConverter();
            string protoType = converter.ConvertFrom(type);
            protoType.Should().Be(ProtoInt32Converter.BaseType);
        }


        [Theory]
        [InlineData(nameof(String))]
        public void Convert_should_convert_to_string(string type)
        {
            ProtoTypeConverter converter = new ProtoTypeConverter();
            string protoType = converter.ConvertFrom(type);
            protoType.Should().Be(ProtoStringConverter.BaseType);
        }


        [Theory]
        [InlineData(nameof(DateTime))]
        [InlineData(nameof(DateTimeOffset))]
        public void Convert_should_convert_to_timestamp(string type)
        {
             ProtoTypeConverter converter = new ProtoTypeConverter();
            string protoType = converter.ConvertFrom(type);
            protoType.Should().Be(ProtoTimestampConverter.BaseType);
        }

        
        [Theory]
        [InlineData(nameof(TimeSpan))]
        public void Convert_should_convert_to_duration(string type)
        {   
            ProtoTypeConverter converter = new ProtoTypeConverter();
            string protoType = converter.ConvertFrom(type);
            protoType.Should().Be(ProtoDurationConverter.BaseType);
        }
    }
}