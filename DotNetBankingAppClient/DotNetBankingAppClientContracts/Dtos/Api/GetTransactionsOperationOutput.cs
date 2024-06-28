using DotNetBankingAppClientContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBankingAppClientContracts.Dtos.Api
{
    public class GetTransactionsOperationOutput
    {
        public required List<TransactionDTO> Transactions { get; set; }
    }
}
