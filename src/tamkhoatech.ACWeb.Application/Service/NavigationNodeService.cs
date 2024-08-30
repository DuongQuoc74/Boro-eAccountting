using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service
{
    public class NavigationNodeService : ApplicationService, INavigationNodeService
    {
        public readonly IRepository<SYNavigationNode, int?> _repository;
        public NavigationNodeService(IRepository<SYNavigationNode, int?> repository)
        {
            _repository = repository;
        }

        public async Task<List<NavigationNodeDto>> GetListAsync()
        {
            var nodes = await _repository.ToListAsync();//.GetListAsync(x => x.IsActive == true && !string.IsNullOrEmpty(x.Url));
            return ObjectMapper.Map<List<SYNavigationNode>, List<NavigationNodeDto>>(nodes);
        }
    }
}
