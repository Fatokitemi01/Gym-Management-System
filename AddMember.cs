using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GymManagementSystem
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bisho\OneDrive\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            this.Hide();
            mf.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            PhoneTb.Text = "";
            AgeTb.Text = "";
            GenderCb.Text = "";
            AmountTb.Text = "";
            TimingCb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(NameTb.Text == "" || PhoneTb.Text == "" || AmountTb.Text == "" || AgeTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into MemberTbl values('" + NameTb.Text + "','" + PhoneTb.Text + "','" + GenderCb.SelectedItem.ToString() + "','" + AgeTb.Text + "','" + AmountTb.Text + "','" + TimingCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Successfully Added");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    AgeTb.Text = "";
                    GenderCb.Text = "";
                    AmountTb.Text = "";
                    TimingCb.Text = "";
                    con.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
