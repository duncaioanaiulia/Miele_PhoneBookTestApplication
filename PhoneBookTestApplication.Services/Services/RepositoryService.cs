﻿using System;
using System.Collections.Generic;
using PhoneBookTestApplication.Models;

namespace PhoneBookTestApplication.Services
{
	public class RepositoryService
	{
		#region Properties

		public List<PersonModel> Persons { get; set; }

		#endregion

		#region Constructor

		public RepositoryService()
		{
			Persons.Add(
				new PersonModel
				{
					PersonId = 1,
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
				});
		}

		#endregion

		#region Methods

		public List<PersonModel> GetAllPersons()
		{
			return Persons;
		}

		public void AddPerson(PersonModel person)
		{
			Persons.Add(person);
		}

		// TODO change the person parameter to just accept the id
		public void RemovePerson(PersonModel person)
		{
			Persons.Remove(person);
		}

		#endregion
	}
}
