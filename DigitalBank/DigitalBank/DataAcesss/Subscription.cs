using DigitalBank.DataAcesss.Entities;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalBank.DataAcesss
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Account>> OnCreateAccount([Service] ITopicEventReceiver eventReceiver,
    CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Account>("AccountCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<User>> OnCreateUser([Service] ITopicEventReceiver eventReceiver,
   CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, User>("UserCreated", cancellationToken);
        }
    }
}
