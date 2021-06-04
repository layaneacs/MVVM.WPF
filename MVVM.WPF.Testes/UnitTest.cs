using MVVM.WPF.Model;
using MVVM.WPF.Model.Repository;
using MVVM.WPF.ViewModel;
using NUnit.Framework;
using System;
using System.Linq;

namespace MVVM.WPF.Testes
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public void ExecutaSalvarCommandSeTodosOsCamposObrigatoriosForemPreenchidos()
        {
            var create = new PersonViewModel()
            {
                Cpf = "12345678910",
                DataNascimento = DateTime.Parse("26/08/1993 00:00:00"),
                Genero = "F",
                Nome = "Layane",
                Sobrenome = "Andreia",
                Bairro = "Campo Grande",
                CEP = "23042460",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Numero = "2",
                Logradouro = "Rua"
            };

            Assert.IsTrue(create.SalvarCommand.CanExecute(null));
        }


        [Test]
        public void NaoExecutaSalvarCommandQuandoCampoNomeNaoEValido()
        {
            var create = new PersonViewModel()
            {
                Cpf = "12345678910",
                DataNascimento = DateTime.Parse("26/08/1993 00:00:00"),
                Genero = "F",
                Nome = null,
                Sobrenome = "Andreia",
                Bairro = "Campo Grande",
                CEP = "23042460",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Numero = "2",
                Logradouro = "Rua"
            };

            Assert.IsFalse(create.SalvarCommand.CanExecute(null));
        }           
        

        [Test]
        public void ExecutaSalvarCommandSeIdadeForIgualA18()
        {
            var create = new PersonViewModel()
            {
                Cpf = "12345678910",
                DataNascimento = DateTime.Parse("04/06/2003"),
                Genero = "F",
                Nome = "Layane",
                Sobrenome = "Andreia",
                Bairro = "Campo Grande",
                CEP = "23042460",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Numero = "2",
                Logradouro = "Rua"
            };

            Assert.IsTrue(create.SalvarCommand.CanExecute(null));
        }

        [Test]
        public void NaoExecutaSalvarCommandSeIdadeForMenor18()
        {
            var create = new PersonViewModel()
            {
                Cpf = "12345678910",
                DataNascimento = DateTime.Parse("03/06/2003"),
                Genero = "F",
                Nome = "Layane",
                Sobrenome = "Andreia",
                Bairro = "Campo Grande",
                CEP = "23042460",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Numero = "2",
                Logradouro = "Rua"
            };

            Assert.IsFalse(create.SalvarCommand.CanExecute(null));
        }


        [Test]
        public void NaoExecutaSalvarCommandSeQuantidadeDeDigitosDoCPFForDiferenteDe11()
        {
            var create = new PersonViewModel()
            {
                Cpf = "1234567890",
                DataNascimento = DateTime.Parse("03/06/2003"),
                Genero = "F",
                Nome = "Layane",
                Sobrenome = "Andreia",
                Bairro = "Campo Grande",
                CEP = "23042460",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Numero = "2",
                Logradouro = "Rua"
            };

            Assert.IsFalse(create.SalvarCommand.CanExecute(null));
        }

        [Test]
        public void NaoExecutaSalvarCommandSeQuantidadeDeDigitosDoCEPForDiferenteDe8()
        {
            var create = new PersonViewModel()
            {
                Cpf = "12345678910",
                DataNascimento = DateTime.Parse("04/06/2003"),
                Genero = "F",
                Nome = "Layane",
                Sobrenome = "Andreia",
                Bairro = "Campo Grande",
                CEP = "2304240",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Numero = "2",
                Logradouro = "Rua"
            };

            Assert.IsFalse(create.SalvarCommand.CanExecute(null));
        }
    }
}