namespace UniversityContracts.BindingModels;

/// <summary>
/// Опции для сохранения отчета, при сохранении указать одно из двух
/// </summary>
public class ReportBindingModel
{
    public string? FileName { get; set; }
    public Stream? Stream { get; set; }

    /// <summary>
    /// Массив айдишников по которым происходит выборка
    /// </summary>
    public int[]? Ids { get; set; }
}