using System;
using System.Collections.Generic;
using System.Text;

namespace SSChema.Services.DAL
{
    /// <summary>
    /// 成都新亚定制
    /// 需要传输的数据包括：通信令牌，会员卡号、创建时间、单据编号、、经手人、出库仓库、实际金额、、订单号、交易类型（购买、退货）。
    /// 购买的商品数据（商品名称、单位、数量、单价、金额、扣率、折后单价、备注、商品序列号）
    /// {'title': 'iphone4s', 'unit': '台', 'number': 1, 'price': 4999, 'promotion': 0.9, 'act_price': 4790, 'note': '备注：该用户使用招行信用卡', 'sn': '54432356125'},
    /// 
    /// 此类表示单据明细
    /// 
    /// </summary>
    [Serializable]
    class XYBillDetail
    {
        #region 属性
        private string _title;
        /// <summary>
        /// 商品名称
        /// </summary>
        public string title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        private string _unit;
        /// <summary>
        /// 单位
        /// </summary>
        public string unit
        {
            get { return this._unit; }
            set { this._unit = value; }
        }

        private double _number;
        /// <summary>
        /// 数量
        /// </summary>
        public double number
        {
            get { return this._number; }
            set { this._number = value; }
        }

        private double _price;
        /// <summary>
        /// 价格
        /// </summary>
        public double price
        {
            get { return this._price; }
            set { this._price = value; }
        }

        private double _promotion;
        /// <summary>
        /// 扣率
        /// </summary>
        public double promotion
        {
            get { return this._promotion; }
            set { this._promotion = value; }
        }

        private double _act_price;
        /// <summary>
        /// 折后单价
        /// </summary>
        public double act_price
        {
            get { return this._act_price; }
            set { this._act_price = value; }
        }

        private double _total;
        /// <summary>
        /// 金额
        /// </summary>
        public double total
        {
            get { return this._total; }
            set { this._total = value; }
        }

        private string _note;
        /// <summary>
        /// 备注
        /// </summary>
        public string note
        {
            get { return this._note; }
            set { this._note = value; }
        }

        private string _sn;
        /// <summary>
        /// 商品序列号
        /// </summary>
        public string sn
        {
            get { return this._sn; }
            set { this._sn = value; }
        }
        #endregion

        public XYBillDetail() { }

        public XYBillDetail(string title, string unit, double number, double price, double promotion, double act_price,double total, string note, string sn)
        {
            this._title = title;
            this._unit = unit;
            this._number = number;
            this._price = price;
            this._promotion = promotion;
            this._act_price = act_price;
            this._total = total;
            this._note = note;
            this._sn = sn;
        }

    }
}
