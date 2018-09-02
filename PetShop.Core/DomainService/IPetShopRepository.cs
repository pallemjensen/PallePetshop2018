using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.DomainService
{
    public interface IPetShopRepository
    {
        IEnumerable<Pet> ReadAllPets();

        Pet UpdatePet(Pet pet);

        Pet DeletePet(Pet pet);

        Pet CreatePet(Pet pet);

        Pet GetPetById(int petId);
    }
}
