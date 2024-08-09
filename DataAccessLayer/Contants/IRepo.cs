﻿namespace DataAccessLayer.Contacts
{
    public interface IRepo<T>
    {
        protected void Delete(T entity);
        protected void Update(T entity,int id);
        protected T GetById(int id);
        protected IEnumerable<T> GetAll();

        protected void Create(T entity);
    }
}
