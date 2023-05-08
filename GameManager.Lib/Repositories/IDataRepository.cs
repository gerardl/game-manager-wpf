using GameManager.Lib.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameManager.Lib.Repositories
{
    public interface IDataRepository
    {
        T AddEntity<T>(T entity) where T : EntityBase;
        Task<T> AddEntityAsync<T>(T entity) where T : EntityBase;
        List<T> GetAll<T>() where T : EntityBase;
        Task<List<T>> GetAllAsync<T>() where T : EntityBase;
        T GetEntity<T>(object id) where T : EntityBase;
        Task<T> GetEntityAsync<T>(object id) where T : EntityBase;
        T UpdateEntity<T>(T updateObj) where T : EntityBase;
        Task<T> UpdateEntityAsync<T>(T updateObj) where T : EntityBase;
        void DeleteEntity<T>(T deleteObj) where T : EntityBase;
        Task DeleteEntityAsync<T>(T deleteObj) where T : EntityBase;
    }
}
