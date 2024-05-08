using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Models;
using DotNetBankingAppApi.Models._Base;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBankingAppApi.Controllers.GetCards;

public class GetTransactionsInput
{
    public required string UserName { get; set; }
}

public class GetTransactionsOutput
{
    public required List<TransactionDTO> Transactions { get; set; }
}

[Route("GetTransactions")]
[ApiController]
public class GetTransactionsController : DotNetBankingAppController
{
    public GetTransactionsController(DatabaseContext context, IConfiguration configs) : base(context, configs)
    {

    }


    /// <summary>
    /// Get the transactions of a specific user
    /// </summary>
    /// <param name="UserName" example="user1"></param>
    /// <returns>List of transactions for the user</returns>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]

    public async Task<ActionResult<BaseEndpointOutput<GetTransactionsOutput>>> GetTransactions(BaseEndpointInput<GetTransactionsInput> input)
    {
        BaseEndpointOutput<GetTransactionsOutput> response = new BaseEndpointOutput<GetTransactionsOutput>();

        var userTransactions = new List<TransactionDTO>();
        var userAccounts = await AccountsData.GetAccountsOfUser(_context, input.Data.UserName);

        for (int i = 0; i < userAccounts.Count; i++)
        {
            var accountTransactions = await TransactionsData.GetTransactionsOfAccount(_context, userAccounts[i].AccountId);

            userTransactions.AddRange(accountTransactions);
        }

        response.SetData(new GetTransactionsOutput
        {
            Transactions = userTransactions,
        });

        return response;

    }
}