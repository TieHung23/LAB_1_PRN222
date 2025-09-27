using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Core.Entities;

namespace EVDMS.BLL.Services.Abstractions
{
    public interface IAccountService
    {
        Task<Account> Login(string username, string password);
        Task<IEnumerable<Account>> GetAccounts(string searchTerm);
        Task<Account> CreateAccountAsync(Account newAccount);
        Task<Account> GetAccountByIdAsync(Guid id);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(Guid id);
        Task<Account> GetAccountByIdWithDetailsAsync(Guid id);
        Task<IEnumerable<Account>> GetDeletedAccountsAsync();
        Task RestoreAccountAsync(Guid id);
        Task<bool> IsUserNameExist(string userName);
    }
}
