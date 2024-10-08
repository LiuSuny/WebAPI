﻿using AutoMapper;
using PersonnalApi.Data;
using PersonnalApi.Interfaces;
using PersonnalApi.Models;
using System.Linq;

namespace PersonnalApi.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CountryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
           return _context.Countries.OrderBy(c => c.Id).ToList();

        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId)
                .Select(o => o.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerFromACountry(int countryId)
        {
            return _context.Owners.Where(p => p.Country.Id
             == countryId).ToList();
        }
    }
}
