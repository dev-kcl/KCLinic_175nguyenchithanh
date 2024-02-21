using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using KClinic2._1.Model;

namespace KClinic2._1.Service
{
    internal class ProcedureDefinitionService
    {
        private readonly SqlConnection _connection;
        public ProcedureDefinitionService()
        {
            var connection = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");
            _connection = new SqlConnection(connection);
        }
        public string[] GetAllProcedureNames()
        {
            try
            {
                DataTable table = new DataTable();
                SqlCommand cmd_Show = _connection.CreateCommand();
                cmd_Show.CommandText = "SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'";
                _connection.Open();
                table.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                _connection.Close();
                var result = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    result.Add(row["SPECIFIC_NAME"].ToString());
                }
                return result.ToArray();
            }
            catch
            {
                return new List<string>().ToArray();
            }

        }

        public ProcedureParam[] GetDefinitions(string procedureName)
        {
            DataTable table = new DataTable();
            SqlCommand cmd_Show = _connection.CreateCommand();
            cmd_Show.CommandText = $"select 'Parameter_name' = name, 'Type' = type_name(user_type_id) from sys.parameters where object_id = object_id('{procedureName}')";
            _connection.Open();
            table.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
            _connection.Close();
            return ResolveProcedureDefinition(table);
        }

        public ProcedureParamEdit[] GetDefinitionsEdit(string procedureName, string procedureId)
        {
            DataTable table = new DataTable();
            SqlCommand cmd_Show = _connection.CreateCommand();
            cmd_Show.CommandText = $"select 'Id' = p.Id, 'NameShowLabel' = p.NameShowLabel,'Parameter_name' = name, 'Type' = type_name(user_type_id),'typeOfControlInput' = p.TypeOfControlInputId," +
                $"typeOfItemSelect, ValueIntCheckBoxTrue,ValueIntCheckBoxFalse,ValueStringCheckBoxTrue, ValueStringCheckBoxFalse, TypeOfLoadItem " +
                $" from sys.parameters c join[procedureParameter] p on SUBSTRING(c.name, 2, LEN(c.name) - 1) = p.ParameterName where object_id = object_id('{procedureName}')  and procedureBaoCaoId = {procedureId}";
            _connection.Open();
            table.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
            _connection.Close();
            return ResolveProcedureDefinitionEdit(table);
        }

        public GetItemSelectEdit[] GetDefinitionsItemSelectEdit(string procedureId)
        {
            DataTable table = new DataTable();
            SqlCommand cmd_Show = _connection.CreateCommand();
            cmd_Show.CommandText = $"exec SP_BaoCao @Action =  N'GetItemSelectByIdprocedureBaoCao', @IdBaoCao = {procedureId}";
            _connection.Open();
            table.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
            _connection.Close();
            return ResolveProcedureDefinitionItemSelectEdit(table);
        }

        private ProcedureParam[] ResolveProcedureDefinition(DataTable table)
        {
            var result = new List<ProcedureParam>();
            foreach (DataRow row in table.Rows)
            {
                result.Add(new ProcedureParam()
                {
                    ParamName = row["Parameter_name"].ToString().Substring(1),
                    Type = row["Type"].ToString()
                });
            }
            return result.ToArray();
        }
        private ProcedureParamEdit[] ResolveProcedureDefinitionEdit(DataTable table)
        {
            var result = new List<ProcedureParamEdit>();
            foreach (DataRow row in table.Rows)
            {
                result.Add(new ProcedureParamEdit()
                {
                    Id = row["Id"].ToString(),
                    NameShowLabel = row["NameShowLabel"].ToString(),
                    ParamName = row["Parameter_name"].ToString().Substring(1),
                    Type = row["Type"].ToString(),
                    typeOfControlInput = row["typeOfControlInput"].ToString(),
                   typeOfItemSelect = row["typeOfItemSelect"].ToString(),
                    ValueIntCheckBoxTrue = row["ValueIntCheckBoxTrue"].ToString(),
                    ValueIntCheckBoxFalse = row["ValueIntCheckBoxFalse"].ToString(),
                    ValueStringCheckBoxTrue = row["ValueStringCheckBoxTrue"].ToString(),
                    ValueStringCheckBoxFalse = row["ValueStringCheckBoxFalse"].ToString(),
                    TypeOfLoadItem = row["TypeOfLoadItem"].ToString(),
                    
       
                });
            }
            return result.ToArray();
        }
        private GetItemSelectEdit[] ResolveProcedureDefinitionItemSelectEdit(DataTable table)
        {
            var result = new List<GetItemSelectEdit>();
            foreach (DataRow row in table.Rows)
            {
                result.Add(new GetItemSelectEdit()
                {
                    Id = Int32.Parse(row["Id"].ToString()),
                    ValueItemString = row["ValueItemString"].ToString(),
                    ValueItemInt = Int32.Parse(row["ValueItemInt"].ToString()),
                    ShowText = row["ShowText"].ToString(),
                    NumericalOrder = Int32.Parse(row["NumericalOrder"].ToString()),
                    procedureParameterId = Int32.Parse(row["procedureParameterId"].ToString()),
                    QueryDatabase = row["QueryDatabase"].ToString(),
                    ColumnKey = row["ColumnKey"].ToString(),
                    ColumnTextShow = row["ColumnTextShow"].ToString(),
                    procedureParameterNumericalOrder = Int32.Parse(row["procedureParameterNumericalOrder"].ToString())
                });
            }
            return result.ToArray();
        }
    }
}
