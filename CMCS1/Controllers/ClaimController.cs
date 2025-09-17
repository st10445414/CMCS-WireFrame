using Microsoft.AspNetCore.Mvc;
using CMCS1.Models;

namespace CMCS1.Controllers;

public class ClaimsController : Controller
{
    [HttpGet] public IActionResult Submit() => View(DemoData.SampleClaim());
    [HttpGet] public IActionResult Approvals() => View(DemoData.PendingClaims());
    [HttpGet] public IActionResult Upload() => View();
    [HttpGet] public IActionResult Status() => View(DemoData.ClaimStatuses());
}
