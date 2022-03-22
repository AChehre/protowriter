using System.ComponentModel;
using FluentAssertions;

namespace ProtoWriter.Test
{
    public class TypeConverterTests
    {
        
        [Theory]
        [InlineData(nameof(SByte))]
        [InlineData(nameof(Byte))]
        [InlineData(nameof(Int16))]
        [InlineData(nameof(Int32))]
        public void Convert_should_convert_to_int32(string type)
        {
            ProtoInt32Converter converter = new ProtoInt32Converter();

            bool canHandle = converter.CanHandle(type);
            canHandle.Should().BeTrue();

            string protoType = converter.ConvertFrom(type);
            protoType.Should().Be(converter.BaseType);
        }
    }
}