using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBankingAppClientContracts.Providers
{
    public interface IAppLoggerProvider
    {
        public Task Log(string value);
    }
}
