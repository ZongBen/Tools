﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interface;

namespace ServiceLayer
{
    public class SbSqlService : ISbSqlService
    {
        public string Output(string[] input)
        {
            StringBuilder result = new StringBuilder();
            result.Append("StringBuilder SbSql = new StringBuilder();" + Environment.NewLine);
            foreach (var item in input)
            {
                result.Append($"SbSql.Append(\"{item.TrimEnd()}\" + Environment.NewLine);" + Environment.NewLine);
            }
            return result.ToString();
        }

        public string Recover(string [] input)
        {
            StringBuilder result = new StringBuilder();
            foreach(var item in input)
            {
                if(item.IndexOf('"') == -1)
                {
                    continue;
                }
                var line = item.Remove(0, item.IndexOf('"') + 1);
                line = line.Substring(0, line.LastIndexOf('"'));
                result.Append(line + Environment.NewLine);
            }
            return result.ToString();
        }
    }
}
