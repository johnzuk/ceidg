using System;
using System.Net;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using ceidg.Exceptions;

namespace ceidg
{
	public class Ceidg
	{
		public HtmlDocument Document {
			get;
			private set;
		}

		public string Uri = "https://prod.ceidg.gov.pl/ceidg/ceidg.public.ui/";

        public void LoadHtml(string html)
		{
			Document = new HtmlDocument();
			Document.LoadHtml(html);
		}

		public List<Subject> GetSubjects()
		{
			using(WebClient client = new WebClient()) {
				return GetUrls().Select(n => Parse(client.DownloadString(n))).ToList();
			}
		}

		protected Subject Parse(string html) 
		{
			Document.LoadHtml(html);

			return new Subject{
				Name = Document.GetElementbyId("MainContent_lblFirstName").InnerText,
				Surname = Document.GetElementbyId("MainContent_lblLastName").InnerText,
				NIP = Document.GetElementbyId("MainContent_lblNip").InnerText,
				REGON = Document.GetElementbyId("MainContent_lblRegon").InnerText,
				Compny = Document.GetElementbyId("MainContent_lblName").InnerText,
				WWW = Document.GetElementbyId("MainContent_lblEmail").InnerText,
				Email = Document.GetElementbyId("MainContent_lblWebstite").InnerText
			};
		}

		protected List<string> GetUrls()
		{
            try {
                return Document.GetElementbyId("MainContent_DataListEntities")
                .SelectNodes("//a[@class='searchITA']")
                .Select(n => Uri + n.Attributes["href"].Value).Distinct().ToList();
            } catch (NullReferenceException ex) {
                throw new InvalidFileFormatException("Invalid file format");
            }
			
		}
	}
}

