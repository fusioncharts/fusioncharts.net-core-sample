using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FusionCharts.Samples.Models;
using System.Configuration;
using System.Data;
using FusionCharts.DataEngine;
using FusionCharts.Visualization;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace FusionCharts.Samples.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        string connectionString = "";
        IHostingEnvironment WebEnv;

        /*
        public HomeController(IConfiguration config)
        {
            configuration = config;
            connectionString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(config, "DefaultConnection");
        }
        */

        public HomeController(IHostingEnvironment hostingEnvironment, IConfiguration config)
        {
            WebEnv = hostingEnvironment;
            configuration = config;
            connectionString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(config, "DefaultConnection");
            connectionString = connectionString.Replace("|DataDirectory|", WebEnv.ContentRootPath);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region chart type samples
        public ActionResult PyramidChart()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Simple pyramid Chart";
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Label", typeof(System.String));
            ChartData.Columns.Add("Value", typeof(System.Double));
            ChartData.Rows.Add("Top 32 mn (0.7%)", 98.7);
            ChartData.Rows.Add("Next 361 mn (7.7%)", 101.8);
            ChartData.Rows.Add("Next 1.1 bn (22.9%)", 33);
            ChartData.Rows.Add("Last 3.2 bn (68.7%)", 7.3);
            StaticSource source = new StaticSource(ChartData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);
            Widget.PyramidChart pyramid = new Widget.PyramidChart("first_pyramid_chart");
            pyramid.Data.Source = model;
            pyramid.Caption.Text = "Global Wealth Pyramid";
            pyramid.Caption.OnTop = false;
            pyramid.SubCaption.Text = "Credit Suisse 2013";
            pyramid.Width.Pixel(400);
            pyramid.Height.Pixel(500);

            ViewData["Chart"] = pyramid.Render();
            return View();
        }
        public ActionResult PieChart()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Simple pyramid Chart";
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Programming Language", typeof(System.String));
            ChartData.Columns.Add("Users", typeof(System.Double));
            ChartData.Rows.Add("Java", 62000);
            ChartData.Rows.Add("Python", 46000);
            ChartData.Rows.Add("Javascript", 38000);
            ChartData.Rows.Add("C++", 31000);
            ChartData.Rows.Add("C#", 27000);
            ChartData.Rows.Add("PHP", 14000);
            ChartData.Rows.Add("Perl", 14000);
            // Create static source with this data table
            StaticSource source = new StaticSource(ChartData);
            // Create instance of DataModel class
            DataModel model = new DataModel();
            // Add DataSource to the DataModel
            model.DataSources.Add(source);
            // Instantiate Pie Chart
            Charts.PieChart pie = new Charts.PieChart("pie_chart");
            // Set Chart's width and height
            pie.Width.Pixel(500);
            pie.Height.Pixel(400);
            // Set DataModel instance as the data source of the chart
            pie.Data.Source = model;
            // Set Chart Title
            pie.Caption.Text = "Most popular programming language";
            //set chart sub title
            pie.SubCaption.Text = "2017-2018";

            ViewData["Chart"] = pie.Render();
            return View();
        }
        public ActionResult DoughnutChart()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Simple pyramid Chart";
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Programming Language", typeof(System.String));
            ChartData.Columns.Add("Users", typeof(System.Double));
            ChartData.Rows.Add("Java", 62000);
            ChartData.Rows.Add("Python", 46000);
            ChartData.Rows.Add("Javascript", 38000);
            ChartData.Rows.Add("C++", 31000);
            ChartData.Rows.Add("C#", 27000);
            ChartData.Rows.Add("PHP", 14000);
            ChartData.Rows.Add("Perl", 14000);
            // Create static source with this data table
            StaticSource source = new StaticSource(ChartData);
            // Create instance of DataModel class
            DataModel model = new DataModel();
            // Add DataSource to the DataModel
            model.DataSources.Add(source);
            // Instantiate Pie Chart
            Charts.DoughnutChart donut = new Charts.DoughnutChart("doughnut_chart");
            // Set Chart's width and height
            donut.Width.Pixel(500);
            donut.Height.Pixel(400);
            // Set DataModel instance as the data source of the chart
            donut.Data.Source = model;
            // Set Chart Title
            donut.Caption.Text = "Most popular programming language";
            //set chart sub title
            donut.SubCaption.Text = "2017-2018";

            ViewData["Chart"] = donut.Render();
            return View();
        }
        public ActionResult ThreeDChart()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Pie 3d Chart";
            DataTable primaryData = new DataTable();

            primaryData.Columns.Add("Language", typeof(System.String));
            primaryData.Columns.Add("User", typeof(System.Double));

            primaryData.Rows.Add("Java", 62000);
            primaryData.Rows.Add("Python", 46000);
            primaryData.Rows.Add("Javascript", 38000);
            primaryData.Rows.Add("C++", 31000);
            primaryData.Rows.Add("C#", 27000);
            primaryData.Rows.Add("php", 14000);
            primaryData.Rows.Add("Perl", 14000);

            StaticSource source = new StaticSource(primaryData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);

            PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

            Charts.PieChart pie = new Charts.PieChart("first_3D_chart");
            pie.ThreeD = true;
            pie.Width.Pixel(600);
            pie.Height.Pixel(450);
            pie.Data.Source = model;
            pie.Data.CategoryField("Language");
            pie.Data.SeriesFields("User");

            pie.Caption.Text = "7 languages and their user base";
            pie.Values.Show = false;

            ViewData["Chart"] = pie.Render();
            return View();
        }
        public ActionResult ColumnChart()
        {
            
            DataTable dt = new DataTable();
            string query = "select ProductName, UnitsInStock  from  ProductsUnitsOrder  where  UnitsOnOrder > 0";

            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);

                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.ColumnChart column = new Charts.ColumnChart("column_chart_db");
                column.Data.Source = model;
                column.Caption.Text = "Product Wise Stock Quantity";
                column.XAxis.Text = "Product Name";
                column.YAxis.Text = "Stocked Quantity";

                column.Width.Pixel(600);
                column.Height.Pixel(400);
                column.Values.Show = false;
                ViewData["Chart"] = column.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }
            return View();

        }
        public ActionResult BarChart()
        {
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Programming Language", typeof(System.String));
            ChartData.Columns.Add("Users", typeof(System.Double));
            ChartData.Rows.Add("Java", 62000);
            ChartData.Rows.Add("Python", 46000);
            ChartData.Rows.Add("Javascript", 38000);
            ChartData.Rows.Add("C++", 31000);
            ChartData.Rows.Add("C#", 27000);
            ChartData.Rows.Add("PHP", 14000);
            ChartData.Rows.Add("Perl", 14000);
            // Create static source with this data table

            StaticSource source = new StaticSource(ChartData);

            // Create instance of DataModel class
            DataModel model = new DataModel();

            // Add DataSource to the DataModel
            model.DataSources.Add(source);

            // Instantiate bar Chart
            Charts.BarChart bar = new Charts.BarChart("bar_chart");

            // Set Chart's width and height
            bar.Width.Pixel(500);
            bar.Height.Pixel(400);

            // Set DataModel instance as the data source of the chart
            bar.Data.Source = model;

            // Set Chart Title
            bar.Caption.Text = "Most popular programming language";
            ViewData["Chart"] = bar.Render();


            return View();

        }
        public ActionResult OverlappedChart()
        {
            DataTable dt = new DataTable();
            string query = "select CategoryName, SUM([Stocked Quantity])as [Stocked Quantity],SUM([Reorder Level]) as [Reorder Level], SUM([Order Quantity]) as [Order Quantity] from CategoryOrderedLevel group by CategoryName";


            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);

                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.BarChart bar = new Charts.BarChart("overlapped_chart_db");
                bar.Overlapped = true;
                bar.Data.Source = model;
                bar.Width.Pixel(600);
                bar.Height.Pixel(450);
                bar.Values.Show = false;
                ViewData["Chart"] = bar.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }
            return View();

        }
        public ActionResult ScrollableChart()
        {
            DataTable dt = new DataTable();
            string query = "select * from CompanyWiseYearlySales";


            dt.Clear();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }

                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);

                Charts.ColumnChart column = new Charts.ColumnChart("scroll_chart_db");
                column.Scrollable = true;
                column.Data.Source = model;

                column.Width.Pixel(500);
                column.Height.Pixel(450);

                column.Values.Show = false;

                ViewData["Chart"] = column.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }


            return View();

        }
        public ActionResult StackedChart()
        {
            DataTable dt = new DataTable();
            string query = "select Country,COUNT([Product Type]) as [Product Types],SUM([Ordered quantity]) as [Ordered quantity] from ProductOrderedQuantity group by Country";


            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);

                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.StackedChart stack = new Charts.StackedChart("stacked_chart_db");

                stack.Width.Pixel(600);
                stack.Height.Pixel(450);

                stack.StackType = Charts.StackedChart.StackChartType.BAR;

                stack.Data.Source = model;
                stack.Data.CategoryField("country");
                stack.Data.SeriesFields("Product types", "Ordered Quantity");
                stack.Values.Show = false;

                ViewData["Chart"] = stack.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }
        public ActionResult LineChart()
        {
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Day", typeof(System.String));
            ChartData.Columns.Add("No. of Visitors", typeof(System.Double));
            ChartData.Rows.Add("Mon", 15123);
            ChartData.Rows.Add("Tue", 14233);
            ChartData.Rows.Add("Wed", 23507);
            ChartData.Rows.Add("Thu", 9110);
            ChartData.Rows.Add("Fri", 15529);
            ChartData.Rows.Add("Sat", 20803);
            ChartData.Rows.Add("Sun", 19202);
            StaticSource source = new StaticSource(ChartData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);

            Charts.LineChart line = new Charts.LineChart("line_chart_db");

            line.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            line.Width.Pixel(700);
            line.Height.Pixel(400);

            line.Data.Source = model;

            line.Caption.Text = "Total Footfall in BakersField Central";
            line.Caption.Bold = true;

            line.SubCaption.Text = "Last Week";
            line.XAxis.Text = "Day";
            line.YAxis.Text = "No. of visitors";

            line.Legend.Show = false;

            ViewData["Chart"] = line.Render();


            return View();
        }
        public ActionResult SplineChart()
        {
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Day", typeof(System.String));
            ChartData.Columns.Add("No. of Visitors", typeof(System.Double));
            ChartData.Rows.Add("Mon", 15123);
            ChartData.Rows.Add("Tue", 14233);
            ChartData.Rows.Add("Wed", 23507);
            ChartData.Rows.Add("Thu", 9110);
            ChartData.Rows.Add("Fri", 15529);
            ChartData.Rows.Add("Sat", 20803);
            ChartData.Rows.Add("Sun", 19202);
            StaticSource source = new StaticSource(ChartData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);

            Charts.SplineChart spline = new Charts.SplineChart("spline_chart");

            spline.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            spline.Width.Pixel(700);
            spline.Height.Pixel(400);

            spline.Data.Source = model;

            spline.Caption.Text = "Total Footfall in BakersField Central";
            spline.Caption.Bold = true;

            spline.SubCaption.Text = "Last Week";
            spline.XAxis.Text = "Day";
            spline.YAxis.Text = "No. of visitors";

            spline.Legend.Show = false;

            ViewData["Chart"] = spline.Render();


            return View();
        }
        public ActionResult AreaChart()
        {
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Day", typeof(System.String));
            ChartData.Columns.Add("Sales", typeof(System.Double));
            ChartData.Rows.Add("Mon", 4123);
            ChartData.Rows.Add("Tue", 4633);
            ChartData.Rows.Add("Wed", 5507);
            ChartData.Rows.Add("Thu", 4910);
            ChartData.Rows.Add("Fri", 5529);
            ChartData.Rows.Add("Sat", 5803);
            ChartData.Rows.Add("Sun", 6202);
            StaticSource source = new StaticSource(ChartData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);
            Charts.AreaChart area = new Charts.AreaChart("area_chart_db");
            area.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            area.Width.Pixel(700);
            area.Height.Pixel(400);
            area.Data.Source = model;
            area.Caption.Text = "Sales of Liquor";
            area.Caption.Bold = true;
            area.SubCaption.Text = "Last week";
            area.XAxis.Text = "Day";
            area.YAxis.Text = "Sales";
            area.Legend.Show = false;

            ViewData["Chart"] = area.Render();


            return View();
        }
        public ActionResult FunnelChart()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Simple pyramid Chart";
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Label", typeof(System.String));
            ChartData.Columns.Add("Value", typeof(System.Double));
            ChartData.Rows.Add("Unique Website Visits", 1460000);
            ChartData.Rows.Add("Programme Details Section Visits", 930000);
            ChartData.Rows.Add("Attempts to Register", 540000);
            ChartData.Rows.Add("Successful Registrations", 210000);
            ChartData.Rows.Add("Logged In", 190000);
            ChartData.Rows.Add("Purchased on Introductory Offers", 120000);
            StaticSource source = new StaticSource(ChartData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);
            Widget.FunnelChart funnel = new Widget.FunnelChart("first_Funnel_chart");
            funnel.Data.Source = model;
            funnel.Caption.Text = "Visit to purchase analysis";
            funnel.Caption.Text = "Harry's Supermart";
            funnel.SubCaption.Text = "Visit to purchase- Conversion Anallysis for last year";
            funnel.Width.Pixel(400);
            funnel.Height.Pixel(400);

            ViewData["Chart"] = funnel.Render();
            return View();
        }

        public ActionResult SingleYCombi2D()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Single Y-axis Combination Chart 2D";

            // initialize DataModel object
            DataModel model = new DataModel();
            // Create object of JsonFileSource. Provide file path as constructor parameter
            JsonFileSource jsonFileSource = new JsonFileSource("https://raw.githubusercontent.com/poushali-guha-12/SampleData/master/mscombi2d.json");
            // Add json source in datasources store of model
            model.DataSources.Add(jsonFileSource);
            // initialize combination chart object
            Charts.CombinationChart combiChart = new Charts.CombinationChart("mscombi2d");
            // set model as data source
            combiChart.Data.Source = model;
            // provide field name, which should be rendered as line column
            combiChart.Data.ColumnPlots("Actual Revenue");
            // provide field name, which should be rendered as line plot
            combiChart.Data.LinePlots("Projected Revenue");
            // provide field name, which should be rendered as area plot
            combiChart.Data.AreaPlots("Profit");
            // Set XAxis caption
            combiChart.XAxis.Text = "Month";
            // Set YAxis caption
            combiChart.PrimaryYAxis.Text = "Amount (in USD)";
            // set chart caption
            combiChart.Caption.Text = "Harrys's Supermart";
            // Set chart sub caption
            combiChart.SubCaption.Text = "Sales analysis of last year";
            // set width, height
            combiChart.Width.Pixel(600);
            combiChart.Height.Pixel(500);
            // set theme
            combiChart.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            ViewData["Chart"] = combiChart.Render();
            return View();
        }
        public ActionResult SingleYCombi3D()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Single Y-axis Combination Chart 3D";

            // initialixe DataModel object
            DataModel model = new DataModel();
            // Create object of JsonFileSource. Provide file path as constructor parameter
            JsonFileSource jsonFileSource = new JsonFileSource("https://raw.githubusercontent.com/poushali-guha-12/SampleData/master/mscombi3d.json");
            // Add json source in datasources store of model
            model.DataSources.Add(jsonFileSource);
            // initialize combination chart object
            Charts.CombinationChart combiChart = new Charts.CombinationChart("mscombi3d");
            // Set threeD
            combiChart.ThreeD = true;
            // set model as data source
            combiChart.Data.Source = model;
            // provide field name, which should be rendered as line column
            combiChart.Data.ColumnPlots("Actual Revenue");
            // provide field name, which should be rendered as line plot
            combiChart.Data.LinePlots("Projected Revenue");
            // provide field name, which should be rendered as area plot
            combiChart.Data.AreaPlots("Profit");
            // Set XAxis caption
            combiChart.XAxis.Text = "Month";
            // Set YAxis caption
            combiChart.PrimaryYAxis.Text = "Amount (in USD)";
            // set chart caption
            combiChart.Caption.Text = "Harrys's Supermart";
            // Set chart sub caption
            combiChart.SubCaption.Text = "Sales analysis of last year";
            // set width, height
            combiChart.Width.Pixel(600);
            combiChart.Height.Pixel(500);
            // set theme
            combiChart.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            ViewData["Chart"] = combiChart.Render();
            return View();
        }
        public ActionResult DualYCombi2D()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Dual Y-axis Combination Chart 2D";

            // initialize DataModel object
            DataModel model = new DataModel();
            // Create object of JsonFileSource. Provide file path as constructor parameter
            JsonFileSource jsonFileSource = new JsonFileSource("https://raw.githubusercontent.com/poushali-guha-12/SampleData/master/mscombidy2d.json");
            // Add json source in datasources store of model
            model.DataSources.Add(jsonFileSource);
            // initialize combination chart object
            Charts.CombinationChart combiChart = new Charts.CombinationChart("mscombidy2d");
            // set model as data source
            combiChart.Data.Source = model;

            // provide field name, which should be rendered as line column
            combiChart.Data.ColumnPlots("Revenues");
            // provide field name, which should be rendered as spline area plot
            combiChart.Data.SplineAreaPlots("Profits");
            // provide field name, which should be rendered as spline plot
            combiChart.Data.SplinePlots("Profit %");
            // set parentAxis
            combiChart.Data.SecondaryYAxisAsParent("Profit %");
            // Set XAxis caption
            combiChart.XAxis.Text = "Month";
            // Set YAxis caption
            combiChart.PrimaryYAxis.Text = "Amount (in USD)";
            // enable dual y
            combiChart.DualY = true;
            // set secondary y axis text
            combiChart.SecondaryYAxis.Text = "Profit %";
            // set chart caption
            combiChart.Caption.Text = "Revenues and Profit";
            // Set chart sub caption
            combiChart.SubCaption.Text = "For last year";
            // set width, height
            combiChart.Width.Pixel(600);
            combiChart.Height.Pixel(500);
            // set theme
            combiChart.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            ViewData["Chart"] = combiChart.Render();
            return View();
        }
        public ActionResult SingleYScrollCombi2D()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Single Y-axis Scroll Combination Chart 2D";

            // initialixe DataModel object
            DataModel model = new DataModel();
            // Create object of JsonFileSource. Provide file path as constructor parameter
            JsonFileSource jsonFileSource = new JsonFileSource("https://raw.githubusercontent.com/poushali-guha-12/SampleData/master/scrollcombi2d.json");
            // Add json source in datasources store of model
            model.DataSources.Add(jsonFileSource);
            // initialize combination chart object
            Charts.CombinationChart combiChart = new Charts.CombinationChart("scrollcombi2d");
            // set model as data source
            combiChart.Data.Source = model;
            // enable scrolling
            combiChart.Scrollable = true;
            // provide field name, which should be rendered as line column
            combiChart.Data.ColumnPlots("Actual Revenue");
            // provide field name, which should be rendered as spline area plot
            combiChart.Data.LinePlots("Projected Revenue");
            // provide field name, which should be rendered as spline plot
            combiChart.Data.AreaPlots("Profit");
            // Set XAxis caption
            combiChart.XAxis.Text = "Month";
            // Set YAxis caption
            combiChart.PrimaryYAxis.Text = "Amount (in USD)";
            // set chart caption
            combiChart.Caption.Text = "Revenues and Profit";
            // Set chart sub caption
            combiChart.SubCaption.Text = "For last year";
            // set width, height
            combiChart.Width.Pixel(600);
            combiChart.Height.Pixel(500);
            // set theme
            combiChart.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            ViewData["Chart"] = combiChart.Render();
            return View();
        }
        public ActionResult DualYScrollCombi2D()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Dual Y-axis Scroll Combination Chart 2D";

            // initialixe DataModel object
            DataModel model = new DataModel();
            // Create object of JsonFileSource. Provide file path as constructor parameter
            JsonFileSource jsonFileSource = new JsonFileSource("https://raw.githubusercontent.com/poushali-guha-12/SampleData/master/scrollcombidy2d.json");
            // Add json source in datasources store of model
            model.DataSources.Add(jsonFileSource);
            // initialize combination chart object
            Charts.CombinationChart combiChart = new Charts.CombinationChart("scrollcombidy2d");
            // set model as data source
            combiChart.Data.Source = model;
            // Enable scrolling
            combiChart.Scrollable = true;
            // provide field name, which should be rendered as line column
            combiChart.Data.ColumnPlots("Revenues");
            // provide field name, which should be rendered as spline area plot
            combiChart.Data.AreaPlots("Profits");
            // provide field name, which should be rendered as spline plot
            combiChart.Data.LinePlots("Profit %");
            // set parentAxis
            combiChart.Data.SecondaryYAxisAsParent("Profit %");
            // Set XAxis caption
            combiChart.XAxis.Text = "Month";
            // Set YAxis caption
            combiChart.PrimaryYAxis.Text = "Amount (in USD)";
            // enable dual y
            combiChart.DualY = true;
            // set secondary y axis text
            combiChart.SecondaryYAxis.Text = "Profit %";
            // set chart caption
            combiChart.Caption.Text = "Revenues and Profit";
            // Set chart sub caption
            combiChart.SubCaption.Text = "For last year";
            // set width, height
            combiChart.Width.Pixel(600);
            combiChart.Height.Pixel(500);
            // set theme
            combiChart.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            ViewData["Chart"] = combiChart.Render();
            return View();
        }
        #endregion
        #region chart components samples
        public ActionResult SeriesCustomization()
        {
            DataTable dt = new DataTable();
            string query = "select * from MonthlyProductSales";


            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);

                Charts.LineChart line = new Charts.LineChart("line_chart_db");
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                line.ThemeName = FusionChartsTheme.ThemeName.FINT;
                line.Width.Pixel(600);
                line.Height.Pixel(450);

                line.Data.Source = model;
                line.Data.CategoryField("Month name");

                line.Data.Series.SeriesFormatting("Produce").ShowValues(false).Dashed(true);
                line.Data.Series.SeriesFormatting("Confections").ShowValues(false);
                line.Data.Series.SeriesFormatting("Meat/Poultry").Visible(false).ShowValues(false);
                line.Data.Series.SeriesFormatting("Beverages").ShowValues(false);
                line.Data.Series.SeriesFormatting("Condiments").ShowValues(false);
                line.Data.Series.SeriesFormatting("Grains/Cereals").ShowValues(false);
                line.Data.Series.SeriesFormatting("Seafood").ShowValues(false);
                line.Data.Series.SeriesFormatting("Dairy Products").ShowValues(false);

                line.Values.Show = false;

                ViewData["Chart"] = line.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }
        public ActionResult ValueAndLabelFormatting()
        {
            DataTable dt = new DataTable();
            string query = "select [Product Category],SUM([Purchase Amount]) as [Purchased Amount] from CategoryWisePurchasedAmount group by [Product Category]";


            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.DoughnutChart doughnut = new Charts.DoughnutChart("doughnut_chart_db");
                doughnut.ThreeD = true;
                doughnut.Width.Pixel(600);
                doughnut.Height.Pixel(450);

                doughnut.Data.Source = model;
                doughnut.Data.ValueFormatting("value > 2200000").ValuePosition(ValueFormat.ValuePosition.BELOW);
                doughnut.Data.LabelFormatting("Clothing").Bold(true).FontSize(10).FontColor("ff0000");

                doughnut.Values.Show = false;

                ViewData["Chart"] = doughnut.Render();

            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }


            return View();
        }

        public ActionResult CategoryFormatting()
        {
            DataTable dt = new DataTable();
            string query = "select [Product Name], SUM(Revenue) as Revenue,SUM([Actual Cost]) as [Actual Cost] from ProductRevenue where [Last Receipt year] = 2001 group by [Product Name]";


            dt.Clear();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.BarChart bar = new Charts.BarChart("category_format_example");

                bar.Width.Pixel(600);
                bar.Height.Pixel(450);

                bar.Data.Source = model;
                bar.Data.Categories.FontColor = "ff0000";
                bar.Data.Categories.CategoryFormatting("Pedals").Bold(true).FontColor("0000ff").BorderColor("000000");

                bar.Values.Show = false;

                ViewData["Chart"] = bar.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult ConditionalValueFormatting()
        {
            DataTable dt = new DataTable();
            string query = "select * from CompanyWiseYearlySales";


            dt.Clear();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.StackedChart stack = new Charts.StackedChart("conditional_formatting");
                stack.Width.Pixel(600);
                stack.Height.Pixel(450);

                stack.Data.Source = model;
                stack.Data.Series.ValueFormatting("value < 1000");
                stack.Data.Series.ValueFormatting("value >= 1000 and value < 5000").ValuePosition(ValueFormat.ValuePosition.ABOVE);
                stack.Data.Series.ValueFormatting("value > 10000").Color("ff0000").ValuePosition(ValueFormat.ValuePosition.ABOVE);
                stack.Data.Series.ValueFormatting("value >= 5000 and value < 10000").Color("0000ff").ValuePosition(ValueFormat.ValuePosition.ABOVE);

                stack.Values.Show = false;

                ViewData["Chart"] = stack.Render();

            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult ChartConfigCustomization()
        {
            DataTable dt = new DataTable();
            string query = "select * from TerriToryWiseSales";


            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.ColumnChart column = new Charts.ColumnChart("conditional_formatting");
                column.Width.Pixel(600);
                column.Height.Pixel(450);

                column.Caption.Text = "Territory wise total sales";
                column.Caption.FontSize = 16;
                column.Caption.Alignment = CaptionObject.CaptionAlignment.CENTER;
                column.Caption.FontColor = "0000ff";

                column.SubCaption.FontSize = 12;
                column.SubCaption.Text = "column chart representation of sales data";
                column.SubCaption.FontColor = "ff0000";

                column.XAxis.Text = "Terriotories";
                column.XAxis.FontSize = 14;
                column.XAxis.BorderColor = "000000";
                column.XAxis.Bold = true;

                column.YAxis.Text = "Total sales";
                column.YAxis.BorderColor = "000000";
                column.YAxis.FontSize = 14;
                column.YAxis.Bold = true;

                column.Data.Source = model;

                column.Values.Show = false;

                ViewData["Chart"] = column.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }
            return View();
        }

        public ActionResult LegendTooltipConfig()
        {
            DataTable dt = new DataTable();
            string query = "select [Designation Group],SUM([Total Employess]) as [Total Employess] from dbo.GroupwiseEmployeeCount group by [Designation Group]";


            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Widget.FunnelChart funnel = new Widget.FunnelChart("conditional_formatting");
                funnel.Width.Pixel(600);
                funnel.Height.Pixel(450);

                funnel.Legend.Show = true;
                funnel.Legend.FontSize = 24;
                funnel.Legend.Position = LegendObject.LegendPosition.RIGHT;
                funnel.Legend.Bold = true;

                funnel.ToolTip.BorderColor = "000000";
                funnel.ToolTip.ShowShadow = true;
                funnel.ToolTip.Color = "0000ff";

                funnel.Data.Source = model;

                funnel.Values.Show = false;

                ViewData["Chart"] = funnel.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult ExportSettings()
        {
            DataTable dt = new DataTable();
            string query = "select COUNT([Product Name]) as [Product Count], [Start Year] as [Start Year] from dbo.YearlyOrderCount group by [Start Year] order by [Start Year]";


            dt.Clear();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.SplineChart spline = new Charts.SplineChart("conditional_formatting");
                spline.Width.Pixel(600);
                spline.Height.Pixel(450);

                spline.Export.Enabled = true;
                spline.Export.ExportedFileName = "fusioncharts.net_visualizations_exported_files";
                spline.Export.Action = Exporter.ExportAction.DOWNLOAD;

                spline.Data.Source = model;
                spline.Data.CategoryField("Start year");
                spline.Data.SeriesFields("Product Count");

                spline.Values.Show = false;

                ViewData["Chart"] = spline.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        #endregion

        #region event samples
        public ActionResult DataLoadEvents()
        {

            DataTable primaryData = new DataTable();

            primaryData.Columns.Add("Country", typeof(System.String));
            primaryData.Columns.Add("Population", typeof(System.Double));

            primaryData.Rows.Add("China", 1415045928);
            primaryData.Rows.Add("India", 1354051854);
            primaryData.Rows.Add("United states", 326766748);
            primaryData.Rows.Add("Indonesia", 266794980);
            primaryData.Rows.Add("Brazil", 210867954);
            primaryData.Rows.Add("Pakistan", 200813818);
            primaryData.Rows.Add("Nigeria", 195875237);
            primaryData.Rows.Add("Bangladesh", 166368149);
            primaryData.Rows.Add("Russia", 143964709);
            primaryData.Rows.Add("Mexico", 130759074);

            StaticSource source = new StaticSource(primaryData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);
            PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

            Widget.PyramidChart pyramid = new Widget.PyramidChart("pyramid_chart");

            pyramid.Data.Source = model;
            pyramid.Data.CategoryField("Country");
            pyramid.Data.SeriesFields("Population");

            pyramid.Width.Pixel(600);
            pyramid.Height.Pixel(450);

            pyramid.Caption.Text = "World top 10 populated countries";

            pyramid.Events.AttachDataLoadEvent(FusionChartsEvents.DataLoadEvents.DATALOADED, "OnDataLoaded");

            pyramid.Values.Show = false;

            ViewData["Chart"] = pyramid.Render();
            return View();
        }

        public ActionResult GenericEvents()
        {
            DataTable dt = new DataTable();
            string query = "select ProductName, UnitsInStock  from  ProductsUnitsOrder  where  UnitsOnOrder > 0";

            dt.Clear();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.ColumnChart column = new Charts.ColumnChart("column_chart_db");
                column.Events.AttachGenericEvents(FusionChartsEvents.GenericEvents.DATAPLOTCLICK, "OnDataPlotClick");
                column.Data.Source = model;
                column.Caption.Text = "Product Wise Stock Quantity";
                column.XAxis.Text = "Product Name";
                column.YAxis.Text = "Stocked Quantity";

                column.Width.Pixel(600);
                column.Height.Pixel(450);

                column.Values.Show = false;

                ViewData["Chart"] = column.Render();

            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult Renderedevents()
        {
            DataTable dt = new DataTable();
            string query = "select ProductName, UnitsInStock  from  ProductsUnitsOrder  where  UnitsOnOrder > 0";

            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.BarChart bar = new Charts.BarChart("bar_chart_db");
                bar.ThreeD = true;
                bar.Data.Source = model;
                bar.Caption.Text = "Product Wise Stock Quantity";
                bar.XAxis.Text = "Product Name";
                bar.YAxis.Text = "Stocked Quantity";

                bar.Width.Pixel(600);
                bar.Height.Pixel(450);

                bar.Events.AttachRenderedEvents(FusionChartsEvents.RenderedEvents.LOADED, "OnChartLoaded");

                bar.Values.Show = false;

                ViewData["Chart"] = bar.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult PieChartsEvents()
        {
            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Pie 3d Chart";
            DataTable primaryData = new DataTable();

            primaryData.Columns.Add("Language", typeof(System.String));
            primaryData.Columns.Add("User", typeof(System.Double));

            primaryData.Rows.Add("Java", 62000);
            primaryData.Rows.Add("Python", 46000);
            primaryData.Rows.Add("Javascript", 38000);
            primaryData.Rows.Add("C++", 31000);
            primaryData.Rows.Add("C#", 27000);
            primaryData.Rows.Add("php", 14000);
            primaryData.Rows.Add("Perl", 14000);

            StaticSource source = new StaticSource(primaryData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);
            PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

            Charts.PieChart pie = new Charts.PieChart("ThreD_chart");

            pie.Width.Pixel(600);
            pie.Height.Pixel(450);
            pie.Data.Source = model;
            pie.Data.CategoryField("Language");
            pie.Data.SeriesFields("User");

            pie.Caption.Text = "7 languages and their user base";

            pie.Events.AttachSpecialEvents(PieDoughnutEvents.SpecialEvents.ROTATIONSTART, "OnRotationStart");
            pie.Events.AttachSpecialEvents(PieDoughnutEvents.SpecialEvents.ROTATIONEND, "OnRotationEnd");

            pie.Values.Show = false;

            ViewData["Chart"] = pie.Render();
            return View();
        }
        public ActionResult ScrollChartsEvents()
        {
            DataTable dt = new DataTable();
            string query = "select * from CompanyWiseYearlySales";

            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.ColumnChart column = new Charts.ColumnChart("scroll_chart_db");
                column.Scrollable = true;
                column.Data.Source = model;

                column.Width.Pixel(650);
                column.Height.Pixel(450);

                column.Events.AttachSpecialEvents(ScrollChartEvents.SpecialEvents.SCROLLEND, "OnScrollEnd");
                column.Events.AttachSpecialEvents(ScrollChartEvents.SpecialEvents.SCROLLSTART, "OnScrollStart");

                column.Values.Show = false;

                ViewData["Chart"] = column.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }
        #endregion
        #region data engine samples
        public ActionResult GroupingwithAggregation()
        {
            DataTable dt = new DataTable();
            string query = "select * from ProductOrderedQuantity";


            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                GroupColumn groupColumn = new GroupColumn { "Country" };
                Aggregation aggregation = new Aggregation {
                { "Product Type", Aggregation.Function.COUNT },
                { "Ordered Quantity", Aggregation.Function.SUM }
            };

                model = model.GroupingWithAggregation(groupColumn, aggregation);

                Charts.StackedChart stack = new Charts.StackedChart("stacked_chart_db");
                stack.Width.Pixel(600);
                stack.Height.Pixel(450);

                stack.Data.Source = model;
                stack.Data.CategoryField("Country");
                stack.Data.SeriesFields("Product Type", "Ordered Quantity");

                stack.Values.Show = false;

                ViewData["Chart"] = stack.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult OrderByClause()
        {
            DataTable dt = new DataTable();
            string query = "select * from CompanyWiseYearlySales";


            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                SortColumn sortColumn = new SortColumn {
                    {"1994",SortColumn.Order.DESC },
                    {"1995",SortColumn.Order.DESC },
                    {"1996",SortColumn.Order.DESC }
                };
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                model = model.OrderBy(sortColumn);
                Charts.ColumnChart column = new Charts.ColumnChart("scroll_chart_db");
                column.Scrollable = true;
                column.Data.Source = model;

                column.Width.Pixel(600);
                column.Height.Pixel(450);

                column.Values.Show = false;

                ViewData["Chart"] = column.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult ExtractTopNRecords()
        {
            DataTable dt = new DataTable();
            string query = "select * from CompanyWiseYearlySales";


            dt.Clear();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                model = model.TopRecords(15);
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                Charts.StackedChart stack = new Charts.StackedChart("conditional_formatting");
                stack.Width.Pixel(600);
                stack.Height.Pixel(450);

                stack.Values.Show = false;
                stack.Data.Source = model;
                ViewData["Chart"] = stack.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult SelectFields()
        {
            DataTable dt = new DataTable();
            string query = "select * from MonthlyProductSales";


            dt.Clear();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }

                }
                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                model = model.SelectColumn("Month Name", "Beverages", "Condiments", "Produce", "Confections");
                Charts.LineChart line = new Charts.LineChart("line_chart_db");
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;


                line.Width.Pixel(600);
                line.Height.Pixel(400);

                line.Data.Source = model;
                line.Data.CategoryField("Month Name");

                line.Values.Show = false;

                ViewData["Chart"] = line.Render();

            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult RowFilters()
        {
            //ViewData["Chart"] = "OK";
            //return View();

            DataTable dt = new DataTable();
            string query = "select P.Name,P.SellEndDate,SUM(P.OrderQty *P.UnitPrice)as [Sales Amount], SUM(P.SafetyStockLevel) as [SafetyStockLevel] from dbo.SalesOrderDetails as P group by P.Name,P.SellEndDate";


            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }
                }

                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                model = model.Where("Name starts with M or Name starts with L and SafetyStockLevel is between 20000 to 50000 and SellEndDate = 2003-06-30 or SellEndDate = 2002-06-30");
                Charts.LineChart line = new Charts.LineChart("line_chart_db");
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;


                line.Width.Pixel(600);
                line.Height.Pixel(450);

                line.Data.Source = model;
                line.Data.CategoryField("SellEndDate");
                line.Data.SeriesFields("SafetyStockLevel", "Sales Amount");

                line.Values.Show = false;

                ViewData["Chart"] = line.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult PivotOperation()
        {
            //ViewData["Chart"] = "OK";
            //return View();

            DataTable dt = new DataTable();
            string query = "select P.Name,P.SellEndDate,SUM(P.OrderQty *P.UnitPrice)as [Sales Amount], SUM(P.SafetyStockLevel) as [SafetyStockLevel] from dbo.SalesOrderDetails as P group by P.Name,P.SellEndDate";


            dt.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                    }
                }

                StaticSource source = new StaticSource(dt);
                DataModel model = new DataModel();
                model.DataSources.Add(source);
                GroupColumn row = new GroupColumn
                {
                    {"Name" }
                };
                GroupColumn column = new GroupColumn
                {
                    {"SellEndDate",GroupColumn.DateGrouping.HALFYEAR }
                };
                Aggregation aggregate = new Aggregation
                {
                    {"Sales Amount",Aggregation.Function.SUM }
                };
                model = model.Pivot(row, column, aggregate);
                Charts.ColumnChart columnChart = new Charts.ColumnChart("column_chart_pivot_db");
                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;


                columnChart.Width.Pixel(600);
                columnChart.Height.Pixel(450);

                columnChart.Data.Source = model;
                //columnChart.Data.CategoryField("SellEndDate");
                //columnChart.Data.SeriesFields("SafetyStockLevel", "Sales Amount");

                columnChart.Values.Show = false;

                ViewData["Chart"] = columnChart.Render();
            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }

        public ActionResult CalculatedColumnsExample()
        {
            JsonFileSource jsonFileSource = new JsonFileSource("https://raw.githubusercontent.com/poushali-guha-12/SampleData/master/CarPurchaseData.json");
            DataModel model = new DataModel();
            model.DataSources.Add(jsonFileSource);
            CalculatedColumns calculatedColumns = new CalculatedColumns
            {
                {"[Order Quantity] * [Unit Price]","Sales" }
            };
            model = model.AddNewCalculatedColumns(calculatedColumns).SelectColumn("Car Model", "Sales");
            Charts.ColumnChart column = new Charts.ColumnChart("chart");
            column.Width.Pixel(600);
            column.Height.Pixel(450);
            column.Data.Source = model;
            ViewData["Chart"] = column.Render();

            return View();
        }

        #endregion

        #region Page level theme
        public ActionResult CommonTheme()
        {
            DataTable pieData = new DataTable();
            DataTable pyramidData = new DataTable();
            string pieQuerystring = "select * from dbo.TerriToryWiseSales";
            string pyramidQueryString = "select [Designation Group], SUM([Total Employess]) as [Total Employess] from dbo.GroupWiseEmployeeCount group by [Designation Group]";

            pieData.Clear();
            pyramidData.Clear();



            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(pieQuerystring, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(pieData);

                    }
                    using (SqlCommand command = new SqlCommand(pyramidQueryString, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(pyramidData);

                    }

                }

                DataModel pieModel = new DataModel();
                StaticSource pieSource = new StaticSource(pieData);
                pieModel.DataSources.Add(pieSource);

                DataModel pyramidModel = new DataModel();
                StaticSource pyramidSource = new StaticSource(pyramidData);
                pyramidModel.DataSources.Add(pyramidSource);

                Charts.PieChart pie = new Charts.PieChart("piecharts");
                pie.ThreeD = true;
                pie.Data.Source = pieModel;

                Widget.PyramidChart pyramid = new Widget.PyramidChart("pyramidchart");
                pyramid.Data.Source = pyramidModel;

                pie.Width.Pixel(300);
                pie.Height.Pixel(450);

                pyramid.Width.Pixel(300);
                pyramid.Height.Pixel(450);

                PageLevelTheme.Theme = FusionChartsTheme.ThemeName.ZUNE;

                pie.Values.Show = false;
                pyramid.Values.Show = false;


                ViewData["Chart1"] = pie.Render();
                ViewData["Chart2"] = pyramid.Render();


            }
            catch (Exception ex)
            {
                ViewData["Chart"] = ex.Message;
            }

            return View();
        }
        #endregion

        #region timeseries exapmle
        public ActionResult TimeSeriesSingleSeries()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Single series Time series chart";
            Charts.TimeSeriesChart timeSeries = new Charts.TimeSeriesChart("first_timeseries");
            timeSeries.Data.SourcePathHandler = @"TimeSeriesDataHandler";
            timeSeries.Width.Pixel(700);
            timeSeries.Height.Pixel(500);
            ViewData["Chart"] = timeSeries.Render();
            return View();
        }
        public ActionResult TimeSeriesMultiSeries()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Single series Time series chart";
            Charts.TimeSeriesChart timeSeries = new Charts.TimeSeriesChart("first_timeseries");
            timeSeries.YAxes.Plot.Add("Total Purchase");
            timeSeries.SeriesName = "Country";
            timeSeries.Data.SourcePathHandler = @"MultiSeriesDataHandler";
            timeSeries.Width.Pixel(700);
            timeSeries.Height.Pixel(500);
            ViewData["Chart"] = timeSeries.Render();
            return View();
        }
        public ActionResult TimeSeriesMultiVariate()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Multi variate Time series chart";
            Charts.TimeSeriesChart timeSeries = new Charts.TimeSeriesChart("first_timeseries");

            timeSeries.Data.SourcePathHandler = @"TimeSeriesMultiVariateData";
            timeSeries.Width.Pixel(700);
            timeSeries.Height.Pixel(700);
            ViewData["Chart"] = timeSeries.Render();
            return View();
        }
        public ActionResult TimeSeriesDualY()
        {

            ViewData["Title"] = "FusionCharts asp.net csharp wrapper samples in MVC6";
            ViewData["Message"] = "Single series Time series chart";
            Charts.TimeSeriesChart timeSeries = new Charts.TimeSeriesChart("first_timeseries");

            timeSeries.Data.SourcePathHandler = @"TimeSeriesMultiVariateData";
            timeSeries.Width.Pixel(700);
            timeSeries.Height.Pixel(700);
            timeSeries.MultiCanvas.Enable = false;
            ViewData["Chart"] = timeSeries.Render();
            return View();
        }
        #endregion
        #region data handler 
        public ActionResult TimeSeriesMultiVariateData()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
            MsSqlClass msSqlClass = new MsSqlClass(connectionString, DataBaseClass.SourceType.TABLE, "SalesDetails");
            DataModel model = new DataModel();
            model.DataSources.Add(msSqlClass);

            return Content(TimeSeriesData.RenderCompatibleDataInJson(model), "text/json");
        }
        public ActionResult TimeSeriesDataHandler()
        {
            // context.Response.ContentType = "text/plain";
            //string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
            MsSqlClass msSqlClass = new MsSqlClass(connectionString, DataBaseClass.SourceType.TABLE, "DailySalesData");
            DataModel model = new DataModel();
            model.DataSources.Add(msSqlClass);

            // context.Response.Write(TimeSeriesData.RenderCompatibleDataInJson(model));

            return Content(TimeSeriesData.RenderCompatibleDataInJson(model), "text/json");
        }
        public ActionResult MultiSeriesDataHandler()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
            MsSqlClass msSqlClass = new MsSqlClass(connectionString, DataBaseClass.SourceType.TABLE, "CountrySalesData");
            DataModel model = new DataModel();
            model.DataSources.Add(msSqlClass);
            return Content(TimeSeriesData.RenderCompatibleDataInJson(model), "text/json");
        }
        #endregion

    }
}
