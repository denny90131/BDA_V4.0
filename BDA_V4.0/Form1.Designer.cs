
namespace BDA_V4._0
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDetPostion = new System.Windows.Forms.Button();
            this.lblFileNum = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnDataStatus = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DimGray;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Location = new System.Drawing.Point(22, 602);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 81);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "瀏覽";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Location = new System.Drawing.Point(408, 13);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(992, 583);
            this.pnlDisplay.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDetPostion);
            this.groupBox1.Controls.Add(this.lblFileNum);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(22, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 303);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "概覽";
            // 
            // btnDetPostion
            // 
            this.btnDetPostion.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnDetPostion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetPostion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetPostion.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDetPostion.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnDetPostion.Location = new System.Drawing.Point(30, 206);
            this.btnDetPostion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDetPostion.Name = "btnDetPostion";
            this.btnDetPostion.Size = new System.Drawing.Size(293, 71);
            this.btnDetPostion.TabIndex = 18;
            this.btnDetPostion.Text = "自動偵測";
            this.btnDetPostion.UseVisualStyleBackColor = false;
            // 
            // lblFileNum
            // 
            this.lblFileNum.AutoSize = true;
            this.lblFileNum.Location = new System.Drawing.Point(197, 58);
            this.lblFileNum.Name = "lblFileNum";
            this.lblFileNum.Size = new System.Drawing.Size(66, 36);
            this.lblFileNum.TabIndex = 6;
            this.lblFileNum.Text = "999";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(197, 133);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(99, 36);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "未偵測";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "檔案類型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "檔案數量";
            // 
            // btnRead
            // 
            this.btnRead.BackColor = System.Drawing.Color.DimGray;
            this.btnRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRead.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRead.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRead.Location = new System.Drawing.Point(152, 602);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(112, 81);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "讀取";
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(281, 602);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 81);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Gray;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHome.Location = new System.Drawing.Point(408, 602);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(230, 81);
            this.btnHome.TabIndex = 5;
            this.btnHome.Text = "主畫面";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnDataStatus
            // 
            this.btnDataStatus.BackColor = System.Drawing.Color.Gray;
            this.btnDataStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataStatus.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDataStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDataStatus.Location = new System.Drawing.Point(660, 602);
            this.btnDataStatus.Name = "btnDataStatus";
            this.btnDataStatus.Size = new System.Drawing.Size(230, 81);
            this.btnDataStatus.TabIndex = 6;
            this.btnDataStatus.Text = "數據狀態";
            this.btnDataStatus.UseVisualStyleBackColor = false;
            this.btnDataStatus.Click += new System.EventHandler(this.btnDataStatus_Click);
            // 
            // btnChart
            // 
            this.btnChart.BackColor = System.Drawing.Color.Gray;
            this.btnChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChart.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnChart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChart.Location = new System.Drawing.Point(918, 602);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(221, 81);
            this.btnChart.TabIndex = 7;
            this.btnChart.Text = "圖表狀態";
            this.btnChart.UseVisualStyleBackColor = false;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Gray;
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSetting.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSetting.Location = new System.Drawing.Point(1170, 602);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(221, 81);
            this.btnSetting.TabIndex = 8;
            this.btnSetting.Text = "相關設定";
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.Location = new System.Drawing.Point(13, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(342, 50);
            this.label7.TabIndex = 19;
            this.label7.Text = "電池資料分析系統";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.Location = new System.Drawing.Point(20, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(271, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Battary Data anazly system";
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("微軟正黑體", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTime.Location = new System.Drawing.Point(18, 510);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(361, 40);
            this.lblTime.TabIndex = 21;
            this.lblTime.Text = "2023/08/03 下午 09:40";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(1412, 712);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnDataStatus);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlDisplay);
            this.Controls.Add(this.btnSearch);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "秉翰集團出品";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDetPostion;
        private System.Windows.Forms.Label lblFileNum;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnDataStatus;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Label lblTime;
    }
}

