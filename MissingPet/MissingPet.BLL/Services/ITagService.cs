using MissingPet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.BLL.Services
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAll();
    }
}
