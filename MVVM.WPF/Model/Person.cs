using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM.WPF.Model
{
    public class Person
    {
        public Person()
        {
            Endereco = new Address();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public Address Endereco { get; set; }
    }
}
