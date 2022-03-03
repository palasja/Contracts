using BLL.ModelsBLL;
using BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAreaRepositiry
    {
        public Task<List<AreaToMenu>> GetAreasSimpleAsync();

        public Task<List<AreaCountOrg>> GetAreasForIndexAsync();

        public Task AddAreaAsync(AreaDTO areaDTO);

        public Task DelAreaAsync(int id);

        public Task UpdateAreaAsync(AreaDTO areaDTO);
    }
}
