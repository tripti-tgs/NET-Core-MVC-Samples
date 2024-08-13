using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Components;

using Newtonsoft.Json;

namespace Edit_Report_in_the_Designer.Controllers
{
    public class DesignerController : Controller
    {
        static DesignerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public IActionResult Index()
        {
      
            return View();
        }
        [HttpPost]
        public IActionResult GetReport()
        {

            var report = new StiReport();
            var value = StiNetCoreHelper.MapPath(this, "Reports/TwoSimpleLists.mrt");
            report.Load(value);


            ApplyDesignRestrictions(report);


            return StiNetCoreDesigner.GetReportResult(this, report);
        }
        [HttpPost]
        public IActionResult DesignerEvent()
        {

            return StiNetCoreDesigner.DesignerEventResult(this);
        }

        private void ApplyDesignRestrictions(StiReport report)
        {
            foreach (StiPage page in report.Pages)
            {

                foreach (StiComponent component in page.GetComponents())
                {
                    component.Restrictions =
                        Stimulsoft.Report.Components.StiRestrictions.None;

                    component.Locked = true;


                }
            }
        }
    }
}
