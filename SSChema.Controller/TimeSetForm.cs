using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace SSChema.Controller
{
    public partial class TimeSetForm : Form
    {
        public TimeSetForm()
        {
            InitializeComponent();

            InitForm();
        }

        /// <summary>
        /// 初始化窗口
        /// </summary>
        private void InitForm()
        {
            //初始化控件
            InitControls();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            this.comboBox2.SelectedIndex = 0;
            this.comboBoxExeType.SelectedIndex = 0;
        }




        /// <summary>
        /// 频率选项改变时
        /// </summary>
        private void PlChanged(object sender)
        {
            RadioButton rbutton = sender as RadioButton;

            if (rbutton == null) return;

            if (rbutton.Name == "radioButton1")
            {
                if (radioButton1.Checked == true)
                {
                    dateTimePickerAExeTime.Enabled = true;

                    radioButton2.Checked = false;
                    numericUpDown1.Enabled = false;
                    comboBox2.Enabled = false;
                    dateTimePicker3.Enabled = false;
                    dateTimePicker4.Enabled = false;
                }
                else
                {
                    dateTimePickerAExeTime.Enabled = false;

                    radioButton2.Checked = true;
                    numericUpDown1.Enabled = true;
                    comboBox2.Enabled = true;
                    dateTimePicker3.Enabled = true;
                    dateTimePicker4.Enabled = true;
                }
            }

            else if (rbutton.Name == "radioButton2")
            {
                if (radioButton2.Checked == true)
                {
                    radioButton1.Checked = false;
                    dateTimePickerAExeTime.Enabled = false;

                    numericUpDown1.Enabled = true;
                    comboBox2.Enabled = true;
                    dateTimePicker3.Enabled = true;
                    dateTimePicker4.Enabled = true;
                }
                else
                {
                    radioButton2.Checked = true;
                    dateTimePickerAExeTime.Enabled = true;

                    numericUpDown1.Enabled = false;
                    comboBox2.Enabled = false;
                    dateTimePicker3.Enabled = false;
                    dateTimePicker4.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 起始，结束日期
        /// </summary>
        /// <param name="sender"></param>
        private void BeginAndEndDateChange(object sender)
        {
            RadioButton ruBtton = sender as RadioButton;

            if (ruBtton == null) return;

            if (ruBtton.Name == "radioButton3")
            {
                if (ruBtton.Checked == true)
                {
                    dateTimePicker2.Enabled = true;
                }
                else
                {
                    dateTimePicker2.Enabled = false;
                }
            }
            else if (ruBtton.Name == "radioButton4")
            {
                if (ruBtton.Checked == true)
                {
                    dateTimePicker2.Enabled = false;
                }
                else
                {
                    dateTimePicker2.Enabled = true;
                }
            }
        }


        /// <summary>
        /// 产生计划摘要
        /// </summary>
        private void CreatePlanInfo()
        {
            string msg1, msg2, msg3;

            //msg1
            decimal pl = numericUpDownExeBetween.Value;
            if (pl == 1)
                msg1 = string.Format("每天");
            else
                msg1 = string.Format("每 {0} 天", pl);

            //msg2
            if (radioButton1.Checked == true)
                msg2 = string.Format("的 {0} 执行。", dateTimePickerAExeTime.Value.ToLongTimeString());
            else
                msg2 = string.Format("在 {0} 和 {1} 之间，每 {2} {3} 执行。", dateTimePicker3.Value.ToLongTimeString(), dateTimePicker4.Value.ToLongTimeString(), numericUpDown1.Value, comboBox2.SelectedItem.ToString());
            

            // msg3
            if (radioButton3.Checked == true)
                msg3 = string.Format("将在 {0} 到 {1} 之间执行计划。", dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            else
                msg3 = string.Format("将从 {0} 开始使用计划。", dateTimePicker1.Value.ToShortDateString());

            this.richTextBox1.Text = string.Format("{0}{1}{2}", msg1, msg2, msg3);
        }


        #region 值变化
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PlChanged(sender);

            CreatePlanInfo();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            BeginAndEndDateChange(sender);

            CreatePlanInfo();
        }

        private void numericUpDownExeBetween_ValueChanged(object sender, EventArgs e)
        {
            CreatePlanInfo();
        }

        private void dateTimePickerAExeTime_ValueChanged(object sender, EventArgs e)
        {
            CreatePlanInfo();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CreatePlanInfo();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreatePlanInfo();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            CreatePlanInfo();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            CreatePlanInfo();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CreatePlanInfo();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CreatePlanInfo();
        }
        #endregion


        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                string exePath = System.IO.Path.Combine(
             Environment.CurrentDirectory, "SSChema.Services.exe");

                Configuration conf = ConfigurationManager.OpenExeConfiguration(exePath);

                //频率
                conf.AppSettings.Settings["planpltype"].Value = this.comboBoxExeType.SelectedItem.ToString();
                conf.AppSettings.Settings["planpl"].Value = numericUpDownExeBetween.Value.ToString();

                //每天频率
                if (radioButton1.Checked == true)
                {
                    conf.AppSettings.Settings["planpleverydaytype"].Value = "1";

                    conf.AppSettings.Settings["planeverydayonedate"].Value = dateTimePickerAExeTime.Value.ToLongTimeString();
                }
                else
                {
                    conf.AppSettings.Settings["planpleverydaytype"].Value = "2";

                    conf.AppSettings.Settings["planeverydaytwotimes"].Value = numericUpDown1.Value.ToString();
                    conf.AppSettings.Settings["planeverydaytwotimestype"].Value = comboBox2.SelectedItem.ToString();
                    conf.AppSettings.Settings["planeverydaytwobdate"].Value = dateTimePicker3.Value.ToLongTimeString();
                    conf.AppSettings.Settings["planeverydaytwoedate"].Value = dateTimePicker4.Value.ToLongTimeString();
                }

                //持续时间
                if (radioButton3.Checked == true)
                {
                    conf.AppSettings.Settings["plancxtype"].Value = "1";
                    conf.AppSettings.Settings["plancxbdate"].Value = dateTimePicker1.Value.ToLongDateString();
                    conf.AppSettings.Settings["plancxedate"].Value = dateTimePicker2.Value.ToLongDateString();
                }
                else
                {
                    conf.AppSettings.Settings["plancxtype"].Value = "2";
                    conf.AppSettings.Settings["plancxbdate"].Value = dateTimePicker1.Value.ToLongDateString();
                }

                conf.AppSettings.Settings["plansetdate"].Value = DateTime.Now.ToString();

                conf.Save();

                MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 窗口加载时显示已经保存的值
        /// </summary>
        private void InitControlsValue()
        {
            try
            {
                string exePath = System.IO.Path.Combine(
                 Environment.CurrentDirectory, "SSChema.Services.exe");

                Configuration conf = ConfigurationManager.OpenExeConfiguration(exePath);

                this.comboBoxExeType.SelectedItem = conf.AppSettings.Settings["planpltype"].Value;
                numericUpDownExeBetween.Value = Convert.ToDecimal(conf.AppSettings.Settings["planpl"].Value);


                //每天频率
                if (conf.AppSettings.Settings["planpleverydaytype"].Value == "1")
                {
                    radioButton1.Checked = true;

                    dateTimePickerAExeTime.Value = DateTime.Parse(conf.AppSettings.Settings["planeverydayonedate"].Value);
                }
                else
                {
                    radioButton2.Checked = true;

                    numericUpDown1.Value = Convert.ToDecimal(conf.AppSettings.Settings["planeverydaytwotimes"].Value);
                    comboBox2.SelectedItem = conf.AppSettings.Settings["planeverydaytwotimestype"].Value;

                    dateTimePicker3.Value = DateTime.Parse(conf.AppSettings.Settings["planeverydaytwobdate"].Value);
                    dateTimePicker4.Value = DateTime.Parse(conf.AppSettings.Settings["planeverydaytwoedate"].Value);
                }

                //持续时间
                if (conf.AppSettings.Settings["plancxtype"].Value == "1")
                {
                    radioButton3.Checked = true;

                    dateTimePicker1.Value = DateTime.Parse(conf.AppSettings.Settings["plancxbdate"].Value);
                    dateTimePicker2.Value = DateTime.Parse(conf.AppSettings.Settings["plancxedate"].Value);
                }
                else
                {
                    radioButton4.Checked = true;

                    dateTimePicker1.Value = DateTime.Parse(conf.AppSettings.Settings["plancxbdate"].Value);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("加载值失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeSetForm_Load(object sender, EventArgs e)
        {
            InitControlsValue();

            PlChanged(radioButton1);
            BeginAndEndDateChange(radioButton3);

            CreatePlanInfo();
        }

        

    }
}
