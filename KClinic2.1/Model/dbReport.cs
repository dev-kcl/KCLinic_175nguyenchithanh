using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KClinic2._1.Model
{
    class dbReport
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable getTypeOfControlInput()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandText = "exec SP_BaoCao @Action =  N'GetTypeOfControlInput'";
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable InsertProcedureParameterReport(string MaBaoCao, string TenBaoCao, string procedureName, string _ReportFile, string _NgayTao, string _NguoiTao, string _TamNgung)

        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'InsertProcedureBaoCao', "
                    + "@MaBaoCao = " + MaBaoCao + ","
                    + "@TenBaoCao = " + TenBaoCao + ","
                    + "@procedureName = " + procedureName + ","
                    + "@ReportFile = " + _ReportFile + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@TamNgung = " + _TamNgung + ""
                    ;

                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable UpdateProcedureBaoCao(string MaBaoCao, string TenBaoCao, string procedureName, string _ReportFile, string _NgayCapNhat, string _NguoiCapNhat, string _TamNgung, string _Idx)

        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'UpdateProcedureBaoCao', "
                    + "@MaBaoCao = " + MaBaoCao + ","
                    + "@TenBaoCao = " + TenBaoCao + ","
                    + "@procedureName = " + procedureName + ","
                    + "@ReportFile = " + _ReportFile + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@IdBaoCao = " + _Idx
                    ;

                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetProcedureByMaBaoCao(string MaBaoCao)

        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'GetBaoCaoByMaBaoCao', "
                    + "@MaBaoCao = N'" + MaBaoCao + "'";


                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetBaoCaoById(string _Id)

        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'GetBaoCaoById', "
                    + "@IdBaoCao = " + _Id;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable InsertProcedureParameter(ProcedureParameter procedureParameter)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                if (procedureParameter.TypeOfControlInputId == 2 || procedureParameter.TypeOfControlInputId == 3)
                {
                    cmd_Show.CommandText = " exec SP_BaoCao @Action = N'InsertProcedureParameter',"
                        + " @NumericalOrderParameter = " + procedureParameter.NumericalOrder + ","
                        + "@typeOfItemSelect =  " + procedureParameter.TypeOfItemSelect + ","
                        + "@ParameterName = N'" + procedureParameter.ParameterName + "',"
                        + "@NameShowLabel =N'" + procedureParameter.NameShowLabel + "',"
                       + "@TypeOfLoadItem = " + procedureParameter.TypeOfLoadItem + ","

                          + "@procedureBaoCaoId = " + procedureParameter.ProcedureBaoCaoId + ","
                          + "@TypeOfControlInputId = " + procedureParameter.TypeOfControlInputId;
                }
                else if (procedureParameter.TypeOfControlInputId == 4)
                {
                    if (procedureParameter.TypeOfItemSelect == 1)
                    {
                        cmd_Show.CommandText = "exec SP_BaoCao @Action = N'InsertProcedureParameter',"
                          + " @NumericalOrderParameter = " + procedureParameter.NumericalOrder + ","
                          + "@typeOfItemSelect = " + procedureParameter.TypeOfItemSelect + ","
                          + "@ParameterName = N'" + procedureParameter.ParameterName + "',"
                          + "@NameShowLabel = N'" + procedureParameter.NameShowLabel + "',"
                          + "@ValueStringCheckBoxTrue = '" + procedureParameter.ValueStringCheckBoxTrue + "',"
                          + "@ValueStringCheckBoxFalse = '" + procedureParameter.ValueStringCheckBoxFalse + "',"

                          + "@procedureBaoCaoId = " + procedureParameter.ProcedureBaoCaoId + ","
                          + "@TypeOfControlInputId = " + procedureParameter.TypeOfControlInputId;
                    }
                    else
                    {

                        cmd_Show.CommandText = "exec SP_BaoCao @Action = N'InsertProcedureParameter',"
                          + " @NumericalOrderParameter = " + procedureParameter.NumericalOrder + ","
                          + "@typeOfItemSelect = " + procedureParameter.TypeOfItemSelect + ","
                          + "@ParameterName = N'" + procedureParameter.ParameterName + "',"
                          + "@NameShowLabel = N'" + procedureParameter.NameShowLabel + "',"
                          + "@ValueIntCheckBoxTrue = " + procedureParameter.ValueIntCheckBoxTrue + ","
                          + "@ValueIntCheckBoxFalse = " + procedureParameter.ValueIntCheckBoxFalse + ","

                          + "@procedureBaoCaoId = " + procedureParameter.ProcedureBaoCaoId + ","
                          + "@TypeOfControlInputId = " + procedureParameter.TypeOfControlInputId;
                    }
                }
                else
                {
                    cmd_Show.CommandText = "exec SP_BaoCao @Action = N'InsertProcedureParameter',"
                  + " @NumericalOrderParameter = " + procedureParameter.NumericalOrder + ","
                  + "@typeOfItemSelect = " + procedureParameter.TypeOfItemSelect + ","
                  + "@ParameterName = N'" + procedureParameter.ParameterName + "',"
                  + "@NameShowLabel = N'" + procedureParameter.NameShowLabel + "',"
                  + "@procedureBaoCaoId = " + procedureParameter.ProcedureBaoCaoId + ","
                  + "@TypeOfControlInputId = " + procedureParameter.TypeOfControlInputId;
                }


                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }

        }

        public static DataTable UpdateProcedureParameter(ProcedureParameter procedureParameter)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                if (procedureParameter.TypeOfControlInputId == 2 || procedureParameter.TypeOfControlInputId == 3)
                {
                    cmd_Show.CommandText = " exec SP_BaoCao @Action = N'UpdateProcedureParameter',"
                        + " @NumericalOrderParameter = " + procedureParameter.NumericalOrder + ","
                        + "@typeOfItemSelect =  " + procedureParameter.TypeOfItemSelect + ","
                        + "@ParameterName = N'" + procedureParameter.ParameterName + "',"
                        + "@NameShowLabel =N'" + procedureParameter.NameShowLabel + "',"
                       + "@TypeOfLoadItem = " + procedureParameter.TypeOfLoadItem + ","

                          + "@procedureBaoCaoId = " + procedureParameter.ProcedureBaoCaoId + ","
                          + "@TypeOfControlInputId = " + procedureParameter.TypeOfControlInputId + ","
                          + "@IdBaoCao = " + procedureParameter.Id;
                }
                else if (procedureParameter.TypeOfControlInputId == 4)
                {
                    if (procedureParameter.TypeOfItemSelect == 1)
                    {
                        cmd_Show.CommandText = "exec SP_BaoCao @Action = N'UpdateProcedureParameter',"
                          + " @NumericalOrderParameter = " + procedureParameter.NumericalOrder + ","
                          + "@typeOfItemSelect = " + procedureParameter.TypeOfItemSelect + ","
                          + "@ParameterName = N'" + procedureParameter.ParameterName + "',"
                          + "@NameShowLabel = N'" + procedureParameter.NameShowLabel + "',"
                          + "@ValueStringCheckBoxTrue = '" + procedureParameter.ValueStringCheckBoxTrue + "',"
                          + "@ValueStringCheckBoxFalse = '" + procedureParameter.ValueStringCheckBoxFalse + "',"

                          + "@procedureBaoCaoId = " + procedureParameter.ProcedureBaoCaoId + ","
                          + "@TypeOfControlInputId = " + procedureParameter.TypeOfControlInputId + ","
                          + "@IdBaoCao = " + procedureParameter.Id;
                    }
                    else
                    {

                        cmd_Show.CommandText = "exec SP_BaoCao @Action = N'UpdateProcedureParameter',"
                          + " @NumericalOrderParameter = " + procedureParameter.NumericalOrder + ","
                          + "@typeOfItemSelect = " + procedureParameter.TypeOfItemSelect + ","
                          + "@ParameterName = N'" + procedureParameter.ParameterName + "',"
                          + "@NameShowLabel = N'" + procedureParameter.NameShowLabel + "',"
                          + "@ValueIntCheckBoxTrue = " + procedureParameter.ValueIntCheckBoxTrue + ","
                          + "@ValueIntCheckBoxFalse = " + procedureParameter.ValueIntCheckBoxFalse + ","

                          + "@procedureBaoCaoId = " + procedureParameter.ProcedureBaoCaoId + ","
                          + "@TypeOfControlInputId = " + procedureParameter.TypeOfControlInputId + ","
                          + "@IdBaoCao = " + procedureParameter.Id;
                    }
                }
                else
                {
                    cmd_Show.CommandText = "exec SP_BaoCao @Action = N'UpdateProcedureParameter',"
                  + " @NumericalOrderParameter = " + procedureParameter.NumericalOrder + ","
                  + "@typeOfItemSelect = " + procedureParameter.TypeOfItemSelect + ","
                  + "@ParameterName = N'" + procedureParameter.ParameterName + "',"
                  + "@NameShowLabel = N'" + procedureParameter.NameShowLabel + "',"
                  + "@procedureBaoCaoId = " + procedureParameter.ProcedureBaoCaoId + ","
                  + "@TypeOfControlInputId = " + procedureParameter.TypeOfControlInputId + ","
                          + "@IdBaoCao = " + procedureParameter.Id;
                }


                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }

        }

        public static DataTable GetProcedureParameterByProcedureBaoCaoId(string procedureBaoCaoId)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'GetProcedureParameterByProcedureBaoCaoId',"
                  + " @procedureBaoCaoId = " + procedureBaoCaoId;

                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();



                return table1;
            }
            catch
            {
                return null;
            }

        }

        public static DataTable InsertItemSelect(ItemSelect itemSelect)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                if (itemSelect.ValueItemInt != null)
                {
                    cmd_Show.CommandText = "exec SP_BaoCao @Action = N'InsertItemSelect', " +
                        "@ValueItemString = null, " +
                        "@ValueItemInt = " + itemSelect.ValueItemInt.ToString() + ", " +
                        "@ShowText = N'" + itemSelect.ShowText + "', " +
                        "@NumericalOrderItem = " + itemSelect.NumericalOrder.ToString() + ", " +
                        "@procedureParameterId = " + itemSelect.procedureParameterId.ToString();

                }
                else if (itemSelect.ValueItemString != null)
                {
                    cmd_Show.CommandText = "exec SP_BaoCao @Action = N'InsertItemSelect', " +
                          "@ValueItemString = N'" + itemSelect.ValueItemString + "', " +
                          "@ValueItemInt = null, " +
                          "@ShowText = N'" + itemSelect.ShowText + "', " +
                          "@NumericalOrderItem = " + itemSelect.NumericalOrder.ToString() + ", " +
                          "@procedureParameterId = " + itemSelect.procedureParameterId.ToString();


                }
                else
                {


                    cmd_Show.CommandText = "    exec SP_BaoCao @Action = N'InsertDBSelect', " +
                              "@QueryDatabase = @QueryDatabaseString, " +
                              "@ColumnKey = N'" + itemSelect.ColumnKey + "', " +
                              "@ColumnTextShow = N'" + itemSelect.ColumnTextShow + "', " +
                              "@procedureParameterId = " + itemSelect.procedureParameterId.ToString();
                    cmd_Show.Parameters.AddWithValue("@QueryDatabaseString", itemSelect.QueryDatabase);
                }

                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }

        }

        public static DataTable UpdateItemSelect(ItemSelect itemSelect)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                if (itemSelect.ValueItemInt != null && itemSelect.ValueItemString == "" && itemSelect.QueryDatabase == "")
                {
                    cmd_Show.CommandText = "exec SP_BaoCao @Action = N'UpdateItemSelect', " +
                        "@ValueItemString = null, " +
                        "@ValueItemInt = " + itemSelect.ValueItemInt.ToString() + ", " +
                        "@ShowText = N'" + itemSelect.ShowText + "', " +
                        "@NumericalOrderItem = " + itemSelect.NumericalOrder.ToString() + ", " +
                        "@procedureParameterId = " + itemSelect.procedureParameterId.ToString() + ", " +
                        "@Idx = " + itemSelect.Id.ToString();
                    ///////////////////////////////////////////////////////////////////
                }
                else if (itemSelect.ValueItemString != "" && itemSelect.QueryDatabase == "") 
                {
                    cmd_Show.CommandText = "exec SP_BaoCao @Action = N'UpdateItemSelect', " +
                          "@ValueItemString = N'" + itemSelect.ValueItemString + "', " +
                          "@ValueItemInt = null, " +
                          "@ShowText = N'" + itemSelect.ShowText + "', " +
                          "@NumericalOrderItem = " + itemSelect.NumericalOrder.ToString() + ", " +
                          "@procedureParameterId = " + itemSelect.procedureParameterId.ToString() + ", " +
                          "@Idx = " + itemSelect.Id.ToString();


                }
                else
                {


                    cmd_Show.CommandText = "exec SP_BaoCao @Action = N'UpdateDBSelect', " +
                              "@QueryDatabase = @QueryDatabaseString, " +
                              "@ColumnKey = N'" + itemSelect.ColumnKey + "', " +
                              "@ColumnTextShow = N'" + itemSelect.ColumnTextShow + "', " +
                              "@procedureParameterId = " + itemSelect.procedureParameterId.ToString() + ", " +
                              "@Idx = " + itemSelect.Id.ToString();
                    cmd_Show.Parameters.AddWithValue("@QueryDatabaseString", itemSelect.QueryDatabase);
                }

                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }

        }

        public static DataTable GetAllReport()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'SelectAllProcedureBaoCao'";
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetReportById(int id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandText = " exec SP_BaoCao @Action = N'GetprocedureBaoCaoById', " +
                    "@IdBaoCao = " + id.ToString();

                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetItemSelectByIdprocedureBaoCao(string procedureBaoCaoId)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();


                cmd_Show.CommandText = " exec SP_BaoCao @Action =  N'GetItemSelectByIdprocedureBaoCao', " +
                    "@IdBaoCao = " + procedureBaoCaoId;

                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsMaBaoCaoExists(string maBaoCao)
        {
            bool exists = false;

            try
            {

                con.Open();
                string queryString = "SELECT COUNT(*) FROM procedureBaoCao WHERE MaBaoCao = @MaBaoCao";

                ////string queryString = "SELECT COUNT(*) FROM procedureBaoCao WHERE MaBaoCao = 'zzz'";
                SqlCommand command = new SqlCommand(queryString, con);
                command.Parameters.AddWithValue("@MaBaoCao", maBaoCao);
                command.Connection = con;
                command.CommandText = queryString;
                command.CommandType = CommandType.Text;


                int count = Convert.ToInt32(command.ExecuteScalar());
                exists = (count > 0);
                con.Close();

            }
            catch
            {

            }

            return exists;


        }

        public static bool CheckLoadDatabase(string query, string ColumnKey, string ColumnTextShow)
        {
            bool ResultCheck = true;
            DataTable table1 = new DataTable();
            try
            {

                SqlCommand cmd_Show = con.CreateCommand();


                cmd_Show.CommandText = query;

                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ResultCheck = false;
                return ResultCheck;
            }

            ResultCheck = table1.Columns.Contains(ColumnKey);
            if (!table1.Columns.Contains(ColumnKey))
            {
                MessageBox.Show("Không tồn tại cột: " + ColumnKey);
                ResultCheck = false;
            }
            if (!table1.Columns.Contains(ColumnTextShow))
            {
                MessageBox.Show("Không tồn tại cột: " + ColumnTextShow);
                ResultCheck = false;
            }

            return ResultCheck;

        }

        public static DataTable ExcuteQuery(string query)
        {

            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();


                cmd_Show.CommandText = query;

                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public static DataTable GetDanhSachBaoCao()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'GetDanhSachBaoCao'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable TamNgungBaoCao(string _Report_Id, string _NgayCapNhat, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'TamNgungBaoCao' , @IdBaoCao = " + _Report_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DeleteBaoCao(string _Report_Id, string _NgayCapNhat, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'DeleteBaoCao' , @IdBaoCao = " + _Report_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectPhongBanPermission()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'SelectPhongBanPermission' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectUserPermissionParent(string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'SelectUserPermissionParent', "
                    + "@PhongBan_Id = " + _PhongBan_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectUserPermissionReport_Id(string _Report_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'SelectUserPermissionReport_Id', "
                    + "@Idx = " + _Report_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DeleteUserPermissionReport_Id(string _Report_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'DeleteUserPermissionReport_Id', "
                    + "@Idx = " + _Report_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertUserPermissionReport_Id(string User_Id, string _Report_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'InsertUserPermissionReport_Id', "
                    + "@User_Id = " + User_Id + ","
                    + "@Idx = " + _Report_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectReportByUser_id(string User_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'SelectReportByUser_id', "
                    + "@User_Id = " + User_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        public static DataTable SelectReportByReport_Id(string _Report_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'SelectReportByReport_Id', "
                    + "@Idx = " + _Report_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectParameterByReport_Id(string _Report_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'SelectParameterByReport_Id', "
                    + "@Idx = " + _Report_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectitemSelectBytypeOfControlInput(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao @Action = N'SelectitemSelectBytypeOfControlInput', "
                    + "@Idx = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ThongTinComBoBox(string _Text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = _Text
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
    }
}
