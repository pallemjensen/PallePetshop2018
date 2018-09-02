using System;
using System.Collections.Generic;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using PetShop.Infrastructure.Static.Data;

namespace PetShop
{
    public class Printer : IPrinter
    {
        

        //enum choice { PrintAllPets, AddPet, DeletePet, UpdatePet, SearchPetByType, SortPetsByPrice, ListFiveCheapestPets  };
        private readonly IPetShopService _petShopService;

        public Printer(IPetShopService petShopService)
        {
            _petShopService = petShopService;
        }


        private readonly string[] _menuItems =
        {
            "List all pets",
            "Create pet",
            "Delete pet",
            "Update pet",
            "Search pet by type",
            "Sort pets by price",
            "List 5 cheapest pets"
        };

        public void ChooseMenuItem()
        {
            Console.WriteLine("Welcome to the petshop!");
            Console.WriteLine("Please choose an option from the menu:");

            for (var i = 0; i < _menuItems.Length; i++) Console.WriteLine($"{i + 1} : {_menuItems[i]}");

            string selection = Console.ReadLine();            
            
            if (int.TryParse(selection, out int verifiedChoice))
            {
                switch (verifiedChoice)
                {
                    case 1:
                        PrintPetList();
                        break;

                    case 2:
                        CreatePet();
                        break;

                    case 3:
                        DeletePet();
                        break;

                    case 4:
                        UpdatePet();
                        break;

                    case 5:
                        GetPetsByType();
                        break;

                    case 6:
                        SortPetsByPrice();
                        break;

                    case 7:
                        ListFiveCheapestPets();
                        break;
                }
                Console.WriteLine("");
                ChooseMenuItem();
            }          
            Console.ReadLine();
        }

        private void PrintPetList()
        {
            Console.Clear();
            Console.WriteLine("You have chosen option 1 - print all pets:");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($"There are now {FakeDb.Pets.Count} pets on your list.");
            Console.WriteLine("");
            var pets = _petShopService.GetAllPets();

            PrintAllPets(pets);
        }

        private void CreatePet()
        {
            Console.Clear();

            Console.WriteLine("You have chosen option 2 : Create pet.");
            Console.WriteLine("\n");

            Console.WriteLine("Input name of the pet:");
            var newPetName = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Input type of pet. This can be any type you desire.");
            var newPetType = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Input birthday of the pet. Date can be written as 15/03/2010 or 15-03-2010.");
            var petBirthday = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Input the date when the pet was sold. Date can be written as 15/03/2010 or 15-03-2010.");
            var petSoldDate = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Input color of the pet.");
            var newPetColor = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Input name of the previous owner of the pet:");
            var newPetPreviousOwner = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Input the price of the pet:");
            var newPetPrice = Console.ReadLine();
            Console.WriteLine("\n");

            Pet pet = new Pet();
            pet.PetName = newPetName;
            pet.Type = newPetType;
            pet.BirthDate = DateTime.Parse(petBirthday);
            pet.SoldDate = DateTime.Parse(petSoldDate);
            pet.Color = newPetColor;
            pet.PreviousOwner = newPetPreviousOwner;
            pet.Price = Double.Parse(newPetPrice);

            Pet createdPet = _petShopService.CreatePet(pet);
            Console.Clear();
            Console.WriteLine("You have created this new pet. Please take good care of it!");
            Console.WriteLine("");
            PrintSinglePet(createdPet);
            Console.WriteLine($"There are now {FakeDb.Pets.Count} pets on your list.");
            Console.WriteLine("");
        }

