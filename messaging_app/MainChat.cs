using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace messaging_app
{
    public partial class MainChat : Form
    {
        private int currentUserId;
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MesajDB;Integrated Security=True;Encrypt=False";

        public MainChat(int UserId)
        {
            InitializeComponent();
            this.currentUserId = UserId;
        }

        private void MainChat_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 2000;
            CenterToScreen();
            LoadMyChatPartners();
        }

        private int GetIdByUsername(string username)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT UserID FROM Users WHERE Username = @name";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", username);
                    object res = cmd.ExecuteScalar();
                    return res != null ? (int)res : -1;
                }
            } 
        }
        private void LoadMyChatPartners()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"SELECT DISTINCT U.Username 
                             FROM Users U
                             INNER JOIN Messages M ON (U.UserID = M.SenderID OR U.UserID = M.ReceiverID)
                             WHERE (M.SenderID = @me OR M.ReceiverID = @me) 
                             AND U.UserID != @me";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@me", currentUserId);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            ListBoxUsers.Items.Clear(); // Listeyi temizle ki mükerrer kayıt olmasın
                            while (dr.Read())
                            {
                                ListBoxUsers.Items.Add(dr["Username"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcı listesi yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }
        private void LoadMessages()
        {
            if (ListBoxUsers.SelectedItem == null) return;

            int receiverId = GetIdByUsername(ListBoxUsers.SelectedItem.ToString());
            if (receiverId == -1) return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"SELECT SenderID, Content FROM Messages 
                                 WHERE (SenderID = @me AND ReceiverID = @other) 
                                 OR (SenderID = @other AND ReceiverID = @me) 
                                 ORDER BY SentDate ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@me", currentUserId);
                    cmd.Parameters.AddWithValue("@other", receiverId);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear();

                        while (dr.Read())
                        {
                            int senderId = (int)dr["SenderID"];
                            string messageText = dr["Content"].ToString();

                            Label lbl = new Label();
                            lbl.Text = messageText;
                            lbl.AutoSize = true;
                            lbl.Padding = new Padding(10);
                            lbl.Margin = new Padding(5);
                            lbl.MaximumSize = new Size(flowLayoutPanel1.Width - 35, 0);

                            if (senderId == currentUserId)
                            {
                                lbl.BackColor = Color.LightGreen;
                                lbl.Anchor = AnchorStyles.Right;
                            }
                            else
                            {
                                lbl.BackColor = Color.LightGray;
                                lbl.Anchor = AnchorStyles.Left;
                            }

                            flowLayoutPanel1.Controls.Add(lbl);
                            flowLayoutPanel1.SetFlowBreak(lbl, true);
                        }
                    }
                }
            }
            flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Maximum;
            flowLayoutPanel1.PerformLayout();
        }

        
        private void btnNewChat_Click(object sender, EventArgs e)
        {
            string targetUsername = Interaction.InputBox(
                "Mesajlaşmak istediğiniz kullanıcı adını giriniz:",
                "Yeni Sohbet Başlat", "");

            if (string.IsNullOrWhiteSpace(targetUsername)) return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT UserID FROM Users WHERE Username = @name";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", targetUsername);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            if (!ListBoxUsers.Items.Contains(targetUsername))
                            {
                                ListBoxUsers.Items.Add(targetUsername);
                                MessageBox.Show(targetUsername + " listeye eklendi.");
                            }
                            else
                            {
                                MessageBox.Show("Bu kullanıcı zaten listenizde.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Böyle bir kullanıcı bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (ListBoxUsers.SelectedItem == null || string.IsNullOrWhiteSpace(rtxtMessage.Text)) return;

            int receiverId = GetIdByUsername(ListBoxUsers.SelectedItem.ToString());

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Messages (SenderID, ReceiverID, Content) VALUES (@s, @r, @c)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@s", currentUserId);
                        cmd.Parameters.AddWithValue("@r", receiverId);
                        cmd.Parameters.AddWithValue("@c", rtxtMessage.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                rtxtMessage.Clear();
                LoadMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesaj gönderilemedi: " + ex.Message);
            }
        }

        private void ListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMessages();
            lblChatUsername.Text = ListBoxUsers.SelectedItem?.ToString() ?? "Sohbet Seçilmedi";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ListBoxUsers.SelectedItem != null)
            {
                LoadMessages();
            }
        }
    }
}