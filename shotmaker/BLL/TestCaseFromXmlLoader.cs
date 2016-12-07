﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;
using ScreenshotMaker.DAL;

namespace ScreenshotMaker.BLL
{
	public static class TestCaseFromXmlLoader
	{
		public static TestCase Load(string filePath)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException(string.Format("Can't find file {0}", filePath));

			var dto = XmlLoader.LoadFromFile(filePath);

			var testCase = new TestCase();

			testCase.IdAndTitle = _idAndTitleFromDto(dto);
			testCase.Setups = _setupsFromDto(dto);
			testCase.Verifications = _verificationsFromDto(dto);

			return testCase;
		}

		private static List<Verification> _verificationsFromDto(rss dto)
		{
			var result = new List<Verification>();
			var verificationItems = dto.channel.item.customfields.First(n => n.customfieldname == "Manual Test Steps").customfieldvalues.steps;
			foreach (var verificationItem in verificationItems)
				result.Add(_verificationFromStep(verificationItem));
			return result;
		}

		private static Verification _verificationFromStep(rssChannelItemCustomfieldCustomfieldvaluesStep verificationItem)
		{
			var result = new Verification();
			result.Data = _dataFromDto(verificationItem.data.Text);
			result.Steps = _stepsFromDto(verificationItem);
			return result;
		}

		private static List<Step> _stepsFromDto(rssChannelItemCustomfieldCustomfieldvaluesStep step)
		{
			var result = new List<Step>();
			foreach (var t in _divideStringIntoLines(step.step.Text))
				result.Add(new Step(t));
			int n = 1;
			foreach (var t in _divideStringIntoLines(step.result.Text))
			{
				int m;
				if (t.IndexOf('.') > 0 && int.TryParse(t.Substring(0, t.IndexOf('.')), out m))
				{
					n = m;
					if (n > 0 && n <= result.Count)
						result[n - 1].Results.Add(new StepResult(t.Substring(t.IndexOf('.') + 1)));
				}
				else
				{
					if (n > 0 && n <= result.Count)
						result[n - 1].Results.Add(new StepResult(t));
				}
			}
			return result;
		}

		private static List<Data> _dataFromDto(string data)
		{
			var result = new List<Data>();
			foreach (var t in _divideStringIntoLines(data.ToString()))
				result.Add(new Data(t));
			return result;
		}

		private static string _idAndTitleFromDto(rss dto)
		{
			var s = dto.channel.item.title;
			s = s.Replace("[", "");
			return s.Replace("] ", "-");
		}

		private static readonly string[] _htmlTags =
		{
			@"<br/>",
			@"<br />",
			@"<ul>", @"</ul>", @"<li>", @"</li>", @"<ul class=""alternate"" type=""square"">",
			@"<p>", @"</p>"
		};

		private static List<string> _divideStringIntoLines(string s)
		{
			return new List<string > (s.Split(_htmlTags, StringSplitOptions.RemoveEmptyEntries));

			var html = new HtmlDocument();
			html.LoadHtml(s + @"<br/>");
			var result = new List<string>();
			//			foreach (string t in lines)
			//			result.Add(new Setup(t));
			var nodes = html.DocumentNode.SelectNodes("//*");
			if (nodes == null)
				result.Add("0" + s);
			else
				//				foreach (HtmlNode node in nodes)
				for (int i = 0; i < nodes.Count; i++)
				{
					var node = nodes[i];
					if (node.Name == "br")
					{
						if (node.PreviousSibling != null)
							result.Add("1" + node.PreviousSibling.InnerText.Trim());
						if (i == nodes.Count - 1)
							result.Add("3" + node.InnerText.Trim());
					}
					else
						result.Add("2" + node.InnerText);
				}
			return result;
		}

		public static List<Setup> _setupsFromString(string s)
		{
			var result = new List<Setup>();
			foreach (var t in _divideStringIntoLines(s))
				result.Add(new Setup(t));
			return result;
		}


		private static List<Setup> _setupsFromDto(rss dto)
		{
			var field = dto.channel.item.customfields.First(n => n.customfieldname == "Setup");
			string s = field.customfieldvalues.customfieldvalue;
//			string[] lines = s.Split(_htmlTags, StringSplitOptions.RemoveEmptyEntries);
			return _setupsFromString(s/* + @"&lt;br/&gt;"*/);
		}
	}
}