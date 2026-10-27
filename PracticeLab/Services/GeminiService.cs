using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Types;
using PracticeLab.DTOs;
using System.Text.Json;


namespace PracticeLab.Services
{
    public class GeminiService : IGeminiService
    {
        private readonly string apiKey;
        public GeminiService(IConfiguration config)
        {
            apiKey = config["Gemini:ApiKey"] ?? throw new ArgumentNullException("No configuration in appsetting");
        }

        public async Task<(InspectionResultDto? Dto, string RawJson)> AnalyzeImageAsync(Stream stream, string contentType)
        {
            var googleAi = new GoogleAI(apiKey);
            var model = googleAi.GenerativeModel("gemini-3.8-flash");
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();


            var prompt = @"Bạn là trợ lý ERP. Phân tích hình ảnh sản phẩm này. Hãy tìm các lỗi(defect) như trầy xước, móp méo. 
Hãy trả về ĐÚNG định dạng JSON sau, không giải thích thêm:
{
    ""ProductName"": ""Tên sản phẩm"",
    ""Category"": ""Tên danh mục sản phẩm"",
    ""QualityStatus"": ""Pass hoặc Fail"",
    ""DefectDescription"": ""Mô tả lỗi (để null nếu Pass)"",
    ""ConfidenceScore"": 0.95,
    ""DefectCategoryId"": 1
}";

            var request = new GenerateContentRequest(prompt);
            request.Contents ??= new List<Content>();
            var base64String = Convert.ToBase64String(fileBytes);
            var filePart = Part.FromBytes(base64String, contentType);
            request.AddPart(filePart);

            request.GenerationConfig = new GenerationConfig
            {
                ResponseMimeType = "application/json"
            };

            var response = await model.GenerateContent(request);
            string rawJson = response.Text ?? "";
            rawJson = rawJson.Replace("```json", "").Replace("```", "").Trim();

            var dto = JsonSerializer.Deserialize<InspectionResultDto>(rawJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            return (dto, rawJson);
        }
    }
}
