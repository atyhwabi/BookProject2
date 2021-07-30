using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BooksKeeperAPI.Infrustructure;
using BooksKeeperAPI.Models;
using System.Diagnostics;
using BooksKeeperAPI.Service.IService;

namespace BooksKeeperAPI.Service
{
    public class BaseLogic<T> : IBaseLogic<T> where T : class, IAuditableEntity
    {
        public static readonly IBaseLogic<T> Instance = new BaseLogic<T>();

        public async Task<IEnumerable<T>> List()
        {
            try
            {

                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    return await repo.GetAllAsync<T>();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> Add(T entity)
        {
            try
            {

                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    repo.Create<T>(entity);
                    return await db.SaveChangesAsync() == 0 ? false : true;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return false;
            }
        }

        public async Task Delete(T entity)
        {
            try
            {
                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    repo.Delete<T>(entity);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    repo.Update<T>(entity);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);

            }
        }
        public async Task<T> FindById(string id)
        {
            try
            {
                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    var temp = await repo.GetByIdAsync<T>(id);
                    if (temp.IsDeleted == true)
                    {
                        return null;
                    }
                    return temp;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return null;
            }
        }

        public bool ValidateModel(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return false;
                }
                if (entity.Id == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return false;
            }
        }

    }
}