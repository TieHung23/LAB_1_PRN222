using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using EVDMS.DAL.Repositories.Abstractions;
using BCrypt.Net;

namespace EVDMS.BLL.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Login(string username, string password)
        {
            var account = await _accountRepository.GetAccountByUsername(username);

            if (account == null)
            {
                return null;
            }
           
            bool isPasswordVerified = BCrypt.Net.BCrypt.Verify(password, account.HashedPassword);

            if (isPasswordVerified)
            {
                return account; // Mật khẩu chính xác, đăng nhập thành công
            }

            return null; // Mật khẩu sai, đăng nhập thất bại
        }
    }
}
