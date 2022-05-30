using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain.Models.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Interfaces.Account
{
    public interface IAccountServiceBase <T> where T : class
    {
        T Add(T entity, T model);
        bool Delete(T entity);
        IEnumerable<T> GetList();
        T GetBy(int id);
        T Update(T entity, T model);
    }
}
