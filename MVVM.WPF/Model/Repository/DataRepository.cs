using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM.WPF.Model.Repository
{
    public class DataRepository
    {
        //-- Simulando um DataBase...
        private static List<Person> data = new List<Person>()
        {
             new Person
             {
                Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"),
                Cpf = "15469788",
                DataNascimento = DateTime.Parse("26/08/1993"),
                Genero = "F",
                Nome = "Layane",
                Sobrenome = "Andreia",
                Endereco = new Address
                {
                    Bairro = "Campo Grande",
                    CEP = "23042460",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                    Numero = "3",
                    Logradouro = "Rua"
                }

             }
        };


        //--CRUD
        public void Create(Person model)
        {
            model.Id = Guid.NewGuid();
            data.Add(model);
        }

        public IEnumerable<Person> GetAll()
        {
            return data.ToList();
        }

        public bool Update(Person model)
        {
            var person = data.FirstOrDefault(p => p.Id.Equals(model.Id));
            if(person != null)
            {
                person = model;
                return true;
            }
            return false;
        }


        public void Delete(Guid id)
        {
            var person = data.FirstOrDefault(p => p.Id.Equals(id));
            if (person != null)
            {
                data.Remove(person);
            }

        }
    }
}
