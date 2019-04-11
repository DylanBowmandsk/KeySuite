﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeySuite
{
    public partial class Form1 : Form
    {

        int currentRow = 0;

        public Form1()
        {
            InitializeComponent();
            DatabaseUtils.fillTable(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;
        }

        private void addEntryButton_Click(object sender, EventArgs e)
        {
            AddForm addform = new AddForm(this);
            addform.Show();
            this.Enabled = false;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            DatabaseUtils.fillTable(dataGridView1);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditForm addform = new EditForm(this);
            addform.Show();
            this.Enabled = false;
        }
    }
}
