using CrimeReportingSystemAPP.Main;
using CrimeReportingSystemAPP.dao;
using CrimeReportingSystemAPP.Entity;
using CrimeReportingSystemAPP.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystemAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainModule main =new MainModule();    
            main.Module();
        }
    }
}
