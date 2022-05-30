using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain.Models.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Interfaces.Account
{
    public interface IAccountServiceBase <A, B, C, D, E, F> where A : class where B : class where D : class where E : class where F : class
    {
        F Add(A model, B appUser);
        bool Delete(C entity);
        void Update(D model, C id);
        bool Check(E user, C id);
    }
}
