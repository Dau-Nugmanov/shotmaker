﻿using System;
using System.Collections.Generic;
using System.IO;

namespace ScreenshotMaker.BLL
{
	public class TestCase : IGenerateFileInfoForTestCaseItem
	{
		public string ExecutionIdAndTitle { get; set; }
		public string IdAndTitle { get; set; }

		public List<Setup> Setups { get; set; }
		public List<Verification> Verifications { get; set; }

		public void ClearSession()
		{
		}

		private void ThrowExceptionIfPathPartIsEmpty(string pathPart, string pathPartName)
		{
			if (pathPart == null || pathPart == "")
				throw new InvalidOperationException("Can't generate a path with an empty name of the " + pathPartName);
		}

		public FileInfoDto GenerateFileInfoForTestCaseItem(TestCaseItem testCaseItem, string rootFolder)
		{
			ThrowExceptionIfPathPartIsEmpty(rootFolder, "root folder");
			ThrowExceptionIfPathPartIsEmpty(ExecutionIdAndTitle, "Test Execution Id and Title");
			ThrowExceptionIfPathPartIsEmpty(IdAndTitle, "Test Case Id and Title");
			FileInfoDto partOfPathAndFileName = GenerateFileInfo(testCaseItem);
			string path = Path.Combine(
				PathCleaner.GetPathWithoutInvalidChars(rootFolder),
				PathCleaner.GetPathWithoutInvalidChars(ExecutionIdAndTitle),
				PathCleaner.GetPathWithoutInvalidChars(IdAndTitle),
				PathCleaner.GetPathWithoutInvalidChars(partOfPathAndFileName.Path));
			string fileName = PathCleaner.GetFileNameWithoutInvalidChars(partOfPathAndFileName.FileName);
			int maxFileNameLength = 100;
			if (fileName.Length > maxFileNameLength)
				fileName = fileName.Substring(0, maxFileNameLength);
			return new FileInfoDto(path, fileName);
		}

		private FileInfoDto GenerateFileInfo(TestCaseItem item)
		{
			if (item is Setup)
				return GenerateFileInfo(item as Setup);
			if (item is Data)
				return GenerateFileInfo(item as Data);
			if (item is StepResult)
				return GenerateFileInfo(item as StepResult);
			throw new InvalidOperationException();
		}

		private FileInfoDto GenerateFileInfo(Data data)
		{
			Verification verification = data.Parent as Verification;
			if (verification == null)
				throw new InvalidOperationException();
			int verificationNum = verification.Number;
			int dataNum = verification.Data.IndexOf(data);
			if (dataNum < 0)
				throw new InvalidOperationException();
			var result = new FileInfoDto();
			result.Path = string.Format(@"Verification-{0}\", verificationNum.ToString("D2"));
			result.FileName = string.Format("Data-{0}-{1}", (dataNum + 1).ToString("D2"), data.Text);
			return result;
		}

		private FileInfoDto GenerateFileInfo(Setup setup)
		{
			int setupNum = Setups.IndexOf(setup);
			if (setupNum < 0)
				throw new InvalidOperationException();
			var result = new FileInfoDto();
			result.Path = @"Setup\";
			result.FileName = string.Format("{0}-{1}", (setupNum + 1).ToString("D2"), setup.Text);
			return result;
		}

		private FileInfoDto GenerateFileInfo(StepResult stepResult)
		{
			Step step = stepResult.Parent as Step;
			if (step == null)
				throw new InvalidOperationException();
			int stepResultNum = step.Results.IndexOf(stepResult);
			if (stepResultNum < 0)
				throw new InvalidOperationException();
			int stepNum = step.Number;
			Verification verification = step.Parent as Verification;
			int verificationNum = verification.Number;
			var result = new FileInfoDto();
			result.Path = string.Format(@"Verification-{0}\",
				verificationNum.ToString("D2"));
			string postfix;
			switch (stepResult.Result)
			{
				case Result.Failed:
					postfix = "Failed";
					break;
				case Result.Passed:
					postfix = "Passed";
					break;
				default:
					postfix = "";
					break;
			}
			result.FileName = string.Format("Step {0}-{1}{2}{3}",
				stepNum,
				step.Results.Count > 1 ? (stepResultNum + 1).ToString("D2") + "-" : "",
				stepResult.Text,
				postfix == "" ? "" : "-" + postfix);
			return result;
		}
	}
}