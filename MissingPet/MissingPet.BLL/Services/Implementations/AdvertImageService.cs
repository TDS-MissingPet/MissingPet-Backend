using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissingPet.DataAccess.Repositories;
using MissingPet.Domain.Models;

namespace MissingPet.BLL.Services.Implementations
{
    public class AdvertImageService : IAdvertImageService
    {
        private readonly IImageUploadService _imageUploadService;
        private readonly IRepository<DataAccess.Entities.AdvertImageEntity> _repository;

        public AdvertImageService(IImageUploadService imageUploadService, IRepository<DataAccess.Entities.AdvertImageEntity> repository)
        {
            _imageUploadService = imageUploadService;
            _repository = repository;
        }

        public async Task<string> Add(AdvertImage image)
        {
            if(image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            var imageUrl = await _imageUploadService.Upload(image.ImageData);

            var imageEntity = new DataAccess.Entities.AdvertImageEntity()
            {
                Url = imageUrl,
                Name = image.Name,
                AdvertId = image.AdvertId
            };

            _repository.Add(imageEntity);
            _repository.Save();

            return imageUrl;
        }
    }
}
