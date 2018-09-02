using PetShop.Core.Entities;
using System.Collections.Generic;


namespace PetShop.Core.ApplicationService
{
    public interface IPetShopService
    {
        List<Pet> GetAllPets();

        List<Pet> GetPetsByType(string type);

        List<Pet> GetFiveCheapestPets();

        List<Pet> SortPetsByPrice();

        Pet CreatePet(Pet pet);

        Pet UpdatePet(Pet pet);

        Pet DeletePet(Pet pet);

        Pet GetPetById(int petId);
    }
}
