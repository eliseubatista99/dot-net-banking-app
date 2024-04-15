using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBankingAppApi.Controllers;

public class DotNetBankingAppController : ControllerBase
{
    protected readonly DatabaseContext _context;
    protected readonly IConfiguration _configs;

    public DotNetBankingAppController(DatabaseContext context, IConfiguration configs)
    {
        _context = context;
        _configs = configs;
    }
}