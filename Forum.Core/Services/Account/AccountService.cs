using Forum.Core.Interfaces.Account;
using Forum.Domain.Models.Identities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Services.Account
{
    public class AccountService : IAccountService
    {
        private UserManager<WebAppUser> _usrManger;

        public AccountService(UserManager<WebAppUser> usrManger)
        {
            this._usrManger = usrManger;
        }



        public WebAppUser Add(WebAppUser entity, WebAppUser model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(WebAppUser entity)
        {
            throw new NotImplementedException();
        }

        public WebAppUser GetBy(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WebAppUser> GetList()
        {
            throw new NotImplementedException();
        }

        public WebAppUser Update(WebAppUser entity, WebAppUser model)
        {
            throw new NotImplementedException();
        }
    }
}
