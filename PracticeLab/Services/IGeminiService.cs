using PracticeLab.DTOs;

namespace PracticeLab.Services
{
    public interface IGeminiService
    {
        Task<(InspectionResultDto? Dto, string RawJson)> AnalyzeImageAsync(Stream stream, string contentType);
    }
}
