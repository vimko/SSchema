using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSChema.Controller
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                string dbinfo = "";

                dbinfo = string.Format("server={0};database=master", this.textBoxServerName.Text.Trim());

                if (this.comboBoxAuthType.SelectedIndex == 0)
                    dbinfo = string.Format("{0};Integrated Security=SSPI", dbinfo);
                else if (this.comboBoxAuthType.SelectedIndex == 1)
                    dbinfo = string.Format("{0};uid={1};pwd={2}", dbinfo, this.textBoxDbUserName.Text.Trim(), this.textBoxPassword.Text.Trim());

                string exePath = System.IO.Path.Combine(
        Environment.CurrentDirectory, "SSChema.Services.exe");

                System.Configuration.Configuration conf = System.Configuration.ConfigurationManager.OpenExeConfiguration(exePath);

                conf.ConnectionStrings.ConnectionStrings["DataBaseConString"].ConnectionString = SSChema.Common.StringEncrypt.Encode(dbinfo);

                //其它配置
                conf.AppSettings.Settings["httpurl"].Value = SSChema.Common.StringEncrypt.Encode(this.textBoxHttp.Text);
                conf.AppSettings.Settings["token"].Value = SSChema.Common.StringEncrypt.Encode(this.textBoxtoken.Text);

                conf.Save();

                MessageBox.Show("操作成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败\n" + ee.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }

        private void comboBoxAuthType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxAuthType.SelectedIndex == 0)
            {
                this.label3.Enabled = false;
                this.label4.Enabled = false;
                this.textBoxDbUserName.Enabled = false;
                this.textBoxPassword.Enabled = false;
            }
            else if (this.comboBoxAuthType.SelectedIndex == 1)
            {
                this.label3.Enabled = true;
                this.label4.Enabled = true;
                this.textBoxDbUserName.Enabled = true;
                this.textBoxPassword.Enabled = true;
            }
        }

        /// <summary>
        /// 窗口加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigForm_Load(object sender, EventArgs e)
        {

            try
            {
                string exePath = System.IO.Path.Combine(
        Environment.CurrentDirectory, "SSChema.Services.exe");

                System.Configuration.Configuration conf = System.Configuration.ConfigurationManager.OpenExeConfiguration(exePath);

                string dbinfo = SSChema.Common.StringEncrypt.Decode(conf.ConnectionStrings.ConnectionStrings["DataBaseConString"].ConnectionString);


                string[] dbInfo = dbinfo.Split(';');

                Dictionary<string, string> dbDic = new Dictionary<string, string>();
                string[] strMate = new string[2];

                foreach (var item in dbInfo)
                {
                    strMate = item.Split('=');

                    dbDic.Add(strMate[0], strMate[1]);
                }

                this.textBoxServerName.Text = dbDic["server"];

                if (dbDic.ContainsKey("Integrated Security"))
                {
                    this.label3.Enabled = false;
                    this.label4.Enabled = false;
                    this.textBoxPassword.Enabled = false;
                    this.textBoxDbUserName.Enabled = false;

                    this.comboBoxAuthType.SelectedIndex = 0;
                }
                else
                {
                    this.comboBoxAuthType.SelectedIndex = 1;

                    this.textBoxDbUserName.Text = dbDic["uid"];
                    this.textBoxPassword.Text = dbDic["pwd"];

                    this.label3.Enabled = true;
                    this.label4.Enabled = true;
                    this.textBoxPassword.Enabled = true;
                    this.textBoxDbUserName.Enabled = true;
                }

                //其它配置
                this.textBoxHttp.Text = SSChema.Common.StringEncrypt.Decode(conf.AppSettings.Settings["httpurl"].Value);
                this.textBoxtoken.Text = SSChema.Common.StringEncrypt.Decode(conf.AppSettings.Settings["token"].Value);
            }
            catch (Exception ee)
            {

                MessageBox.Show("操作失败\n" + ee.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
