using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Professional_calculator.Model
{
    static class ArithmeticCalculator
    {
        public static float Sum(float a, float b)
        {
            return a + b;   
        }

        public static float Difference (float a, float b)
        {
            return a - b;   
        }

        public static float Mult(float a, float b)
        {
            return a * b;
        }

        public static float Div(float a, float b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>   Rsult of expression calculation    </returns>
        public static string Calculate(string expression)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string expressionResult = dataTable.Compute(expression, null).ToString();
                return expressionResult;
            }
            catch (Exception)
            {
                return String.Format("Incorect expression: ({0})",expression);
            }
        }

        /* This code don`t run for 4-5 and more operands */

        /*static public float CalculateExpression(IEnumerable<float> operandsCollection, IEnumerable<char> operatorsCollection)
        {
            IEnumerator<float> operands = operandsCollection.GetEnumerator();
            IEnumerator<char> operators = operatorsCollection.GetEnumerator();

            operands.MoveNext();
            float result = operands.Current;
            while (operators.MoveNext())
            {
                operands.MoveNext();
                float nextOperand = operands.Current;
                switch (operators.Current)
                {
                    case '+':
                        result += nextOperand;
                        break;
                    case '-':
                        result -= nextOperand;
                        break;
                    case '*':
                        result *= nextOperand;
                        break;
                    case '/':
                        result /= nextOperand;
                        break;
                    default:
                        throw new Exception("Wrong operator!!!");
                }
            }
            return result;
        }*/
    }
}
