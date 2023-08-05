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

namespace BDA_V4._0
{
    public partial class Form1 : Form
    {
        private ucSetting _ucSetting;
        private ucDataBase _ucDataBase;
        private ucChart _ucChart;
        private ucMain _ucMain;
        public Form1()
        {
            InitializeComponent();
            _ucSetting = new ucSetting();
            _ucDataBase = new ucDataBase();
            _ucChart = new ucChart();
            _ucMain = new ucMain();
            clsGlobe._ClsGlobe.subMaxVoltageList();
            clsGlobe._ClsGlobe.subMinVoltageList();
            clsGlobe._ClsGlobe.subMaxTemList();
            mSelectedPage = ePage.home;
            mSelectedFunction = eFunction.Null;
        }
        private ePage _prePage;
        private ePage mSelectedPage
        {
            get { return _prePage; }
            set
            {
                if (_prePage != value && value != ePage.Null)
                {
                    this.pnlDisplay.Controls.Clear();
                    this.tmrUpdate.Enabled = true;
                    //初始化按鈕配置
                    btnRead.Enabled = false;
                    switch (value)
                    {
                        case ePage.setting:
                            {
                                if(clsGlobe.FileNum != 0)
                                {
                                    btnRead.Enabled = true;
                                }
                                pnlDisplay.Controls.Add(_ucSetting);
                                break;
                            }
                        case ePage.database:
                            {
                                clsGlobe._ClsGlobe.subCatch();
                                _ucDataBase.subClearDatatable();
                                _ucDataBase.subDataBase();
                                pnlDisplay.Controls.Add(_ucDataBase);
                                break;
                            }
                        case ePage.chart:
                            {
                                pnlDisplay.Controls.Add(_ucChart);
                                break;
                            }
                        case ePage.home:
                            {
                                if(clsGlobe.FileNum != 0)
                                {
                                    btnRead.Enabled = true;
                                }
                                pnlDisplay.Controls.Add(_ucMain);
                                break;
                            }
                    }
                }
            }
        }

        private eFunction _preFunction;
        private eFunction mSelectedFunction
        {
            get { return _preFunction; }
            set
            {
                if(value == eFunction.Null)
                {
                    btnClear.Enabled = false;
                    btnRead.Enabled = false;
                    btnDetPostion.Enabled = false;
                    btnDataStatus.Enabled = false;
                    btnChart.Enabled = false;
                }
                else
                {
                    switch (value)
                    {
                        case eFunction.clear:
                            {
                                _ucDataBase.subClearDatatable();
                                _ucChart.subClearChart_Form(clsGlobe.FileNum - 1);
                                clsGlobe._ClsGlobe.subClear();
                                btnClear.Enabled = false;
                                btnRead.Enabled = false;
                                btnChart.Enabled = false;
                                btnDataStatus.Enabled = false;
                                btnSearch.Enabled = true;
                                mSelectedPage = ePage.home;
                                break;
                            }
                        case eFunction.read:
                            {
                                for (int i = 0; i <= clsGlobe.FileNum - 1; i++)
                                {
                                    clsGlobe._ClsGlobe.subReadFile(clsGlobe._path._Lpath[i], clsGlobe.pMaxV, clsGlobe.pMinV, clsGlobe.pMaxT);
                                    clsGlobe._ClsGlobe.subReCheckReadFile(i);
                                }
                                btnChart.Enabled = true;
                                btnDataStatus.Enabled = true;
                                btnRead.Enabled = false;
                                break;
                            }
                        case eFunction.search:
                            {
                                clsGlobe._ClsGlobe.subSearchFile();
                                if (clsGlobe.FileNum != 0)
                                {
                                    btnRead.Enabled = true;
                                    btnClear.Enabled = true;
                                    btnDetPostion.Enabled = true;
                                    btnSearch.Enabled = false;
                                }
                                break;
                            }
                    }
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            mSelectedFunction = eFunction.search;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            lblFileNum.Text = clsGlobe.FileNum.ToString();
            lblType.Text = clsGlobe.FileType;
            this.lblTime.Text = DateTime.Now.ToString();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            mSelectedFunction = eFunction.read;
        }

        private void btnDataStatus_Click(object sender, EventArgs e)
        {
            mSelectedPage = ePage.database;
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            mSelectedPage = ePage.chart;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            mSelectedFunction = eFunction.clear;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            mSelectedPage = ePage.setting;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            mSelectedPage = ePage.home;
        }

    }
}
