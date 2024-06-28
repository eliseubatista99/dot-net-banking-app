﻿using DotNetBankingAppClient.Services;

namespace DotNetBankingAppClient.Dtos.Api
{
    public class BaseEndpointInputDto<T>
    {
        public required T Data { get; set; }
        public required BaseEndpointInputMetaData MetaData { get; set; }
    }
}