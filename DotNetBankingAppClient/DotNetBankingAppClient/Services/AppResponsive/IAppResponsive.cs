namespace DotNetBankingAppClient.Services
{
    public enum ResponsiveWindowSize
    {
        Mobile,
        Tablet,
        Desktop,
    }

    public interface IAppResponsive
    {
        public ResponsiveWindowSize GetCurrentSize();
        public Task ListenForResponsiveChanges(Action<ResponsiveWindowSize> callback);
    }
}
