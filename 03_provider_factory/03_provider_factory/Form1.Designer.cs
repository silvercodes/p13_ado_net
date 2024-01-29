namespace _03_provider_factory
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxProvider = new System.Windows.Forms.ComboBox();
            this.lblConnString = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.dgwMain = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMain)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxProvider
            // 
            this.cbxProvider.FormattingEnabled = true;
            this.cbxProvider.Location = new System.Drawing.Point(29, 29);
            this.cbxProvider.Name = "cbxProvider";
            this.cbxProvider.Size = new System.Drawing.Size(517, 67);
            this.cbxProvider.TabIndex = 0;
            this.cbxProvider.SelectedIndexChanged += new System.EventHandler(this.cbxProvider_SelectedIndexChanged);
            // 
            // lblConnString
            // 
            this.lblConnString.AutoSize = true;
            this.lblConnString.Location = new System.Drawing.Point(30, 115);
            this.lblConnString.Name = "lblConnString";
            this.lblConnString.Size = new System.Drawing.Size(137, 59);
            this.lblConnString.TabIndex = 1;
            this.lblConnString.Text = "label1";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(36, 202);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(1229, 65);
            this.txtQuery.TabIndex = 2;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(1300, 204);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(303, 63);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "EXECUTE";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // dgwMain
            // 
            this.dgwMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMain.Location = new System.Drawing.Point(39, 292);
            this.dgwMain.Name = "dgwMain";
            this.dgwMain.RowHeadersWidth = 82;
            this.dgwMain.RowTemplate.Height = 41;
            this.dgwMain.Size = new System.Drawing.Size(1564, 883);
            this.dgwMain.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(24F, 59F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1646, 1204);
            this.Controls.Add(this.dgwMain);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.lblConnString);
            this.Controls.Add(this.cbxProvider);
            this.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgwMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbxProvider;
        private Label lblConnString;
        private TextBox txtQuery;
        private Button btnExecute;
        private DataGridView dgwMain;
    }
}