using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SSChema.Services.DAL
{
    /// <summary>
    /// 成都新亚定制
    /// 
    /// 需要传输的数据包括：通信令牌，会员卡号、创建时间、单据编号、、经手人、出库仓库、实际金额、、订单号、交易类型（购买、退货）。
    /// 购买的商品数据（商品名称、单位、数量、单价、金额、扣率、折后单价、备注、商品序列号）
    /// {'title': 'iphone4s', 'unit': '台', 'number': 1, 'price': 4999, 'promotion': 0.9, 'act_price': 4790, 'note': '备注：该用户使用招行信用卡', 'sn': '54432356125'},
    /// 
    /// post_data = {
	///'card_num':		'xxxxxxxxxxx',				# 会员卡号
	///'token':		'xxxxxxxxxxx',				# 安全令牌
	///'create_time': 	'2012-05-25 12:51:39',		# 创建时间
	///'sheet_id':		354,						# 单据编号
	///'dealer':		'徐峥',						# 经手人
	///'store':		'四川总仓',					# 出库仓库
	///'desc':			'这个订单的说明',				# 订单说明
	///'comment':		'这个订单的摘要',				# 订单摘要
	///'total_cost':	234.5,						# 实际金额
	///'items':		items,						# 商品明细数据
    ///'oid':        ‘xxxxxxxx’,			    # 对应订单号
	///'deal_type':	0,							# 交易类型：0:购买、1:退货
    ///}
    /// 
    /// 此类表示单据明细
    /// 
    /// </summary>
    [Serializable]
    class XYSaleBill
    {
        #region 属性

        private int _billtype;
        /// <summary>
        /// 单据类型
        /// </summary>
        public int billtype
        {
            get { return this._billtype; }
            set { this._billtype = value; }
        }

        private string _card_num;
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string card_num
        {
            get { return this._card_num; }
            set { this._card_num = value; }
        }

        private string _token;
        /// <summary>
        /// 安全令牌
        /// </summary>
        public string token
        {
            get { return this._token; }
            set { this._token = value; }
        }

        private DateTime _create_time;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time
        {
            get { return this._create_time; }
            set { this._create_time = value; }
        }

        private int _sheet_id;
        /// <summary>
        /// 单据编号 
        /// </summary>
        public int sheet_id
        {
            get { return this._sheet_id; }
            set { this._sheet_id = value; }
        }

        private string _dealer;
        /// <summary>
        /// 经手人
        /// </summary>
        public string dealer
        {
            get { return this._dealer; }
            set { this._dealer = value; }
        }

        private string _store;
        /// <summary>
        /// 出库仓库
        /// </summary>
        public string store
        {
            get { return this._store; }
            set { this._store = value; }
        }

        private string _desc;
        /// <summary>
        /// 单据说明
        /// </summary>
        public string desc
        {
            get { return this._desc; }
            set { this._desc = value; }
        }

        private string _comment;
        /// <summary>
        /// 单据摘要
        /// </summary>
        public string comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        private double _total_cost;
        /// <summary>
        /// 实际金额
        /// </summary>
        public double total_cost
        {
            get { return this._total_cost; }
            set { this._total_cost = value; }
        }

        private int _oid;
        /// <summary>
        /// 对应订单号
        /// </summary>
        public int oid
        {
            get { return this._oid; }
            set { this._oid = value; }
        }

        private DealType _deal_type;
        /// <summary>
        /// 交易类型
        /// </summary>
        public DealType deal_type
        {
            get { return this._deal_type; }
            set { this._deal_type = value; }
        }

        private List<XYBillDetail> _items;
        /// <summary>
        /// 单据明细
        /// </summary>
        public List<XYBillDetail> items
        {
            get { return this._items; }
            set { this._items = value; }
        }


        private XYPostBillInfo postBillInfo;
        /// <summary>
        /// 单据提交记录
        /// </summary>
        public XYPostBillInfo PostBillInfo
        {
            get { return this.postBillInfo; }
            set { this.postBillInfo = value; }
        }

        #endregion

        public XYSaleBill() { }

        public XYSaleBill(int billtype, string card_num, string token, DateTime create_time, int sheet_id, string dealer, string store, string desc, string comment, double total_cost, int oid, DealType deal_type, List<XYBillDetail> items,XYPostBillInfo postbillinfo)
        {
            this._billtype = billtype;
            this._card_num = card_num;
            this._token = token;
            this._create_time = create_time;
            this._sheet_id = sheet_id;
            this._dealer = dealer;
            this._store = store;
            this._desc = desc;
            this._comment = comment;
            this._total_cost = total_cost;
            this._oid = oid;
            this._deal_type = deal_type;
            this._items = items;
            this.postBillInfo = postbillinfo;
        }

        /// <summary>
        /// 更新提交信息
        /// </summary>
        /// <param name="issuccess"></param>
        /// <returns></returns>
        public int UpDatePostInfo(int issuccess)
        {
            if (this.postBillInfo == null)
            {
                this.postBillInfo = new XYPostBillInfo();

                this.postBillInfo.BillNumberId = this.sheet_id;
                this.postBillInfo.IsSuccess = issuccess;
                this.postBillInfo.HasPosts = 1;
                this.postBillInfo.FirstPostDate = DateTime.Now;
                this.postBillInfo.LastPostDate = DateTime.Now;
            }
            else
            {
                this.postBillInfo.IsSuccess = issuccess;
                this.postBillInfo.HasPosts += 1;
                this.postBillInfo.LastPostDate = DateTime.Now;
            }

            return this.postBillInfo.UpdatePostInfo();
        }


    }


    /// <summary>
    /// 保存单据提交信息
    /// </summary>
    public class XYPostBillInfo
    {
        //BillNumberId NUMERIC(10,0) NOT NULL PRIMARY KEY, -- 单据ID
        //IsSuccess INT,	-- 是否上传成功，1，成功；0，失败
        //HasPosts INT,	-- 已经上传的次数
        //FirstPostDate DATETIME,	-- 首次上传的时间
        //LastPostDate DATETIME,	-- 最近上传的时间

        private int billNumberId;
        /// <summary>
        /// 单据编号
        /// </summary>
        public int BillNumberId
        {
            get { return this.billNumberId; }
            set { this.billNumberId = value; }
        }

        private int isSuccess;
        /// <summary>
        /// 是否更新成功
        /// <remarks>1,成功；0，失败</remarks>
        /// </summary>
        public int IsSuccess
        {
            get { return this.isSuccess; }
            set { this.isSuccess = value; }
        }


        private int hasPosts;
        /// <summary>
        /// 已经提交的次数
        /// </summary>
        public int HasPosts
        {
            get { return this.hasPosts; }
            set { this.hasPosts = value; }
        }

        private DateTime firstPostDate;
        /// <summary>
        /// 首次上传时间
        /// </summary>
        public DateTime FirstPostDate
        {
            get { return this.firstPostDate; }
            set { this.firstPostDate = value; }
        }

        private DateTime lastPostDate;
        /// <summary>
        /// 最后一次上传时间
        /// </summary>
        public DateTime LastPostDate
        {
            get { return this.lastPostDate; }
            set { this.lastPostDate = value; }
        }

        /// <summary>
        /// 更新 post 数据
        /// </summary>
        /// <returns></returns>
        public int UpdatePostInfo()
        {
            string sql = "";

            if (this.HasPosts == 1)
                sql = "INSERT INTO dbo.Ex_IsPostSuccess( BillNumberId ,IsSuccess ,HasPosts ,FirstPostDate ,LastPostDate) VALUES (@BillNumberId,@IsSuccess,@HasPosts,@FirstPostDate,@LastPostDate)";
            else
                sql = "UPDATE dbo.Ex_IsPostSuccess SET IsSuccess=@IsSuccess ,HasPosts=@HasPosts,FirstPostDate=@FirstPostDate,LastPostDate=@LastPostDate WHERE BillNumberId = @BillNumberId";

            SqlParameter[] pas = new SqlParameter[] { 
                new SqlParameter("@BillNumberId",this.BillNumberId),
                new SqlParameter("@IsSuccess",this.IsSuccess),
                new SqlParameter("@HasPosts",this.HasPosts),
                new SqlParameter("@FirstPostDate",this.FirstPostDate),
                new SqlParameter("@LastPostDate",this.LastPostDate)
            };

            try
            {
                return DBHelper.ExcuteSQL(sql, pas, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                Common.AppLog.CreateAppLog().Error(ex.Message);

                return 0;
            }

            
        }

    }


    /// <summary>
    /// 交易类型
    /// 0:购买；1：退货
    /// </summary>
    enum DealType
    {
        /// <summary>
        /// 购买 0
        /// </summary>
        SALE = 0, //购买

        /// <summary>
        /// 退货 1
        /// </summary>
        BACK = 1, //退货
    }


}
