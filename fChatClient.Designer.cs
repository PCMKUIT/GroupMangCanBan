﻿namespace HotelManager
{
    partial class fChatClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChatClient));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.labelID = new System.Windows.Forms.Label();
            this.txbID = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbmessage = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btSend = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.lv1 = new MetroFramework.Controls.MetroListView();
            this.cbSearch = new MetroFramework.Controls.MetroComboBox();
            this.btnCancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btSearch = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bt_close = new Bunifu.Framework.UI.BunifuThinButton2();
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
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.Transparent;
            this.labelID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.Gold;
            this.labelID.Location = new System.Drawing.Point(25, 40);
            this.labelID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(129, 25);
            this.labelID.TabIndex = 67;
            this.labelID.Text = "Tên nhân viên";
            // 
            // txbID
            // 
            this.txbID.BackColor = System.Drawing.Color.Black;
            this.txbID.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbID.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbID.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbID.BorderThickness = 1;
            this.txbID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbID.Enabled = false;
            this.txbID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbID.ForeColor = System.Drawing.Color.Gold;
            this.txbID.isPassword = false;
            this.txbID.Location = new System.Drawing.Point(31, 69);
            this.txbID.Margin = new System.Windows.Forms.Padding(0);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(265, 36);
            this.txbID.TabIndex = 65;
            this.txbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(318, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 68;
            this.label1.Text = "Chat box";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(22, -6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 46);
            this.label2.TabIndex = 70;
            this.label2.Text = "Chat";
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
            this.tbmessage.Location = new System.Drawing.Point(30, 254);
            this.tbmessage.Margin = new System.Windows.Forms.Padding(0);
            this.tbmessage.Name = "tbmessage";
            this.tbmessage.Size = new System.Drawing.Size(271, 31);
            this.tbmessage.TabIndex = 74;
            this.tbmessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btSend
            // 
            this.btSend.ActiveBorderThickness = 1;
            this.btSend.ActiveCornerRadius = 20;
            this.btSend.ActiveFillColor = System.Drawing.Color.Gold;
            this.btSend.ActiveForecolor = System.Drawing.Color.Black;
            this.btSend.ActiveLineColor = System.Drawing.Color.Gold;
            this.btSend.BackColor = System.Drawing.Color.Black;
            this.btSend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSend.BackgroundImage")));
            this.btSend.ButtonText = "Gửi tin nhắn";
            this.btSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSend.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.ForeColor = System.Drawing.Color.Transparent;
            this.btSend.IdleBorderThickness = 1;
            this.btSend.IdleCornerRadius = 20;
            this.btSend.IdleFillColor = System.Drawing.Color.Black;
            this.btSend.IdleForecolor = System.Drawing.Color.Gold;
            this.btSend.IdleLineColor = System.Drawing.Color.Gold;
            this.btSend.Location = new System.Drawing.Point(30, 293);
            this.btSend.Margin = new System.Windows.Forms.Padding(5);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(276, 47);
            this.btSend.TabIndex = 75;
            this.btSend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(906, 13);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 20);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 79;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lv1
            // 
            this.lv1.BackColor = System.Drawing.Color.Black;
            this.lv1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lv1.ForeColor = System.Drawing.Color.White;
            this.lv1.FullRowSelect = true;
            this.lv1.Location = new System.Drawing.Point(323, 68);
            this.lv1.Name = "lv1";
            this.lv1.OwnerDraw = true;
            this.lv1.Size = new System.Drawing.Size(604, 393);
            this.lv1.Style = MetroFramework.MetroColorStyle.Black;
            this.lv1.TabIndex = 73;
            this.lv1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lv1.UseCompatibleStateImageBehavior = false;
            this.lv1.UseSelectable = true;
            // 
            // cbSearch
            // 
            this.cbSearch.BackColor = System.Drawing.Color.Black;
            this.cbSearch.ForeColor = System.Drawing.Color.Gold;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.ItemHeight = 24;
            this.cbSearch.Location = new System.Drawing.Point(33, 210);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(268, 30);
            this.cbSearch.Style = MetroFramework.MetroColorStyle.Yellow;
            this.cbSearch.TabIndex = 81;
            this.cbSearch.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cbSearch.UseSelectable = true;
            // 
            // btnCancel
            // 
            this.btnCancel.ActiveBorderThickness = 1;
            this.btnCancel.ActiveCornerRadius = 20;
            this.btnCancel.ActiveFillColor = System.Drawing.Color.Red;
            this.btnCancel.ActiveForecolor = System.Drawing.Color.Black;
            this.btnCancel.ActiveLineColor = System.Drawing.Color.Red;
            this.btnCancel.BackColor = System.Drawing.Color.Black;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.ButtonText = "Huỷ Tìm";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Gold;
            this.btnCancel.IdleBorderThickness = 1;
            this.btnCancel.IdleCornerRadius = 20;
            this.btnCancel.IdleFillColor = System.Drawing.Color.Black;
            this.btnCancel.IdleForecolor = System.Drawing.Color.Red;
            this.btnCancel.IdleLineColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(31, 347);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(271, 40);
            this.btnCancel.TabIndex = 82;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btSearch
            // 
            this.btSearch.ActiveBorderThickness = 1;
            this.btSearch.ActiveCornerRadius = 20;
            this.btSearch.ActiveFillColor = System.Drawing.Color.Gold;
            this.btSearch.ActiveForecolor = System.Drawing.Color.Black;
            this.btSearch.ActiveLineColor = System.Drawing.Color.Gold;
            this.btSearch.BackColor = System.Drawing.Color.Black;
            this.btSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSearch.BackgroundImage")));
            this.btSearch.ButtonText = "Tìm kiếm tin nhắn";
            this.btSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearch.ForeColor = System.Drawing.Color.Transparent;
            this.btSearch.IdleBorderThickness = 1;
            this.btSearch.IdleCornerRadius = 20;
            this.btSearch.IdleFillColor = System.Drawing.Color.Black;
            this.btSearch.IdleForecolor = System.Drawing.Color.Gold;
            this.btSearch.IdleLineColor = System.Drawing.Color.Gold;
            this.btSearch.Location = new System.Drawing.Point(33, 340);
            this.btSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(268, 47);
            this.btSearch.TabIndex = 83;
            this.btSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // bt_close
            // 
            this.bt_close.ActiveBorderThickness = 1;
            this.bt_close.ActiveCornerRadius = 20;
            this.bt_close.ActiveFillColor = System.Drawing.Color.Gold;
            this.bt_close.ActiveForecolor = System.Drawing.Color.Black;
            this.bt_close.ActiveLineColor = System.Drawing.Color.Gold;
            this.bt_close.BackColor = System.Drawing.Color.Black;
            this.bt_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_close.BackgroundImage")));
            this.bt_close.ButtonText = "Đóng";
            this.bt_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_close.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_close.ForeColor = System.Drawing.Color.Transparent;
            this.bt_close.IdleBorderThickness = 1;
            this.bt_close.IdleCornerRadius = 20;
            this.bt_close.IdleFillColor = System.Drawing.Color.Black;
            this.bt_close.IdleForecolor = System.Drawing.Color.Gold;
            this.bt_close.IdleLineColor = System.Drawing.Color.Gold;
            this.bt_close.Location = new System.Drawing.Point(33, 397);
            this.bt_close.Margin = new System.Windows.Forms.Padding(5);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(268, 47);
            this.bt_close.TabIndex = 84;
            this.bt_close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click_1);
            // 
            // fChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::HotelManager.Properties.Resources.background_vang_den_toi_gian_082943093;
            this.ClientSize = new System.Drawing.Size(958, 488);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.tbmessage);
            this.Controls.Add(this.lv1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.txbID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fChatClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fChat";
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Label labelID;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuMetroTextbox tbmessage;
        private Bunifu.Framework.UI.BunifuThinButton2 btSend;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private MetroFramework.Controls.MetroListView lv1;
        private MetroFramework.Controls.MetroComboBox cbSearch;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCancel;
        private Bunifu.Framework.UI.BunifuThinButton2 btSearch;
        private Bunifu.Framework.UI.BunifuThinButton2 bt_close;
    }
}