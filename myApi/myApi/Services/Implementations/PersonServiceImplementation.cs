using myApi.Model;
using myApi.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace myApi.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {


        private readonly MySqlContext _context;
        public PersonServiceImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Felipe",
                LastName = "Costa",
                Address = "Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

    }
}
