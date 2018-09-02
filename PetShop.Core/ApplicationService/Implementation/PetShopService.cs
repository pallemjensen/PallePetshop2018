using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Implementation
{
    public class PetShopService : IPetShopService
    {
        private readonly IPetShopRepository _petShopRepository;

        public PetShopService(IPetShopRepository petShopRepository)
        {
            _petShopRepository = petShopRepository;
        }

        public List<Pet> GetAllPets()
        {
           return _petShopRepository.ReadAllPets().ToList();
        }

        public List<Pet> GetPetsByType(string type)
        {
            List<Pet> petsByType = new List<Pet>();
            foreach (var pet in GetAllPets())
            {
                if (string.Equals(pet.Type, type, StringComparison.OrdinalIgnoreCase))
                {
                    petsByType.Add(pet);
                }
            }          
            return petsByType;
        }

        public List<Pet> GetFiveCheapestPets()
        {
            var getFiveCheapestPets = SortPetsByPrice().GetRange(0,5).ToList();

            return getFiveCheapestPets;
        }

        public List<Pet> SortPetsByPrice()
        {
            var orderedByPrice = GetAllPets().OrderBy(orderedPet => orderedPet.Price).ToList();

            return orderedByPrice;
        }      

        public Pet CreatePet(Pet pet)
        {
           return _petShopRepository.CreatePet(pet);           
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petShopRepository.UpdatePet(pet);
        }

        public Pet DeletePet(Pet pet)
        {
            return _petShopRepository.DeletePet(pet);
        }

        public Pet GetPetById(int petId)
        {
            return _petShopRepository.GetPetById(petId);
        }
    }
}
