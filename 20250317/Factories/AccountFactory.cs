using _20250317.Interfaces;
using _20250317.Models;

namespace _20250317.Factories
{
    public class AccountFactory
    {
        private readonly IAccountRepository _repository;
        private readonly IServiceProvider _serviceProvider;

        public AccountFactory (IAccountRepository repository, IServiceProvider serviceProvider)
        {
            _repository = repository;
            _serviceProvider = serviceProvider;
        }

        public async Task AddAccount(string account)
        {
            var newAccount = new AccountModel
            {
                accountName = account
            };

            await _repository.AddAccountAsync(newAccount);
        }

        public async Task<AccountModel> GetAccount(int id) 
        {
           return await _repository.GetAccountByIdAsync(id);
        }

        public async Task EditAccountAsync(int id, string accountName)
        {
            var data = await _repository.GetAccountByIdAsync(id);

            if (data == null)
            {
                throw new Exception("Account not found.");
            }

            data.accountName = accountName; 
            await _repository.UpdateAccountAsync(data);
        }

        public async Task DeleteAccountAsync (int id)
        {
            await _repository.DeleteAccountAsync(id);
        }
    }
}
