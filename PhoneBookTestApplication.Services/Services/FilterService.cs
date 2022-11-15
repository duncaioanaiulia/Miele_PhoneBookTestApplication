using PhoneBookTestApplication.Models;
using PhoneBookTestApplication.Services.Interfaces;
using PhoneBookTestApplication.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookTestApplication.Services
{
	public class FilterService : BaseService, IFilterService
    {
        #region Constructor

        private readonly IList<PersonModel> _persons;

        public FilterService(IList<PersonModel> persons) 
        {
            this._persons = persons;
        }

		#endregion

		#region Methods

		public IList<PersonModel> GetPersonsByName(string firstName, string lastName)
		{
             
                 var searchedPerson = _persons.Where(p => p.FirstName == firstName
                                         && p.LastName == lastName)
                                         .ToList();
                 return searchedPerson;
             
        }

        #endregion
    }
}
