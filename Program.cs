using System;
using System.Net;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ceidg
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string content = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "test.html");
			Ceidg data = new Ceidg(content);

			foreach (var item in data.GetSubjects()) {
				Console.WriteLine (item.Compny);
			}
		}
	}
}
