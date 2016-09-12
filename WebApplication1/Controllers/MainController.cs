using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.IO;

namespace WebApplication1.Controllers
{
    public class MainController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Main
        public ActionResult Index()
        {
            ViewBag.TotalMachines = (from x in db.Тренажёры select x).Count();

            return View();
        }


        public ActionResult MachinesChart()
        {
            //db.Тренажёры.


            var data = new Dictionary<string, float>
            {
                {"test1", 10.023f},
                {"test2", 20.020f},
                {"test3", 19.203f},
                {"test4", 4.039f},
                {"test5", 5.343f}
            };








            Chart chart = new Chart();
            chart.Width = 700;
            chart.Height = 300;

            var area = new ChartArea();
            //настройка области диаграммы размеры и т.д.
            chart.ChartAreas.Add(area);

            //Создание и определение серии данных
            var series = new Series();
            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);
            }
            series.Label = "#PERCENT{P0}";
            series.Font = new Font("Segoe UI", 8.0f, FontStyle.Bold);
            series.ChartType = SeriesChartType.Bar;
            series["PieLabelStyle"] = "Outside";

            chart.Series.Add(series);

            var returnStream = new MemoryStream();
            chart.ImageType = ChartImageType.Png;
            chart.SaveImage(returnStream);
            returnStream.Position = 0;
            return new FileStreamResult(returnStream, "image/png");
        }

    }
}