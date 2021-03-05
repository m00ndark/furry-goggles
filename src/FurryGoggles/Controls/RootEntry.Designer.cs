
namespace FurryGoggles.Controls
{
	partial class RootEntry
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
			this.pictureBoxExpandCollapse = new System.Windows.Forms.PictureBox();
			this.labelRoot = new System.Windows.Forms.Label();
			this.groupBoxSeparator = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.labelInfo = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandCollapse)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxExpandCollapse
			// 
			this.pictureBoxExpandCollapse.BackColor = System.Drawing.SystemColors.Window;
			this.pictureBoxExpandCollapse.Location = new System.Drawing.Point(2, 2);
			this.pictureBoxExpandCollapse.Name = "pictureBoxExpandCollapse";
			this.pictureBoxExpandCollapse.Size = new System.Drawing.Size(16, 16);
			this.pictureBoxExpandCollapse.TabIndex = 0;
			this.pictureBoxExpandCollapse.TabStop = false;
			this.pictureBoxExpandCollapse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxExpandCollapse_MouseDown);
			// 
			// labelRoot
			// 
			this.labelRoot.AutoSize = true;
			this.labelRoot.Location = new System.Drawing.Point(20, 2);
			this.labelRoot.Name = "labelRoot";
			this.labelRoot.Size = new System.Drawing.Size(35, 13);
			this.labelRoot.TabIndex = 1;
			this.labelRoot.Text = "[root]";
			// 
			// groupBoxSeparator
			// 
			this.groupBoxSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxSeparator.Location = new System.Drawing.Point(-10, 16);
			this.groupBoxSeparator.Name = "groupBoxSeparator";
			this.groupBoxSeparator.Size = new System.Drawing.Size(290, 115);
			this.groupBoxSeparator.TabIndex = 2;
			this.groupBoxSeparator.TabStop = false;
			// 
			// flowLayoutPanel
			// 
			this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel.Location = new System.Drawing.Point(0, 29);
			this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel.Name = "flowLayoutPanel";
			this.flowLayoutPanel.Size = new System.Drawing.Size(270, 90);
			this.flowLayoutPanel.TabIndex = 0;
			// 
			// labelInfo
			// 
			this.labelInfo.AutoSize = true;
			this.labelInfo.Location = new System.Drawing.Point(6, 34);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(0, 13);
			this.labelInfo.TabIndex = 3;
			// 
			// RootEntry
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.labelInfo);
			this.Controls.Add(this.flowLayoutPanel);
			this.Controls.Add(this.labelRoot);
			this.Controls.Add(this.pictureBoxExpandCollapse);
			this.Controls.Add(this.groupBoxSeparator);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.Name = "RootEntry";
			this.Size = new System.Drawing.Size(270, 120);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandCollapse)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxExpandCollapse;
		private System.Windows.Forms.Label labelRoot;
		private System.Windows.Forms.GroupBox groupBoxSeparator;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
		private System.Windows.Forms.Label labelInfo;
	}
}
