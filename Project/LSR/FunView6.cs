using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSR
{
    public partial class FunView6 : DevExpress.XtraEditors.XtraUserControl
    {
        public FunView6()
        {
            InitializeComponent();
        }

        // 获取今天是第n天
        private int n;

        //记忆持度
        //已规划 记忆度低 中 高 极高
        private void FunView6_Load(object sender, EventArgs e)
        {
            SqliteManager sqliteManager = new SqliteManager();
            n = sqliteManager.getLearningDate();

            // Create a line series.
            Series series1 = new Series("已规划", ViewType.Line);
            Series series2 = new Series("记忆度低", ViewType.Line);
            Series series3 = new Series("记忆度中", ViewType.Line);
            Series series4 = new Series("记忆度高", ViewType.Line);
            Series series5 = new Series("记忆度极高", ViewType.Line);


            // Add points to it.
            series1.DataSource = totalWords();

            // Specify data members to bind the series.
            series1.ArgumentScaleType = ScaleType.Auto;
            series1.ArgumentDataMember = "Time";
            series1.ValueScaleType = ScaleType.Numerical;
            series1.ValueDataMembers.AddRange(new string[] { "Value" });


            // Access the view-type-specific options of the series.
            //((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Triangle;
            //((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash;

            series2.DataSource = tenDays();

            series2.ArgumentScaleType = ScaleType.Auto;
            series2.ArgumentDataMember = "Time";
            series2.ValueScaleType = ScaleType.Numerical;
            series2.ValueDataMembers.AddRange(new string[] { "Value" });


            series3.DataSource = thirtyDays();
            series3.ArgumentScaleType = ScaleType.Auto;
            series3.ArgumentDataMember = "Time";
            series3.ValueScaleType = ScaleType.Numerical;
            series3.ValueDataMembers.AddRange(new string[] { "Value" });


            series4.DataSource = sistyDays();
            series4.ArgumentScaleType = ScaleType.Auto;
            series4.ArgumentDataMember = "Time";
            series4.ValueScaleType = ScaleType.Numerical;
            series4.ValueDataMembers.AddRange(new string[] { "Value" });


            series5.DataSource = nintyDays();
            series5.ArgumentScaleType = ScaleType.Auto;
            series5.ArgumentDataMember = "Time";
            series5.ValueScaleType = ScaleType.Numerical;
            series5.ValueDataMembers.AddRange(new string[] { "Value" });

            // Add the series to the chart.
            lineChart.Series.AddRange(new Series[] {
                series1,
                series2,
                series3,
                series4,
                series5
            });

            // Access the type-specific options of the diagram.
            ((XYDiagram)lineChart.Diagram).EnableAxisXZooming = false;

            // Hide the legend (if necessary).
            lineChart.Legend.Visible = true;

            // Add a title to the chart (if necessary).
            lineChart.Titles.Add(new ChartTitle());
            lineChart.Titles[0].Text = "记忆持久度";

            // Add the chart to the form.
            //lineChart.Dock = DockStyle.Fill;
            this.Controls.Add(lineChart);
        }

        private DataTable totalWords()
        {
            SqliteManager sqliteManager = new SqliteManager();
            // Create an empty table.
            DataTable table = new DataTable("已规划单词");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));


            // Add data rows to the table.
            DataRow row;

            for (int i = n; i >= 0; i--)
            {
                row = table.NewRow();
                if (i == 0)
                {
                    row["Time"] = "今天";
                }
                else if (i == 1)
                {
                    row["Time"] = "昨天";
                }
                else if (i == 2)
                {
                    row["Time"] = "前天";
                }
                else
                {
                    row["Time"] = i + "天前";
                }

                row["Value"] = sqliteManager.getWordsNum(i);
                
                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable tenDays()
        {
            SqliteManager sqliteManager = new SqliteManager();
            // Create an empty table.
            DataTable table = new DataTable("记忆度低");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            // Add data rows to the table.
            DataRow row;

            for (int i = n; i >= 0; i--)
            {
                row = table.NewRow();
                if (i == 0)
                {
                    row["Time"] = "今天";
                }
                else if (i == 1)
                {
                    row["Time"] = "昨天";
                }
                else if (i == 2)
                {
                    row["Time"] = "前天";
                }
                else
                {
                    row["Time"] = i + "天前";
                }

                row["Value"] = sqliteManager.lastingTime(i,10);

                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable thirtyDays()
        {
            SqliteManager sqliteManager = new SqliteManager();
            // Create an empty table.
            DataTable table = new DataTable("记忆度中");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            // Add data rows to the table.
            DataRow row;

            for (int i = n; i >= 0; i--)
            {
                row = table.NewRow();
                if (i == 0)
                {
                    row["Time"] = "今天";
                }
                else if (i == 1)
                {
                    row["Time"] = "昨天";
                }
                else if (i == 2)
                {
                    row["Time"] = "前天";
                }
                else
                {
                    row["Time"] = i + "天前";
                }

                row["Value"] = sqliteManager.lastingTime(i, 30);

                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable sistyDays()
        {
            SqliteManager sqliteManager = new SqliteManager();
            // Create an empty table.
            DataTable table = new DataTable("记忆度高");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            // 获取今天是第n天
            int n;
            n = sqliteManager.getLearningDate();

            // Add data rows to the table.
            DataRow row;

            for (int i = n; i >= 0; i--)
            {
                row = table.NewRow();
                if (i == 0)
                {
                    row["Time"] = "今天";
                }
                else if (i == 1)
                {
                    row["Time"] = "昨天";
                }
                else if (i == 2)
                {
                    row["Time"] = "前天";
                }
                else
                {
                    row["Time"] = i + "天前";
                }

                row["Value"] = sqliteManager.lastingTime(i, 60);

                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable nintyDays()
        {
            SqliteManager sqliteManager = new SqliteManager();
            // Create an empty table.
            DataTable table = new DataTable("记忆度极高");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            // Add data rows to the table.
            DataRow row;

            for (int i = n; i >= 0; i--)
            {
                row = table.NewRow();
                if (i == 0)
                {
                    row["Time"] = "今天";
                }
                else if (i == 1)
                {
                    row["Time"] = "昨天";
                }
                else if (i == 2)
                {
                    row["Time"] = "前天";
                }
                else
                {
                    row["Time"] = i + "天前";
                }

                row["Value"] = sqliteManager.lastingTime(i, 90);

                table.Rows.Add(row);
            }

            return table;
        }

    }
}
