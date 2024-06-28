using DotNetBankingAppClientContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBankingAppClientContracts.Dtos.Api
{
    public class GetInboxOperationOutput
    {
        [DataMember]

        public required List<MessageDTOGroup> GroupedMessages { get; set; }
    }

}
