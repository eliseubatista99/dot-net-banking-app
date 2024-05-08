namespace DotNetBankingAppClient.Services
{
    public interface IAppNavigation
    {
        public void NavigateTo(string uri, bool replace = true);
    }
}
