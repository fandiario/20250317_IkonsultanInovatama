using _20250317.Models;
using System.Security.Principal;

namespace _20250317.Interfaces
{
    public interface IAccountRepository
    {
        Task AddAccountAsync(AccountModel account);
        Task<AccountModel> GetAccountByIdAsync(int id);
        Task UpdateAccountAsync(AccountModel account);
        Task DeleteAccountAsync(int id);

    }
}
