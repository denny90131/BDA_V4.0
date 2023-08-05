using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace BDA_V4._0
{
    public partial class ucSetting : UserControl
    {
        public List<cls_1>  Postion_Setting = new List<cls_1>();
        DataTable dt = new DataTable();
        public ucSetting()
        {
            InitializeComponent();

        }
        private void ucSetting_Load(object sender, EventArgs e)
        {
            subDataTableDisplay();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtMaxV.Text!="0" && txtMinV.Text!= "0"&& txtMaxT.Text != "0")
            {
                clsGlobe.pMaxV = (Convert.ToInt32(txtMaxV.Text)-1);
                clsGlobe.pMinV = (Convert.ToInt32(txtMinV.Text)-1);
                clsGlobe.pMaxT = (Convert.ToInt32(txtMaxT.Text)-1);
                btnExport.Enabled = true;
            }
            else
            {
                MessageBox.Show("請輸入完整數據");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(txtPostionName.Text != string.Empty)
            {
                using (var writer = new StreamWriter("Postion.csv", true))
                {
                    writer.WriteLine($"{txtPostionName.Text},{clsGlobe.pMaxV + 1},{clsGlobe.pMinV + 1},{clsGlobe.pMaxT + 1}");
                    writer.Close();
                }
                subDataTableDisplay();
                btnExport.Enabled = false;
                txtPostionName.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("請輸入檔案名稱");
            }
        }
        public class cls_1
        {
            public string name;
            public int p1;
            public int p2;
            public int p3;
        }
        private void subDataTableDisplay()
        {
            dt.Columns.Clear();
            dt.Rows.Clear();
            dt.Clear();
            dt.Columns.Add("案場名稱與電控類型");
            dt.Columns.Add("最高電壓位置");
            dt.Columns.Add("最低電壓位置");
            dt.Columns.Add("最高溫度位置");
            clsGlobe._ClsGlobe.subPostionSetting("Postion.csv", 0, 1, 2, 3);
            for (int i = 1; i <= clsGlobe.Memory_.a.Count - 1; i++)
            {
                dt.Rows.Add(clsGlobe.Memory_.a[i], clsGlobe.Memory_.b[i], clsGlobe.Memory_.c[i], clsGlobe.Memory_.d[i]);
            }
            clsGlobe.Memory_.a.Clear();
            clsGlobe.Memory_.b.Clear();
            clsGlobe.Memory_.c.Clear();
            clsGlobe.Memory_.d.Clear();
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
