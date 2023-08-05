using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BDA_V4._0
{
    class clsGlobe
    {
        #region 檔案相關參數
        public static int FileNum; //檔案數量
        public static string FileType = "未偵測"; //檔案類型 
        public static string ExportPath;
        public static double ChartMaximumSize;
        public static double ChartMinimumSize;

        #endregion

        #region 讀取位置之參數

        public static int pMaxV;   //最高電壓位置 
        public static int pMinV;   //最低電壓位置
        public static int pMaxT;   //最高溫度位置
        #endregion

        #region 存放資料之列表

        public static path _path = new path(); //檔案路徑列表
        public static MaxVoltage lmaxVoltage = new MaxVoltage(); //最高電壓列表
        public static MinVoltage lminVoltage = new MinVoltage(); //最低電壓列表
        public static MaxTem lmaxTem = new MaxTem();             //最高溫度列表
        public static memory_list Memory_ = new memory_list();   //記憶體暫存列表
        #endregion

        //宣告函式庫(函式 and 列表
        public static _clsGlobe _ClsGlobe = new _clsGlobe();
    }
    public enum ePage
    {
        Null,
        home,
        database,
        chart,
        setting,
        clear
    }

    public enum eFunction
    {
        Null,
        clear,
        search,
        read,
        autoDet,
    }
    public class _clsGlobe
    {
        //SearchFile
        public void subSearchFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = $"讀取檔案";
            openFile.Multiselect = true;
            openFile.Filter = "xls Files(*.xls; *.xlsx;*.csv;)| *.xls; *.xlsx; *.csv;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (String _file in openFile.FileNames)
                {
                    clsGlobe._path._Lpath.Add(_file);
                    clsGlobe.FileNum += 1;
                    if (clsGlobe.FileType == "未偵測")
                    {
                        if (_file.Contains("BCE"))
                        {
                            clsGlobe.FileType = "BCU";
                        }
                        else if (_file.Contains("BME"))
                        {
                            clsGlobe.FileType = "BMU";
                        }
                        else
                        {
                            clsGlobe.FileType = "未偵測";
                        }
                    }
                }
            }
        } 

        //ReadFileToMemory
        public void subReadFile(string path, int pMaxVoltage, int pMinVoltage, int pMaxTemperature) // 最高電壓、最低電壓、最高溫度、SOC
        {
            try
            {
                var reader = new StreamReader(File.OpenRead(path));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    clsGlobe.Memory_.a.Add(values[pMaxVoltage]);
                    clsGlobe.Memory_.b.Add(values[pMinVoltage]);
                    clsGlobe.Memory_.c.Add(values[pMaxTemperature]);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("請檢察檔案是否重複開啟" +"\n" + ex.ToString());
            }
        }
        public void subPostionSetting(string _File, int p1, int p2, int p3, int p4)
        {
            try
            {
                var reader = new StreamReader(File.OpenRead(_File));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    clsGlobe.Memory_.a.Add(values[p1]);
                    clsGlobe.Memory_.b.Add(values[p2]);
                    clsGlobe.Memory_.c.Add(values[p3]);
                    clsGlobe.Memory_.d.Add(values[p4]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("請檢察檔案是否重複開啟" + "\n" + ex.ToString());
            }
        }
        //MemoryToList
        public void subReCheckReadFile(int FileIndex)
        {
            for(int i = 1; i < clsGlobe.Memory_.a.Count - 2; i++)
            {
                clsGlobe.lmaxVoltage.lMaxVoltage[FileIndex].Add(Convert.ToDouble(clsGlobe.Memory_.a[i]));
            }
            for (int i = 1; i < clsGlobe.Memory_.b.Count - 2; i++)
            {
                clsGlobe.lminVoltage.lMinVoltage[FileIndex].Add(Convert.ToDouble(clsGlobe.Memory_.b[i]));
            }
            for (int i = 1; i < clsGlobe.Memory_.c.Count - 2; i++)
            {
                clsGlobe.lmaxTem.lMaxTem[FileIndex].Add(Convert.ToDouble(clsGlobe.Memory_.c[i]));
            }
            clsGlobe.Memory_.a.Clear();
            clsGlobe.Memory_.b.Clear();
            clsGlobe.Memory_.c.Clear();
        }

        // Clear_All
        public void subClear()
        {
            clsGlobe._path._Lpath.Clear();
            clsGlobe.Memory_.a.Clear();
            clsGlobe.Memory_.b.Clear();
            clsGlobe.Memory_.c.Clear();

            for(int i = 0; i <= clsGlobe.FileNum - 1; i++)
            {
                clsGlobe.lmaxVoltage.lMaxVoltage[i].Clear();
                clsGlobe.lminVoltage.lMinVoltage[i].Clear();
                clsGlobe.lmaxTem.lMaxTem[i].Clear();
            }


            clsGlobe.lmaxVoltage.mMaxVoltage.Clear();
            clsGlobe.lminVoltage.mMinVoltage.Clear();
            clsGlobe.lmaxTem.mMaxTem.Clear();

            clsGlobe._ClsGlobe.subMaxVoltageList();
            clsGlobe._ClsGlobe.subMinVoltageList();
            clsGlobe._ClsGlobe.subMaxTemList();
            clsGlobe.FileNum = 0;
        }

        public void subMemoryClear()
        {
            clsGlobe.Memory_.a.Clear();
            clsGlobe.Memory_.b.Clear();
            clsGlobe.Memory_.c.Clear();
        }
        //Catch_Maxiumn
        public void subCatch()
        {
            for (int i = 0; i <= clsGlobe.FileNum - 1; i++)
            {
                clsGlobe.lmaxVoltage.mMaxVoltage.Add(clsGlobe.lmaxVoltage.lMaxVoltage[i].Max());
                clsGlobe.lminVoltage.mMinVoltage.Add(clsGlobe.lminVoltage.lMinVoltage[i].Min());
                clsGlobe.lmaxTem.mMaxTem.Add(clsGlobe.lmaxTem.lMaxTem[i].Max());
            }
        }

        //Creat_MaxVoltage_List
        public void subMaxVoltageList()
        {
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_1);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_2);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_3);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_4);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_5);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_6);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_7);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_8);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_9);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_10);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_11);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_12);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_13);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_14);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_15);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_16);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_17);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_18);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_19);
            clsGlobe.lmaxVoltage.lMaxVoltage.Add(clsGlobe.lmaxVoltage.MaxV_20);
        }

        //Creat_MinVoltage_List
        public void subMinVoltageList()
        {
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_1);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_2);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_3);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_4);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_5);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_6);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_7);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_8);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_9);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_10);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_11);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_12);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_13);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_14);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_15);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_16);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_17);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_18);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_19);
            clsGlobe.lminVoltage.lMinVoltage.Add(clsGlobe.lminVoltage.MinV_20);
        }

        //Creat_MaxTemperture_List
        public void subMaxTemList()
        {
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_1);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_2);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_3);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_4);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_5);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_6);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_7);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_8);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_9);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_10);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_11);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_12);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_13);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_14);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_15);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_16);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_17);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_18);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_19);
            clsGlobe.lmaxTem.lMaxTem.Add(clsGlobe.lmaxTem.MaxT_20);
        }
    }
    #region List類別
    public class path
    {
        public List<string> _Lpath = new List<string>();
    }
    public class MaxVoltage
    {
        public List<List<double>> lMaxVoltage = new List<List<double>>();
        public List<double> mMaxVoltage = new List<double>();
        public List<double> MaxV_1 = new List<double>();
        public List<double> MaxV_2 = new List<double>();
        public List<double> MaxV_3 = new List<double>();
        public List<double> MaxV_4 = new List<double>();
        public List<double> MaxV_5 = new List<double>();
        public List<double> MaxV_6 = new List<double>();
        public List<double> MaxV_7 = new List<double>();
        public List<double> MaxV_8 = new List<double>();
        public List<double> MaxV_9 = new List<double>();
        public List<double> MaxV_10 = new List<double>();
        public List<double> MaxV_11 = new List<double>();
        public List<double> MaxV_12 = new List<double>();
        public List<double> MaxV_13 = new List<double>();
        public List<double> MaxV_14 = new List<double>();
        public List<double> MaxV_15 = new List<double>();
        public List<double> MaxV_16 = new List<double>();
        public List<double> MaxV_17 = new List<double>();
        public List<double> MaxV_18 = new List<double>();
        public List<double> MaxV_19 = new List<double>();
        public List<double> MaxV_20 = new List<double>();
    }

    public class MinVoltage
    {
        public List<List<double>> lMinVoltage = new List<List<double>>();
        public List<double> mMinVoltage = new List<double>();
        public List<double> MinV_1 = new List<double>();
        public List<double> MinV_2 = new List<double>();
        public List<double> MinV_3 = new List<double>();
        public List<double> MinV_4 = new List<double>();
        public List<double> MinV_5 = new List<double>();
        public List<double> MinV_6 = new List<double>();
        public List<double> MinV_7 = new List<double>();
        public List<double> MinV_8 = new List<double>();
        public List<double> MinV_9 = new List<double>();
        public List<double> MinV_10 = new List<double>();
        public List<double> MinV_11 = new List<double>();
        public List<double> MinV_12 = new List<double>();
        public List<double> MinV_13 = new List<double>();
        public List<double> MinV_14 = new List<double>();
        public List<double> MinV_15 = new List<double>();
        public List<double> MinV_16 = new List<double>();
        public List<double> MinV_17 = new List<double>();
        public List<double> MinV_18 = new List<double>();
        public List<double> MinV_19 = new List<double>();
        public List<double> MinV_20 = new List<double>();
    }

    public class MaxTem
    {
        public List<List<double>> lMaxTem = new List<List<double>>();
        public List<double> mMaxTem = new List<double>();
        public List<double> MaxT_1 = new List<double>();
        public List<double> MaxT_2 = new List<double>();
        public List<double> MaxT_3 = new List<double>();
        public List<double> MaxT_4 = new List<double>();
        public List<double> MaxT_5 = new List<double>();
        public List<double> MaxT_6 = new List<double>();
        public List<double> MaxT_7 = new List<double>();
        public List<double> MaxT_8 = new List<double>();
        public List<double> MaxT_9 = new List<double>();
        public List<double> MaxT_10 = new List<double>();
        public List<double> MaxT_11 = new List<double>();
        public List<double> MaxT_12 = new List<double>();
        public List<double> MaxT_13 = new List<double>();
        public List<double> MaxT_14 = new List<double>();
        public List<double> MaxT_15 = new List<double>();
        public List<double> MaxT_16 = new List<double>();
        public List<double> MaxT_17 = new List<double>();
        public List<double> MaxT_18 = new List<double>();
        public List<double> MaxT_19 = new List<double>();
        public List<double> MaxT_20 = new List<double>();
    }
    public class memory_list
    {
        public List<string> a = new List<string>();
        public List<string> b = new List<string>();
        public List<string> c = new List<string>();
        public List<string> d = new List<string>();
    }

    #region List<string>
    //public class MaxVoltage
    //{
    //    public List<List<string>> lMaxVoltage = new List<List<string>>();
    //    public List<string> mMaxVoltage = new List<string>();
    //    public List<string> MaxV_1 = new List<string>();
    //    public List<string> MaxV_2 = new List<string>();
    //    public List<string> MaxV_3 = new List<string>();
    //    public List<string> MaxV_4 = new List<string>();
    //    public List<string> MaxV_5 = new List<string>();
    //    public List<string> MaxV_6 = new List<string>();
    //    public List<string> MaxV_7 = new List<string>();
    //    public List<string> MaxV_8 = new List<string>();
    //    public List<string> MaxV_9 = new List<string>();
    //    public List<string> MaxV_10 = new List<string>();
    //    public List<string> MaxV_11 = new List<string>();
    //    public List<string> MaxV_12 = new List<string>();
    //    public List<string> MaxV_13 = new List<string>();
    //    public List<string> MaxV_14 = new List<string>();
    //    public List<string> MaxV_15 = new List<string>();
    //    public List<string> MaxV_16 = new List<string>();
    //    public List<string> MaxV_17 = new List<string>();
    //    public List<string> MaxV_18 = new List<string>();
    //    public List<string> MaxV_19 = new List<string>();
    //    public List<string> MaxV_20 = new List<string>();
    //}

    //public class MinVoltage
    //{
    //    public List<List<string>> lMinVoltage = new List<List<string>>();
    //    public List<string> mMinVoltage = new List<string>();
    //    public List<string> MinV_1 = new List<string>();
    //    public List<string> MinV_2 = new List<string>();
    //    public List<string> MinV_3 = new List<string>();
    //    public List<string> MinV_4 = new List<string>();
    //    public List<string> MinV_5 = new List<string>();
    //    public List<string> MinV_6 = new List<string>();
    //    public List<string> MinV_7 = new List<string>();
    //    public List<string> MinV_8 = new List<string>();
    //    public List<string> MinV_9 = new List<string>();
    //    public List<string> MinV_10 = new List<string>();
    //    public List<string> MinV_11 = new List<string>();
    //    public List<string> MinV_12 = new List<string>();
    //    public List<string> MinV_13 = new List<string>();
    //    public List<string> MinV_14 = new List<string>();
    //    public List<string> MinV_15 = new List<string>();
    //    public List<string> MinV_16 = new List<string>();
    //    public List<string> MinV_17 = new List<string>();
    //    public List<string> MinV_18 = new List<string>();
    //    public List<string> MinV_19 = new List<string>();
    //    public List<string> MinV_20 = new List<string>();
    //}

    //public class MaxTem
    //{
    //    public List<List<string>> lMaxTem = new List<List<string>>();
    //    public List<string> mMaxTem = new List<string>();
    //    public List<string> MaxT_1 = new List<string>();
    //    public List<string> MaxT_2 = new List<string>();
    //    public List<string> MaxT_3 = new List<string>();
    //    public List<string> MaxT_4 = new List<string>();
    //    public List<string> MaxT_5 = new List<string>();
    //    public List<string> MaxT_6 = new List<string>();
    //    public List<string> MaxT_7 = new List<string>();
    //    public List<string> MaxT_8 = new List<string>();
    //    public List<string> MaxT_9 = new List<string>();
    //    public List<string> MaxT_10 = new List<string>();
    //    public List<string> MaxT_11 = new List<string>();
    //    public List<string> MaxT_12 = new List<string>();
    //    public List<string> MaxT_13 = new List<string>();
    //    public List<string> MaxT_14 = new List<string>();
    //    public List<string> MaxT_15 = new List<string>();
    //    public List<string> MaxT_16 = new List<string>();
    //    public List<string> MaxT_17 = new List<string>();
    //    public List<string> MaxT_18 = new List<string>();
    //    public List<string> MaxT_19 = new List<string>();
    //    public List<string> MaxT_20 = new List<string>();
    //} 
    #endregion
    #endregion
}
