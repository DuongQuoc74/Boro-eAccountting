using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.EntityFrameworkCore;
using tamkhoatech.ACWeb.IService.IQuanLyKho;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.Service.QuanLyKho
{
    public class CommonService : ApplicationService, ICommonService
    {
        public readonly ACWebDbContext _context;
        public CommonService(ACWebDbContext context)
        {
            _context = context;
        }
        public async Task<GiaTriTonKhoDto> GetTonKhos(int? vatTuId, int? khoId, DateTime? ngayHt, decimal? soLuong)
        {
            if(!vatTuId.HasValue || !khoId.HasValue || !ngayHt.HasValue)
                return new GiaTriTonKhoDto();
            try
            {
                var sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@VatTuId", SqlDbType.Int)
                    {
                        Value = vatTuId 
                    },
                    new SqlParameter("@KhoId", SqlDbType.Int)
                    {
                        Value = khoId 
                    },
                    new SqlParameter("@Ngay", SqlDbType.DateTime)
                    {
                        Value = ngayHt 
                    },
                    new SqlParameter("@SoLuong", SqlDbType.Decimal)
                    {
                        Value = soLuong.HasValue ? soLuong : DBNull.Value
                    }
                };
                var connection = _context.Database.GetDbConnection();              
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "TheKho_GetLoThuoc";
                foreach (var param in sqlParams)
                {
                    command.Parameters.Add(param);
                }
                GiaTriTonKhoDto data = new GiaTriTonKhoDto();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    int stt = 1;
                    while (await reader.ReadAsync())
                    {
                        if(!data.VatTuId.HasValue && !data.KhoId.HasValue)
                        {
                            data.VatTuId = reader.GetInt32(reader.GetOrdinal("VatTuId"));
                            data.KhoId = reader.GetInt32(reader.GetOrdinal("KhoId"));
                        }
                        GiaTri giaTri = new GiaTri
                        {
                            Stt = stt,
                            SoCt = reader.GetString(reader.GetOrdinal("SoCt")),
                            NgayCt = reader.GetDateTime(reader.GetOrdinal("NgayCt")),
                            SoLuong = reader.GetDecimal(reader.GetOrdinal("SoLuong")),
                            GiaVND = reader.GetDecimal(reader.GetOrdinal("Gia")),
                            TienVND = reader.GetDecimal(reader.GetOrdinal("Tien")),
                        };
                        stt++;

                        data.GiaTris.Add(giaTri);
                    }
                    await reader.NextResultAsync();
                    while (await reader.ReadAsync())
                    {
                        if (!data.VatTuId.HasValue && !data.KhoId.HasValue)
                        {
                            data.VatTuId = reader.GetInt32(reader.GetOrdinal("VatTuId"));
                            data.KhoId = reader.GetInt32(reader.GetOrdinal("KhoId"));
                        }
                        TonKho tonKho = new TonKho
                        {
                            Ton = reader.GetDecimal(reader.GetOrdinal("Ton")),
                            DaPhat = reader.GetDecimal(reader.GetOrdinal("DaPhat")),
                        };

                        data.TonKho = tonKho;
                    }

                }
                await connection.CloseAsync();
                return data;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return  new GiaTriTonKhoDto();
            }

        }
    }
}
