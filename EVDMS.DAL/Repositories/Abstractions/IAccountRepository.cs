using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Core.Entities;

namespace EVDMS.DAL.Repositories.Abstractions
{
    public interface IAccountRepository
    {
        Task<Account> AddAsync(Account newAccount);
        Task<Account> GetAccountByUsername(string username);
        Task<IEnumerable<Account>> GetAccounts(string searchTerm);
        Task<Account> GetByIdAsync(Guid id);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Account account);
        Task<Account> GetByIdWithDetailsAsync(Guid id);
        Task<IEnumerable<Account>> GetDeletedAccountsAsync();
        Task RestoreAsync(Account account);

        Task<IEnumerable<Account>> GetAccountsByDealerAsync(Guid dealerId);

        Task<bool> IsUserExist(string userName);

    }
}
