using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using PhoneBookTestApplication.Models;
using PhoneBookTestApplication.Services;
using PhoneBookTestApplication.Services.Interfaces;

namespace PhoneBookTestApplication.ViewModels.ViewModels
{
	public class PersonViewModel
	{
		#region Fields

		private IRepositoryService _repositoryService;
		private IFilterService _filterService;

		#endregion

		#region Properties

		public PersonModel Person { get; set; }

		#endregion

		#region Constructor

		public PersonViewModel()
		{
			_repositoryService = new RepositoryService();
            _filterService = new FilterService(GetAllPersons());
        }

		#endregion

		#region Methods

		public IList<PersonModel> GetAllPersons()
		{
			return _repositoryService.GetAllPersons();
		}

		public void AddOrEditPerson()
		{
			// TODO check if person object is valid and has all mandatory fields
			var allPersons = GetAllPersons();
			bool personExist = allPersons.Any(p=>
					p.LastName == Person.LastName 
					&& p.FirstName == Person.FirstName);
			if (personExist)
			{
                _repositoryService.EditPerson(Person);
				return;
            }
            Person.PersonId = allPersons.Count;
            _repositoryService.AddPerson(Person);
		}

		public void RemovePerson(int idPerson)
		{
			var removePerson = GetAllPersons()
									.Single(person => person.PersonId == idPerson);

			if (removePerson is null)
				return; 

            _repositoryService.RemovePerson(removePerson);
		}

		public IList<PersonModel> SearchPerson(string firstName, string lastName)
		{
			return _filterService.GetPersonsByName(firstName, lastName);
		}

		#endregion
	}
}
