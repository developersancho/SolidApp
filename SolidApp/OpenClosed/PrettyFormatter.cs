using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidApp.OpenClosed
{
    public class PrettyFormatter
    {
        // Format tipleri
        public enum FormatTypes
        {
            Json,
            Html,
            Xml
        }

        //// Formatlama işlemini yapacak olan nesneler
        //private JsonFormatter _jsonFormatter = new JsonFormatter();
        //private HtmlFormatter _htmlFormatter = new HtmlFormatter();

        //private XmlFormatter _xmlFormatter = new XmlFormatter(); // (2) <-- !!!

        //// Formatlama işlemini yapan metod
        //public string Format(FormatTypes inputType, string input)
        //{
        //    switch (inputType)
        //    {
        //        case FormatTypes.Json:
        //            return _jsonFormatter.Format(input);
        //        case FormatTypes.Html:
        //            return _htmlFormatter.Format(input);
        //        case FormatTypes.Xml: // (3) <-- !!!
        //            return _xmlFormatter.Format(input);
        //        default:
        //            throw new Exception("Desteklenmeyen format tipi!");
        //    }
        //}

        public string Format(PrettyFormatProvider provider, string input)
        {
            return provider.Format(input);
        }

    }

    public abstract class PrettyFormatProvider
    {
        public abstract string Format(string input);
    }

    public class JsonFormatter : PrettyFormatProvider
    {
        JsonValidator _validator = new JsonValidator();

        public override string Format(string input)
        {
            if (!_validator.IsValid(input))
                throw new ValidationException();
            
            return "formatlanmış metin";
        }
    }

    public class HtmlFormatter: PrettyFormatProvider
    {
        private HtmlValidator _ validator = new HtmlValidator();

        public override string Format(string input)
        {
            if (!_validator.IsValid(input))
                throw new ValidationException();
            
            return "formatlanmış metin";
        }
    }

    public class XmlFormatter : PrettyFormatProvider
    {
        XmlValidator _validator = new XmlValidator();

        public override string Format(string input)
        {
            if (!_validator.IsValid(input))
                throw new ValidationException();
            
            return "formatlanmış metin";
        }
    }
}
