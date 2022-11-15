using PhoneBookTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookTestApplication.Services.Interfaces
{
    public interface IFilterService
    {
        IList<PersonModel> GetPersonsByName(string firstName, string lastName);
    }
}
