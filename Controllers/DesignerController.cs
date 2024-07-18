using System;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Components;

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

        public IActionResult GetReport()
        {
           
            var report = new StiReport();
            var value = StiNetCoreHelper.MapPath(this, "Reports/TwoSimpleLists_2+pages.mrt");
            report.Load(value);
           
        
                ApplyDesignRestrictions(report);
  

            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult DesignerEvent() { 

            return StiNetCoreDesigner.DesignerEventResult(this);
        }
        public IActionResult OpenReport()
        {
            // Example: Load the report based on the reportName parameter
            var reportPath = $"Reports/TwoSimpleLists_2+pages.mrt"; // Adjust the path as per your project structure
            var report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, reportPath));

            // Apply any necessary design restrictions or modifications
            ApplyDesignRestrictions(report);

            // Return the report result
            return StiNetCoreDesigner.GetReportResult(this, report);
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
