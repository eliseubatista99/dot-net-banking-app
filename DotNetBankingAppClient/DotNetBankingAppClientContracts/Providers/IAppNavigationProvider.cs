namespace DotNetBankingAppClientContracts.Providers
{
    public interface IAppNavigationProvider
    {
        public void NavigateTo(string uri, bool replace = true);
    }
}
