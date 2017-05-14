namespace NetworkChecker
{
    partial class NetworkChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkChecker));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Log = new System.Windows.Forms.TabPage();
            this.swapTimes = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.totalSwaps = new System.Windows.Forms.ToolStripStatusLabel();
            this.swapsPerHour = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastSwapTS = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.Log.SuspendLayout();
            this.swapTimes.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(554, 175);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Log);
            this.tabControl1.Controls.Add(this.swapTimes);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 207);
            this.tabControl1.TabIndex = 1;
            // 
            // Log
            // 
            this.Log.Controls.Add(this.richTextBox1);
            this.Log.Location = new System.Drawing.Point(4, 22);
            this.Log.Name = "Log";
            this.Log.Padding = new System.Windows.Forms.Padding(3);
            this.Log.Size = new System.Drawing.Size(560, 181);
            this.Log.TabIndex = 0;
            this.Log.Text = "Log";
            this.Log.UseVisualStyleBackColor = true;
            // 
            // swapTimes
            // 
            this.swapTimes.Controls.Add(this.richTextBox2);
            this.swapTimes.Location = new System.Drawing.Point(4, 22);
            this.swapTimes.Name = "swapTimes";
            this.swapTimes.Size = new System.Drawing.Size(560, 181);
            this.swapTimes.TabIndex = 1;
            this.swapTimes.Text = "Swap Times";
            this.swapTimes.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox2.HideSelection = false;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox2.Size = new System.Drawing.Size(560, 181);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalSwaps,
            this.swapsPerHour,
            this.lastSwapTS});
            this.statusStrip1.Location = new System.Drawing.Point(0, 208);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(568, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // totalSwaps
            // 
            this.totalSwaps.BackColor = System.Drawing.Color.Transparent;
            this.totalSwaps.ForeColor = System.Drawing.SystemColors.WindowText;
            this.totalSwaps.Name = "totalSwaps";
            this.totalSwaps.Size = new System.Drawing.Size(81, 19);
            this.totalSwaps.Text = "Total Swaps: 0";
            // 
            // swapsPerHour
            // 
            this.swapsPerHour.BackColor = System.Drawing.Color.Transparent;
            this.swapsPerHour.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.swapsPerHour.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.swapsPerHour.ForeColor = System.Drawing.SystemColors.WindowText;
            this.swapsPerHour.Name = "swapsPerHour";
            this.swapsPerHour.Size = new System.Drawing.Size(145, 19);
            this.swapsPerHour.Text = "Avg Swaps Per Hour: 0.00";
            // 
            // lastSwapTS
            // 
            this.lastSwapTS.ActiveLinkColor = System.Drawing.Color.Red;
            this.lastSwapTS.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lastSwapTS.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lastSwapTS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lastSwapTS.Name = "lastSwapTS";
            this.lastSwapTS.Size = new System.Drawing.Size(98, 19);
            this.lastSwapTS.Text = "Last Swap: None";
            // 
            // NetworkChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(568, 232);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetworkChecker";
            this.ShowIcon = false;
            this.Text = "NetworkChecker";
            this.tabControl1.ResumeLayout(false);
            this.Log.ResumeLayout(false);
            this.swapTimes.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Log;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel totalSwaps;
        private System.Windows.Forms.ToolStripStatusLabel swapsPerHour;
        private System.Windows.Forms.TabPage swapTimes;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ToolStripStatusLabel lastSwapTS;
    }
}

