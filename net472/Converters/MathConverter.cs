using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Text.RegularExpressions;

namespace XUi.Converters
{
    /// <summary>
    /// Implement a math converter
    /// Use @VALUE to get the value
    /// Can get a ressource defined in the application
    /// </summary>
    public class MathConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Converter base method
        /// </summary>
        /// 
        /// <param name="value">Value to use</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Main math expression</param>
        /// <param name="culture"></param>
        /// 
        /// <returns>Main math expression evaluated</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Assign the math equation to a string
            string mathEquation = parameter as string;
            double result = 0;

            // Replace all the @VALUE iteration by the value
            mathEquation = mathEquation.Replace(" ", "");
            mathEquation = mathEquation.Replace("@VALUE", value.ToString());

            // Regex to find all the accolades
            Regex ressourcesRegex = new Regex(@"(?<=\{).+?(?=\})");
            // Get all the matches and get all the value
            string[] ressourcesMatches = ressourcesRegex.Matches(mathEquation).Cast<Match>().Select(m => m.Value).ToArray();
            foreach (string match in ressourcesMatches) {
                // Get the ressource value
                string ressourceValue = RessourceEval(match);
                // Replace the ressource value by the raw match in the math equation
                mathEquation = mathEquation.Replace("{" + match + "}", ressourceValue);
            }

            // Regex to find all the parentheses
            Regex parenthesesRegex = new Regex(@"(?<=\().+?(?=\))");
            // Get all the matches and get all the value
            string[] parenthesesMatches = parenthesesRegex.Matches(mathEquation).Cast<Match>().Select(m => m.Value).ToArray();
            foreach (string match in parenthesesMatches) {
                // Eval the parenthese expression and add it to the result
                result += ParenthesesEval(match);
                // Remove the parenthese expression
                mathEquation = mathEquation.Replace($"({match})", "");
            }

            // Regex to find all the number
            Regex findNumber = new Regex(@"\d+");
            // Get all the matches and get all the value
            string[] numbersMatch = findNumber.Matches(mathEquation).Cast<Match>().Select(m => m.Value).ToArray();
            // Get all the operators
            string[] operators = mathEquation.Split(numbersMatch, StringSplitOptions.None);
            // Eval the last math equation
            result += MathExpressionEval(operators, numbersMatch);

            // Return the result
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Find the ressource value in the application
        /// </summary>
        /// 
        /// <param name="ressource">Ressource name</param>
        /// 
        /// <returns>Ressource value by his name</returns>
        public string RessourceEval(string ressource)
        {
            string result = "";
            // Get the ressource value
            object value = XUiTheme.XUiDictionnaries[ressource];

            // Determine his type and parse it with is type
            if (value is double)
                result = value.ToString();
            else if (value is int)
                result = value.ToString();
            else if (value is string)
                result = (string)value;
            else
                // Don't support his type
                throw new Exception("Unsuported type");

            // Return the result
            return result;
        }

        /// <summary>
        /// Evaluate a parenthese expression
        /// </summary>
        /// 
        /// <param name="mathEquation">Parenthese math expression</param>
        /// 
        /// <returns>Parenthese expression evaluated</returns>
        public double ParenthesesEval(string mathEquation)
        {
            double result = 0;
            // Regex to find all the number
            Regex findNumber = new Regex(@"\d+");
            // Split all the parentheses because the regex expression is bad
            string[] parenthesesSplit = mathEquation.Split(new char[] { '(', ')' });

            // For each sub math expression
            foreach (string mathExpression in parenthesesSplit)
            {
                // Match all the numbers
                string[] numbersMatch = findNumber.Matches(mathEquation).Cast<Match>().Select(m => m.Value).ToArray();
                // Get all the operators
                string[] operators = mathExpression.Split(numbersMatch, StringSplitOptions.None);
                // Eval the math expression
                result = MathExpressionEval(operators, numbersMatch);
            }

            return result;
        }

        /// <summary>
        /// Evaluate any math expression
        /// This method is the heart of the math converter
        /// </summary>
        /// 
        /// <param name="operators">All the operators in the math expression</param>
        /// <param name="numbers">All the numbers in the math expression</param>
        /// 
        /// <returns>Math expression evaluated by the operators and the numbers passed in the method</returns>
        public double MathExpressionEval(string[] operators, string[] numbers)
        {
            // Define some variables
            double result = double.Parse(numbers[0]);
            int operatorCount = operators.Length - 1;
            int indexNumbersMatch = 0;

            for (int i = 0; i <= operatorCount; i++)
            {
                // Check if the operators is not blank
                if (operators[i] != "")
                {
                    if (i == 0 && operators[i] != "")
                    {
                        // Switch the operators
                        switch (operators[i])
                        {
                            case "+":
                                result += double.Parse(numbers[indexNumbersMatch]) + double.Parse(numbers[indexNumbersMatch + 1]);
                                break;

                            case "-":
                                result += double.Parse(numbers[indexNumbersMatch]) - double.Parse(numbers[indexNumbersMatch + 1]);
                                break;

                            case "*":
                                result += double.Parse(numbers[indexNumbersMatch]) * double.Parse(numbers[indexNumbersMatch + 1]);
                                break;

                            case "/":
                                result += double.Parse(numbers[indexNumbersMatch]) / double.Parse(numbers[indexNumbersMatch + 1]);
                                break;

                            case "%":
                                result += double.Parse(numbers[indexNumbersMatch]) % double.Parse(numbers[indexNumbersMatch + 1]);
                                break;
                        }

                        // Update the index
                        indexNumbersMatch += 2;
                    }
                    else if (operators[i] != "")
                    {
                        // Switch the operators
                        switch (operators[i])
                        {
                            case "+":
                                result = result + double.Parse(numbers[indexNumbersMatch + 1]);
                                break;

                            case "-":
                                result = result - double.Parse(numbers[indexNumbersMatch + 1]);
                                break;

                            case "*":
                                result = result * double.Parse(numbers[indexNumbersMatch + 1]);
                                break;

                            case "/":
                                result = result / double.Parse(numbers[indexNumbersMatch + 1]);
                                break;

                            case "%":
                                result = result % double.Parse(numbers[indexNumbersMatch + 1]);
                                break;
                        }

                        // Update the index
                        indexNumbersMatch += 1;
                    }
                }
            }

            return result;
        }
    }
}
