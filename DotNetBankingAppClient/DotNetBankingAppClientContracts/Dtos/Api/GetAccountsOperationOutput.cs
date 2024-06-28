using DotNetBankingAppClientContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBankingAppClientContracts.Dtos.Api
{
    public class GetAccountsOperationOutput
    {
        public required List<AccountDTO> CheckingAccounts { get; set; }
        public required List<AccountDTO> SavingAccounts { get; set; }
    }
}
