using System.Collections.Generic;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Static.Data.Repositories
{
    public class PetShopRepository: IPetShopRepository
    {      
        public IEnumerable<Pet> ReadAllPets()
        {
            return FakeDb.Pets;
        }

        public Pet UpdatePet(Pet pet)
        {
            Pet petToUpdate = GetPetById(pet.PetId);
            petToUpdate.PetName = pet.PetName;
            petToUpdate.Type = pet.Type;
            petToUpdate.BirthDate = pet.BirthDate;
            petToUpdate.SoldDate = pet.SoldDate;
            petToUpdate.Color = pet.Color;
            petToUpdate.PreviousOwner = pet.PreviousOwner;
            pet.Price = pet.Price;

            return pet;
        }

        public Pet DeletePet(Pet pet)
        {        
            FakeDb.Pets.Remove(pet);
            return pet;
        }

        public Pet CreatePet(Pet pet)
        {
            pet.PetId = FakeDb.PetId++;
            FakeDb.Pets.Add(pet);
            return pet;
        }

        public Pet GetPetById(int id)
        {
            foreach (var pet in FakeDb.Pets)
            {
                if (pet.PetId == id)
                {
                    return pet;
                }
            }
            return null;
        }
    }   
}
