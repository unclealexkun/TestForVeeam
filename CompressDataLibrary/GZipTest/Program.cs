using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace GZipTest
{
	class Program
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		static int Main(string[] args)
		{
			switch (args.Length)
			{
				case 0:
				{
					logger.Error("Command line is empty! Use \\h for help.");

					return 1;
				}
				case 1:
				{
					logger.Info(Helper);

					break;
				}
				case 3:
				{
					try
					{

					}
					catch (Exception ex)
					{
						logger.Error(ex);

						return 1;
					}

					break;
				}
				default:
				{
					logger.Error("Command line consist more 3 value! Use \\h for help.");

					return 1;
				}
			}

			return 0;
		}

		static string Helper()
		{
			var help = new StringBuilder();
			help.AppendLine("Helper");
			help.AppendLine("Command syntax: compress/decompress [source file name] [result file name]");
			help.AppendLine("Example: GZipTest.exe compress C:\\1.txt C:\\2.zip");

			return help.ToString();
		}
	}
}
