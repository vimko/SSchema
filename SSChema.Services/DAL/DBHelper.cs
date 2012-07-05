using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SSChema.Services.DAL
{
    class DBHelper
    {


        private string strConnect;


        //连接字符串
        //static string strConn = ConfigurationManager.ConnectionStrings["CnnhoRechargePlatformConnectionString"].ToString();
        static string strConn;

        public DBHelper()
        {
            this.strConnect = BaseData.StaConnectString;
        }

        public DBHelper(string strconn)
        {
            this.strConnect = strconn;
        }

        static DBHelper()
        {
            strConn = BaseData.StaConnectString;
        }

        //保存查询参数
        private List<SqlParameter> sqlParameters = new List<SqlParameter>();

        /// <summary>
        /// 添加查询参数
        /// </summary>
        /// <param name="parametername"></param>
        /// <param name="value"></param>
        public void AddParameter(string parametername, object value)
        {
            SqlParameter param = new SqlParameter(parametername, value);

            this.sqlParameters.Add(param);
        }


        /// <summary>
        /// 执行带有参数的储存过程，但无输出参数
        /// </summary>
        /// <param name="procname"></param>
        /// <returns></returns>
        public DataTable ExcuteProcedureHasParameterNoOutPut(string procname)
        {
            DataTable dt = new DataTable("table");

            using (SqlConnection conn = new SqlConnection(this.strConnect))
            {
                SqlDataAdapter da = new SqlDataAdapter(procname, conn);

                foreach (var item in this.sqlParameters)
                {
                    da.SelectCommand.Parameters.Add(item);
                }

                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// 执行没有参数的储存过程，无输出参数
        /// </summary>
        /// <param name="procname"></param>
        /// <returns></returns>
        public DataTable ExcuteProcedureNoParameterNoOutPut(string procname)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(this.strConnect))
            {
                SqlDataAdapter da = new SqlDataAdapter(procname, conn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// 返回结果的第一行的第一个值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteSqlScalar(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.strConnect))
                {
                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();

                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sql;
                    object obj = comm.ExecuteScalar();

                    return obj;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 返回结果的第一行
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataRow ExecuteSqlSingleRow(string sql)
        {
            try
            {
                DataTable table = new DataTable();

                using (SqlConnection conn = new SqlConnection(this.strConnect))
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(table);

                    return table.Rows[0];
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// 返回一个 DataTable 类型的数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteSql(string sql)
        {
            try
            {
                DataTable table = new DataTable("table");

                using (SqlConnection conn = new SqlConnection(this.strConnect))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(table);

                    return table;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 返回一个 DataTable 类型的数据，并指定返回表的名称
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteSql(string sql, string tablename)
        {
            try
            {
                DataTable table = new DataTable(tablename);

                using (SqlConnection conn = new SqlConnection(this.strConnect))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(table);

                    return table;
                }
            }
            catch (Exception)
            {
                //return null;
                throw;
            }
        }



        /// <summary>
        /// 执行没有返回查询的sql，返回影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSqlNoQuery(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.strConnect))
                {
                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();

                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sql;
                    return comm.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 批量更新数据
        /// 传入一个 datatable 类型的数据，和一个 要更新的表的名称
        /// table 的第一个字段是主键，且为 int
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public int UpdataByDataTable(DataTable table, string tablename)
        {
            List<string> colList = new List<string>();

            DataColumnCollection cols = table.Columns;

            foreach (DataColumn item in cols)
            {
                colList.Add(item.ColumnName);
            }

            int colCout = colList.Count;

            string sql = "";
            string rowsql = "";

            foreach (DataRow item in table.Rows)
            {
                if (item[0] != null && item[0].ToString().Length > 0)
                {
                    string usql = "";

                    for (int i = 1; i < colCout; i++)
                    {
                        usql += colList[i] + " = '" + item[i] + "', ";
                    }

                    usql = usql.Substring(0, usql.Length - 2);

                    rowsql = string.Format("UPDATE {0} SET {1} WHERE {2} = {3};", tablename, usql, colList[0], item[0]);
                }
                else
                {
                    string isql1 = "( ";
                    string isql2 = "( ";

                    for (int i = 1; i < colCout; i++)
                    {
                        isql1 += colList[i] + ", ";
                        isql2 += " '" + item[i] + "', ";
                    }

                    isql1 = isql1.Substring(0, isql1.Length - 2);
                    isql2 = isql2.Substring(0, isql2.Length - 2);

                    isql1 += " )";
                    isql2 += " )";

                    rowsql = string.Format("INSERT INTO {0} {1} VALUES {2};", tablename, isql1, isql2);
                }

                sql += rowsql;
            }


            try
            {
                using (SqlConnection conn = new SqlConnection(this.strConnect))
                {
                    conn.Open();

                    SqlCommand comm = conn.CreateCommand();

                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sql;

                    return comm.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #region 执行查询，返回DataTable对象-----------------------


        public static DataTable GetTable(string strSQL)
        {
            return GetTable(strSQL, null);


        }
        public static DataTable GetTable(string strSQL, SqlParameter[] pas)
        {
            return GetTable(strSQL, pas, CommandType.Text);
        }
        /// <summary>
        /// 执行查询，返回DataTable对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <param name="pas">参数数组</param>
        /// <param name="cmdtype">Command类型</param>
        /// <returns>DataTable对象</returns>
        public static DataTable GetTable(string strSQL, SqlParameter[] pas, CommandType cmdtype)
        {
            DataTable dt = new DataTable("table"); ;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                da.SelectCommand.CommandType = cmdtype;
                if (pas != null)
                {
                    da.SelectCommand.Parameters.AddRange(pas);
                }
                da.Fill(dt);

            }
            return dt;
        }


        #endregion



        #region 执行查询，返回DataSet对象-------------------------



        public static DataSet GetDataSet(string strSQL)
        {
            return GetDataSet(strSQL, null);
        }

        public static DataSet GetDataSet(string strSQL, SqlParameter[] pas)
        {
            return GetDataSet(strSQL, pas, CommandType.Text);
        }
        /// <summary>
        /// 执行查询，返回DataSet对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <param name="pas">参数数组</param>
        /// <param name="cmdtype">Command类型</param>
        /// <returns>DataSet对象</returns>
        public static DataSet GetDataSet(string strSQL, SqlParameter[] pas, CommandType cmdtype)
        {
            DataSet dt = new DataSet(); ;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                da.SelectCommand.CommandType = cmdtype;
                if (pas != null)
                {
                    da.SelectCommand.Parameters.AddRange(pas);
                }
                da.Fill(dt);
            }
            return dt;
        }
        #endregion



        #region 执行非查询存储过程和SQL语句-----------------------------



        public static int ExcuteProc(string ProcName)
        {
            return ExcuteSQL(ProcName, null, CommandType.StoredProcedure);
        }

        public static int ExcuteProc(string ProcName, SqlParameter[] pars)
        {
            return ExcuteSQL(ProcName, pars, CommandType.StoredProcedure);
        }

        public static int ExcuteSQL(string strSQL)
        {
            return ExcuteSQL(strSQL, null);
        }

        public static int ExcuteSQL(string strSQL, SqlParameter[] paras)
        {
            return ExcuteSQL(strSQL, paras, CommandType.Text);
        }

        /// 执行非查询存储过程和SQL语句
        /// 增、删、改
        /// </summary>
        /// <param name="strSQL">要执行的SQL语句</param>
        /// <param name="paras">参数列表，没有参数填入null</param>
        /// <param name="cmdType">Command类型</param>
        /// <returns>返回影响行数</returns>
        public static int ExcuteSQL(string strSQL, SqlParameter[] paras, CommandType cmdType)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.CommandType = cmdType;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                conn.Open();
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return i;

        }

        #endregion





        #region 执行查询返回第一行，第一列---------------------------------



        public static int ExcuteScalarSQL(string strSQL)
        {
            return ExcuteScalarSQL(strSQL, null);
        }

        public static int ExcuteScalarSQL(string strSQL, SqlParameter[] paras)
        {
            return ExcuteScalarSQL(strSQL, paras, CommandType.Text);
        }
        public static int ExcuteScalarProc(string strSQL, SqlParameter[] paras)
        {
            return ExcuteScalarSQL(strSQL, paras, CommandType.StoredProcedure);
        }
        /// <summary>
        /// 执行SQL语句，返回第一行，第一列
        /// </summary>
        /// <param name="strSQL">要执行的SQL语句</param>
        /// <param name="paras">参数列表，没有参数填入null</param>
        /// <returns>返回影响行数</returns>
        public static int ExcuteScalarSQL(string strSQL, SqlParameter[] paras, CommandType cmdType)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.CommandType = cmdType;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                conn.Open();
                i = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            return i;

        }

        #endregion






        #region 查询获取单个值------------------------------------



        /// <summary>
        /// 调用不带参数的存储过程获取单个值
        /// </summary>
        /// <param name="ProcName"></param>
        /// <returns></returns>
        public static object GetObjectByProc(string ProcName)
        {
            return GetObjectByProc(ProcName, null);
        }
        /// <summary>
        /// 调用带参数的存储过程获取单个值
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static object GetObjectByProc(string ProcName, SqlParameter[] paras)
        {
            return GetObject(ProcName, paras, CommandType.StoredProcedure);
        }
        /// <summary>
        /// 根据sql语句获取单个值
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static object GetObject(string strSQL)
        {
            return GetObject(strSQL, null);
        }
        /// <summary>
        /// 根据sql语句 和 参数数组获取单个值
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static object GetObject(string strSQL, SqlParameter[] paras)
        {
            return GetObject(strSQL, paras, CommandType.Text);
        }

        /// <summary>
        /// 执行SQL语句，返回首行首列
        /// </summary>
        /// <param name="strSQL">要执行的SQL语句</param>
        /// <param name="paras">参数列表，没有参数填入null</param>
        /// <returns>返回的首行首列</returns>
        public static object GetObject(string strSQL, SqlParameter[] paras, CommandType cmdtype)
        {
            object o = null;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.CommandType = cmdtype;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);

                }

                conn.Open();
                o = cmd.ExecuteScalar();
                conn.Close();
            }
            return o;

        }


        #endregion



        #region 查询获取DataReader------------------------------------



        /// <summary>
        /// 调用不带参数的存储过程，返回DataReader对象
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns>DataReader对象</returns>
        public static SqlDataReader GetReaderByProc(string procName)
        {
            return GetReaderByProc(procName, null);
        }
        /// <summary>
        /// 调用带有参数的存储过程，返回DataReader对象
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="paras">参数数组</param>
        /// <returns>DataReader对象</returns>
        public static SqlDataReader GetReaderByProc(string procName, SqlParameter[] paras)
        {
            return GetReader(procName, paras, CommandType.StoredProcedure);
        }
        /// <summary>
        /// 根据sql语句返回DataReader对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <returns>DataReader对象</returns>
        public static SqlDataReader GetReader(string strSQL)
        {
            return GetReader(strSQL, null);
        }
        /// <summary>
        /// 根据sql语句和参数返回DataReader对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <param name="paras">参数数组</param>
        /// <returns>DataReader对象</returns>
        public static SqlDataReader GetReader(string strSQL, SqlParameter[] paras)
        {
            return GetReader(strSQL, paras, CommandType.Text);
        }
        /// <summary>
        /// 查询SQL语句获取DataReader
        /// </summary>
        /// <param name="strSQL">查询的SQL语句</param>
        /// <param name="paras">参数列表，没有参数填入null</param>
        /// <returns>查询到的DataReader（关闭该对象的时候，自动关闭连接）</returns>
        public static SqlDataReader GetReader(string strSQL, SqlParameter[] paras, CommandType cmdtype)
        {
            SqlDataReader sqldr = null;
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.CommandType = cmdtype;
            if (paras != null)
            {
                cmd.Parameters.AddRange(paras);
            }
            conn.Open();
            //CommandBehavior.CloseConnection的作用是如果关联的DataReader对象关闭，则连接自动关闭
            sqldr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return sqldr;
        }


        #endregion



        #region 批量插入数据---------------------------------------------



        /// <summary>
        /// 往数据库中批量插入数据
        /// </summary>
        /// <param name="sourceDt">数据源表</param>
        /// <param name="targetTable">服务器上目标表</param>
        public static void BulkToDB(DataTable sourceDt, string targetTable)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlBulkCopy bulkCopy = new SqlBulkCopy(conn);   //用其它源的数据有效批量加载sql server表中
            bulkCopy.DestinationTableName = targetTable;    //服务器上目标表的名称
            bulkCopy.BatchSize = sourceDt.Rows.Count;   //每一批次中的行数

            try
            {
                conn.Open();
                if (sourceDt != null && sourceDt.Rows.Count != 0)
                    bulkCopy.WriteToServer(sourceDt);   //将提供的数据源中的所有行复制到目标表中
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                if (bulkCopy != null)
                    bulkCopy.Close();
            }

        }

        #endregion


        #region 返回一行数据--------------------------------------

        /// <summary>
        /// 返回结果的第一行
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataRow ExecuteSqlGetSingleRow(string sql, SqlParameter[] paras, CommandType cmdtype)
        {
            try
            {
                DataTable table = new DataTable();

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                    da.SelectCommand.CommandType = cmdtype;

                    if (paras != null)
                        da.SelectCommand.Parameters.AddRange(paras);

                    da.Fill(table);

                    return table.Rows[0];
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion


        /// <summary>
        /// 检查数据库存连接是否可用
        /// </summary>
        /// <returns></returns>
        public static bool CheckConnectCanAvailable()
        {
            SqlConnection con = new SqlConnection(strConn);

            try
            {
                con.Open();
                con.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
