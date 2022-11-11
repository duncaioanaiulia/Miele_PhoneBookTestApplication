using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneBookTestApplication.Models;
using PhoneBookTestApplication.ViewModels.ViewModels;

namespace PhoneBookTestApplication
{
	class MainClass
	{
		private static PersonViewModel _personViewModel;

		private const string commandList = "list";
		private const string commandAdd = "add";
		private const string commandRemove = "remove";

        public static void Main(string[] args)
		{
			_personViewModel = new PersonViewModel();

			var test = _personViewModel.GetAllPersons();
				//  "Available commands: \n  {0} \n {1} (Person) \n {2} (Person Name) \n command example: add Ionica|Popescu|Crisului|6|||1|0742131415"
            
            Console.WriteLine(string.Format(
				  "Available commands: \n  {0}\n {1}\n {2}"
				  , commandList, commandAdd, commandRemove));

			while (true)
			{
				Console.WriteLine("Insert command:");
				ParseCommand(Console.ReadLine());

				Console.ReadLine();
			}
		}

		private static void ParseCommand(string command)
		{

            var persons = _personViewModel.GetAllPersons();

            switch (command)
			{
				case (commandList):
					{
						foreach (var person in persons)
						{
							StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(person.PersonId);
                            stringBuilder.Append(" ");
                            stringBuilder.Append(person.FirstName);
							stringBuilder.Append(" ");
							stringBuilder.Append(person.LastName);
							stringBuilder.Append(",");
                            Console.WriteLine(stringBuilder.ToString());
						}

						break;
					}
                case (commandAdd):
                    {
                        Console.WriteLine("Insert example: Ionica|Popescu|Crisului|6|||1|0742131415");
                        ParseAddCommand(Console.ReadLine());
                        break;
                    }
                case (commandRemove):
                    {
                        Console.WriteLine("Insert name:");
                        ParseRemoveCommand(Console.ReadLine(), persons);

                        break;
                    }
                default:
					break;
			}
		}

		private static void ParseAddCommand(string command)
		{
            List<string> detailsPerson = command.Split("|").ToList();
			if (detailsPerson is null)
				return;

			_personViewModel.Person =
				new PersonModel()
				{
					FirstName = detailsPerson.ElementAt(0),
					LastName = detailsPerson.ElementAt(1)
                };

			_personViewModel.Person.Addresses.Add(new AddressModel()
			{
				StreetName = detailsPerson.ElementAt(2),
				StreetNumber = int.Parse(detailsPerson.ElementAt(3)),
				Country = detailsPerson.ElementAt(4)


				//PhoneNumbers
			});

            _personViewModel.AddPerson();
        }

		private static void ParseRemoveCommand(string command, IList<PersonModel> persons)
		{
			var removePerson = persons.FirstOrDefault(person
				=> command.Contains(person.FirstName) 
				&& command.Contains(person.LastName));

			if (removePerson is null)
				return;

			_personViewModel.RemovePerson(removePerson.PersonId);
        }
	}
}
