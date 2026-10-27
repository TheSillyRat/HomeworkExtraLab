using PracticeLab.DTOs;

namespace PracticeLab.Services
{
    public interface IInspectionService
    {
        Task<bool> SaveInspectionAndReportAsync(ReportConfirmDto dto);
    }
}
