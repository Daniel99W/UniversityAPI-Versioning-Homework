using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Core.Abstractions;

namespace UniversityAPI.DAL
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected UniversitateContext _universitateContext { get; set; }

        public Repository(UniversitateContext universitateContext)
        {
            _universitateContext = universitateContext;
        }

        public T Create(T obj)
        {
            return _universitateContext.Add(obj).Entity;
        }

        public void Delete(T obj)
        {
            _universitateContext.Remove(obj);
        }

        public async Task<T?> Read(int id)
        {
            return await _universitateContext.FindAsync<T>(id);
        }

        public T Update(T obj)
        {
            return _universitateContext.Update(obj).Entity;
        }

        public async Task SaveChanges()
        {
            _universitateContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _universitateContext.SaveChangesAsync();
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await _universitateContext.Set<T>().ToListAsync();
        }
    }
}
