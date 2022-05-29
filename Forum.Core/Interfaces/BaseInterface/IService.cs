using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Interfaces.BaseInterface
{
    public interface IService<T> where T : class
    {
        T Add(T entity);
        bool Delete(T entity);
        IEnumerable<T> GetList();
        T GetBy(int id);
        T Update(T entity);

    }
}
