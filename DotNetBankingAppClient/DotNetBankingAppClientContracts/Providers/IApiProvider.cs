using DotNetBankingAppClientContracts.Dtos.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBankingAppClientContracts.Providers
{
    public interface IApiProvider
    {
        public Task<BaseEndpointOutputDto<GetAccountsOperationOutput>> GetAccounts(GetAccountsOperationInput input);
        public Task<BaseEndpointOutputDto<GetCardsOperationOutput>> GetCards(GetCardsOperationInput input);
        public Task<BaseEndpointOutputDto<GetInboxOperationOutput>> GetInbox(GetInboxOperationInput input);
        public Task<BaseEndpointOutputDto<GetTransactionsOperationOutput>> GetTransactions(GetTransactionsOperationInput input);
        public Task<BaseEndpointOutputDto<SignInOperationOutput>> SignIn(SignInOperationInput input);
        public Task<BaseEndpointOutputDto<SignUpOperationOutput>> SignUp(SignUpOperationIntput input);
    }
}
