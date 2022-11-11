using System;
using System.Collections.Generic;
using System.Linq;
using PhoneBookTestApplication.Models;
using PhoneBookTestApplication.Services;

namespace PhoneBookTestApplication.ViewModels.ViewModels
{
	public class PersonViewModel
	{
		#region Fields

		private RepositoryService _repositoryService;

		#endregion

		#region Properties

		public PersonModel Person { get; set; }

		#endregion

		#region Constructor

		public PersonViewModel()
		{
			_repositoryService = new RepositoryService();
		}

		#endregion

		#region Methods

		public IList<PersonModel> GetAllPersons()
		{
			return _repositoryService.GetAllPersons();
		}

		public void GetPersonsByName(string name)
		{
			// TODO implement filter by name
		}

		private static int lastPersonId = 0;
		public void AddPerson()
		{
			// TODO check if person object is valid and has all mandatory fields
			Person.PersonId = GetAllPersons().Count;
            _repositoryService.AddPerson(Person);
		}

		public void RemovePerson(int idPerson)
		{
			var removePerson = GetAllPersons()
									.First(person => person.PersonId == idPerson);

			if (removePerson is null)
				return; 

            _repositoryService.RemovePerson(removePerson);
		}

		#endregion
	}
}
