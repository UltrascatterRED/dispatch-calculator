using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSCI_2210_Bartonn_Project4
{
	public static class Menu
	{
		private static readonly Regex VariableFormat = new("[a-z]+");
		public static Dictionary<string, Func<double, double, double>> CalcDispatch = new()
		{
			{ AppCommands.Commands["add"].name, (double a, double b) => a + b },
			{ AppCommands.Commands["sub"].name, (double a, double b) => a - b },
			{ AppCommands.Commands["mtp"].name, (double a, double b) => a * b },
			{ AppCommands.Commands["div"].name, (double a, double b) => a / b },
			{ AppCommands.Commands["mod"].name, (double a, double b) => a % b },
			{ AppCommands.Commands["exp"].name, Math.Pow }
		};

		// refactor to use dispatch table for commands instead of case-switch block
		public static void Run()
		{
            Console.WriteLine("--< Programming Calculator Service >-- | type 'help' for command info");
            bool userContinue = true;
			while (userContinue)
			{
				Console.Write(">>> ");
				string[] input;
				try
				{
					input = Console.ReadLine().ToLower().Split(" ");
					// NON-MATH COMMANDS (not in CalcDispatch due to varying qauntity/type of arguments)
					if (input[0] == AppCommands.Commands["exit"].name) break;
					if (input[0] == AppCommands.Commands["help"].name) 
					{
						if (input.Length <= 1) AppCommands.Display();
						else AppCommands.Display(input[1]);
						continue;
					}
					if (input[0] == AppCommands.Commands["dvar"].name) 
					{
						if (input.Length <= 1) Calculator.DisplayVars();
						else if (Calculator.RunArgAgainstVars(input[1]) >= 0) Calculator.DisplayVar(input[1]);
						else Console.WriteLine($"Invalid command; Variable '{input[1]}' does not exist");
                        continue;
					}
					if (input[0] == AppCommands.Commands["var"].name) 
					{ 
						Calculator.MakeVar(input[1], double.Parse(input[2]));
						continue; 
					}
					if (input[0] == AppCommands.Commands["clr"].name)
					{
						Calculator.ResetAnswer();
						continue;
					}
					// MATH COMMANDS
					double result;
					int arg1Type = Calculator.RunArgAgainstVars(input[1]);
					int arg2Type = Calculator.RunArgAgainstVars(input[2]);
					double arg1;
					double arg2;
					// resolve values of arg1 and arg2
					switch (arg1Type)
					{
						case 1:
							arg1 = Calculator.GetAnswer();
							break;
						case 0:
							arg1 = Calculator.GetVarValue(input[1]);
							break;
						case -1:
							arg1 = double.Parse(input[1]);
							break;
						default:
							arg1 = double.Parse(input[1]);
							break;
					}
					switch (arg2Type)
					{
						case 1:
							arg2 = Calculator.GetAnswer();
							break;
						case 0:
							arg2 = Calculator.GetVarValue(input[2]);
							break;
						case -1:
							arg2 = double.Parse(input[2]);
							break;
						default:
							arg2 = double.Parse(input[1]);
							break;
					}
					// run input command on arguments, update answer variable, display answer to screen
					result = CalcDispatch[input[0]](arg1, arg2);
					Calculator.SetAnswer(result);
					Console.WriteLine(result);
				}
				catch
				{
                    Console.WriteLine("Invalid command or syntax; type 'help' or 'help [command name]' for more info");
                }
			}
		}
	}
}
