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
        private readonly IRepository<DataAccess.Entities.AdvertImage> _repository;

        public AdvertImageService(IImageUploadService imageUploadService, IRepository<DataAccess.Entities.AdvertImage> repository)
        {
            _imageUploadService = imageUploadService;
            _repository = repository;
        }

        public async Task Add(AdvertImage image)
        {
            if(image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            var imageUrl = await _imageUploadService.Upload(image.ImageData);

            var imageEntity = new DataAccess.Entities.AdvertImage()
            {
                Url = imageUrl,
                Name = image.Name,
                AdvertId = image.AdvertId
            };

            _repository.Add(imageEntity);
            _repository.Save();
        }
    }
}
