﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface ISbSqlService
    {
        string Output(string[] input);
        string Recover(string[] input);
    }
}
