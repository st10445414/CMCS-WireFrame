using System.ComponentModel.DataAnnotations;

namespace CMCS1.Models;

public class ClaimViewModel
{
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal HourlyRate { get; set; }
    public List<ClaimLineItemViewModel> Items { get; set; } = new();
}

public class ClaimLineItemViewModel
{
    public DateTime? Date { get; set; }
    public string Module { get; set; } = "";
    public decimal Hours { get; set; }
    public string? Notes { get; set; }
}

public record ApprovalListItem(
    int ClaimId, string Lecturer, string Period, string Stage, string Status,
    decimal TotalHours, decimal TotalAmount);

public record ClaimStatusItem(
    int ClaimId, string Period, string Status, DateTime LastUpdated, string? Comment);

public static class DemoData
{
    public static ClaimViewModel SampleClaim() => new()
    {
        Month = DateTime.Now.Month,
        Year = DateTime.Now.Year,
        HourlyRate = 420,
        Items = new()
        {
            new(){ Date=DateTime.Today.AddDays(-2), Module="ICT1511", Hours=2, Notes="Tut" },
            new(){ Date=DateTime.Today.AddDays(-1), Module="ICT2612", Hours=3.5m, Notes="Marking" }
        }
    };

    public static List<ApprovalListItem> PendingClaims() => new()
    {
        new(101, "A. Dlamini", "2025-08", "Programme Coordinator","Pending", 22, 9240),
        new(102, "B. Naidoo",  "2025-08", "Academic Manager", "Returned", 18, 7200),
        new(103, "C. Smith",   "2025-09", "Programme Coordinator","Pending", 12, 4560),
    };

    public static List<ClaimStatusItem> ClaimStatuses() => new()
    {
        new(101, "2025-08", "UnderReview", DateTime.Today.AddDays(-1), "Awaiting PC review"),
        new(102, "2025-08", "Returned",    DateTime.Today.AddDays(-2), "Attach timetable"),
        new(103, "2025-09", "Submitted",   DateTime.Today,              "In queue"),
    };
}
