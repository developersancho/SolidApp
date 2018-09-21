using SolidApp.OpenClosed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidApp.LiskovSubstitution
{
    //public class XmlSchemaValidator
    //{
    //    private string _xsdSchema;

    //    public XmlSchemaValidator(string xsd)
    //    {
    //        _xsdSchema = xsd;
    //    }

    //    public bool IsValid(string input)
    //    {
    //        // XSD şemaya göre kural denetimini yap
    //        return true;
    //    }

    //}

    //public class XmlFormatter : PrettyFormatProvider
    //{
    //    private XmlValidator _validator;
    //    private XmlSchemaValidator _schemaValidator; // (1) <-- !!!

    //    public XmlFormatter(string xsd)
    //    {
    //        if (String.IsNullOrWhiteSpace(xsd))
    //            _validator = new XmlValidator();
    //        else
    //            _schemaValidator = new XmlSchemaValidator(xsd);
    //    }

    //    public override string Format(string input)
    //    {
    //        if (_validator != null && _validator.IsValid(input))
    //            throw new ValidationException();

    //        if (_schemaValidator != null && _schemaValidator.IsValid(input))
    //            throw new ValidationException();

    //        // Formatlama işlemini yap
    //        return "formatlanmış metin!";
    //    }
    //}

    // ***********************************************************

    public abstract class PrettyFormatValidator
    {
        public abstract bool IsValid(string input);
    }

    public class XmlValidator : PrettyFormatValidator
    {
        public override bool IsValid(string input)
        {
            // Kural denetimini yap
            return true;
        }
    }

    public class XmlSchemaValidator : PrettyFormatValidator
    {
        private string _xsdSchema;
        public XmlSchemaValidator(string xsd)
        {
            _xsdSchema = xsd;
        }

        public override bool IsValid(string input)
        {
            // XSD şemaya göre kural denetimini yap
            return true;
        }
    }

    public class XmlFormatter : PrettyFormatProvider
    {
        private PrettyFormatValidator _validator;

        public XmlFormatter(PrettyFormatValidator validator)
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


}
