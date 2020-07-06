using ClassroomSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE.Abstractions
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account GetAccountByAccountId(Guid AccountId);
        Account Add(Account itemToAdd);
        bool Delete(Account itemToDelete);
        Account Update(Account itemToUpdate);
    }
}