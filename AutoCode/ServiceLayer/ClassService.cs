﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interface;
using System.IO;
using ParametersLayer;
using DataAccessLayer;
using DataAccessLayer.Interface;

namespace ServiceLayer
{
    public class ClassService : IClassService
    {
        private readonly IDBProvider _Provider;
        private readonly ICommonService _commonService;
        public ClassService()
        {
            _Provider = new DBProvider();
            _commonService = new CommonService();
        }

        public void AutoCode(string TableName, string FolderPath, string ConnectStr)
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            FolderPath += $"\\{TableName}.cs";
            StreamWriter sw = File.CreateText(FolderPath);
            List<TableColumns> tableColumns = _Provider.GetTableColumns(TableName, ConnectStr).ToList();
            sw.Write(_commonService.CodeClass(TableName, tableColumns));
            sw.Flush();
            sw.Close();
        }
    }
}
