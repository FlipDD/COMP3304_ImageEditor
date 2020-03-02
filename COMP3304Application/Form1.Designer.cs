namespace COMP3304Application
{
    partial class Form1
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
            this.tableLayoutpicturePanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.loadButton = new COMP3304Application.CustomRoundButton();
            this.previousButton = new COMP3304Application.CustomRoundButton();
            this.nextButton = new COMP3304Application.CustomRoundButton();
            this.tableLayoutpicturePanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutpicturePanel
            // 
            this.tableLayoutpicturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutpicturePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutpicturePanel.ColumnCount = 3;
            this.tableLayoutpicturePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutpicturePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutpicturePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutpicturePanel.Controls.Add(this.loadButton, 1, 0);
            this.tableLayoutpicturePanel.Controls.Add(this.previousButton, 0, 0);
            this.tableLayoutpicturePanel.Controls.Add(this.nextButton, 2, 0);
            this.tableLayoutpicturePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutpicturePanel.Location = new System.Drawing.Point(3, 320);
            this.tableLayoutpicturePanel.Name = "tableLayoutpicturePanel";
            this.tableLayoutpicturePanel.RowCount = 1;
            this.tableLayoutpicturePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutpicturePanel.Size = new System.Drawing.Size(522, 95);
            this.tableLayoutpicturePanel.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutpicturePanel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.picturePanel, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.02339F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.97661F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(528, 418);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // picturePanel
            // 
            this.picturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePanel.AutoSize = true;
            this.picturePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picturePanel.Location = new System.Drawing.Point(3, 3);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(522, 311);
            this.picturePanel.TabIndex = 5;
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.loadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loadButton.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.loadButton.ButtonColor = System.Drawing.Color.White;
            this.loadButton.FlatAppearance.BorderSize = 0;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.loadButton.Location = new System.Drawing.Point(107, 3);
            this.loadButton.Name = "loadButton";
            this.loadButton.OnHoverBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.loadButton.OnHoverButtonColor = System.Drawing.Color.White;
            this.loadButton.OnHoverTextColor = System.Drawing.Color.DeepSkyBlue;
            this.loadButton.Size = new System.Drawing.Size(307, 89);
            this.loadButton.TabIndex = 8;
            this.loadButton.Text = "Load";
            this.loadButton.TextColor = System.Drawing.Color.DeepSkyBlue;
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // previousButton
            // 
            this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previousButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.previousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.previousButton.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.previousButton.ButtonColor = System.Drawing.Color.White;
            this.previousButton.FlatAppearance.BorderSize = 0;
            this.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousButton.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.previousButton.Location = new System.Drawing.Point(3, 3);
            this.previousButton.Name = "previousButton";
            this.previousButton.OnHoverBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.previousButton.OnHoverButtonColor = System.Drawing.Color.White;
            this.previousButton.OnHoverTextColor = System.Drawing.Color.DeepSkyBlue;
            this.previousButton.Size = new System.Drawing.Size(98, 89);
            this.previousButton.TabIndex = 7;
            this.previousButton.Text = "<";
            this.previousButton.TextColor = System.Drawing.Color.DeepSkyBlue;
            this.previousButton.UseVisualStyleBackColor = false;
            this.previousButton.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.nextButton.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.nextButton.ButtonColor = System.Drawing.Color.White;
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.nextButton.Location = new System.Drawing.Point(420, 3);
            this.nextButton.Name = "nextButton";
            this.nextButton.OnHoverBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.nextButton.OnHoverButtonColor = System.Drawing.Color.White;
            this.nextButton.OnHoverTextColor = System.Drawing.Color.DeepSkyBlue;
            this.nextButton.Size = new System.Drawing.Size(99, 89);
            this.nextButton.TabIndex = 6;
            this.nextButton.Text = ">";
            this.nextButton.TextColor = System.Drawing.Color.DeepSkyBlue;
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(552, 442);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "Form1";
            this.Text = "Image Editor";
            this.tableLayoutpicturePanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutpicturePanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CustomRoundButton loadButton;
        private CustomRoundButton previousButton;
        private CustomRoundButton nextButton;
        private System.Windows.Forms.Panel picturePanel;
    }
}

