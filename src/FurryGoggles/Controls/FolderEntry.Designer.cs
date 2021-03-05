
namespace FurryGoggles.Controls
{
	partial class FolderEntry
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderEntry));
			this.buttonMenu = new System.Windows.Forms.Button();
			this.linkLabelFolder = new System.Windows.Forms.LinkLabel();
			this.labelFiles = new System.Windows.Forms.Label();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.SuspendLayout();
			// 
			// buttonMenu
			// 
			this.buttonMenu.BackColor = System.Drawing.Color.Transparent;
			this.buttonMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonMenu.FlatAppearance.BorderSize = 0;
			this.buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
			this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonMenu.Image")));
			this.buttonMenu.Location = new System.Drawing.Point(0, 1);
			this.buttonMenu.Name = "buttonMenu";
			this.buttonMenu.Size = new System.Drawing.Size(21, 21);
			this.buttonMenu.TabIndex = 0;
			this.buttonMenu.UseVisualStyleBackColor = false;
			this.buttonMenu.Click += new System.EventHandler(this.ButtonMenu_Click);
			// 
			// linkLabelFolder
			// 
			this.linkLabelFolder.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
			this.linkLabelFolder.AutoSize = true;
			this.linkLabelFolder.BackColor = System.Drawing.Color.Transparent;
			this.linkLabelFolder.DisabledLinkColor = System.Drawing.Color.Gray;
			this.linkLabelFolder.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabelFolder.LinkColor = System.Drawing.SystemColors.HotTrack;
			this.linkLabelFolder.Location = new System.Drawing.Point(20, 4);
			this.linkLabelFolder.Name = "linkLabelFolder";
			this.linkLabelFolder.Size = new System.Drawing.Size(44, 13);
			this.linkLabelFolder.TabIndex = 1;
			this.linkLabelFolder.TabStop = true;
			this.linkLabelFolder.Text = "[folder]";
			this.linkLabelFolder.VisitedLinkColor = System.Drawing.SystemColors.HotTrack;
			this.linkLabelFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelFolder_LinkClicked);
			// 
			// labelFiles
			// 
			this.labelFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFiles.AutoSize = true;
			this.labelFiles.Location = new System.Drawing.Point(288, 4);
			this.labelFiles.Name = "labelFiles";
			this.labelFiles.Size = new System.Drawing.Size(34, 13);
			this.labelFiles.TabIndex = 2;
			this.labelFiles.Text = "[files]";
			// 
			// buttonRemove
			// 
			this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemove.BackColor = System.Drawing.Color.Transparent;
			this.buttonRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonRemove.FlatAppearance.BorderSize = 0;
			this.buttonRemove.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
			this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
			this.buttonRemove.Location = new System.Drawing.Point(328, 0);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(21, 21);
			this.buttonRemove.TabIndex = 3;
			this.toolTip.SetToolTip(this.buttonRemove, "Delete All");
			this.buttonRemove.UseVisualStyleBackColor = false;
			this.buttonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
			// 
			// FolderEntry
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.buttonRemove);
			this.Controls.Add(this.labelFiles);
			this.Controls.Add(this.linkLabelFolder);
			this.Controls.Add(this.buttonMenu);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "FolderEntry";
			this.Size = new System.Drawing.Size(350, 22);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonMenu;
		private System.Windows.Forms.LinkLabel linkLabelFolder;
		private System.Windows.Forms.Label labelFiles;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
	}
}
