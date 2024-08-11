using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_Chart_Graph
{
    internal class Xgenerate
    {
        public double leftx, rightx, stepx;
        public Xgenerate(double leftx, double rightx, double stepx)
        {
            this.leftx = leftx;
            this.rightx = rightx;
            this.stepx = stepx;
        }
        public class ZeroStepExeption : Exception
        {
            // Конструктор для передачи сообщения об ошибке базовому классу Exception
            public ZeroStepExeption(string message) : base(message)
            {
            }
        }
        public class  BorderExeption: Exception
        {
            // Конструктор для передачи сообщения об ошибке базовому классу Exception
            public BorderExeption(string message) : base(message)
            {
            }
        }

        public double[] Xgen(double leftx, double rightx, double stepx)
        {
            if (stepx == 0)
            {
                throw new ZeroStepExeption("Choose a step other than zero!");
            }

            if (leftx >= rightx)
            {
                throw new BorderExeption("The left border must be smaller than the right!");
            }

            int lenofmas = (int)Math.Ceiling((rightx - leftx) / stepx) + 1;

            double[] x = new double[lenofmas];
            for (int i = 0; i < lenofmas; i++)
            {
                x[i] = leftx + i * stepx;
            }

            return x;

          /*   if (stepx == 0)
             {
                 throw new ZeroStepExeption("Выберите шаг отличный от нуля!");

             }
             int lenofmas = 0;
             if (leftx < 0 || rightx < 0)
             {
                 lenofmas = (int)((Math.Abs(leftx) + rightx) / stepx) + 1;
             }

             else if((leftx < 1.0) && (rightx < 1.0) && (IsFractionPartEven(leftx) == false) && (IsFractionPartEven(rightx) == false))
             {
                 int lenofmasspecific = (int)((rightx - leftx) / stepx) + 1;
                 lenofmas = (int)(Math.Ceiling((rightx - leftx) / stepx)) + 1;

                 if(lenofmas < lenofmasspecific)
                 {
                     lenofmas = lenofmasspecific;
                 }
             }

             else
             {
                 lenofmas = (int)((rightx - leftx) / stepx) + 1;

             }

             double[] x = new double[lenofmas];
             int i = 0;
             while (i < x.Length)
             {
                 x[i] = leftx + i * stepx;
                 i++;
             }
             return x;
            */
        }
        
       public double StepFinder(double stepfromSet, double firstValue, double secondValue)
        {
            double stepfind;

            if(stepfromSet != null)
            {
                stepfind = stepfromSet;
                return stepfind;
            }
            else
            {
                stepfind = Math.Abs(secondValue - firstValue);
                return stepfind;
            }
        }
        bool IsFractionPartEven(double number)
        {
            string numberAsString = number.ToString();
            char lastChar = numberAsString[numberAsString.Length - 1];
            int lastDigit = int.Parse(lastChar.ToString());
            return lastDigit % 2 == 0;
        }


    }
}
