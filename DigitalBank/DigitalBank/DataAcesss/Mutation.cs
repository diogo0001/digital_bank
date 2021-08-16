using DigitalBank.DataAcesss.Entities;
using DigitalBank.DataAcesss.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace DigitalBank.DataAcesss
{
    public class Mutation
    {
        public async Task<Account> TakeValueAwayByAccountNumber([Service] AccountRepository accountRepository,
    [Service] ITopicEventSender eventSender, int accountNumber, int takeAwayValue)
        {
            Account gottenAccount = accountRepository.TakeValueAwayByAccountNumber(accountNumber, takeAwayValue);
            await eventSender.SendAsync("SubtractedAccountValue", gottenAccount);
            return gottenAccount;
        }

        public async Task<Account> DepositValueByAccountNumber([Service] AccountRepository accountRepository,
    [Service] ITopicEventSender eventSender, int accountNumber, int takeAwayValue)
        {
            Account gottenAccount = accountRepository.DepositValueByAccountNumber(accountNumber, takeAwayValue);
            await eventSender.SendAsync("AddedAccountValue", gottenAccount);
            return gottenAccount;
        }
    }
}
