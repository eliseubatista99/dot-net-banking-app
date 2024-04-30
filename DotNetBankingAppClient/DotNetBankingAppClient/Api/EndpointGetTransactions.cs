using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Api;

[DataContract]
public class GetTransactionsInput
{
    public required string UserName { get; set; }
}

public class GetTransactionsOutput
{
    public required List<TransactionDTO> Transactions { get; set; }
}