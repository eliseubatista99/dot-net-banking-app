using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBankingAppApi.Controllers;

public class ServiceGetAccountsInput
{
    public required string UserName { get; set; }
}

public class ServiceGetAccountsOutput
{
    public required List<AccountDTO> CheckingAccounts { get; set; }
    public required List<AccountDTO> SavingAccounts { get; set; }
}

[Route("GetAccounts")]
[ApiController]
public class GetAccountsController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IConfiguration _configs;

    public GetAccountsController(DatabaseContext context, IConfiguration configs)
    {
        _context = context;
        _configs = configs;
    }


    /// <summary>
    /// Get the accounts of a specific user
    /// </summary>
    /// <param name="username" example="user"></param>
    /// <returns>List of checking accounts and saving accounts</returns>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]

    public async Task<ActionResult<ApiResponse<ServiceGetAccountsOutput>>> GetAccounts(ServiceGetAccountsInput input)
    {
        ApiResponse<ServiceGetAccountsOutput> response = new ApiResponse<ServiceGetAccountsOutput>();

        var accounts = await AccountsData.GetAccountsOfUser(_context, input.UserName);

        var checkingAccounts = accounts.Where(a => a.AccountType == AccountType.Checking).ToList();
        var savinbgsAccounts = accounts.Where(a => a.AccountType == AccountType.Savings).ToList();


        response.SetData(new ServiceGetAccountsOutput
        {
            CheckingAccounts = checkingAccounts,
            SavingAccounts = savinbgsAccounts,
        });

        return response;

    }
}