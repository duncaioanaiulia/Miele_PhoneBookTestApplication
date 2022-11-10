using System;
using System.Collections.Generic;
using System.Text;
using PhoneBookTestApplication.Models;
using PhoneBookTestApplication.ViewModels.ViewModels;

namespace PhoneBookTestApplication
{
	class MainClass
	{
		private static PersonViewModel _personViewModel;

		public static void Main(string[] args)
		{
			_personViewModel = new PersonViewModel();

			var test = _personViewModel.GetAllPersons();

            Console.WriteLine("Available commands: \n list \n add (Person) \n remove (Person Name) \n command example: add Ionica|Popescu|Crisului|6|||1|0742131415");

			while (true)
			{
				Console.WriteLine("Insert command:");
				ParseCommand(Console.ReadLine());

				Console.ReadLine();
			}
		}

		private static void ParseCommand(string command)
		{
			switch (command)
			{
				case ("list"):
					{
						var persons = _personViewModel.GetAllPersons();

						foreach (var person in persons)
						{
							StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(person.FirstName);
							stringBuilder.Append(" ");
							stringBuilder.Append(person.LastName);
							stringBuilder.Append(",");


                            Console.WriteLine(stringBuilder.ToString());
						}

						break;
					}
				// TODO implement the add and remove command parsings (also make checks that the user does not enter
				// faulty data and the mandatory fields are filled in)
				default:
					break;
			}

		}
	}
}
