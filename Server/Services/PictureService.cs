using Microsoft.EntityFrameworkCore;
using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.Responses;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Services
{
    public class PictureService : IPictureService
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper<Picture, PictureViewModel> _mapper;

        public PictureService(
            IWebHostEnvironment hostingEnvironment,
            ApplicationDbContext dbContext,
            IMapper<Picture, PictureViewModel> mapper)
        {
            _hostingEnvironment = hostingEnvironment;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<PictureViewModel> GetAllPictures()
        {
            // todo
            var pics = _dbContext.Pictures.ToList();
            var result = new List<PictureViewModel>();
            foreach (var picture in pics)
            {
                result.Add(_mapper.GetMappedResult(picture));
            }
            return result;
        }

        public async Task<List<FileUploadResponse>> AddPicture(IEnumerable<IFormFile> files, int smartphoneId)
        {
            var file = files.First();
            var response = await ProcessFile(file);
            if (response == null || !response.Uploaded) return new List<FileUploadResponse>();
            var smartphone = _dbContext.Smartphones.FirstOrDefault(x => x.SmartphoneId.Equals(smartphoneId));
            if (smartphone == null) return new();
            _dbContext.Pictures.Add(new Picture
            {
                Title = file.FileName,
                PathToData = Path.Combine("Content\\Pictures", _hostingEnvironment.EnvironmentName, file.FileName),
                SmartphoneId = smartphoneId,
                Smartphone = smartphone
            });
            await _dbContext.SaveChangesAsync();
            return new List<FileUploadResponse>() { response };
        }

        public PictureViewModel GetPictureById(int pictureId)
        {
            var pic = _dbContext.Pictures.FirstOrDefault(x => x.PictureId == pictureId);
            if (pic != null)
            {
                return _mapper.GetMappedResult(pic);
            }
            return new();
        }

        public List<PictureViewModel> GetPicturesForSmartphone(int smartphoneId)
        {
            var pics = _dbContext.Pictures.Where(x => x.SmartphoneId == smartphoneId);
            if (pics == null)
            {
                return new();
            }
            var result = new List<PictureViewModel>();
            foreach (var picture in pics)
            {
                result.Add(_mapper.GetMappedResult(picture));
            }
            return result;
        }

        public async Task<List<FileUploadResponse>> UpdatePicture(IEnumerable<IFormFile> files, int smartphoneId, int pictureId)
        {
            var smartphone = _dbContext.Smartphones.FirstOrDefault(x => x.SmartphoneId.Equals(smartphoneId));
            if (smartphone == null)
            {
                return new List<FileUploadResponse>();
            }

            var file = files.First();
            var picToUpdate = _dbContext.Pictures.FirstOrDefault(x => x.PictureId.Equals(pictureId));
            if (picToUpdate == null)
            {
                return await AddPicture(new List<IFormFile>() { file }, smartphoneId);
            }

            DeleteFile(Path.Combine(_hostingEnvironment.WebRootPath, picToUpdate.PathToData));

            var response = await ProcessFile(file);
            if (response == null || !response.Uploaded) return new List<FileUploadResponse>();
            picToUpdate.SmartphoneId = smartphoneId;
            picToUpdate.PathToData = Path.Combine("Content\\Pictures", _hostingEnvironment.EnvironmentName, file.FileName);
            picToUpdate.Smartphone = smartphone;

            await _dbContext.SaveChangesAsync();

            return new List<FileUploadResponse>() { response };
        }

        public async Task DeletePicture(int pictureId)
        {
            var picToDelete = await _dbContext.Pictures.FirstOrDefaultAsync(x => x.PictureId.Equals(pictureId));

            if (picToDelete == null) return;

            //var picFileName = picToDelete.PathToData.Split('\\').Last();
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, picToDelete.PathToData);
            DeleteFile(filePath);
            _dbContext.Pictures.Remove(picToDelete);
            await _dbContext.SaveChangesAsync();
        }

        private void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private async Task<FileUploadResponse> ProcessFile(IFormFile file)
        {
            var uploadResult = new FileUploadResponse();
            string trustedFileNameForFileStorage;
            var untrustedFileName = file.FileName;
            uploadResult.FileName = untrustedFileName;

            if (file.Length == 0)
            {
                uploadResult.ErrorCode = 1;
            }
            else
            {
                try
                {
                    trustedFileNameForFileStorage = Path.GetRandomFileName();
                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "Content\\Pictures",
                        _hostingEnvironment.EnvironmentName);
                    Directory.CreateDirectory(path);
                    var filePath = Path.Combine(path, file.FileName);
                    await using FileStream fs = new(filePath, FileMode.Create);
                    await file.CopyToAsync(fs);

                    uploadResult.Uploaded = true;
                    uploadResult.StoredFileName = trustedFileNameForFileStorage;
                }
                catch (IOException ex)
                {
                    uploadResult.ErrorCode = 3;
                }
            }

            await _dbContext.SaveChangesAsync();

            return uploadResult;
        }
    }
}
