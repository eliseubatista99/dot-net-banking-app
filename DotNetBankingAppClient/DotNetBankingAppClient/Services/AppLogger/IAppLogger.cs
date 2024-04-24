namespace DotNetBankingAppClient.Services
{
    public interface IAppLogger
    {
        public Task Log(object value);
    }
}
