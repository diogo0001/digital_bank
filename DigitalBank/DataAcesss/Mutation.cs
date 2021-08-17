using DigitalBank.DataAcesss.Entities;
using DigitalBank.DataAcesss.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace DigitalBank.DataAcesss
{
    public class Mutation
    {
        public async Task<Account> Sacar([Service] AccountRepository accountRepository,
    [Service] ITopicEventSender eventSender, int accountNumber, int takeAwayValue)
        {
            Account gottenAccount = await accountRepository.TakeValueAwayByAccountNumber(accountNumber, takeAwayValue);
            await eventSender.SendAsync("SubtractedAccountValue", gottenAccount);
            return gottenAccount;
        }

        public async Task<Account> Depositar([Service] AccountRepository accountRepository,
    [Service] ITopicEventSender eventSender, int accountNumber, int addValue)
        {
            Account gottenAccount = await  accountRepository.DepositValueByAccountNumber(accountNumber, addValue);
            await eventSender.SendAsync("AddedAccountValue", gottenAccount);
            return gottenAccount;
        }
    }
}
