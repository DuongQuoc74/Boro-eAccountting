using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.EntityFrameworkCore;
using tamkhoatech.ACWeb.IService.IUtilities;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.Service.Utilities
{
    public class ThueSuatService : ApplicationService, IThueSuatService
    {
        public readonly ACWebDbContext _context;
        public ThueSuatService(ACWebDbContext context)
        {
            _context = context;
        }
        public async Task<List<ThueSuatDto>> GetListAsync()
        {
            try
            {
                //left join từng bản ghi thảo mãn điều kiện
                var query = from ts in _context.ThueSuats
                            join tkc in _context.TaiKhoans on ts.TkCo equals tkc.Id into ts_tkc
                            from tkcLeft in ts_tkc.DefaultIfEmpty()
                            join tkn in _context.TaiKhoans on ts.TkNo equals tkn.Id into ts_tkn
                            from tknLeft in ts_tkn.DefaultIfEmpty()
                            where !ts.IsDeleted && (ts.TkCo == null || !tkcLeft.IsDeleted) && (ts.TkNo == null || !tknLeft.IsDeleted)
                            select new { ts, tkcLeft, tknLeft };

                var items = await query.Select(x => new ThueSuatDto()
                {
                    Id = x.ts.Id,
                    ThueSuatUd = x.ts.ThueSuatUd,
                    ThueSuatNm = x.ts.ThueSuatNm,
                    ThueSuatNm2 = x.ts.ThueSuatNm2,
                    GiaTri = x.ts.GiaTri,
                    TkCo = x.tkcLeft.Id,
                    TkCoUd = x.tkcLeft.TaiKhoanUd,
                    TkNo = x.tknLeft.Id,
                    TkNoUd = x.tknLeft.TaiKhoanUd,
                }).ToListAsync();

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ThueSuatDto>();
            }
        }
    }
}
