using Red_Social.Repository;
using System;
using System.Collections.Generic;

namespace Red_Social.Services
{
    public interface IBaseService <T> where T : class 
    {
        public ICollection<T> GetAll();
        public void Save(T Model);
        public T GetById(int id);
        public void Update(int id, T Model);
        public void Delete(int id);
    }
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository) 
        {
            _baseRepository = baseRepository;
        }

        public virtual void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public virtual  ICollection<T> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public virtual  T GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public virtual  void Save(T Model)
        {
            _baseRepository.Add(Model);
        }

        public virtual void Update(int id, T Model)
        {
            _baseRepository.Update(id,Model);
        }
    }
}
