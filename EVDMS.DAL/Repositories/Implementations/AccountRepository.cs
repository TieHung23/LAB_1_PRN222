using EVDMS.Core.Entities;
using EVDMS.DAL.Database;
using EVDMS.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace EVDMS.DAL.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountByUsername(string username)
        {
            return await _context.Accounts
                                  .Include(a => a.Role)
                                  .FirstOrDefaultAsync(a => a.UserName.Equals(username));
        }

        public async Task<IEnumerable<Account>> GetAccounts(string searchTerm)
        {
          
            var query = _context.Accounts
                                .Where(a => !a.IsDeleted)
                                .Include(a => a.Role)
                                .Include(a => a.Dealer)
                                .AsQueryable();

            
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(a => a.UserName.Contains(searchTerm) || a.FullName.Contains(searchTerm));
            }

            return await query.OrderBy(a => a.UserName).ToListAsync();
        }


        public async Task<Account> AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Account account)
        {
            account.IsDeleted = true;
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
        public async Task<Account> GetByIdWithDetailsAsync(Guid id)
        {
            return await _context.Accounts
                                 .Include(a => a.Role)
                                 .Include(a => a.Dealer)
                                 .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Account>> GetDeletedAccountsAsync()
        {
            return await _context.Accounts
                                 .Where(a => a.IsDeleted) 
                                 .Include(a => a.Role)
                                 .Include(a => a.Dealer)
                                 .ToListAsync();
        }

        public async Task RestoreAsync(Account account)
        {
            account.IsDeleted = false; 
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}