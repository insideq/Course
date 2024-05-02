namespace UniversityBusinessLogics.OfficePackage.HelperModels
{
    public class PdfInfo
    {
        public string? FileName { get; set; }
        public Stream? Stream { get; set; }

        public string Title { get; set; } = string.Empty;
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
        public List<object> ReportObjects { get; set; } = new();
    }
}
