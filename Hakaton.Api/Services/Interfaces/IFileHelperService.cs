using HakatonApi.Entities;

namespace HakatonApi.Services.Interfaces
{
    public interface IFileHelperService
    {
        Task<string?> SaveFileAsync(IFormFile file, EFileType fileTypeEnum, EFileFolder fileFolderEnum);
    }
}
