using System;
using System.Collections.Generic;
using System.Linq;
using PhoneBookTestApplication.Models;
using PhoneBookTestApplication.Services.Interfaces;
using PhoneBookTestApplication.Services.Services;

namespace PhoneBookTestApplication.Services
{
    public class RepositoryService : BaseService, IRepositoryService
    {
        #region Properties

        public IList<PersonModel> Persons { get; set; } = new List<PersonModel>();

        #endregion

        #region Constructor

        public RepositoryService()
        {
            Persons.Add(
                new PersonModel
                {
                    PersonId = 0,
                    FirstName = "Ionica",
                    LastName = "Popescu",
                    Addresses = new List<AddressModel>
                {
                    new AddressModel
                    {
                        StreetName = "Crisului",
                        StreetNumber = 6,
                        PhoneNumbers = new List<PhoneNumberModel>
                        {
                            new PhoneNumberModel
                            {
                                PhoneType = Models.Enums.PhoneTypeEnum.Personal,
                                PhoneNumber = "0742131415"
                            }
                        }
                    }
                }
                }); ;
            Persons.Add(
        new PersonModel
        {
            PersonId = 1,
            FirstName = "test",
            LastName = "test",
            Addresses = new List<AddressModel>
        {
                    new AddressModel
                    {
                        StreetName = "test",
                        StreetNumber = 6,
                        PhoneNumbers = new List<PhoneNumberModel>
                        {
                            new PhoneNumberModel
                            {
                                PhoneType = Models.Enums.PhoneTypeEnum.Personal,
                                PhoneNumber = "4532642645"
                            }
                        }
                    }
        }
        });
        }

        #endregion

        #region Methods

        public IList<PersonModel> GetAllPersons()
        {
            return Persons;
        }

        public void AddPerson(PersonModel person)
        {
            Persons.Add(person);
        }

        public void EditPerson(PersonModel newPerson)
        {
            ExceptionHandlingAsync(() =>
            {
                var oldPerson = Persons.SingleOrDefault(p => p.PersonId == newPerson.PersonId);
                var index = Persons.IndexOf(oldPerson);
                Persons[index] = newPerson;
            });
        }

        public void RemovePerson(PersonModel person)
        {
            ExceptionHandlingAsync(() =>
            {
                Persons.Remove(person);

            });
        }

        public void ThrowException()
        {
            ExceptionHandlingAsync(() =>
            {
                throw new Exception($"Test Exception");
            });
        }



        #endregion
    }
}
