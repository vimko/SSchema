namespace SSChema.Controller
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "同步服务",
            ""}, 0);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.buttonServices = new System.Windows.Forms.Button();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSController = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemServices = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewServiceStatus = new System.Windows.Forms.ListView();
            this.imageListServerceStatus = new System.Windows.Forms.ImageList(this.components);
            this.buttonPlan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.notifyContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(311, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 27);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 302);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(532, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabel1.Text = "同上服务控制器";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(13, 159);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(414, 136);
            this.listBox2.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(445, 62);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(445, 92);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "启动";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(445, 122);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(445, 152);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(75, 23);
            this.buttonRestart.TabIndex = 7;
            this.buttonRestart.Text = "重新启动";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // buttonServices
            // 
            this.buttonServices.Location = new System.Drawing.Point(445, 182);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(75, 23);
            this.buttonServices.TabIndex = 8;
            this.buttonServices.Text = "服务";
            this.buttonServices.UseVisualStyleBackColor = true;
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            // 
            // buttonConfig
            // 
            this.buttonConfig.Location = new System.Drawing.Point(445, 212);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonConfig.TabIndex = 9;
            this.buttonConfig.Text = "配置";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(445, 272);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "服务状态：";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyContextMenuStrip;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "同步服务控制器";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // notifyContextMenuStrip
            // 
            this.notifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSController,
            this.toolStripMenuItemServices,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.notifyContextMenuStrip.Name = "notifyContextMenuStrip";
            this.notifyContextMenuStrip.Size = new System.Drawing.Size(179, 76);
            // 
            // toolStripMenuItemSController
            // 
            this.toolStripMenuItemSController.Name = "toolStripMenuItemSController";
            this.toolStripMenuItemSController.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemSController.Text = "打开同步服务控制器";
            this.toolStripMenuItemSController.Click += new System.EventHandler(this.toolStripMenuItemSController_Click);
            // 
            // toolStripMenuItemServices
            // 
            this.toolStripMenuItemServices.Name = "toolStripMenuItemServices";
            this.toolStripMenuItemServices.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemServices.Text = "打开服务";
            this.toolStripMenuItemServices.Click += new System.EventHandler(this.toolStripMenuItemServices_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemExit.Text = "退出";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // listViewServiceStatus
            // 
            this.listViewServiceStatus.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listViewServiceStatus.Location = new System.Drawing.Point(13, 62);
            this.listViewServiceStatus.Name = "listViewServiceStatus";
            this.listViewServiceStatus.Size = new System.Drawing.Size(414, 91);
            this.listViewServiceStatus.SmallImageList = this.imageListServerceStatus;
            this.listViewServiceStatus.TabIndex = 12;
            this.listViewServiceStatus.UseCompatibleStateImageBehavior = false;
            this.listViewServiceStatus.View = System.Windows.Forms.View.SmallIcon;
            this.listViewServiceStatus.DoubleClick += new System.EventHandler(this.listViewServiceStatus_DoubleClick);
            // 
            // imageListServerceStatus
            // 
            this.imageListServerceStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListServerceStatus.ImageStream")));
            this.imageListServerceStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListServerceStatus.Images.SetKeyName(0, "play.ico");
            this.imageListServerceStatus.Images.SetKeyName(1, "play_gray.ico");
            // 
            // buttonPlan
            // 
            this.buttonPlan.Location = new System.Drawing.Point(445, 242);
            this.buttonPlan.Name = "buttonPlan";
            this.buttonPlan.Size = new System.Drawing.Size(75, 23);
            this.buttonPlan.TabIndex = 13;
            this.buttonPlan.Text = "执行计划";
            this.buttonPlan.UseVisualStyleBackColor = true;
            this.buttonPlan.Click += new System.EventHandler(this.buttonPlan_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 324);
            this.Controls.Add(this.buttonPlan);
            this.Controls.Add(this.listViewServiceStatus);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonConfig);
            this.Controls.Add(this.buttonServices);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "同步服务控制器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.notifyContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonServices;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSController;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemServices;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListView listViewServiceStatus;
        private System.Windows.Forms.ImageList imageListServerceStatus;
        private System.Windows.Forms.Button buttonPlan;
    }
}

