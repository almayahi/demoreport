using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


 
 
using Microsoft.AspNetCore.Hosting;

using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Dictionary.Design;
using Stimulsoft.Base;

namespace ReporDemo.Controllers
{
    public class ReportViewerController : Controller
    {
        private readonly IHostingEnvironment HostEnvironment;
        public ReportViewerController(IHostingEnvironment hostEnvironment)
        {
             
            HostEnvironment = hostEnvironment;
           

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DesignerEvent()

        {

            return StiNetCoreDesigner.DesignerEventResult(this);

        }

        public IActionResult ViewerEvent()
        {

            return StiNetCoreViewer.ViewerEventResult(this);
        }

        public IActionResult GetReport()
        {
            string Report = "demoreport";

            var reportPath = HostEnvironment.WebRootPath + "\\Reports\\" + Report + ".mrt";
            StiReport report = new StiReport();
            //report.Load(reportPath);


            report.Load(StiNetCoreHelper.MapPath(this, reportPath));

            ////
            ///What is the code for loading the json her 
            ///The link to json is , considering that the json api is protected
            ///http://localhost:52507/api/Reports/GetEmployees

            return StiNetCoreViewer.GetReportResult(this, report);
        }



        public IActionResult ReportDesigner()
        {
            string Report = "demoreport";

            var reportPath = HostEnvironment.WebRootPath + "\\Reports\\" + Report + ".mrt";
            StiReport report = new StiReport();
            
            //report.Load(reportPath);

            ///What is the code for desgining from  json her 
            ///The link to json is , considering that the json api is protected
            ///http://localhost:52507/api/Reports/GetEmployees

            report.Load(StiNetCoreHelper.MapPath(this, reportPath));

            var jsonString = "{ }"; // Your code to autorization and get JSON string
            var dataSet = StiJsonToDataSetConverter.GetDataSet(jsonString);
            report.RegData("ConnectionName", dataSet);
            report.Dictionary.Synchronize();



            return StiNetCoreDesigner.GetReportResult(this, report);

        }
    }
}