using System.Collections.Generic;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IBoPhanService : IApplicationService
    {
        Task<List<BoPhanDto>> GetListAsync();
    }
}
