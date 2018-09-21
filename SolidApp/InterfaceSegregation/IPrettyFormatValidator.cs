using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidApp.InterfaceSegregation
{
    public interface IPrettyFormatValidator
    {
        string Schema { get; set; }
        bool IsValid(string input);
    }

    public class JsonValidator : IPrettyFormatValidator
    {
        public string Schema { get; set; }

        public bool IsValid(string input)
        {
            return true;
        }
    }

    public class HtmlValidator : IPrettyFormatValidator
    {
        public string Schema { get; set; }

        public bool IsValid(string input)
        {
            return true;
        }
    }

    public class XmlValidator : IPrettyFormatValidator
    {
        public string Schema { get; set; }

        public bool IsValid(string input)
        {
            return true;
        }
    }

    public class XmlSchemaValidator : IPrettyFormatValidator
    {
        public string Schema { get; set; }

        public bool IsValid(string input)
        {
            return true;
        }
    }
    //Bu düzenlemedeki temel sorun, şema denetimi yapmayacakları halde JsonValidator, HtmlValidator ve XmlValidatorsınıflarının da Schema özelliğine sahip olma zorunluluğudur.Denetleme sınıflarımızı kontrat tasarımından kaynaklanan bu zorunluluktan kurtarmak için IPrettyFormatValidator arayüzündeki Schema özelliğini daha özelleşmiş bir arayüz olan IPrettyFormatSchemaValidator arayüzüne taşıyabiliriz.

    // interfaceleri bu şekil ayrıştıracaksın

    public interface IPrettyFormatValidator
    {
        bool IsValid(string input);
    }
    public interface IPrettyFormatSchemaValidator : IPrettyFormatValidator
    {
        string Schema { get; set; }
    }

}
