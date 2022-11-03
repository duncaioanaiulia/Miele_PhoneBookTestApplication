using System;
using System.Collections.Generic;

namespace PhoneBookTestApplication.Models
{
	public class PersonModel
	{
		// mandatory
		public int PersonId { get; set; }

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
