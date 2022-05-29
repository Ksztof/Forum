using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Interfaces.BaseInterface
{
    public interface IRepository<T> where T : class //musi być klasą 
    {
        T GetBy(int id);
        T Add(T entity);
        bool Delete(T entity);
        T Update(T entity);
        IEnumerable<T> GetList();
    }

    /* public interface IRepositoryAsync<T> where T : class
     {
         Task<T> GetBy(int id);
         Task<IEnumerable<T>> GetList();
     }*/

    /*public class Test
    {
        public int Test1(int id, string text)
        {
            return id;
        }

        public T Test2<T>(object obj) where T : class
        {
            return (T)obj;
        }

        public IEnumerable<T> Test3<T>(object obj) where T:class
        {
            List<T> list = new List<T>();
            list.Add((T)obj);

            return list;
        }
    }*/
}
