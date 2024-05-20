namespace HotelManager
{
    partial class ChatClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatClient));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.tbmessage = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lv1 = new MetroFramework.Controls.MetroListView();
            this.btClose = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btSend = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.txbID = new Bunifu.Framework.UI.BunifuMetroTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // tbmessage
            // 
            this.tbmessage.BackColor = System.Drawing.Color.Black;
            this.tbmessage.BorderColorFocused = System.Drawing.Color.Gold;
            this.tbmessage.BorderColorIdle = System.Drawing.Color.Gold;
            this.tbmessage.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.tbmessage.BorderThickness = 1;
            this.tbmessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbmessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbmessage.ForeColor = System.Drawing.Color.Gold;
            this.tbmessage.isPassword = false;
            this.tbmessage.Location = new System.Drawing.Point(319, 391);
            this.tbmessage.Margin = new System.Windows.Forms.Padding(0);
            this.tbmessage.Name = "tbmessage";
            this.tbmessage.Size = new System.Drawing.Size(445, 49);
            this.tbmessage.TabIndex = 83;
            this.tbmessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lv1
            // 
            this.lv1.BackColor = System.Drawing.Color.Black;
            this.lv1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lv1.ForeColor = System.Drawing.Color.Gold;
            this.lv1.FullRowSelect = true;
            this.lv1.Location = new System.Drawing.Point(319, 85);
            this.lv1.Name = "lv1";
            this.lv1.OwnerDraw = true;
            this.lv1.Size = new System.Drawing.Size(445, 285);
            this.lv1.TabIndex = 82;
            this.lv1.UseCompatibleStateImageBehavior = false;
            this.lv1.UseSelectable = true;
            // 
            // btClose
            // 
            this.btClose.ActiveBorderThickness = 1;
            this.btClose.ActiveCornerRadius = 20;
            this.btClose.ActiveFillColor = System.Drawing.Color.Gold;
            this.btClose.ActiveForecolor = System.Drawing.Color.Black;
            this.btClose.ActiveLineColor = System.Drawing.Color.Gold;
            this.btClose.BackColor = System.Drawing.SystemColors.Control;
            this.btClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btClose.BackgroundImage")));
            this.btClose.ButtonText = "Đóng";
            this.btClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.ForeColor = System.Drawing.Color.Gold;
            this.btClose.IdleBorderThickness = 1;
            this.btClose.IdleCornerRadius = 20;
            this.btClose.IdleFillColor = System.Drawing.Color.Black;
            this.btClose.IdleForecolor = System.Drawing.Color.Gold;
            this.btClose.IdleLineColor = System.Drawing.Color.Gold;
            this.btClose.Location = new System.Drawing.Point(26, 391);
            this.btClose.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(271, 49);
            this.btClose.TabIndex = 81;
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btSend
            // 
            this.btSend.ActiveBorderThickness = 1;
            this.btSend.ActiveCornerRadius = 20;
            this.btSend.ActiveFillColor = System.Drawing.Color.Gold;
            this.btSend.ActiveForecolor = System.Drawing.Color.Black;
            this.btSend.ActiveLineColor = System.Drawing.Color.Gold;
            this.btSend.BackColor = System.Drawing.SystemColors.Control;
            this.btSend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSend.BackgroundImage")));
            this.btSend.ButtonText = "Gửi tin nhắn";
            this.btSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSend.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.ForeColor = System.Drawing.Color.Gold;
            this.btSend.IdleBorderThickness = 1;
            this.btSend.IdleCornerRadius = 20;
            this.btSend.IdleFillColor = System.Drawing.Color.Black;
            this.btSend.IdleForecolor = System.Drawing.Color.Gold;
            this.btSend.IdleLineColor = System.Drawing.Color.Gold;
            this.btSend.Location = new System.Drawing.Point(26, 321);
            this.btSend.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(271, 49);
            this.btSend.TabIndex = 80;
            this.btSend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(18, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 46);
            this.label2.TabIndex = 79;
            this.label2.Text = "Chat";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(762, 29);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 20);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 78;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(314, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 77;
            this.label1.Text = "Chat box";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.Transparent;
            this.labelID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.Gold;
            this.labelID.Location = new System.Drawing.Point(21, 56);
            this.labelID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(127, 25);
            this.labelID.TabIndex = 76;
            this.labelID.Text = "Mã nhân viên";
            // 
            // txbID
            // 
            this.txbID.BackColor = System.Drawing.Color.Black;
            this.txbID.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbID.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbID.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbID.BorderThickness = 1;
            this.txbID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbID.ForeColor = System.Drawing.Color.Gold;
            this.txbID.isPassword = false;
            this.txbID.Location = new System.Drawing.Point(27, 85);
            this.txbID.Margin = new System.Windows.Forms.Padding(0);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(265, 36);
            this.txbID.TabIndex = 75;
            this.txbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelManager.Properties.Resources.background_vang_den_toi_gian_082943093;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbmessage);
            this.Controls.Add(this.lv1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.txbID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChatClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fChat";
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuMetroTextbox tbmessage;
        private MetroFramework.Controls.MetroListView lv1;
        private Bunifu.Framework.UI.BunifuThinButton2 btClose;
        private Bunifu.Framework.UI.BunifuThinButton2 btSend;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelID;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbID;
    }
}