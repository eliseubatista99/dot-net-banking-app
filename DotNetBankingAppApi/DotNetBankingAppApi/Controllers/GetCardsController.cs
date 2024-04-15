﻿using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBankingAppApi.Controllers.GetCards;

public class GetCardsInput
{
    public required string AccountID { get; set; }
}

public class GetCardsOutput
{
    public required List<CardDTO> Cards { get; set; }
}

[Route("GetCards")]
[ApiController]
public class GetCardsController : DotNetBankingAppController
{
    public GetCardsController(DatabaseContext context, IConfiguration configs): base(context, configs)
    {
        
    }


    /// <summary>
    /// Get the cards of a specific account
    /// </summary>
    /// <param name="accountId" example="123412341234"></param>
    /// <returns>List of cards for the account</returns>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]

    public async Task<ActionResult<ApiResponse<GetCardsOutput>>> GetCards(GetCardsInput input)
    {
        ApiResponse<GetCardsOutput> response = new ApiResponse<GetCardsOutput>();

        var cards = await CardsData.GetCardsOfAccounts(_context, input.AccountID);

        response.SetData(new GetCardsOutput
        {
            Cards = cards,
        });

        return response;

    }
}