using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210_Bartonn_Project4
{
	public static class AppCommands
	{
		public record CommandRecord(string name, string syntax, string description);
		public static readonly Dictionary<string, CommandRecord> Commands = new()
		{
			{ "add", new CommandRecord("add", "add <double1> <double2>", "Adds double1 and double2 together.") },
			{ "sub", new CommandRecord("sub", "sub <double1> <double2>", "Subtracts double2 from double1.") },
			{ "mtp", new CommandRecord("mtp", "mtp <double1> <double2>", "Multiplies double1 and double2 together.") },
			{ "div", new CommandRecord("div", "div <double1> <double2>", "Divides double1 by double2.") },
			{ "mod", new CommandRecord("mod", "mod <double1> <double2>", "Calculates remainder of (double1 / double2).") },
			{ "exp", new CommandRecord("exp", "exp <double1> <double2>", "Raises double1 to the power of double2.") },
			{ "clr", new CommandRecord("clr", "clr", "Clears answer data (sets environment variable 'ans' to 0).") },
			{ "var", new CommandRecord("var", "var <str> <dbl>", "Creates a session variable with name str and value dbl.\nVariable names must be comprised of lowercase alphabetical characters only.") },
			{ "dvar", new CommandRecord("dvar", "dvar [name]", "Displays the specified variable 'name', or all session variables if none are specified.") },
			{ "help", new CommandRecord("help", "help [command]", "Displays syntax and description for the specified command.\nDisplays help for all commands if no command is specified.") },
			{ "exit", new CommandRecord("exit", "exit", "Exits the app.") }
		};
		public static void Display()
		{
			Console.WriteLine("<arg> = mandatory argument | [arg] = optional argument");
            Console.WriteLine("-----------------------------------------------------------\n");
            foreach (var command in Commands)
			{
				Display(command.Key);
            }
		}
		public static void Display(string command)
		{
			Console.WriteLine(Commands[command].name + " | SYNTAX: " + Commands[command].syntax);
			Console.WriteLine("-----------------------------------------------------------");
			Console.WriteLine(Commands[command].description + "\n");
		}
	}
}
