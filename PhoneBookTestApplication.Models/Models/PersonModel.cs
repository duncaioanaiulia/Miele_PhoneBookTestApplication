using System;
using System.Collections.Generic;
using PhoneBookTestApplication;

namespace PhoneBookTestApplication.Models
{
	public class PersonModel
	{
		public PersonModel()
		{
            PersonId++;
        }

		private static int personID = 0;

		// mandatory
		public int PersonId { 
			get => personID;
			private set => personID++; 
		}

		// mandatory
		public string FirstName { get; set; }

		// mandatory
		public string LastName { get; set; }

		// at least one is mandatory
		public List<AddressModel> Addresses { get; set; }

		// not mandatory
		//TODO Birthdate
	}
}
