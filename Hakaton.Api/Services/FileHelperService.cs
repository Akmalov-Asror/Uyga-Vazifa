using HakatonApi.Entities;
using HakatonApi.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;
using HakatonApi.Extensions.AddServiceFromAttribute;

namespace HakatonApi.Services;

[Scoped]
public class FileHelperService : IFileHelperService
{
    public async Task<string?> SaveFileAsync(IFormFile? file, EFileType fileTypeEnum, EFileFolder fileFolderEnum)
    {
        if(file is null ) return null;
        var fileFolder = fileFolderEnum.ToString();
        var fileType = fileTypeEnum.ToString();

        var path = Path.Combine("wwwroot", fileType, fileFolder);
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);

        var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        System.IO.File.WriteAllBytes(Path.Combine(path, fileName), ms.ToArray());

        return fileName;
    }
}
