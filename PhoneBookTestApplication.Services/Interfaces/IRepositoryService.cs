using PhoneBookTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookTestApplication.Services.Interfaces
{
    public interface IRepositoryService
    {
        public IList<PersonModel> GetAllPersons();
        public void AddPerson(PersonModel person);

        public void RemovePerson(PersonModel person);
    }
}
