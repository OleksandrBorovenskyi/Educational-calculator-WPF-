using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Professional_calculator.Model
{
    /* Class for:
     * parsing string expression into operators and operands,
     */
    class InputParser
    {
        List<char> operators;
        List<float> operands;

        public List<char> GetOperators { get { return operators; } }
        public List<float> GetOperands { get { return operands; } }


        public InputParser(string expression)
        {
            operators = new List<char>();
            operands = new List<float>();
            Parse(expression);
        }


        /// <summary>
        /// String parser on operators and operands
        /// </summary>
        /// <param name="expression"></param>
        private void Parse(string expression)
        {
            char[] separators = new char[] { '+', '-', '*', '/' };
            LinkedList<string> operandsAsString = new LinkedList<string>(expression.Split(separators));

            for (int separatorItem = 0; separatorItem < separators.Length; separatorItem++)
            {
                for (int expressionChar = 0; expressionChar < expression.Length; expressionChar++)
                {
                    if (expression[expressionChar] == separators[separatorItem])
                    {
                        operators.Add(expression[expressionChar]);
                    }
                }
            }

            // Parsing of operands
            foreach (var item in operandsAsString)
            {
                operands.Add(float.Parse(item));
            }
        }
    }
}
