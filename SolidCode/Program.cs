using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonFormatter = new JsonFormatter();

            PrettyFormatter formatter = new PrettyFormatter(jsonFormatter);
            var formattedText = formatter
             .Format(@"{""id"":1,""ad"":""developers"",""soyad"":""Sancho""}");

            Console.WriteLine(formattedText);
            Console.ReadKey();
        }
    }

    public class PrettyFormatter
    {
        private PrettyFormatProvider _provider;
        public PrettyFormatter(PrettyFormatProvider provider)
        {
            _provider = provider;
        }

        // Formatlama işlemini yapan metod
        public string Format(string input)
        {
            return _provider.Format(input);
        }
    }

    #region Providers
    public abstract class PrettyFormatProvider
    {
        public abstract string Format(string input);
    }

    public class JsonFormatter : PrettyFormatProvider
    {
        private IPrettyFormatValidator _validator;

        public JsonFormatter()
        {
        }

        public JsonFormatter(IPrettyFormatValidator validator)
        {
            _validator = validator;
        }


        public override string Format(string input)
        {

            if (!_validator.IsValid(input))
                throw new ValidationException();

            // Formatlama işlemini yap
            return "formatlanmış metin!";
        }
    }

    public class HtmlFormatter : PrettyFormatProvider
    {
        private IPrettyFormatValidator _validator;
        public HtmlFormatter(IPrettyFormatValidator validator)
        {
            _validator = validator;
        }


        public override string Format(string input)
        {

            if (!_validator.IsValid(input))
                throw new ValidationException();

            // Formatlama işlemini yap
            return "formatlanmış metin!";
        }
    }

    public class XmlFormatter : PrettyFormatProvider
    {
        private IPrettyFormatValidator _validator;

        public XmlFormatter(IPrettyFormatValidator validator)
        {
            _validator = validator;
        }

        public override string Format(string input)
        {

            if (_validator.IsValid(input))
                throw new ValidationException();

            // Formatlama işlemini yap
            return "formatlanmış metin!";
        }
    }

    #endregion // Providers

    #region Validators
    public class ValidationException : ApplicationException { }

    public interface IPrettyFormatValidator
    {
        bool IsValid(string input);
    }

    public interface IPrettyFormatSchemaValidator : IPrettyFormatValidator
    {
        string Schema { get; set; }
    }


    public class JsonValidator : IPrettyFormatValidator
    {
        public bool IsValid(string input)
        {
            // Kural denetimini yap
            return true;
        }
    }

    public class HtmlValidator : IPrettyFormatValidator
    {
        public bool IsValid(string input)
        {
            // Kural denetimini yap
            return true;
        }
    }

    public class XmlValidator : IPrettyFormatValidator
    {
        public bool IsValid(string input)
        {
            // Kural denetimini yap
            return true;
        }
    }

    public class XmlSchemaValidator : IPrettyFormatSchemaValidator
    {
        public string Schema { get; set; }

        public bool IsValid(string input)
        {
            // XSD şemaya göre kural denetimini yap
            return true;
        }
    }

    #endregion //Validators
}
