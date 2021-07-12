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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bisho\OneDrive\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillName()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select MName from MemberTbl",con);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); 
            dt.Columns.Add("MName", typeof(string));
            dt.Load(sdr);
            NameCb.ValueMember = "MName";
            NameCb.DataSource = dt;
            con.Close();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from PaymentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void filterName()
        {
            con.Open();
            string query = "select * from PaymentTbl where PMember = '"+SearchTb.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //NameTb.Text = "";
            AmountTb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            this.Hide();
            mf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(NameCb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string payperiod = Period.Value.Day.ToString() + "/" + Period.Value.Month.ToString() + "/" + Period.Value.Year.ToString();
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PaymentTbl where PMember = '"+NameCb.SelectedValue.ToString()+"' and PMonth = '"+payperiod+"'",con);  
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows[0][0] == "1")
                    {
                        MessageBox.Show("You already paid for this month");
                    }
                    else
                    {
                        string query = "insert into PaymentTbl values('"+payperiod+"','"+NameCb.SelectedValue.ToString()+"',"+AmountTb.Text+")";
                        SqlCommand cmd = new SqlCommand(query,con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Amount paid successfully");
                    }
                    con.Close();
                    populate();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            fillName();
            populate();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchTb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filterName();
            SearchTb.Text = "";
        }
    }
}
