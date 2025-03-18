
using _20250317.Data;
using _20250317.Interfaces;
using _20250317.Models;
using Microsoft.EntityFrameworkCore;

namespace _20250317.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDBContext _context;

        public AccountRepository(ApplicationDBContext context) { 
            _context = context;
        }

        public async Task AddAccountAsync(AccountModel account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task<AccountModel> GetAccountByIdAsync (int id)
        {
            return await _context.Accounts.Where(d => d.id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAccountAsync (AccountModel account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync (int id)
        {
            var data = await GetAccountByIdAsync(id);
            if (data != null) 
            {
                _context.Accounts.Remove(data);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Account not found.");
            }

        }
    }
}
