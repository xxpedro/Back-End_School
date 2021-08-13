using Microsoft.EntityFrameworkCore;
using Red_Social.Model.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Red_Social.Repository
{
    public interface IBaseRepository<T> where T:class
    {
        public  ICollection<T> GetAll();
        public T GetById(int Id);
        public void Add(T model);
        public void Update(int id,T model);
        public void Delete(int id);
        public void Save();


    }
    public class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        private readonly EscuelitaContext _Context  = null;
        private DbSet<T> table = null;

        public BaseRepository(EscuelitaContext context) 
        {
            _Context = context;
            table = _Context.Set<T>();
        }

        public void Add(T model)
        {
            table.Add(model);
            Save();
        }

        public void Delete(int id)
        {
            T exists = table.Find(id);
            table.Remove(exists);
            Save();
        }

        public ICollection<T> GetAll()
        {
            return  table.ToList();
        }

        public T GetById(int Id)
        {
            return table.Find(Id);
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        public void Update(int id,T model)
        {
            //T exists = table.Find(id);
            table.Attach(model);
            _Context.Entry(model).State = EntityState.Modified;
            Save();
        }
    }
}
