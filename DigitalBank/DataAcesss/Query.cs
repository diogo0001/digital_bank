using DigitalBank.DataAcesss.Entities;
using DigitalBank.DataAcesss.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.DataAcesss
{
    public class Query
    {
        public List<User> Usuarios([Service] UserRepository userRepository) => userRepository.GetUsers();

        public List<User> UsuariosContas([Service] UserRepository userRepository) =>
            userRepository.GetUsersWithAccounts();

        public List<Account> Contas([Service] AccountRepository accountRepository) =>
            accountRepository.GetAllAccounts();

        public async Task<Account> DadosDaConta([Service] AccountRepository accountRepository,
            [Service] ITopicEventSender eventSender, int accountNumber)
        {
            Account gottenAccount = accountRepository.GetAccountDataByAccountNumber(accountNumber);
            await eventSender.SendAsync("ReturnedAccount", gottenAccount);
            return gottenAccount;
        }
    }
}
