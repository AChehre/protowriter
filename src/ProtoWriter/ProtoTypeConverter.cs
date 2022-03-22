using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtEase.Extensions;

namespace ProtoWriter
{

    public abstract class ProtoTypeConverterBase
    {
        private ProtoTypeConverterBase _nextConvertor;

        protected ProtoTypeConverterBase(ProtoTypeConverterBase nextConvertor)
        {
            _nextConvertor = nextConvertor;
        }

        //public void SetNextConvertor(ProtoTypeConverterBase nextConvertor)
        //{
        //    _nextConvertor = nextConvertor;
        //}
        protected abstract bool CanHandle(string type);
        protected abstract string ConvertFrom(string type);

        public string ConvertFromType(string type)
        {
            if (CanHandle(type))
            {
                return ConvertFrom(type);
            }

            if (_nextConvertor.IsNotNull())
                return _nextConvertor.ConvertFromType(type);

            throw new ArgumentOutOfRangeException(nameof(type));
        }
    }

    public class ProtoTypeConverter
    {
        private readonly ProtoTypeConverterBase converter;
        public ProtoTypeConverter() => converter = new ProtoInt32Converter(
            new ProtoStringConverter(
            new ProtoTimestampConverter(
            new ProtoDurationConverter(nextConvertor: null))));

        public string ConvertFrom(string type)
        {
            return converter.ConvertFromType(type);
        }
    }
}
