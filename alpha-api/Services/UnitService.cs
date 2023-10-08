﻿using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Services
{
    
    // intermediary service, when this grows with more complex relations and fetches a service will help

    public class UnitService : IUnitService
    {
        private readonly IRepository<Unit> repository;

        public UnitService(IRepository<Unit> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Unit>> GetAllAsync()
        {
            return (await this.repository.GetAllAsync()).ToList();
        }

        public async Task<Unit> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<Unit> AddAsync(Unit unit)
        {
            var u = await repository.CreateAsync(unit);
            return u;
        }

        public async Task<Unit> UpdateAsync(Unit unit) 
        {
            try
            {
                var u = await repository.UpdateAsync(unit);
                return u;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }
            
        public async Task<bool> DeleteAsync(int id) 
        { 
            return await repository.DeleteAsync(id); 
        }


    }
}