using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report;

namespace Edit_Report_in_the_Designer.Controllers
{
    public class EditController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetReport()
        {
            var report = new StiReport();
            var value = StiNetCoreHelper.MapPath(this, "Reports/TwoSimpleLists_2+pages.mrt");
            report.Load(value);
            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }

    }
}
