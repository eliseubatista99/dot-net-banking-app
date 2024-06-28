﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBankingAppClientContracts.Dtos.Api
{
    [DataContract]
    public class SignInOperationInput
    {
        [DataMember]
        public required string UserName { get; set; }
        [DataMember]
        public required string Password { get; set; }
    }

}