using Forum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Forum.Core.Interfaces.BaseInterface
{
    public abstract class Repository
    {
        private ForumDb _db = null;

        public virtual ForumDb Db
        {
            get
            {
                if (_db == null)
                {
                    _db = new ForumDb();
                }

                return _db;
            }
        }
    }
}
