using DigitalBank.DataAcesss.Entities;
using DigitalBank.DataAcesss.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.DataAcesss
{
    public class Mutation
    {
        public async Task<Account> TakeValueAwayByAccountNumber([Service] AccountRepository accountRepository,
    [Service] ITopicEventSender eventSender, int accountNumber, int takeAwayValue)
        {
            Account gottenAccount = accountRepository.TakeValueAwayByAccountNumber(accountNumber, takeAwayValue);
            await eventSender.SendAsync("ChangedAccountValue", gottenAccount);
            return gottenAccount;
        }
    }
}
