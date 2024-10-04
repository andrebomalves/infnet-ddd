using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Utils
{
    public static class EnumConvert
    {
        public static T ToEnum<T>(this string value)
        {
            var nome = Enum.GetNames(typeof(T)).FirstOrDefault();

            var valorInicial = Enum.Parse(typeof(T), nome);
            if (!Enum.IsDefined(typeof(T), value))
                return (T)Enum.GetValues(typeof(T)).GetValue(0);


            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
