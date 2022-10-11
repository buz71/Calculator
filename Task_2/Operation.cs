//Подключение необходимых библиотек
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace Operations
{
    internal static class Operation
    {
        //Сумма
        public static void Sum(StringBuilder firstNum, StringBuilder secondNum, bool isDouble, ref string result)
        {
            if (!isDouble)
            {
                int num1 = int.Parse(firstNum.ToString());
                int num2 = int.Parse(secondNum.ToString());
                result = (num1 + num2).ToString();
            }
            if (isDouble)
            {
                double num1 = Convert.ToDouble((firstNum.ToString()));
                double num2 = Convert.ToDouble((secondNum.ToString()));
                result = (num1 + num2).ToString();
            }
        }

        //Разность
        public static void Sub(StringBuilder firstNum, StringBuilder secondNum, bool isDouble, ref string result)
        {
            if (!isDouble)
            {
                int num1 = int.Parse(firstNum.ToString());
                int num2 = int.Parse(secondNum.ToString());
                result = (num1 - num2).ToString();
            }
            if (isDouble)
            {

                double num1 = Convert.ToDouble((firstNum.ToString()));
                double num2 = Convert.ToDouble((secondNum.ToString()));
                result = (num1 - num2).ToString();
            }
        }

        //Умножение
        public static void Multip(StringBuilder firstNum, StringBuilder secondNum, bool isDouble, ref string result)
        {
            if (!isDouble)
            {
                int num1 = int.Parse(firstNum.ToString());
                int num2 = int.Parse(secondNum.ToString());
                result = (num1 * num2).ToString();
            }
            if (isDouble)
            {

                double num1 = Convert.ToDouble((firstNum.ToString()));
                double num2 = Convert.ToDouble((secondNum.ToString()));
                result = (num1 * num2).ToString();
            }
        }

        //Деление
        public static void Div(StringBuilder firstNum, StringBuilder secondNum, bool isDouble, ref string result)
        {
            if (!isDouble)
            {
                double num1 = int.Parse(firstNum.ToString());
                double num2 = int.Parse(secondNum.ToString());
                result = (num1 / num2).ToString();
            }
            if (isDouble)
            {
                double num1 = Convert.ToDouble((firstNum.ToString()));
                double num2 = Convert.ToDouble((secondNum.ToString()));
                result = (num1 / num2).ToString();
            }
        }

    }
}
