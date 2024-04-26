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
        public ResponsiveWindowSize CalculateWindowSize(int windowWidth);
        public ResponsiveWindowSize GetCurrentSize();
        public Task<int> GetWindowWidth();
        public Task ListenForResponsiveChanges(Action<ResponsiveWindowSize, int> callback);
    }
}
