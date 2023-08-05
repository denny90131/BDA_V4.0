using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDA_V4._0
{
    public partial class ucChart : UserControl
    {
        public ucChart()
        {
            InitializeComponent();
            this.MouseWheel += func_MouseWheel;
        }
        private void Point_Clear(int num)
        {
            for (int i = 0; i <= num - 1; i++)
            {
                chart1.Series[i].Points.Clear();
            }
        }
        public void subClearChart_Form(int fileNum)
        {
            if (clsGlobe.FileNum != 0)
            {
                Point_Clear(clsGlobe.FileNum);
                cbTitle.Text = string.Empty;
                chart1.DataBind();
            }
        }
        //圖表最大值與最小值存取與帶入
        private void subSettingChartSetting(double max, double mini)
        {
            chart1.ChartAreas[0].AxisY.Maximum = max;
            chart1.ChartAreas[0].AxisY.Minimum = mini;
        }
        private void func_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            double Y_Max = chart1.ChartAreas[0].AxisY.Maximum;
            double Y_Min = chart1.ChartAreas[0].AxisY.Minimum;
            bool _switch_falut = false;
            if (e.Delta > 0)
            {
                if (Y_Max - Y_Min > 50)
                {
                    _switch_falut = false;
                    if (_switch_falut == false)
                    {
                        chart1.ChartAreas[0].AxisY.Maximum -= e.Delta / 10;
                        chart1.ChartAreas[0].AxisY.Minimum += e.Delta / 10;
                    }
                }
                else
                {
                    _switch_falut = true;
                }
            }
            else if (e.Delta < 0)
            {
                chart1.ChartAreas[0].AxisY.Maximum -= e.Delta / 10;
                chart1.ChartAreas[0].AxisY.Minimum += e.Delta / 10;
            }
        }//滾輪改變圖表大小

        private void ucChart_Load(object sender, EventArgs e)
        {
            string[] array_BCU = { "最高單體電壓", "最低單體電壓", "最高單體溫度" };
            string[] array_BMU = { "最高單體電壓", "最低單體電壓", "最高單體溫度" };
            if (clsGlobe.FileType == "BCU")
            {
                cbTitle.Items.AddRange(array_BCU);
            }
            else
            {
                cbTitle.Items.AddRange(array_BMU);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtExportFileName.Text != string.Empty)
            {
                try
                {
                    FolderBrowserDialog Export = new FolderBrowserDialog();
                    Export.Description = "請寫入資料夾";
                    if (Export.ShowDialog() == DialogResult.OK)
                    {
                        clsGlobe.ExportPath = Export.SelectedPath + "\\" + txtExportFileName.Text + ".png";
                    }
                    chart1.SaveImage(clsGlobe.ExportPath, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                    MessageBox.Show("儲存成功");
                }
                catch
                {
                    MessageBox.Show("存儲失敗");
                }
            }
        }

        private void btnSettingOK_Click(object sender, EventArgs e)
        {
            //Y軸設定
            if (numMaximumSize_Y.Value > numMinimumSize_Y.Value && numMinimumSize_Y.Value != 0)
            {
                clsGlobe.ChartMaximumSize = (double)numMaximumSize_Y.Value;
                clsGlobe.ChartMinimumSize = (double)numMinimumSize_Y.Value;
                subSettingChartSetting(clsGlobe.ChartMaximumSize, clsGlobe.ChartMinimumSize);
            }
            else if (numMaximumSize_Y.Value > numMinimumSize_Y.Value && numMinimumSize_Y.Value == 0)
            {
                numMaximumSize_Y.Value = (decimal)chart1.ChartAreas[0].AxisY.Maximum;
                clsGlobe.ChartMaximumSize = (double)numMaximumSize_Y.Value;
                clsGlobe.ChartMinimumSize = (double)numMinimumSize_Y.Value;
                subSettingChartSetting(clsGlobe.ChartMaximumSize, clsGlobe.ChartMinimumSize);
            }
            else if (numMaximumSize_Y.Value < numMinimumSize_Y.Value && numMaximumSize_Y.Value == 0)
            {
                numMaximumSize_Y.Value = (decimal)chart1.ChartAreas[0].AxisY.Maximum;
                clsGlobe.ChartMaximumSize = (double)numMaximumSize_Y.Value;
                clsGlobe.ChartMinimumSize = (double)numMinimumSize_Y.Value;
                subSettingChartSetting(clsGlobe.ChartMaximumSize, clsGlobe.ChartMinimumSize);
            }
            else if (numMaximumSize_Y.Value < numMinimumSize_Y.Value && numMaximumSize_Y.Value != 0)
            {
                MessageBox.Show("極限值輸入錯誤");
            }

            //X軸設定
            if(numMaximumSize_X.Value > numMinimumSize_X.Value && numMaximumSize_X.Value == 0)
            {
                numMinimumSize_X.Value = (decimal)chart1.ChartAreas[0].AxisX.Minimum;
                chart1.ChartAreas[0].AxisX.Maximum = (double)numMaximumSize_X.Value;
            }
            else if(numMaximumSize_X.Value < numMinimumSize_X.Value && numMaximumSize_X.Value == 0)
            {
                numMaximumSize_X.Value = (decimal)chart1.ChartAreas[0].AxisX.Maximum;
                chart1.ChartAreas[0].AxisX.Minimum = (double)numMinimumSize_X.Value;
            }
            else if(numMinimumSize_X.Value > numMaximumSize_X.Value && numMaximumSize_X.Value != 0)
            {
                MessageBox.Show("極限值輸入錯誤");
            }
            else if(numMaximumSize_X.Value == 0 && numMinimumSize_X.Value == 0)
            {

            }
            else
            {
                chart1.ChartAreas[0].AxisX.Minimum = (double)numMinimumSize_X.Value;
                chart1.ChartAreas[0].AxisX.Maximum = (double)numMaximumSize_X.Value;
            }
        }

        private void cbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clsGlobe.lmaxVoltage.lMaxVoltage[0].Count != 0 && clsGlobe.lminVoltage.lMinVoltage[0].Count != 0 && clsGlobe.lmaxTem.lMaxTem[0].Count != 0)
            {

                try
                {
                    Point_Clear(clsGlobe.FileNum);
                    //if (clsGlobe._SOC.lSOC[0] > clsGlobe._SOC.lSOC[200])
                    //{
                    //    chart1.ChartAreas[0].AxisX.IsReversed = true;
                    //}
                    switch (cbTitle.SelectedIndex)
                    {
                        case 0:
                            {
                                for (int i = 1; i <= clsGlobe.FileNum; i++)
                                {
                                    for (int j = 1; j <= clsGlobe.lmaxVoltage.lMaxVoltage[0].Count - 5; j++)
                                    {
                                        chart1.Series[i - 1].Points.AddXY(j, clsGlobe.lmaxVoltage.lMaxVoltage[i - 1][j]);
                                    }
                                    //clsGlobe._SOC.lSOC[j]
                                }
                                break;
                            }
                        case 1:
                            {
                                for (int i = 1; i <= clsGlobe.FileNum; i++)
                                {
                                    for (int j = 1; j < clsGlobe.lminVoltage.lMinVoltage[0].Count - 5; j++)
                                    {
                                        chart1.Series[i - 1].Points.AddXY(j, clsGlobe.lminVoltage.lMinVoltage[i - 1][j]);
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                for (int i = 1; i <= clsGlobe.FileNum; i++)
                                {
                                    for (int j = 1; j < clsGlobe.lmaxTem.lMaxTem[0].Count - 5; j++)
                                    {
                                        chart1.Series[i - 1].Points.AddXY(j, clsGlobe.lmaxTem.lMaxTem[i - 1][j]);
                                    }
                                }
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("圖表載入失敗");
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
