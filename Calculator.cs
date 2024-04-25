using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210_Bartonn_Project4
{
	public static class Calculator
	{
		private static (string name, double value) Answer = ("ans", 0);
		private static Dictionary<string, double> UserVars = new();

		public static double GetAnswer() { return Answer.value; }
		public static void SetAnswer(double answer)
		{
			Answer.value = answer;
		}
		public static void ResetAnswer()
		{
			Answer.value = 0;
		}
		public static double GetVarValue(string name) { return UserVars[name]; }
		public static void MakeVar(string name, double value)
		{
			UserVars.Add(name, value);
		}
		public static void DisplayVar(string name)
		{
			if (name == Answer.name)
			{
				Console.WriteLine($"{Answer.name} = {Answer.value}");
				return;
			}
			Console.WriteLine($"{name} = {UserVars[name]}");
		}
		public static void DisplayVars()
		{
			Console.WriteLine
				("Current Variables" +
				"\n--------------------------------------------");
			Console.WriteLine($"{Answer.name} = {Answer.value}");
			foreach (string var in UserVars.Keys)
			{
				DisplayVar(var);
			}
			Console.WriteLine("--------------------------------------------");
		}
		public static void RemoveVar(string name)
		{
			UserVars.Remove(name);
		}
		/// <summary>
		/// Compares input string with each existing Calculator variable.
		/// </summary>
		/// <param name="arg"></param>
		/// <returns>
		/// 1 if input is enviroment variable 'ans' <br/>
		/// 0 if input is a valid user-created variable <br/>
		/// -1 if input is not an existing variable
		/// </returns>
		public static int RunArgAgainstVars(string arg)
		{
			if (arg == Answer.name) return 1;
			foreach (string var in UserVars.Keys)
			{
				if(arg == var) return 0;
			}
			return -1;
		}
	}
}
