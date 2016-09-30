using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Controllers
{




    public class MainController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        

        // GET: Main
        public ActionResult Index()
        {
            db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            bool flag = true;
            ViewBag.TotalMachines = (from x in db.Тренажёры select x).Count();
            ViewBag.TotalClients = (from x in db.Клиенты select x).Count();

            foreach(var x in db.Склад_запасных_деталей)
            {
                if(x.Количество - x.Плановый_запас < 0)
                {
                    flag = false;
                    break;
                }
            }

            if (!flag)
                ViewBag.TotalSpare = "ВНИМАНИЕ! Не хватает запасных деталей на складе!";
            else
                ViewBag.TotalSpare = "На складе достаточно запасных деталей";

            return View();
        }



        public ActionResult MachinesChart()
        {
            List<string> sn = (from x in db.Тренажёры select x.Начало_SN).Distinct().ToList();
            Dictionary<string, int> machinesData = new Dictionary<string, int>();

            db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            foreach (var x in sn)
            {
                machinesData.Add(x, 0);
            }


            foreach (var x in db.Тренажёры)
            {
                int temp = (int)machinesData[x.Начало_SN];
                temp += 1;
                machinesData[x.Начало_SN] = temp;
            }


            int y;

            Chart chart = new Chart();
            chart.Width = 700;
            chart.BackColor = Color.FromArgb(0x99, 0x99, 0x99);
            var area = new ChartArea();
            area.AxisX.Interval = 1;
            area.AxisY.Interval = 1;
            area.BackColor = Color.FromArgb(0xdd, 0xdd, 0xdd);
            chart.ChartAreas.Add(area);

            //Создание и определение серии данных
            var series = new Series();


            //foreach (DictionaryEntry item in machinesData)
                foreach (var item in machinesData.OrderBy(x => x.Value))
                {
                series.Points.AddXY(item.Key, item.Value);
            }
            chart.Height = series.Points.Count() * 45;


            series.Label = "#PERCENT{P0}";
            series.Font = new Font("Segoe UI", 8.0f, FontStyle.Bold);
            series.ChartType = SeriesChartType.Bar;
            series.Color = Color.FromArgb(0xf9, 0xe1, 0x1b);
            series.BorderColor = Color.Black;


            chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


            var returnStream = new MemoryStream();
            chart.ImageType = ChartImageType.Png;
            chart.SaveImage(returnStream);
            returnStream.Position = 0;
            return new FileStreamResult(returnStream, "image/png");
        }



        public ActionResult ClientsChart()
        {
            List<int> clientCode = (from x in db.Тренажёры select x.Код_клиента).Distinct().ToList();

            db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            Dictionary<int, int> clientsData = new Dictionary<int, int>();
            Dictionary<int, string> codeName = new Dictionary<int, string>();


            foreach (var x in db.Клиенты)
            {
                if (!codeName.ContainsKey(x.Код_клиента))
                    codeName.Add(x.Код_клиента, x.ФИО_Название_клуба);
            }


            foreach (var x in clientCode)
            {
                clientsData.Add(x, 0);
            }


            foreach (var x in db.Тренажёры)
            {
                int temp = (int)clientsData[x.Код_клиента];
                temp += 1;
                clientsData[x.Код_клиента] = temp;
            }


            Chart chart = new Chart();
            chart.Width = 700;
            chart.BackColor = Color.FromArgb(0x99, 0x99, 0x99);
            var area = new ChartArea();
            area.AxisX.Interval = 1;
            area.AxisY.Interval = 1;
            area.BackColor = Color.FromArgb(0xdd, 0xdd, 0xdd);
            chart.ChartAreas.Add(area);

            //Создание и определение серии данных
            var series = new Series();


            //foreach (DictionaryEntry item in machinesData)
            foreach (var item in clientsData.OrderBy(x => x.Value))
            {
                series.Points.AddXY(codeName[item.Key], item.Value);
            }
            chart.Height = series.Points.Count() * 45;


            series.Label = "#PERCENT{P0}";
            series.Font = new Font("Segoe UI", 8.0f, FontStyle.Bold);
            series.ChartType = SeriesChartType.Bar;
            series.Color = Color.FromArgb(0xf9, 0xe1, 0x1b);
            series.BorderColor = Color.Black;



            chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


            var returnStream = new MemoryStream();
            chart.ImageType = ChartImageType.Png;
            chart.SaveImage(returnStream);
            returnStream.Position = 0;
            return new FileStreamResult(returnStream, "image/png");
        }




        public ActionResult SpareChart()
        {
            Chart chart = new Chart();
            chart.Width = 700;
            chart.BackColor = Color.FromArgb(0x99, 0x99, 0x99);
            var area = new ChartArea();
            area.AxisX.Interval = 1;
            area.AxisY.Interval = 1;
            area.AxisY.Enabled = AxisEnabled.False;
            area.BackColor = Color.FromArgb(0xdd, 0xdd, 0xdd);
            chart.ChartAreas.Add(area);

            db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            //Создание и определение серии данных
            var series = new Series();
            var series2 = new Series();

            foreach (var item in db.Склад_запасных_деталей)
            {
                series.Points.AddXY(item.Код_детали, item.Количество);

                if (item.Плановый_запас == null)
                    series2.Points.AddXY(item.Код_детали, 0);
                else
                    series2.Points.AddXY(item.Код_детали, item.Плановый_запас);
            }

            chart.Height = series.Points.Count()*45;

            series.Label = series2.Label = "#VALY";
            series.Font = series2.Font = new Font("Segoe UI", 8.0f, FontStyle.Bold);
            series.ChartType = series2.ChartType = SeriesChartType.Bar;
            series.Color = Color.FromArgb(0xf9, 0xe1, 0x1b);
            series2.Color = Color.Red;
            series.BorderColor = series2.BorderColor = Color.Black;

            series.LegendText = "фактический запас";
            series2.LegendText = "необходимый запас";


            chart.Series.Add(series);
            chart.Series.Add(series2);


            chart.Legends.Add(new Legend("Legend2"));



            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;


            var returnStream = new MemoryStream();
            chart.ImageType = ChartImageType.Png;
            chart.SaveImage(returnStream);
            returnStream.Position = 0;
            return new FileStreamResult(returnStream, "image/png");
        }



    }
}