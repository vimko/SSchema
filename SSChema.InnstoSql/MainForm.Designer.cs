namespace SSChema.InnstoSql
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.wizardControl1 = new WizardBase.WizardControl();
            this.startStep1 = new WizardBase.StartStep();
            this.intermediateStepDBCon = new WizardBase.IntermediateStep();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDBPassword = new System.Windows.Forms.TextBox();
            this.textBoxDbUserName = new System.Windows.Forms.TextBox();
            this.textBoxDBAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.finishStep1 = new WizardBase.FinishStep();
            this.labelInfo = new System.Windows.Forms.Label();
            this.intermediateStepDBCon.SuspendLayout();
            this.finishStep1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.BackButtonEnabled = false;
            this.wizardControl1.BackButtonText = "< 上一步";
            this.wizardControl1.BackButtonVisible = true;
            this.wizardControl1.CancelButtonEnabled = true;
            this.wizardControl1.CancelButtonText = "取消";
            this.wizardControl1.CancelButtonVisible = true;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.EulaButtonEnabled = false;
            this.wizardControl1.EulaButtonText = "eula";
            this.wizardControl1.EulaButtonVisible = false;
            this.wizardControl1.FinishButtonText = "完成";
            this.wizardControl1.HelpButtonEnabled = false;
            this.wizardControl1.HelpButtonText = "帮助";
            this.wizardControl1.HelpButtonVisible = true;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextButtonEnabled = true;
            this.wizardControl1.NextButtonText = "下一步 >";
            this.wizardControl1.NextButtonVisible = true;
            this.wizardControl1.Size = new System.Drawing.Size(476, 334);
            this.wizardControl1.WizardSteps.AddRange(new WizardBase.WizardStep[] {
            this.startStep1,
            this.intermediateStepDBCon,
            this.finishStep1});
            this.wizardControl1.FinishButtonClick += new System.EventHandler(this.wizardControl1_FinishButtonClick);
            this.wizardControl1.NextButtonClick += new WizardBase.GenericCancelEventHandler<WizardBase.WizardControl>(this.wizardControl1_NextButtonClick);
            // 
            // startStep1
            // 
            this.startStep1.BindingImage = ((System.Drawing.Image)(resources.GetObject("startStep1.BindingImage")));
            this.startStep1.Icon = ((System.Drawing.Image)(resources.GetObject("startStep1.Icon")));
            this.startStep1.Name = "startStep1";
            this.startStep1.Subtitle = "提供程序数据库脚本安装指导";
            this.startStep1.Title = "数据库脚本安装指导";
            // 
            // intermediateStepDBCon
            // 
            this.intermediateStepDBCon.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStepDBCon.BindingImage")));
            this.intermediateStepDBCon.Controls.Add(this.textBoxDBName);
            this.intermediateStepDBCon.Controls.Add(this.label4);
            this.intermediateStepDBCon.Controls.Add(this.textBoxDBPassword);
            this.intermediateStepDBCon.Controls.Add(this.textBoxDbUserName);
            this.intermediateStepDBCon.Controls.Add(this.textBoxDBAddress);
            this.intermediateStepDBCon.Controls.Add(this.label3);
            this.intermediateStepDBCon.Controls.Add(this.label2);
            this.intermediateStepDBCon.Controls.Add(this.label1);
            this.intermediateStepDBCon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.intermediateStepDBCon.Name = "intermediateStepDBCon";
            this.intermediateStepDBCon.Subtitle = "输入数据库连接信息";
            this.intermediateStepDBCon.Title = "数据库连接信息";
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(139, 223);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.Size = new System.Drawing.Size(294, 21);
            this.textBoxDBName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "数据库名称：";
            // 
            // textBoxDBPassword
            // 
            this.textBoxDBPassword.Location = new System.Drawing.Point(139, 181);
            this.textBoxDBPassword.Name = "textBoxDBPassword";
            this.textBoxDBPassword.PasswordChar = '*';
            this.textBoxDBPassword.Size = new System.Drawing.Size(294, 21);
            this.textBoxDBPassword.TabIndex = 5;
            // 
            // textBoxDbUserName
            // 
            this.textBoxDbUserName.Location = new System.Drawing.Point(139, 136);
            this.textBoxDbUserName.Name = "textBoxDbUserName";
            this.textBoxDbUserName.Size = new System.Drawing.Size(294, 21);
            this.textBoxDbUserName.TabIndex = 4;
            // 
            // textBoxDBAddress
            // 
            this.textBoxDBAddress.Location = new System.Drawing.Point(139, 91);
            this.textBoxDBAddress.Name = "textBoxDBAddress";
            this.textBoxDBAddress.Size = new System.Drawing.Size(294, 21);
            this.textBoxDBAddress.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库地址：";
            // 
            // finishStep1
            // 
            this.finishStep1.BindingImage = ((System.Drawing.Image)(resources.GetObject("finishStep1.BindingImage")));
            this.finishStep1.Controls.Add(this.labelInfo);
            this.finishStep1.Name = "finishStep1";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(38, 148);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(41, 12);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "label5";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 334);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库脚本安装";
            this.intermediateStepDBCon.ResumeLayout(false);
            this.intermediateStepDBCon.PerformLayout();
            this.finishStep1.ResumeLayout(false);
            this.finishStep1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardBase.StartStep startStep1;
        private WizardBase.IntermediateStep intermediateStepDBCon;
        private WizardBase.FinishStep finishStep1;
        private WizardBase.WizardControl wizardControl1;
        private System.Windows.Forms.TextBox textBoxDBPassword;
        private System.Windows.Forms.TextBox textBoxDbUserName;
        private System.Windows.Forms.TextBox textBoxDBAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDBName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelInfo;
    }
}

