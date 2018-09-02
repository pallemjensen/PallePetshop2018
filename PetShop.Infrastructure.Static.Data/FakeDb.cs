using System;
using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Static.Data
{
    public static class FakeDb
    {
       
        public static int PetId = 1;
        public static List<Pet> Pets = new List<Pet>();      

        public static void InitData()
        {
            var pet1 = new Pet()
            {
                PetId = PetId++,
                PetName = "Fluffy",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(10)),
                Color = "White",
                PreviousOwner = "Hans",
                Price = 123,
                Type = "Dog"               

            };
            var pet2 = new Pet()
            {
                PetId = PetId++,
                PetName = "Buffy",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(20)),
                Color = "Black",
                PreviousOwner = "Peter",
                Price = 234,
                Type = "Dog"

            };
            var pet3 = new Pet()
            {
                PetId = PetId++,
                PetName = "Bongo",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(40)),
                Color = "Grey",
                PreviousOwner = "Bente",
                Price = 9236,
                Type = "Goat"

            };
            var pet4 = new Pet()
            {
                PetId = PetId++,
                PetName = "Titan",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(30)),
                Color = "Striped",
                PreviousOwner = "Finn",
                Price = 549,
                Type = "Horse"
            };
            var pet5 = new Pet()
            {
                PetId = PetId++,
                PetName = "Venus",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(50)),
                Color = "Yellow",
                PreviousOwner = "Jasper",
                Price = 2356,
                Type = "Bird"
            };
            var pet6 = new Pet()
            {
                PetId = PetId++,
                PetName = "Moron",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(5)),
                Color = "Brown",
                PreviousOwner = "Sophie",
                Price = 12,
                Type = "Cat"
            };
            var pet7 = new Pet()
            {
                PetId = PetId++,
                PetName = "Derp",
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Today.Add(TimeSpan.FromDays(100)),
                Color = "Purple",
                PreviousOwner = "Carrie",
                Price = 56,
                Type = "Cat"
            };
            Pets.Add(pet1);
            Pets.Add(pet2);
            Pets.Add(pet3);
            Pets.Add(pet4);
            Pets.Add(pet5);
            Pets.Add(pet6);
            Pets.Add(pet7);
        }
    }
}