        private void DeletePet()
        {
            Console.Clear();

            Console.WriteLine("You chose option 3 : Delete pet.");
            Console.WriteLine("");
            Console.WriteLine("Input the pet-id-number for the pet you want to delete?");
            int petToBeDeleted = int.Parse(Console.ReadLine());
            Pet pet = _petShopService.GetPetById(petToBeDeleted);
            Pet deletedPet = _petShopService.DeletePet(pet);
            Console.WriteLine("");
            Console.WriteLine($"Pet with id: {deletedPet.PetId} was deleted.");
            Console.WriteLine("");
            Console.WriteLine($"There are now {FakeDb.Pets.Count} pets on your list.");
            Console.WriteLine("");
        }

        private void UpdatePet()
        {
            Console.WriteLine("You have chosen option 4 - update pet information");
            Console.WriteLine("");
            Console.WriteLine("Choose the id number for the pet you want to update:");
            int updatePetId = int.Parse(Console.ReadLine());
            Pet pet = _petShopService.GetPetById(updatePetId);

            Console.WriteLine("");
            Console.WriteLine("Input a new name for the pet in question:");
            string newPetName = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Input a new type for the pet in question:");
            string newPetType = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Input a new date for the pet's birthday:");
            DateTime newPetBirthday = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Input a new date for when the pet was sold:");
            DateTime newPetSoldDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Input a new color for the in question:");
            string newPetColor = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Inout a new name for the previous owner:");
            string newPreviousOwnerName = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Input a new price for the pet in question:");
            int newPetPrice = Convert.ToInt32(Console.ReadLine());  //using convert or int.parse whatever (unless you need a big int or want to save space)
            Console.WriteLine("");

            pet.PetId = pet.PetId;
            pet.PetName = newPetName;
            pet.Type = newPetType;
            pet.BirthDate = newPetBirthday;
            pet.SoldDate = newPetSoldDate;
            pet.Color = newPetColor;
            pet.PreviousOwner = newPreviousOwnerName;
            pet.Price = newPetPrice;

            Pet updatedPet = _petShopService.UpdatePet(pet);
            Console.WriteLine($"Pet with id: {pet.PetId} was updated and now has the following stats:");
            Console.WriteLine("");
            PrintSinglePet(updatedPet);
            Console.WriteLine("");
        }

        private void GetPetsByType()
        {
            Console.WriteLine("You have chosen option 5 - get pets by type.");
            Console.WriteLine("");
            Console.WriteLine("What type of pet are you searching for?");

            string petByType = Console.ReadLine();

            List<Pet> returnedPetsByType = _petShopService.GetPetsByType(petByType);

            Console.WriteLine("");
            Console.WriteLine($"There were {returnedPetsByType.Count} results. Here they are:");
            Console.WriteLine("");

            PrintAllPets(returnedPetsByType);

            Console.WriteLine("");
        }

        public void SortPetsByPrice()
        {
            Console.WriteLine("You chose option 6 - show pets by price:");
            Console.WriteLine("");
            var petsByPrice = _petShopService.SortPetsByPrice();
            PrintAllPets(petsByPrice);
        }

        private void ListFiveCheapestPets()
        {
            Console.WriteLine("You have chosen option 7 - show the five cheapest pet.");
            Console.WriteLine("");
            var fiveCheapestPets = _petShopService.GetFiveCheapestPets();
            PrintAllPets(fiveCheapestPets);
        }

        public void PrintSinglePet(Pet pet)
        {
            Console.WriteLine($"Id: {pet.PetId}");
            Console.WriteLine($"Name: {pet.PetName}");
            Console.WriteLine($"Pet type: {pet.Type}");
            Console.WriteLine($"Color: {pet.Color}");
            Console.WriteLine($"Birthdate: {pet.BirthDate}");
            Console.WriteLine($"Sold at date: {pet.SoldDate}");
            Console.WriteLine($"Previous owner: {pet.PreviousOwner}");
            Console.WriteLine($"Pet price: {pet.Price} kroner.");
            Console.WriteLine("\n");
        }

        public void PrintAllPets(List<Pet> pets)
        {
            foreach (var pet in pets)
            {
                PrintSinglePet(pet);
            }
        }
    }
}

