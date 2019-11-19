using MissingPet.DataAccess.Entities;
using MissingPet.Domain.Models;
using System.Threading.Tasks;

namespace MissingPet.BLL.Services
{
    public interface IAdvertImageService
    {
        Task Add(Domain.Models.AdvertImage image);
    }
}
