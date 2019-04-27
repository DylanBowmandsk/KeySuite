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
            this.addEntryButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.marketPriceLabel = new System.Windows.Forms.Label();
            this.keysOnMarketLabel = new System.Windows.Forms.Label();
            this.retailValueLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.databaseStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.internetStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.markdownLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdkey,
            this.product,
            this.supplier,
            this.distributor,
            this.steam_url,
            this.g2a_url,
            this.region});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(817, 364);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // cdkey
            // 
            this.cdkey.DataPropertyName = "cdkey";
            this.cdkey.HeaderText = "cdkey";
            this.cdkey.Name = "cdkey";
            this.cdkey.ReadOnly = true;
            this.cdkey.Width = 150;
            // 
            // product
            // 
            this.product.DataPropertyName = "product";
            this.product.HeaderText = "product";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            this.product.Width = 150;
            // 
            // supplier
            // 
            this.supplier.DataPropertyName = "supplier";
            this.supplier.HeaderText = "supplier";
            this.supplier.Name = "supplier";
            this.supplier.ReadOnly = true;
            // 
            // distributor
            // 
            this.distributor.DataPropertyName = "distributor";
            this.distributor.HeaderText = "distributor";
            this.distributor.Name = "distributor";
            this.distributor.ReadOnly = true;
            // 
            // steam_url
            // 
            this.steam_url.DataPropertyName = "steam_url";
            this.steam_url.HeaderText = "steam_url";
            this.steam_url.Name = "steam_url";
            this.steam_url.ReadOnly = true;
            // 
            // g2a_url
            // 
            this.g2a_url.DataPropertyName = "g2a_url";
            this.g2a_url.HeaderText = "g2a_url";
            this.g2a_url.Name = "g2a_url";
            this.g2a_url.ReadOnly = true;
            // 
            // region
            // 
            this.region.DataPropertyName = "region";
            this.region.HeaderText = "region";
            this.region.Name = "region";
            this.region.ReadOnly = true;
            this.region.Width = 74;
            // 
            // addEntryButton
            // 
            this.addEntryButton.Location = new System.Drawing.Point(24, 412);
            this.addEntryButton.Name = "addEntryButton";
            this.addEntryButton.Size = new System.Drawing.Size(75, 36);
            this.addEntryButton.TabIndex = 2;
            this.addEntryButton.Text = "Add";
            this.addEntryButton.UseVisualStyleBackColor = true;
            this.addEntryButton.Click += new System.EventHandler(this.addEntryButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(105, 412);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 36);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // editButton
            // 
            this.editButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.editButton.Location = new System.Drawing.Point(186, 412);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 36);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deleteButton.Location = new System.Drawing.Point(267, 412);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 36);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(94, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(191, 20);
            this.searchBox.TabIndex = 6;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(12, 11);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 21);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Items.AddRange(new object[] {
            "cdkey",
            "product",
            "supplier",
            "distributor",
            "steam_url",
            "g2a_url",
            "region"});
            this.categoryComboBox.Location = new System.Drawing.Point(291, 11);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.categoryComboBox.TabIndex = 8;
            // 
            // marketPriceLabel
            // 
            this.marketPriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marketPriceLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marketPriceLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.marketPriceLabel.Location = new System.Drawing.Point(617, 430);
            this.marketPriceLabel.Name = "marketPriceLabel";
            this.marketPriceLabel.Size = new System.Drawing.Size(88, 17);
            this.marketPriceLabel.TabIndex = 9;
            this.marketPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keysOnMarketLabel
            // 
            this.keysOnMarketLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keysOnMarketLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keysOnMarketLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.keysOnMarketLabel.Location = new System.Drawing.Point(482, 430);
            this.keysOnMarketLabel.MaximumSize = new System.Drawing.Size(200, 200);
            this.keysOnMarketLabel.Name = "keysOnMarketLabel";
            this.keysOnMarketLabel.Size = new System.Drawing.Size(106, 17);
            this.keysOnMarketLabel.TabIndex = 10;
            this.keysOnMarketLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // retailValueLabel
            // 
            this.retailValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.retailValueLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retailValueLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.retailValueLabel.Location = new System.Drawing.Point(368, 430);
            this.retailValueLabel.MaximumSize = new System.Drawing.Size(200, 200);
            this.retailValueLabel.Name = "retailValueLabel";
            this.retailValueLabel.Size = new System.Drawing.Size(83, 17);
            this.retailValueLabel.TabIndex = 11;
            this.retailValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(365, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Retail Value";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(479, 412);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Keys on Market";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(614, 412);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Market Price";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseStatusLabel,
            this.internetStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 460);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(841, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "20";
            // 
            // databaseStatusLabel
            // 
            this.databaseStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.databaseStatusLabel.Name = "databaseStatusLabel";
            this.databaseStatusLabel.Size = new System.Drawing.Size(168, 17);
            this.databaseStatusLabel.Text = "Database Status: Disconnected";
            // 
            // internetStatusLabel
            // 
            this.internetStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.internetStatusLabel.Name = "internetStatusLabel";
            this.internetStatusLabel.Size = new System.Drawing.Size(191, 17);
            this.internetStatusLabel.Text = "Internet Connection: Disconnected";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(727, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Mark Down";
            // 
            // markdownLabel
            // 
            this.markdownLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.markdownLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.markdownLabel.Location = new System.Drawing.Point(753, 430);
            this.markdownLabel.Name = "markdownLabel";
            this.markdownLabel.Size = new System.Drawing.Size(27, 18);
            this.markdownLabel.TabIndex = 17;
            this.markdownLabel.Text = "%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(841, 482);
            this.Controls.Add(this.markdownLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.retailValueLabel);
            this.Controls.Add(this.keysOnMarketLabel);
            this.Controls.Add(this.marketPriceLabel);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.addEntryButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "KeySuite";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addEntryButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label marketPriceLabel;
        private System.Windows.Forms.Label keysOnMarketLabel;
        private System.Windows.Forms.Label retailValueLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel databaseStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel internetStatusLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label markdownLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn distributor;
        private System.Windows.Forms.DataGridViewTextBoxColumn steam_url;
        private System.Windows.Forms.DataGridViewTextBoxColumn g2a_url;
        private System.Windows.Forms.DataGridViewTextBoxColumn region;
    }
}

