namespace HL7Analyser
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.hl7Text = new System.Windows.Forms.RichTextBox();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.lengthText = new System.Windows.Forms.TextBox();
			this.menuToolStrip = new System.Windows.Forms.ToolStrip();
			this.processButton = new System.Windows.Forms.ToolStripButton();
			this.extendButton = new System.Windows.Forms.ToolStripButton();
			this.compressButton = new System.Windows.Forms.ToolStripButton();
			this.clearButton = new System.Windows.Forms.ToolStripButton();
			this.wrapButton = new System.Windows.Forms.ToolStripButton();
			this.aboutButton = new System.Windows.Forms.ToolStripButton();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.obsGroup = new System.Windows.Forms.GroupBox();
			this.obsListView = new System.Windows.Forms.ListView();
			this.timestampColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.unitsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.splitter = new System.Windows.Forms.Splitter();
			this.hl7Group = new System.Windows.Forms.GroupBox();
			this.contextMenu.SuspendLayout();
			this.menuToolStrip.SuspendLayout();
			this.mainPanel.SuspendLayout();
			this.obsGroup.SuspendLayout();
			this.hl7Group.SuspendLayout();
			this.SuspendLayout();
			// 
			// hl7Text
			// 
			this.hl7Text.ContextMenuStrip = this.contextMenu;
			this.hl7Text.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hl7Text.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hl7Text.Location = new System.Drawing.Point(3, 16);
			this.hl7Text.Name = "hl7Text";
			this.hl7Text.Size = new System.Drawing.Size(578, 197);
			this.hl7Text.TabIndex = 0;
			this.hl7Text.Text = "";
			this.hl7Text.WordWrap = false;
			this.hl7Text.TextChanged += new System.EventHandler(this.hl7Text_TextChanged);
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.copyToolStripMenuItem});
			this.contextMenu.Name = "contextMenuStrip";
			this.contextMenu.Size = new System.Drawing.Size(165, 48);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(466, 442);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "HL7 length";
			// 
			// lengthText
			// 
			this.lengthText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lengthText.Location = new System.Drawing.Point(531, 439);
			this.lengthText.Name = "lengthText";
			this.lengthText.ReadOnly = true;
			this.lengthText.Size = new System.Drawing.Size(50, 20);
			this.lengthText.TabIndex = 2;
			this.lengthText.TabStop = false;
			// 
			// menuToolStrip
			// 
			this.menuToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.menuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processButton,
            this.extendButton,
            this.compressButton,
            this.clearButton,
            this.wrapButton,
            this.aboutButton});
			this.menuToolStrip.Location = new System.Drawing.Point(0, 0);
			this.menuToolStrip.Name = "menuToolStrip";
			this.menuToolStrip.Size = new System.Drawing.Size(584, 39);
			this.menuToolStrip.TabIndex = 0;
			// 
			// processButton
			// 
			this.processButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.processButton.Image = global::HL7Analyser.Properties.Resources.play_32;
			this.processButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.processButton.Name = "processButton";
			this.processButton.Size = new System.Drawing.Size(36, 36);
			this.processButton.Text = "Process";
			this.processButton.Click += new System.EventHandler(this.processButton_Click);
			// 
			// extendButton
			// 
			this.extendButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.extendButton.Image = ((System.Drawing.Image)(resources.GetObject("extendButton.Image")));
			this.extendButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.extendButton.Name = "extendButton";
			this.extendButton.Size = new System.Drawing.Size(36, 36);
			this.extendButton.Text = "Extend";
			this.extendButton.Click += new System.EventHandler(this.extendButton_Click);
			// 
			// compressButton
			// 
			this.compressButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.compressButton.Image = ((System.Drawing.Image)(resources.GetObject("compressButton.Image")));
			this.compressButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.compressButton.Name = "compressButton";
			this.compressButton.Size = new System.Drawing.Size(36, 36);
			this.compressButton.Text = "compressButton";
			this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
			// 
			// clearButton
			// 
			this.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
			this.clearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(36, 36);
			this.clearButton.Text = "clearButton";
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// wrapButton
			// 
			this.wrapButton.CheckOnClick = true;
			this.wrapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.wrapButton.Image = ((System.Drawing.Image)(resources.GetObject("wrapButton.Image")));
			this.wrapButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.wrapButton.Name = "wrapButton";
			this.wrapButton.Size = new System.Drawing.Size(36, 36);
			this.wrapButton.Text = "wrapButton";
			this.wrapButton.Click += new System.EventHandler(this.wrapButton_Click);
			// 
			// aboutButton
			// 
			this.aboutButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.aboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.aboutButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutButton.Image")));
			this.aboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.aboutButton.Name = "aboutButton";
			this.aboutButton.Size = new System.Drawing.Size(36, 36);
			this.aboutButton.Text = "About";
			this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
			// 
			// mainPanel
			// 
			this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainPanel.Controls.Add(this.obsGroup);
			this.mainPanel.Controls.Add(this.splitter);
			this.mainPanel.Controls.Add(this.hl7Group);
			this.mainPanel.Location = new System.Drawing.Point(0, 42);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(584, 391);
			this.mainPanel.TabIndex = 9;
			this.mainPanel.Resize += new System.EventHandler(this.mainPanel_Resize);
			// 
			// obsGroup
			// 
			this.obsGroup.Controls.Add(this.obsListView);
			this.obsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.obsGroup.Location = new System.Drawing.Point(0, 224);
			this.obsGroup.Name = "obsGroup";
			this.obsGroup.Size = new System.Drawing.Size(584, 167);
			this.obsGroup.TabIndex = 2;
			this.obsGroup.TabStop = false;
			this.obsGroup.Text = "Observations";
			// 
			// obsListView
			// 
			this.obsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timestampColumnHeader,
            this.typeColumnHeader,
            this.valueColumnHeader,
            this.unitsColumnHeader});
			this.obsListView.ContextMenuStrip = this.contextMenu;
			this.obsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.obsListView.FullRowSelect = true;
			this.obsListView.Location = new System.Drawing.Point(3, 16);
			this.obsListView.Name = "obsListView";
			this.obsListView.Size = new System.Drawing.Size(578, 148);
			this.obsListView.TabIndex = 0;
			this.obsListView.UseCompatibleStateImageBehavior = false;
			this.obsListView.View = System.Windows.Forms.View.Details;
			// 
			// timestampColumnHeader
			// 
			this.timestampColumnHeader.Text = "Time stamp";
			this.timestampColumnHeader.Width = 150;
			// 
			// typeColumnHeader
			// 
			this.typeColumnHeader.Text = "Type";
			this.typeColumnHeader.Width = 190;
			// 
			// valueColumnHeader
			// 
			this.valueColumnHeader.Text = "Value";
			// 
			// unitsColumnHeader
			// 
			this.unitsColumnHeader.Text = "Units";
			this.unitsColumnHeader.Width = 170;
			// 
			// splitter
			// 
			this.splitter.BackColor = System.Drawing.SystemColors.ControlDark;
			this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter.Location = new System.Drawing.Point(0, 216);
			this.splitter.MinExtra = 100;
			this.splitter.MinSize = 100;
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(584, 8);
			this.splitter.TabIndex = 1;
			this.splitter.TabStop = false;
			this.splitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter_SplitterMoved);
			// 
			// hl7Group
			// 
			this.hl7Group.Controls.Add(this.hl7Text);
			this.hl7Group.Dock = System.Windows.Forms.DockStyle.Top;
			this.hl7Group.Location = new System.Drawing.Point(0, 0);
			this.hl7Group.Name = "hl7Group";
			this.hl7Group.Size = new System.Drawing.Size(584, 216);
			this.hl7Group.TabIndex = 0;
			this.hl7Group.TabStop = false;
			this.hl7Group.Text = "HL7";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 462);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.menuToolStrip);
			this.Controls.Add(this.lengthText);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "HL7 Analyser";
			this.contextMenu.ResumeLayout(false);
			this.menuToolStrip.ResumeLayout(false);
			this.menuToolStrip.PerformLayout();
			this.mainPanel.ResumeLayout(false);
			this.obsGroup.ResumeLayout(false);
			this.hl7Group.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox hl7Text;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox lengthText;
		private System.Windows.Forms.ToolStrip menuToolStrip;
		private System.Windows.Forms.ToolStripButton processButton;
		private System.Windows.Forms.ToolStripButton extendButton;
		private System.Windows.Forms.ToolStripButton compressButton;
		private System.Windows.Forms.ToolStripButton clearButton;
		private System.Windows.Forms.ToolStripButton wrapButton;
		private System.Windows.Forms.ToolStripButton aboutButton;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.ListView obsListView;
		private System.Windows.Forms.Splitter splitter;
		private System.Windows.Forms.ColumnHeader timestampColumnHeader;
		private System.Windows.Forms.ColumnHeader typeColumnHeader;
		private System.Windows.Forms.ColumnHeader valueColumnHeader;
		private System.Windows.Forms.ColumnHeader unitsColumnHeader;
		private System.Windows.Forms.GroupBox obsGroup;
		private System.Windows.Forms.GroupBox hl7Group;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
	}
}

