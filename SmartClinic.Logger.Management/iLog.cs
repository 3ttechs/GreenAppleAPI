﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamrtClinic.Logger.Management
{
    interface iLog
    {
        string Log(string sPathName, string sErrMsg);
    }
}
