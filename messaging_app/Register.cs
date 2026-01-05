using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace messaging_app
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=MesajDB;Integrated Security=True;Encrypt=False");
        private void Register_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnKayitol_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                return;
            }

           
            

            
                try
                {
                    con.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @user";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@user", txtusername.Text);

                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Bu kullanıcı adı zaten alınmış!");
                    }
                    else
                    {
                        
                        string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@user, @pass)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                        insertCmd.Parameters.AddWithValue("@user", txtusername.Text);
                        insertCmd.Parameters.AddWithValue("@pass", txtpassword.Text);

                        int result = insertCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla tamamlandı! Şimdi giriş yapabilirsiniz.");
                            this.Close(); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message);
                }
            
        }
    }
}
