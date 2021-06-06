using MVVM.WPF.Model.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM.WPF.Model.Repository
{
    class PersonRepository
    {
        private readonly WPFContext _context;

        public PersonRepository(WPFContext context)
        {
            _context = context;
        }

        public void Create(Person model)
        {
            model.Id = Guid.NewGuid();
            model.Endereco.Id = Guid.NewGuid();
            _context.Persons.Add(model);
            _context.SaveChanges();
        }

        public List<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public bool Update(Person model)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id.Equals(model.Id));
            if (person != null)
            {
                person = model;
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public void Delete(Guid id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id.Equals(id));
            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
            }

        }
    }
}
