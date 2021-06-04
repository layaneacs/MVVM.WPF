using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM.WPF.Model
{
    public class Address
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
    }
}
