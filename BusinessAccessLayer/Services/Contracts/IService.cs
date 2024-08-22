using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Contracts
{
    public interface IService<T> where T : class
    {
        public void Create(T _object);
        public void Delete(int Id);
        public void Update(T _object);
        public IEnumerable<T> GetAll();

        public T Get(int id);
    }
}
