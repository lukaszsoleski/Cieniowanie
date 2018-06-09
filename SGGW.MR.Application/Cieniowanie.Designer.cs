namespace SGGW.MR.Application
{
    partial class Cieniowanie
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
            this.ShadingDragAndDropImageBox = new System.Windows.Forms.PictureBox();
            this.ShadingPreviewImageBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ShadingSaveAsButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.CieniowanieTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ShadingStartButton = new System.Windows.Forms.Button();
            this.HilbertTabPage = new System.Windows.Forms.TabPage();
            this.HilbertExecuteButton = new System.Windows.Forms.Button();
            this.HilbertDepthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InfoTabPage = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.ShadingDragAndDropImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShadingPreviewImageBox)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.CieniowanieTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.HilbertTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShadingDragAndDropImageBox
            // 
            this.ShadingDragAndDropImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShadingDragAndDropImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShadingDragAndDropImageBox.Location = new System.Drawing.Point(4, 25);
            this.ShadingDragAndDropImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.ShadingDragAndDropImageBox.Name = "ShadingDragAndDropImageBox";
            this.ShadingDragAndDropImageBox.Size = new System.Drawing.Size(364, 366);
            this.ShadingDragAndDropImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShadingDragAndDropImageBox.TabIndex = 0;
            this.ShadingDragAndDropImageBox.TabStop = false;
            // 
            // ShadingPreviewImageBox
            // 
            this.ShadingPreviewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShadingPreviewImageBox.Location = new System.Drawing.Point(376, 25);
            this.ShadingPreviewImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.ShadingPreviewImageBox.Name = "ShadingPreviewImageBox";
            this.ShadingPreviewImageBox.Size = new System.Drawing.Size(364, 366);
            this.ShadingPreviewImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShadingPreviewImageBox.TabIndex = 1;
            this.ShadingPreviewImageBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Drag and drop image";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(364, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Preview ";
            // 
            // ShadingSaveAsButton
            // 
            this.ShadingSaveAsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ShadingSaveAsButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShadingSaveAsButton.Location = new System.Drawing.Point(661, 399);
            this.ShadingSaveAsButton.Margin = new System.Windows.Forms.Padding(4);
            this.ShadingSaveAsButton.Name = "ShadingSaveAsButton";
            this.ShadingSaveAsButton.Size = new System.Drawing.Size(79, 33);
            this.ShadingSaveAsButton.TabIndex = 7;
            this.ShadingSaveAsButton.Text = "Save as";
            this.ShadingSaveAsButton.UseVisualStyleBackColor = true;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.CieniowanieTabPage);
            this.MainTabControl.Controls.Add(this.HilbertTabPage);
            this.MainTabControl.Controls.Add(this.InfoTabPage);
            this.MainTabControl.Location = new System.Drawing.Point(13, 13);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(768, 486);
            this.MainTabControl.TabIndex = 8;
            // 
            // CieniowanieTabPage
            // 
            this.CieniowanieTabPage.Controls.Add(this.tableLayoutPanel1);
            this.CieniowanieTabPage.Location = new System.Drawing.Point(4, 30);
            this.CieniowanieTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.CieniowanieTabPage.Name = "CieniowanieTabPage";
            this.CieniowanieTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.CieniowanieTabPage.Size = new System.Drawing.Size(760, 452);
            this.CieniowanieTabPage.TabIndex = 1;
            this.CieniowanieTabPage.Text = "Cieniowanie";
            this.CieniowanieTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ShadingPreviewImageBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ShadingDragAndDropImageBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ShadingSaveAsButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ShadingStartButton, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 436);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // ShadingStartButton
            // 
            this.ShadingStartButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ShadingStartButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShadingStartButton.Location = new System.Drawing.Point(294, 398);
            this.ShadingStartButton.Name = "ShadingStartButton";
            this.ShadingStartButton.Size = new System.Drawing.Size(75, 35);
            this.ShadingStartButton.TabIndex = 8;
            this.ShadingStartButton.Text = "Start";
            this.ShadingStartButton.UseVisualStyleBackColor = true;
            this.ShadingStartButton.Click += new System.EventHandler(this.ShadingStartButton_Click);
            // 
            // HilbertTabPage
            // 
            this.HilbertTabPage.Controls.Add(this.HilbertExecuteButton);
            this.HilbertTabPage.Controls.Add(this.HilbertDepthTextBox);
            this.HilbertTabPage.Controls.Add(this.label2);
            this.HilbertTabPage.Location = new System.Drawing.Point(4, 30);
            this.HilbertTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.HilbertTabPage.Name = "HilbertTabPage";
            this.HilbertTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.HilbertTabPage.Size = new System.Drawing.Size(760, 452);
            this.HilbertTabPage.TabIndex = 0;
            this.HilbertTabPage.Text = "Krzywa Hilberta";
            this.HilbertTabPage.UseVisualStyleBackColor = true;
            // 
            // HilbertExecuteButton
            // 
            this.HilbertExecuteButton.Location = new System.Drawing.Point(342, 5);
            this.HilbertExecuteButton.Name = "HilbertExecuteButton";
            this.HilbertExecuteButton.Size = new System.Drawing.Size(106, 33);
            this.HilbertExecuteButton.TabIndex = 2;
            this.HilbertExecuteButton.Text = "Execute";
            this.HilbertExecuteButton.UseVisualStyleBackColor = true;
            // 
            // HilbertDepthTextBox
            // 
            this.HilbertDepthTextBox.Location = new System.Drawing.Point(236, 8);
            this.HilbertDepthTextBox.Name = "HilbertDepthTextBox";
            this.HilbertDepthTextBox.Size = new System.Drawing.Size(100, 28);
            this.HilbertDepthTextBox.TabIndex = 1;
            this.HilbertDepthTextBox.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "[x,y] = Hilbert(n); line(x,y); n = ";
            // 
            // InfoTabPage
            // 
            this.InfoTabPage.Location = new System.Drawing.Point(4, 30);
            this.InfoTabPage.Name = "InfoTabPage";
            this.InfoTabPage.Size = new System.Drawing.Size(760, 452);
            this.InfoTabPage.TabIndex = 2;
            this.InfoTabPage.Text = "Info";
            this.InfoTabPage.UseVisualStyleBackColor = true;
            // 
            // Cieniowanie
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.MainTabControl);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Cieniowanie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cieniowanie";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Cieniowanie_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Cieniowanie_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.ShadingDragAndDropImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShadingPreviewImageBox)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.CieniowanieTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.HilbertTabPage.ResumeLayout(false);
            this.HilbertTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ShadingDragAndDropImageBox;
        private System.Windows.Forms.PictureBox ShadingPreviewImageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ShadingSaveAsButton;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage HilbertTabPage;
        private System.Windows.Forms.TabPage CieniowanieTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ShadingStartButton;
        private System.Windows.Forms.TabPage InfoTabPage;
        private System.Windows.Forms.Button HilbertExecuteButton;
        private System.Windows.Forms.TextBox HilbertDepthTextBox;
        private System.Windows.Forms.Label label2;
    }
}

