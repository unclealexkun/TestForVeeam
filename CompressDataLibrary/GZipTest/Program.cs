using System;
using System.IO;
using System.Text;
using CompressDataLibrary;
using CompressDataLibrary.Enums;
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
					if (args[0].ToLower() == "\\h")
					{
						logger.Info(Helper);
					}
					else
					{
						logger.Error("Unknown parameter.");
						logger.Error("Command line consist more 3 value! Use \\h for help.");

						return 1;
					}

					break;
				}
				case 3:
				{
					Mode mode = Mode.None;

					if (args[0].ToLower() == "compress")
					{
						mode = Mode.Compress;
					}

					if (args[0].ToLower() == "decompress")
					{
						mode = Mode.Decompress;
					}

					var source = new FileInfo(args[1].ToLower());
					var distribute = new FileInfo(args[2].ToLower());
					var compressor = new Compressor();

					try
					{
						if (mode == Mode.Compress)
						{
							compressor.Compress(source.FullName, distribute.FullName);
						}

						if (mode == Mode.Decompress)
						{
							compressor.Decompress(source.FullName, distribute.FullName);
						}
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
