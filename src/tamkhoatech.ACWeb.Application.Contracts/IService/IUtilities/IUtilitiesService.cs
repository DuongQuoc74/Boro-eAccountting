using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using OfficeOpenXml;
using System.Threading.Tasks;

namespace tamkhoatech.ACWeb.IService.IUtilities
{
    public interface IUtilitiesService : IApplicationService
    {
        ExcelPackage CreateExcelTemplate(int countRow, int countColumn, string titleName);
        Task<DateTime?> DefultNgayHt(DateTime? fromDate, DateTime? toDate);
    }
}
