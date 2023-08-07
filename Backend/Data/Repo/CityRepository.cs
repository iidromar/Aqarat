﻿using HSPA.Interfaces;
using HSPA.Models;
using Microsoft.EntityFrameworkCore;

namespace HSPA.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dc;
        public CityRepository(DataContext dc)
        {

            this.dc = dc;

        }

        public void AddCity(City city)
        {
             dc.Cities.Add(city);
        }
        public void DeleteCity(int CityId)
        {
            var city = dc.Cities.Find(CityId);
            dc.Cities.Remove(city);
        }

        public async Task<City> FindCity(int id)
        {
            return await dc.Cities.FindAsync(id);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dc.Cities.ToListAsync();
        }

  
    }
}
