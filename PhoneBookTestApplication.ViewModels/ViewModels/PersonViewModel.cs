using System;
using System.Collections.Generic;
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

		public List<PersonModel> GetAllPersons()
		{
			return _repositoryService.GetAllPersons();
		}

		public void GetPersonsByName(string name)
		{
			// TODO implement filter by name
		}

		public void AddPerson()
		{
			// TODO check if person object is valid and has all mandatory fields

			_repositoryService.AddPerson(Person);
		}

		public void RemovePerson()
		{
			// TODO check if person object is valid

			_repositoryService.RemovePerson(Person);
		}

		#endregion
	}
}
