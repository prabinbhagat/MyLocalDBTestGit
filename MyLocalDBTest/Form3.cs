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

namespace MyLocalDBTest
{
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\prabi\OneDrive\Documents\MyFirstDatabase.mdf;Integrated Security=True;Connect Timeout=30");   
        public Form3()
        {
            InitializeComponent();
        }

        private void usernameTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CheckBlank() == false) 
            {
                if (passwordTextBox1.Text == textBox1.Text)
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into tblSignup values ('" + full_NameTextBox.Text + "','" + emailTextBox.Text + "','" + addressTextBox.Text + "','" + usernameTextBox1.Text + "','" + passwordTextBox1.Text + "' )";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("SignUp successfull");
                }
                else
                {
                    MessageBox.Show("Password and confirm password do not match");
                    passwordTextBox1.Text = "";
                    textBox1.Text = "";
                }

               
            }
            

            
        }   

        private void Form3_Load(object sender, EventArgs e)
        {
            groupBox2.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(groupBox2.Visible == true)
            {
                groupBox2.Hide();
            }
            else if(groupBox2.Visible == false)
            {
                groupBox2.Show();
            }
        }

        private void usernameLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblSignup where Username = '"+usernameTextBox.Text+"' and Password = '"+passwordTextBox.Text+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                
                MessageBox.Show("Welcome "+usernameTextBox.Text.ToUpper(),"Success");
                this.Hide();
                // Form1 fr = new Form1();
                // fr.Show();
                new Form1().Show();
                
            }
            
          
            else
            {       
                MessageBox.Show("Invalid Username! Try Again");
            }
            conn.Close();

        }
        private bool CheckBlank()
        {
            bool blank = false;
            string blankLabel = "";

            if (full_NameTextBox.Text =="")
            {
               blank = true;
                blankLabel = "Full Name"; 
            }
            else if (emailTextBox.Text == "")
            {
                blank = true;
                blankLabel = "Email";
            }
            else if(addressTextBox.Text == "")
            {
                blank = true;
                blankLabel = "Address";
            }
            else if (usernameTextBox1.Text == "")
            {
                blank = true;
                blankLabel = "Username";
            }
            else if (passwordTextBox1.Text =="")
            {
                blank = true;
                blankLabel = "Password";
            }
            if (blank)
            {
                MessageBox.Show($"Value in the field {blankLabel} cannot be blank; ");
                return true;
            }
            else
            {
                return false;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                passwordTextBox1.PasswordChar = '\0';
            }
            else  passwordTextBox1.PasswordChar = '*';
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                passwordTextBox.PasswordChar = '\0';
            }
            else passwordTextBox.PasswordChar = '*';

        }
    }
}
