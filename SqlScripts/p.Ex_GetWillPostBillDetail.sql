/*
成都新亚定制
查找交次需要同步的单据
305:零售单
11:销售出库单
45：销售退货单
*/

IF OBJECTPROPERTY(OBJECT_ID('Ex_GetWillPostBillDetail'),'IsProcedure') = 1
	DROP PROCEDURE Ex_GetWillPostBillDetail 
GO

CREATE PROCEDURE Ex_GetWillPostBillDetail
(
	@BillNumberId NUMERIC(10,0),
	@BillType INT
)
AS
BEGIN
	DECLARE @sql VARCHAR(1000),
			@billname VARCHAR(100)
	SET @sql = ''
	
	IF @BillType = 305
		SET @billname = 'retailBill'
	IF @BillType = 11
		SET @billname = 'SaleBill'
	IF @BillType = 45
		SET @billname = 'saleBackBill'

			
	SET @sql = 'SELECT pt.FullName AS title,pt.Unit1 AS unit,bd.Qty AS number,bd.SalePrice AS price, bd.discount AS promotion, bd.DiscountPrice AS act_price,bd.total AS total,bd.comment AS note,bd.Serial AS sn 
			FROM ' + @billname + ' bd
			LEFT JOIN dbo.ptype pt ON bd.PtypeId = pt.typeId
			WHERE bd.BillNumberId = ' + CAST(@BillNumberId AS VARCHAR)
			
	EXEC(@sql)
	
END
GO