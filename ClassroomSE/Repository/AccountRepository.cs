using ClassroomSE.Abstractions;
using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ClassroomContext dbContext) : base(dbContext)
        {

        }
        public Account GetAccountByAccountId(Guid accountId)
        {
            var account = dbContext.Accounts
                         .Where(c => c.AccountID == accountId)
                         .SingleOrDefault();
            return account;
        }
    }
}