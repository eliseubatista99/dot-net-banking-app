using DotNetBankingAppClientContracts.Enums;

namespace DotNetBankingAppClientContracts.Providers
{
    public interface IAppResponsiveProvider
    {
        public ResponsiveWindowSize CalculateWindowSize(int windowWidth);
        public ResponsiveWindowSize GetCurrentSize();
        public Task<int> GetWindowWidth();
        public Task ListenForResponsiveChanges(Action<ResponsiveWindowSize, int> callback);
    }
}
