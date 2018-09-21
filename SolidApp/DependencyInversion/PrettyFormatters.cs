using SolidApp.OpenClosed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidApp.DependencyInversion
{
    //PrettyFormatter sınıfının web uygulama katmanında yer alan bir sınıf olduğunu JsonFormatter ve HtmlFormatter sınıflarının ise kütüphane olarak kullanılan daha alt katmanlardan birinde yer aldığını varsayalım.

    public class PrettyFormatters
    {
        // Format tipleri
        public enum FormatTypes
        {
            Json,
            Html
        }

        // Formatlama işlemini yapacak olan nesneler
        private JsonFormatter _jsonFormatter = new JsonFormatter();
        private HtmlFormatter _htmlFormatter = new HtmlFormatter();

        // Formatlama işlemini yapan metod
        public string Format(FormatTypes inputType, string input)
        {
            switch (inputType)
            {
                case FormatTypes.Json:
                    return _jsonFormatter.Format(input);
                case FormatTypes.Html:
                    return _htmlFormatter.Format(input);
                default:
                    throw new Exception("Desteklenmeyen format tipi!");
            }
        }
    }

    //üst katmandaki PrettyFormatter sınıfı alt katmanda yer alan JsonFormatter ve HtmlFormatter sınıflarından nesneleri kendisi oluşturmalıdır yani PrettyFormatter sınıfı sorumluluğunu yerine getirmek için alt katmanlardaki sınıflara bağımlıdır.Bu bağımlılığı ortadan kaldırmak için JsonFormatter ve HtmlFormatter sınıflarını PrettyFormatProvider sınıfından türeterek PrettyFormatter sınıfına kurucu fonksiyonu (constructor) vasıtası ile dışarıdan verilmesini (constructor injection) sağlayabiliriz.

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

}
