﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddMember add = new AddMember();
            this.Hide();
            add.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDelete ud = new UpdateDelete();
            ud.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateDelete ud = new UpdateDelete();
            ud.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Payment py = new Payment();
            this.Hide();
            py.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewMembers vw = new ViewMembers();
            this.Hide();
            vw.Show();
        }
    }
}
