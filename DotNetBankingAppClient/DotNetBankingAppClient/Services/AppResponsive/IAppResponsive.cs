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
        public Task ListenForResponsiveChanges(Action<ResponsiveWindowSize> callback);
    }
}
