/*
成都新亚定制
查找交次需要同步的单据
305:零售单
11:销售出库单
45：销售退货单
*/

IF OBJECTPROPERTY(OBJECT_ID('Ex_GetWillPostBill'),'IsProcedure') = 1
	DROP PROCEDURE Ex_GetWillPostBill 
go

CREATE PROCEDURE Ex_GetWillPostBill
as
BEGIN
	


SELECT bi.billtype,nvip.VipCardCode AS card_num,bi.BillDate AS create_time,bi.BillNumberId AS sheet_id,em.FullName AS dealer,st.FullName AS store,bi.explain AS [desc],bi.Comment AS comment,bi.totalmoney AS total_cost,-1 AS oid,(CASE WHEN bi.BillType IN (305,11) THEN 0 ELSE 1 END) AS deal_type FROM dbo.BillIndex bi
	LEFT JOIN dbo.nVipCardSign nvip ON bi.VipCardID = nvip.VipCardID
	LEFT JOIN dbo.employee em ON bi.etypeid = em.typeId
	LEFT JOIN dbo.Stock st ON bi.ktypeid = st.typeId
	WHERE bi.BillType IN (305,11,45)
		  AND bi.RedWord = 0
		  AND bi.ifcheck = 't'
		  AND bi.draft = 0
		  AND NOT EXISTS(
			SELECT * FROM dbo.Ex_IsPostSuccess eis 
				WHERE eis.BillNumberId = bi.BillNumberId AND eis.IsSuccess = 1
		  )
	ORDER BY BillDate
	
END
	
GO
