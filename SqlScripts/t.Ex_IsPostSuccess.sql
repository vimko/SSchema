/*
	20120704 by zps
	保存是否已经上传的单据
*/
IF OBJECTPROPERTY(OBJECT_ID('Ex_IsPostSuccess'),'IsUserTable') = 1
	DROP TABLE Ex_IsPostSuccess
GO

CREATE TABLE Ex_IsPostSuccess
(
	BillNumberId NUMERIC(10,0) NOT NULL PRIMARY KEY, -- 单据ID
	IsSuccess INT,	-- 是否上传成功，1，成功；0，失败
	HasPosts INT,	-- 已经上传的次数
	FirstPostDate DATETIME,	-- 首次上传的时间
	LastPostDate DATETIME,	-- 最近上传的时间
)

GO
