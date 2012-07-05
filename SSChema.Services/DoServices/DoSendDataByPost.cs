using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SSChema.Services.DAL;
using System.Net;
using System.IO;
using System.Xml;

namespace SSChema.Services.DoServices
{
    class DoSendDataByPost
    {

        public void Do()
        {
            List<XYSaleBill> sas = XYDataHelper.GetSaleBillIndexs();

            foreach (XYSaleBill item in sas)
            {
                //Common.AppLog.CreateAppLog().Debug(JsonConvert.SerializeObject(item));

                ddd(item);
            }
    
        }


        private void ddd(XYSaleBill sb)
        {
            try
            {
                string url = Common.AppSetting.httpurl;


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                string postdata = "body=" + JsonConvert.SerializeObject(sb);

                UTF8Encoding code = new UTF8Encoding();　　//这里采用UTF8编码方式
                byte[] data = code.GetBytes(postdata);

                request.ContentLength = data.Length;

                using (Stream stream = request.GetRequestStream()) //获取数据流,该流是可写入的 
                {
                    stream.Write(data, 0, data.Length); //发送数据流 
                    stream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream ss = response.GetResponseStream();

                    XmlTextReader Reader = new XmlTextReader(ss);
                    Reader.MoveToContent();
                    string status = Reader.ReadInnerXml();

                    if (status == "302")
                    {
                        sb.UpDatePostInfo(1);

                        Common.AppLog.CreateAppLog().Info(string.Format("编号为：{0} 的单据于 {1} 更新成功", sb.sheet_id, DateTime.Now));
                    }
                    else
                    {
                        sb.UpDatePostInfo(0);

                        Common.AppLog.CreateAppLog().Error(string.Format("编号为：{0} 的单据于 {1} 更新失败", sb.sheet_id, DateTime.Now));
                    }
                }


            }
            catch (Exception ex)
            {
                Common.AppLog.CreateAppLog().Error(ex.Message);
            }

        }

    }
}
