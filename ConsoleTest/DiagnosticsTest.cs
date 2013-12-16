using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    public class DiagnosticsTest 
    {
        public static void Test()
        {
            object obj = null;
            Trace.Assert(obj != null, "汇总结果不应为空。");
            Console.WriteLine("sadf");
        }
    }
}
