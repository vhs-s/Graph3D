using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Core;
using NCalc;

namespace _3D_Chart_Graph
{
    internal class MyFunctions
    {
        public MyFunctions()
        {
         
        }

        public class NaNorInfinity : Exception
        {
            // Конструктор для передачи сообщения об ошибке базовому классу Exception
            public NaNorInfinity(string message) : base(message)
            {
            }
        }

        public class  OneParameter: Exception
        {
            // Конструктор для передачи сообщения об ошибке базовому классу Exception
            public OneParameter(string message) : base(message)
            {
            }
        }
        _3D_Chart_Graph.Logger logger = new _3D_Chart_Graph.Logger("Program.log"); // Имя файла лога
        public double f1 (double x, double y, string equation)
        {
            // return (Math.Pow(x, 2) - Math.Pow(y, 2));
            //return Math.Cos (x+y);
            // double r = 0.15 * Math.Sqrt(x * x + y * y);
            //if (r < 1e-10) return 120;
            // else return 120 * Math.Sin(r) / r;
            
            
                string eq = equation;
                Expression eqobb = new Expression(eq);
            
                eqobb.Parameters["x"] = x;
                eqobb.Parameters["y"] = y;

                var result = eqobb.Evaluate();
           
                if(!eq.Contains('x') || !eq.Contains('y')) { throw new OneParameter("Please enter a function of two variables. Example: x + y"); }
                if (result == null || (Double.IsNaN((double)result) || Double.IsInfinity((double)result))) { logger.WriteLog($"Error With Parametrs x = {x}, y = {y}, Function = {eq}") ; throw new NaNorInfinity("the calculations resulted in an invalid value"); }
                return (double)result;
        }
    }
}
