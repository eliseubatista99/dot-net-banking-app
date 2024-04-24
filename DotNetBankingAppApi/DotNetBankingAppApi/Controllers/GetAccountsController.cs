using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Models;
using DotNetBankingAppApi.Models._Base;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBankingAppApi.Controllers.GetAccounts;

public class GetAccountsInput
{
    public required string UserName { get; set; }
}

public class GetAccountsOutput
{
    public required List<AccountDTO> CheckingAccounts { get; set; }
    public required List<AccountDTO> SavingAccounts { get; set; }
}

[Route("GetAccounts")]
[ApiController]
public class GetAccountsController : DotNetBankingAppController
{
    public GetAccountsController(DatabaseContext context, IConfiguration configs) : base(context, configs)
    {

    }


    /// <summary>
    /// Get the accounts of a specific user
    /// </summary>
    /// <param name="username" example="user"></param>
    /// <returns>List of checking accounts and saving accounts</returns>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]

    public async Task<ActionResult<BaseEndpointOutput<GetAccountsOutput>>> GetAccounts(BaseEndpointInput<GetAccountsInput> input)
    {
        BaseEndpointOutput<GetAccountsOutput> response = new BaseEndpointOutput<GetAccountsOutput>();

        var accounts = await AccountsData.GetAccountsOfUser(_context, input.Data.UserName);

        var checkingAccounts = accounts.Where(a => a.AccountType == AccountType.Checking).ToList();
        var savinbgsAccounts = accounts.Where(a => a.AccountType == AccountType.Savings).ToList();


        response.SetData(new GetAccountsOutput
        {
            CheckingAccounts = checkingAccounts,
            SavingAccounts = savinbgsAccounts,
        });

        return response;

    }
}