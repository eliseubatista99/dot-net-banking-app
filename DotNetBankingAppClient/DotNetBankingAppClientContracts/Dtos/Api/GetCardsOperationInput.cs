using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBankingAppClientContracts.Dtos.Api
{
    [DataContract]
    public class GetCardsOperationInput
    {
        [DataMember]
        public required string AccountID { get; set; }
    }
}
