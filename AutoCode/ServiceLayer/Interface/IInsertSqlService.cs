﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParametersLayer;

namespace ServiceLayer.Interface
{
    public interface IInsertSqlService
    {
        List<string> GetCols(string TableName, string ConnectStr);
        CodeSqlResultModel AutoCode(string TableName, List<string> ColList);
    }
}
