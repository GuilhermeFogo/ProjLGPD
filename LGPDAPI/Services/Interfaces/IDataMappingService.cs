using LGPD.DTO;
using LGPD.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Services.Interfaces
{
    public interface IDataMappingService
    {
        public void Save(DatamappingDTO dataMapping);

        public DatamappingDTO PesquisarPorArea(string area);
    }
}
