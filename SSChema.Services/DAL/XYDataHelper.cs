using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SSChema.Services.DAL
{
    class XYDataHelper
    {
        /// <summary>
        /// 返回销售单据表头数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSaleBillIndexDataTable()
        {
            try
            {
                return DBHelper.GetTable("Ex_GetWillPostBill", null, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Common.AppLog.CreateAppLog().Error(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// 返回强类型的单据表头列表
        /// </summary>
        /// <returns></returns>
        public static List<XYSaleBill> GetSaleBillIndexs()
        {
            List<XYSaleBill> rv = new List<XYSaleBill>();

            foreach (DataRow item in GetSaleBillIndexDataTable().Rows)
            {
                XYSaleBill sb = new XYSaleBill();

                sb.token = Common.AppSetting.token;
                sb.billtype = Convert.ToInt32(item["billtype"]);
                sb.card_num = item["card_num"].ToString();
                sb.create_time = Convert.ToDateTime(item["create_time"]);
                sb.sheet_id = Convert.ToInt32(item["sheet_id"]);
                sb.dealer = item["dealer"].ToString();
                sb.store = item["store"].ToString();
                sb.desc = item["desc"].ToString();
                sb.comment = item["comment"].ToString();
                sb.total_cost = Convert.ToDouble(item["total_cost"]);
                sb.oid = Convert.ToInt32(item["oid"]);
                sb.deal_type = item["deal_type"].ToString() == "0" ? DealType.SALE : DealType.BACK;

                sb.items = GetASaleBillDetails(sb.sheet_id, sb.billtype);

                sb.PostBillInfo = GetSaleBillPostInfo(sb.sheet_id);

                rv.Add(sb);
            }

            return rv;
        }

        /// <summary>
        /// 获取单据明细
        /// </summary>
        /// <param name="billnumberid"></param>
        /// <param name="billtype"></param>
        /// <returns></returns>
        public static List<XYBillDetail> GetASaleBillDetails(object billnumberid,object billtype)
        {
            List<XYBillDetail> rv = new List<XYBillDetail>();

            DataTable table = DBHelper.GetTable("Ex_GetWillPostBillDetail", new SqlParameter[2] { new SqlParameter("@BillNumberId", billnumberid), new SqlParameter("@BillType",billtype) }, CommandType.StoredProcedure);

            foreach (DataRow item in table.Rows)
            {
                XYBillDetail bd = new XYBillDetail();

                bd.title = item["title"].ToString();
                bd.unit = item["unit"].ToString();
                bd.number = Convert.ToDouble(item["number"]);
                bd.price = Convert.ToDouble(item["price"]);
                bd.promotion = Convert.ToDouble(item["promotion"]);
                bd.act_price = Convert.ToDouble(item["act_price"]);
                bd.total = Convert.ToDouble(item["total"]);
                bd.note = item["note"].ToString();
                bd.sn = item["sn"].ToString();

                rv.Add(bd);
            }


            return rv;
        }

        /// <summary>
        /// 获取单据提交信息
        /// </summary>
        /// <param name="billnumberid"></param>
        /// <returns></returns>
        public static XYPostBillInfo GetSaleBillPostInfo(object billnumberid)
        {
            XYPostBillInfo rv = new XYPostBillInfo();

            DataRow row = DBHelper.ExecuteSqlGetSingleRow("SELECT * FROM dbo.Ex_IsPostSuccess WHERE BillNumberId = @billnumberid", new SqlParameter[] { new SqlParameter("@billnumberid", billnumberid) }, CommandType.Text);

            if (row == null)
                return null;
            else
            {
                rv.BillNumberId = Convert.ToInt32(row["BillNumberId"]);
                rv.IsSuccess = Convert.ToInt32(row["IsSuccess"]);
                rv.HasPosts = Convert.ToInt32(row["HasPosts"]);
                rv.FirstPostDate = Convert.ToDateTime(row["FirstPostDate"]);
                rv.LastPostDate = Convert.ToDateTime(row["LastPostDate"]);
            }

            return rv;
        }

    }
}
