namespace messaging_app
{
    partial class MainChat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainChat));
            this.ListBoxUsers = new System.Windows.Forms.ListBox();
            this.btnNewChat = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblChatUsername = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtxtMessage = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ListBoxUsers
            // 
            this.ListBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBoxUsers.FormattingEnabled = true;
            this.ListBoxUsers.ItemHeight = 28;
            this.ListBoxUsers.Location = new System.Drawing.Point(2, 2);
            this.ListBoxUsers.Name = "ListBoxUsers";
            this.ListBoxUsers.Size = new System.Drawing.Size(129, 284);
            this.ListBoxUsers.TabIndex = 0;
            this.ListBoxUsers.SelectedIndexChanged += new System.EventHandler(this.ListBoxUsers_SelectedIndexChanged);
            // 
            // btnNewChat
            // 
            this.btnNewChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewChat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewChat.Location = new System.Drawing.Point(2, 292);
            this.btnNewChat.Name = "btnNewChat";
            this.btnNewChat.Size = new System.Drawing.Size(129, 57);
            this.btnNewChat.TabIndex = 1;
            this.btnNewChat.Text = "Yeni Sohbet Başlat";
            this.btnNewChat.UseVisualStyleBackColor = true;
            this.btnNewChat.Click += new System.EventHandler(this.btnNewChat_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(137, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(479, 259);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // lblChatUsername
            // 
            this.lblChatUsername.AutoSize = true;
            this.lblChatUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatUsername.Location = new System.Drawing.Point(137, 5);
            this.lblChatUsername.Name = "lblChatUsername";
            this.lblChatUsername.Size = new System.Drawing.Size(164, 20);
            this.lblChatUsername.TabIndex = 3;
            this.lblChatUsername.Text = "Konuşulan Kullanıcı Adı";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(505, 293);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(111, 51);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Gönder";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtxtMessage
            // 
            this.rtxtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtMessage.Location = new System.Drawing.Point(137, 293);
            this.rtxtMessage.Name = "rtxtMessage";
            this.rtxtMessage.Size = new System.Drawing.Size(362, 51);
            this.rtxtMessage.TabIndex = 6;
            this.rtxtMessage.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 356);
            this.Controls.Add(this.rtxtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblChatUsername);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnNewChat);
            this.Controls.Add(this.ListBoxUsers);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainChat";
            this.Load += new System.EventHandler(this.MainChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxUsers;
        private System.Windows.Forms.Button btnNewChat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblChatUsername;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtxtMessage;
        private System.Windows.Forms.Timer timer1;
    }
}