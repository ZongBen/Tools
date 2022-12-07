﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Interface;
using ParametersLayer;

namespace ServiceLayer
{
    public class InsertSqlService : ICodeSqlService
    {
        private readonly IDBProvider _Provider;
        public InsertSqlService()
        {
            _Provider = new DBProvider();
        }

        public List<string> GetCols(string TableName, string ConnectStr)
        {
            IList<TableColumns> tableColumns = _Provider.GetTableColumns(TableName, ConnectStr);
            return tableColumns.Select(x => x.Column_Name).ToList();
        }

        public CodeSqlResultModel AutoCode(string TableName, List<string> ColList)
        {
            StringBuilder SbSql = new StringBuilder();
            StringBuilder SbCol = new StringBuilder();
            StringBuilder SbVal = new StringBuilder();
            StringBuilder SbParam = new StringBuilder();

            SbSql.Append($"INSERT INTO {TableName}" + Environment.NewLine);
            SbSql.Append("(" + Environment.NewLine);

            
            foreach (string col in ColList)
            {
                SbCol.Append($",{col}" + Environment.NewLine);
                SbVal.Append($",@{col}" + Environment.NewLine);
                SbParam.Append($"parameters.Add(\"@{col}\", model.{col});" + Environment.NewLine);
            }
            SbCol = SbCol.Remove(0, 1);
            SbVal = SbVal.Remove(0, 1);

            SbSql.Append(SbCol.ToString());
            SbSql.Append(")" + Environment.NewLine);
            SbSql.Append("VALUES" + Environment.NewLine);
            SbSql.Append("(" + Environment.NewLine);
            SbSql.Append(SbVal.ToString());
            SbSql.Append(")");

            return new CodeSqlResultModel { InsertSql = SbSql.ToString(), Params = SbParam.ToString() };
        }
    }
}
