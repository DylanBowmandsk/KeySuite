namespace KeySuite
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cdkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distributor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.steam_url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g2a_url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.addEntryButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdkey,
            this.product,
            this.supplier,
            this.distributor,
            this.steam_url,
            this.g2a_url,
            this.region});
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 364);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cdkey
            // 
            this.cdkey.DataPropertyName = "cdkey";
            this.cdkey.HeaderText = "cdkey";
            this.cdkey.Name = "cdkey";
            // 
            // product
            // 
            this.product.DataPropertyName = "product";
            this.product.HeaderText = "product";
            this.product.Name = "product";
            // 
            // supplier
            // 
            this.supplier.DataPropertyName = "supplier";
            this.supplier.HeaderText = "supplier";
            this.supplier.Name = "supplier";
            // 
            // distributor
            // 
            this.distributor.DataPropertyName = "distributor";
            this.distributor.HeaderText = "distributor";
            this.distributor.Name = "distributor";
            // 
            // steam_url
            // 
            this.steam_url.DataPropertyName = "steam_url";
            this.steam_url.HeaderText = "steam_url";
            this.steam_url.Name = "steam_url";
            // 
            // g2a_url
            // 
            this.g2a_url.DataPropertyName = "g2a_url";
            this.g2a_url.HeaderText = "g2a_url";
            this.g2a_url.Name = "g2a_url";
            // 
            // region
            // 
            this.region.DataPropertyName = "region";
            this.region.HeaderText = "region";
            this.region.Name = "region";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // addEntryButton
            // 
            this.addEntryButton.Location = new System.Drawing.Point(12, 412);
            this.addEntryButton.Name = "addEntryButton";
            this.addEntryButton.Size = new System.Drawing.Size(75, 23);
            this.addEntryButton.TabIndex = 2;
            this.addEntryButton.Text = "Add";
            this.addEntryButton.UseVisualStyleBackColor = true;
            this.addEntryButton.Click += new System.EventHandler(this.addEntryButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(94, 412);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // editButton
            // 
            this.editButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.editButton.Location = new System.Drawing.Point(176, 412);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.addEntryButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addEntryButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn distributor;
        private System.Windows.Forms.DataGridViewTextBoxColumn steam_url;
        private System.Windows.Forms.DataGridViewTextBoxColumn g2a_url;
        private System.Windows.Forms.DataGridViewTextBoxColumn region;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button editButton;
    }
}

