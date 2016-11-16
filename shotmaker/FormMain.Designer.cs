﻿namespace shotmaker
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Installed OLSS and ECM 5.0 Server");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Installed OLSS Client and AUU");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Preconditions", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Internal Authentication");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("OLSS user \'user1\' with privileges to login into AUU Web UI");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Data", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("AUU Login page with \"User name\" and \"Password\" without \"Domain\"");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("1. Navigate to AUU home page", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Password is encrypted");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("2. Enter valid credentials of \'user1\' from Data", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("AUU System Information page is open");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Current user is \'user1\'");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("3. Click \"Log In\" button", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Steps", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode10,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Verification: 1", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Case: OLSS-4435-TC-AUU-Login-Positive-Scenarios-0001 ", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Execution: OLSS-4589-TE-Sprint-4-Saratov", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "1",
            "a",
            "b"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "2",
            "",
            "",
            ""}, -1);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(37, 29);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node4";
            treeNode1.Text = "Installed OLSS and ECM 5.0 Server";
            treeNode2.Name = "Node6";
            treeNode2.Text = "Installed OLSS Client and AUU";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Preconditions";
            treeNode4.Name = "Node9";
            treeNode4.Text = "Internal Authentication";
            treeNode5.Name = "Node10";
            treeNode5.Text = "OLSS user \'user1\' with privileges to login into AUU Web UI";
            treeNode6.Name = "Node8";
            treeNode6.Text = "Data";
            treeNode7.Name = "Node13";
            treeNode7.Text = "AUU Login page with \"User name\" and \"Password\" without \"Domain\"";
            treeNode8.Name = "Node12";
            treeNode8.Text = "1. Navigate to AUU home page";
            treeNode9.Name = "Node15";
            treeNode9.Text = "Password is encrypted";
            treeNode10.Name = "Node14";
            treeNode10.Text = "2. Enter valid credentials of \'user1\' from Data";
            treeNode11.Name = "Node17";
            treeNode11.Text = "AUU System Information page is open";
            treeNode12.Name = "Node18";
            treeNode12.Text = "Current user is \'user1\'";
            treeNode13.Name = "Node16";
            treeNode13.Text = "3. Click \"Log In\" button";
            treeNode14.Name = "Node11";
            treeNode14.Text = "Steps";
            treeNode15.Name = "Node7";
            treeNode15.Text = "Verification: 1";
            treeNode16.Checked = true;
            treeNode16.Name = "Node2";
            treeNode16.Text = "Case: OLSS-4435-TC-AUU-Login-Positive-Scenarios-0001 ";
            treeNode17.Checked = true;
            treeNode17.Name = "Node0";
            treeNode17.Text = "Execution: OLSS-4589-TE-Sprint-4-Saratov";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode17});
            this.treeView1.Size = new System.Drawing.Size(462, 406);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // listView1
            // 
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(803, 52);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(365, 327);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 482);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
    }
}
