/*
	20120704 by zps
	�����Ƿ��Ѿ��ϴ��ĵ���
*/
IF OBJECTPROPERTY(OBJECT_ID('Ex_IsPostSuccess'),'IsUserTable') = 1
	DROP TABLE Ex_IsPostSuccess
GO

CREATE TABLE Ex_IsPostSuccess
(
	BillNumberId NUMERIC(10,0) NOT NULL PRIMARY KEY, -- ����ID
	IsSuccess INT,	-- �Ƿ��ϴ��ɹ���1���ɹ���0��ʧ��
	HasPosts INT,	-- �Ѿ��ϴ��Ĵ���
	FirstPostDate DATETIME,	-- �״��ϴ���ʱ��
	LastPostDate DATETIME,	-- ����ϴ���ʱ��
)

GO
