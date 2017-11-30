using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using PhotoShare.Data;
using System.Linq;
using System;

namespace PhotoShare.Services
{
    public class TownService : ITownService
    {
        private readonly PhotoShareContext context;

        public TownService(PhotoShareContext context)
        {
            this.context = context;
        }

        public Town ByName(string name)
        {
            return context.Towns
                .SingleOrDefault(t => t.Name == name);
        }

        public Town Create(string townName, string countryName)
        {
            var town = this.ByName(townName);

            if (town != null)
            {
                throw new ArgumentException($"Town {townName} was already added!");
            }

            town = new Town
            {
                Name = townName,
                Country = countryName
            };

            context.Towns.Add(town);

            context.SaveChanges();

            return town;
        }
    }
}
