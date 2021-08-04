using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BooksKeeperAPI.Models;

namespace BookKeeper.Service.IService
{
    
        public interface IBaseLogic<T> where T : class, IAuditableEntity
        {
            Task<IEnumerable<T>> List();
            Task<bool> Add(T entity);
            Task Delete(T entity);
            Task Update(T entity);
            Task<T> FindById(string id);
        }
    
}
