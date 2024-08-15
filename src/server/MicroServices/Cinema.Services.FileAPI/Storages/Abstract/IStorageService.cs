namespace Cinema.Services.FileAPI.Storages.Abstract
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
