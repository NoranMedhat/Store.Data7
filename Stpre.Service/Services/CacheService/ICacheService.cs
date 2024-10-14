namespace Store.Service.Services.CacheServeice
{
    public interface ICacheService
    {
        Task SetCacheResponseAsync(string key, object response, TimeSpan timeToLive);
        Task<string> GetCacheResponseAsync(string key); 
    }
}
