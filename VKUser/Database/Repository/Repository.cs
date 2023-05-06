using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKUser.Models;

namespace VKUser.Database.Repository
{
    public class Repository<T> where T: Entity
    {
        protected readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        
        
        public async Task<T?> GetAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        
        public List<User> GetListUsersAsync()
        {
            return _context.User.ToList();
        }

        public async Task<User?> GetAsync(String login)
        {
           // return await _context.Set<T>().FirstOrDefaultAsync(x => x.Login == login);
           return await _context.User.FirstOrDefaultAsync(x => x.Login == login);
        }
        
        public bool IsUserGroupOneAdmin()
        {
         return _context.User.Where(x => x.UserGroupId == 1).ToList().Count < 1;
        }
    }
}