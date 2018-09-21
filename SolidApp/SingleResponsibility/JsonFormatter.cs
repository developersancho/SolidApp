using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidApp
{
    public class ValidationException : ApplicationException { }

    public class JsonFormatter
    {
        private JsonValidator _validator = new JsonValidator();

        public string Format(string input)
        {
            if (!_validator.IsValid(input))
                throw new ValidationException();

            return "formatlanmış metin";
        }

        //private bool IsInputValid(string input)
        //{
        //    return true;
        //}

    }

    public class JsonValidator
    {
        public bool IsValid(string input)
        {
            // Kural denetimini yap
            return true;
        }
    }

    public class HtmlValidator
    {
        public bool IsValid(string input)
        {
            // Kural denetimini yap
            return true;
        }
    }

    public class XmlValidator
    {
        public bool IsValid(string input)
        {
            // Kural denetimini yap
            return true;
        }
    }
}
