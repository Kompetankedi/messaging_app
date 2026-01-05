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

namespace messaging_app
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=MesajDB;Integrated Security=True;Encrypt=False");
        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnklblkayitol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register rg = new Register();
            rg.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
                try
                {
                    con.Open();
                    // 2. SQL Sorgusunu yaz (SQL Injection önlemek için parametre kullanıyoruz)
                    string query = "SELECT UserID FROM Users WHERE Username = @user AND Password = @pass";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@user", txtusername.Text);
                    cmd.Parameters.AddWithValue("@pass", txtpassword.Text);

                    // 3. Sorguyu çalıştır ve dönen değeri al
                    object result = cmd.ExecuteScalar();
                    con.Close();
                if (result != null) // Eğer bir UserID döndüyse giriş başarılıdır
                    {
                        int loggedInUserId = Convert.ToInt32(result);
                        MessageBox.Show("Giriş Başarılı! Hoş geldiniz.");

                      
                        MainChat chatForm = new MainChat(loggedInUserId); // ID'yi diğer forma gönderiyoruz
                        chatForm.ShowDialog();
                        
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            
        }
    }
}
