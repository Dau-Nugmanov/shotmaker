﻿using System;
using System.Windows.Forms;
using ScreenshotMaker.BLL;
using ScreenshotMaker.DAL;

namespace ScreenshotMaker.PrL
{
	public partial class FormMain : Form, IView
	{
		private IPresenter _presenter;

		public FormMain(IPresenter presenter)
		{
			InitializeComponent();

			presenter.View = this;

			_presenter = presenter;

			treeView2.ExpandAll();
		}

		public string GetTestExecutionName()
		{
			throw new NotImplementedException();
		}

		public string GetOuputFolderPath()
		{
			throw new NotImplementedException();
		}

		public void ShowMessage(string message)
		{
			throw new NotImplementedException();
		}

		public void RefreshTreeStructure()
		{
			throw new NotImplementedException();
		}

		public void RefreshData()
		{
			throw new NotImplementedException();
		}

		public string GetInputFileName()
		{
			throw new NotImplementedException();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			string[] files = new string[] {
			"C:\\proj\\shotmaker\\task\\examples of input\\OLSS-4818.xml",
			"C:\\proj\\shotmaker\\task\\examples of input\\test case.xml",
			"C:\\proj\\shotmaker\\task\\examples of input\\test1.xml",
			"C:\\proj\\shotmaker\\task\\examples of input\\test2.xml",
			"C:\\proj\\shotmaker\\task\\examples of input\\test3.xml",
			"C:\\proj\\shotmaker\\task\\examples of input\\test4.xml",
			"C:\\proj\\shotmaker\\task\\examples of input\\test5.xml"
			};
			foreach (string s in files)
			{
//				var dto = XmlLoader.LoadFromFile(s);
				var testCase = TestCaseFromXmlLoader.Load(s);
//				MessageBox.Show(dto.channel.item.title.ToString());
			}
		}
	}
}