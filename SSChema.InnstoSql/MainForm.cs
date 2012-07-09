using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

using WizardBase;

namespace SSChema.InnstoSql
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void wizardControl1_NextButtonClick<T>(object sender, GenericCancelEventArgs<T> e)
        {
            WizardControl wc = e.Value as WizardControl;

            if (wc.CurrentStepIndex == 1)
            {
                try
                {
                    this.wizardControl1.NextButtonEnabled = false;

                    this.labelInfo.Text = "正在执行数据库脚本...";

                    ServerConnection sCon = new ServerConnection();

                    sCon.ServerInstance = this.textBoxDBAddress.Text.Trim();
                    sCon.LoginSecure = false;
                    sCon.Login = this.textBoxDbUserName.Text.Trim();
                    sCon.Password = this.textBoxDBPassword.Text.Trim();

                    //Server dbServer = new Server(sCon);

                    Microsoft.SqlServer.Management.Smo.Server dbServer = new Microsoft.SqlServer.Management.Smo.Server(sCon);

                    Database db = dbServer.Databases[this.textBoxDBName.Text.Trim()];

                    Scripter scr = new Scripter(dbServer);

                    db.ExecuteNonQuery(GetSqlScripts());

                    this.labelInfo.Text = "数据库脚本执行完成\n安装成功";

                    this.wizardControl1.NextButtonEnabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.labelInfo.Text = ex.Message;

                    this.wizardControl1.NextButtonEnabled = true;
                }

            }
        }

        private string GetSqlScripts()
        {
            string sql = "";

            string path = System.Environment.CurrentDirectory;

            if (!path.EndsWith("\\"))
                path += "\\";

            path += "install.sql";

            if (File.Exists(path))
            {
                FileInfo file = new FileInfo(path);

                return file.OpenText().ReadToEnd();
            }

            return sql;
        }

        private void wizardControl1_FinishButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
