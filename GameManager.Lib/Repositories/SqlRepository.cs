using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GameManager.Lib.Models;
using GameManager.Lib.Models.Base;

namespace GameManager.Lib.Repositories
{
    public class SQLRepository : IDataRepository
    {
        private readonly GameDbContext _context;

        public SQLRepository(GameDbContext context)
        {
            _context = context;
        }

        public List<T> GetAll<T>() where T : EntityBase
        {
            return _context.Set<T>().ToList();
        }
        
        public async Task<List<T>> GetAllAsync<T>() where T : EntityBase
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetEntity<T>(object id) where T : EntityBase
        {
            try
            {
                return _context.Set<T>().Find(id) ?? throw new Exceptions.ResourceNotFoundException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetEntityAsync<T>(object id) where T : EntityBase
        {
            try
            {
                return await _context.Set<T>().FindAsync(id) ?? throw new Exceptions.ResourceNotFoundException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T AddEntity<T>(T entity) where T : EntityBase
        {
            try
            {
                _context.Entry<T>(entity).State = EntityState.Added;
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> AddEntityAsync<T>(T entity) where T : EntityBase
        {
            try
            {
                _context.Entry<T>(entity).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T UpdateEntity<T>(T updateObj) where T : EntityBase
        {
            try
            {
                _context.Entry<T>(updateObj).State = EntityState.Modified;
                _context.SaveChanges();

                return updateObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> UpdateEntityAsync<T>(T updateObj) where T : EntityBase
        {
            try
            {
                _context.Entry<T>(updateObj).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return updateObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteEntity<T>(T deleteObj) where T : EntityBase
        {
            try
            {
                deleteObj.IsDeleted = true;
                deleteObj.DateModified = DateTime.UtcNow;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
