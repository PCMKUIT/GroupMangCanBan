﻿namespace HotelManager
{
    partial class fBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBill));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bindingBill = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSeenBill = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnCLose1 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label6 = new System.Windows.Forms.Label();
            this.saveBill = new System.Windows.Forms.SaveFileDialog();
            this.groupService = new System.Windows.Forms.GroupBox();
            this.txbFinalPrice = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDiscount = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbStatusRoom = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbDateCreate = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbUser = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txbName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txbPrice = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbSearch = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnSearch = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnCancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewBill = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdReciveRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStaffsetUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldDateOfCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txbMaHD = new Bunifu.Framework.UI.BunifuMetroTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBill)).BeginInit();
            this.bindingBill.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupService.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBill)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(8, 66);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1782, 19);
            this.bunifuSeparator1.TabIndex = 62;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // bindingBill
            // 
            this.bindingBill.AddNewItem = null;
            this.bindingBill.AutoSize = false;
            this.bindingBill.BackColor = System.Drawing.Color.Black;
            this.bindingBill.BackgroundImage = global::HotelManager.Properties.Resources.background_vang_den_toi_gian_082943093;
            this.bindingBill.CountItem = this.bindingNavigatorCountItem;
            this.bindingBill.CountItemFormat = "Số lượng hóa đơn";
            this.bindingBill.DeleteItem = null;
            this.bindingBill.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingBill.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingBill.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingBill.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1});
            this.bindingBill.Location = new System.Drawing.Point(4, 37);
            this.bindingBill.MoveFirstItem = null;
            this.bindingBill.MoveLastItem = null;
            this.bindingBill.MoveNextItem = null;
            this.bindingBill.MovePreviousItem = null;
            this.bindingBill.Name = "bindingBill";
            this.bindingBill.PositionItem = null;
            this.bindingBill.Size = new System.Drawing.Size(1429, 66);
            this.bindingBill.TabIndex = 29;
            this.bindingBill.Text = "binding";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.ForeColor = System.Drawing.Color.Gold;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(170, 61);
            this.bindingNavigatorCountItem.Text = "Số lượng hóa đơn";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 66);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 66);
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = global::HotelManager.Properties.Resources.background_vang_den_toi_gian_082943093;
            this.groupBox2.Controls.Add(this.btnSeenBill);
            this.groupBox2.Controls.Add(this.btnCLose1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.Gold;
            this.groupBox2.Location = new System.Drawing.Point(6, 661);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(612, 128);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // btnSeenBill
            // 
            this.btnSeenBill.ActiveBorderThickness = 1;
            this.btnSeenBill.ActiveCornerRadius = 20;
            this.btnSeenBill.ActiveFillColor = System.Drawing.Color.Gold;
            this.btnSeenBill.ActiveForecolor = System.Drawing.Color.Black;
            this.btnSeenBill.ActiveLineColor = System.Drawing.Color.Gold;
            this.btnSeenBill.BackColor = System.Drawing.Color.Black;
            this.btnSeenBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSeenBill.BackgroundImage")));
            this.btnSeenBill.ButtonText = "Chi Tiết Hóa Đơn";
            this.btnSeenBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeenBill.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeenBill.ForeColor = System.Drawing.Color.Gold;
            this.btnSeenBill.IdleBorderThickness = 1;
            this.btnSeenBill.IdleCornerRadius = 20;
            this.btnSeenBill.IdleFillColor = System.Drawing.Color.Black;
            this.btnSeenBill.IdleForecolor = System.Drawing.Color.Gold;
            this.btnSeenBill.IdleLineColor = System.Drawing.Color.Gold;
            this.btnSeenBill.Location = new System.Drawing.Point(17, 41);
            this.btnSeenBill.Margin = new System.Windows.Forms.Padding(6);
            this.btnSeenBill.Name = "btnSeenBill";
            this.btnSeenBill.Size = new System.Drawing.Size(262, 61);
            this.btnSeenBill.TabIndex = 50;
            this.btnSeenBill.TabStop = false;
            this.btnSeenBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCLose1
            // 
            this.btnCLose1.ActiveBorderThickness = 1;
            this.btnCLose1.ActiveCornerRadius = 20;
            this.btnCLose1.ActiveFillColor = System.Drawing.Color.Gold;
            this.btnCLose1.ActiveForecolor = System.Drawing.Color.Black;
            this.btnCLose1.ActiveLineColor = System.Drawing.Color.Gold;
            this.btnCLose1.BackColor = System.Drawing.Color.Black;
            this.btnCLose1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCLose1.BackgroundImage")));
            this.btnCLose1.ButtonText = "Đóng";
            this.btnCLose1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCLose1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLose1.ForeColor = System.Drawing.Color.Gold;
            this.btnCLose1.IdleBorderThickness = 1;
            this.btnCLose1.IdleCornerRadius = 20;
            this.btnCLose1.IdleFillColor = System.Drawing.Color.Black;
            this.btnCLose1.IdleForecolor = System.Drawing.Color.Gold;
            this.btnCLose1.IdleLineColor = System.Drawing.Color.Gold;
            this.btnCLose1.Location = new System.Drawing.Point(315, 41);
            this.btnCLose1.Margin = new System.Windows.Forms.Padding(6);
            this.btnCLose1.Name = "btnCLose1";
            this.btnCLose1.Size = new System.Drawing.Size(262, 61);
            this.btnCLose1.TabIndex = 52;
            this.btnCLose1.TabStop = false;
            this.btnCLose1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCLose1.Click += new System.EventHandler(this.btnCLose1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(334, 55);
            this.label6.TabIndex = 61;
            this.label6.Text = "Quản Lí Hoá Đơn";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveBill
            // 
            this.saveBill.FileName = "Danh sách dịch vụ";
            this.saveBill.Filter = "Excel File(*.xls)|*.xls|Excel File (*.xlsx) |.xlsx|PDF File(*.pdf)|*.pdf";
            // 
            // groupService
            // 
            this.groupService.BackgroundImage = global::HotelManager.Properties.Resources.background_vang_den_toi_gian_082943093;
            this.groupService.Controls.Add(this.txbMaHD);
            this.groupService.Controls.Add(this.txbFinalPrice);
            this.groupService.Controls.Add(this.label3);
            this.groupService.Controls.Add(this.txbDiscount);
            this.groupService.Controls.Add(this.label2);
            this.groupService.Controls.Add(this.txbStatusRoom);
            this.groupService.Controls.Add(this.label1);
            this.groupService.Controls.Add(this.txbDateCreate);
            this.groupService.Controls.Add(this.label4);
            this.groupService.Controls.Add(this.txbUser);
            this.groupService.Controls.Add(this.txbName);
            this.groupService.Controls.Add(this.txbPrice);
            this.groupService.Controls.Add(this.label16);
            this.groupService.Controls.Add(this.label15);
            this.groupService.Controls.Add(this.label13);
            this.groupService.Controls.Add(this.label20);
            this.groupService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupService.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupService.ForeColor = System.Drawing.Color.Gold;
            this.groupService.Location = new System.Drawing.Point(9, 246);
            this.groupService.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupService.Name = "groupService";
            this.groupService.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupService.Size = new System.Drawing.Size(609, 418);
            this.groupService.TabIndex = 1;
            this.groupService.TabStop = false;
            this.groupService.Text = "Thông tin hoá đơn";
            // 
            // txbFinalPrice
            // 
            this.txbFinalPrice.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbFinalPrice.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbFinalPrice.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbFinalPrice.BorderThickness = 1;
            this.txbFinalPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbFinalPrice.Enabled = false;
            this.txbFinalPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFinalPrice.ForeColor = System.Drawing.Color.Gold;
            this.txbFinalPrice.isPassword = false;
            this.txbFinalPrice.Location = new System.Drawing.Point(312, 325);
            this.txbFinalPrice.Margin = new System.Windows.Forms.Padding(0);
            this.txbFinalPrice.Name = "txbFinalPrice";
            this.txbFinalPrice.Size = new System.Drawing.Size(262, 45);
            this.txbFinalPrice.TabIndex = 70;
            this.txbFinalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(315, 294);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 31);
            this.label3.TabIndex = 69;
            this.label3.Text = "Thành tiền:";
            // 
            // txbDiscount
            // 
            this.txbDiscount.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbDiscount.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbDiscount.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbDiscount.BorderThickness = 1;
            this.txbDiscount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbDiscount.Enabled = false;
            this.txbDiscount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDiscount.ForeColor = System.Drawing.Color.Gold;
            this.txbDiscount.isPassword = false;
            this.txbDiscount.Location = new System.Drawing.Point(315, 246);
            this.txbDiscount.Margin = new System.Windows.Forms.Padding(0);
            this.txbDiscount.Name = "txbDiscount";
            this.txbDiscount.Size = new System.Drawing.Size(262, 45);
            this.txbDiscount.TabIndex = 68;
            this.txbDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(315, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 31);
            this.label2.TabIndex = 67;
            this.label2.Text = "Giảm giá:";
            // 
            // txbStatusRoom
            // 
            this.txbStatusRoom.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbStatusRoom.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbStatusRoom.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbStatusRoom.BorderThickness = 1;
            this.txbStatusRoom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbStatusRoom.Enabled = false;
            this.txbStatusRoom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbStatusRoom.ForeColor = System.Drawing.Color.Gold;
            this.txbStatusRoom.isPassword = false;
            this.txbStatusRoom.Location = new System.Drawing.Point(315, 71);
            this.txbStatusRoom.Margin = new System.Windows.Forms.Padding(0);
            this.txbStatusRoom.Name = "txbStatusRoom";
            this.txbStatusRoom.Size = new System.Drawing.Size(262, 45);
            this.txbStatusRoom.TabIndex = 66;
            this.txbStatusRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(315, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 31);
            this.label1.TabIndex = 65;
            this.label1.Text = "Trạng Thái:";
            // 
            // txbDateCreate
            // 
            this.txbDateCreate.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbDateCreate.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbDateCreate.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbDateCreate.BorderThickness = 1;
            this.txbDateCreate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbDateCreate.Enabled = false;
            this.txbDateCreate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDateCreate.ForeColor = System.Drawing.Color.Gold;
            this.txbDateCreate.isPassword = false;
            this.txbDateCreate.Location = new System.Drawing.Point(17, 329);
            this.txbDateCreate.Margin = new System.Windows.Forms.Padding(0);
            this.txbDateCreate.Name = "txbDateCreate";
            this.txbDateCreate.Size = new System.Drawing.Size(262, 45);
            this.txbDateCreate.TabIndex = 64;
            this.txbDateCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(17, 299);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 31);
            this.label4.TabIndex = 63;
            this.label4.Text = "Ngày tạo:";
            // 
            // txbUser
            // 
            this.txbUser.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbUser.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbUser.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbUser.BorderThickness = 1;
            this.txbUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbUser.Enabled = false;
            this.txbUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUser.ForeColor = System.Drawing.Color.Gold;
            this.txbUser.isPassword = false;
            this.txbUser.Location = new System.Drawing.Point(17, 246);
            this.txbUser.Margin = new System.Windows.Forms.Padding(0);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(262, 45);
            this.txbUser.TabIndex = 61;
            this.txbUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txbName
            // 
            this.txbName.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbName.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbName.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbName.BorderThickness = 1;
            this.txbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbName.Enabled = false;
            this.txbName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbName.ForeColor = System.Drawing.Color.Gold;
            this.txbName.isPassword = false;
            this.txbName.Location = new System.Drawing.Point(17, 159);
            this.txbName.Margin = new System.Windows.Forms.Padding(0);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(262, 45);
            this.txbName.TabIndex = 1;
            this.txbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txbPrice
            // 
            this.txbPrice.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbPrice.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbPrice.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbPrice.BorderThickness = 1;
            this.txbPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbPrice.Enabled = false;
            this.txbPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPrice.ForeColor = System.Drawing.Color.Gold;
            this.txbPrice.isPassword = false;
            this.txbPrice.Location = new System.Drawing.Point(315, 159);
            this.txbPrice.Margin = new System.Windows.Forms.Padding(0);
            this.txbPrice.Name = "txbPrice";
            this.txbPrice.Size = new System.Drawing.Size(262, 45);
            this.txbPrice.TabIndex = 59;
            this.txbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Gold;
            this.label16.Location = new System.Drawing.Point(17, 40);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 31);
            this.label16.TabIndex = 22;
            this.label16.Text = "Mã hoá đơn:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Gold;
            this.label15.Location = new System.Drawing.Point(17, 126);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 31);
            this.label15.TabIndex = 24;
            this.label15.Text = "Tên phòng:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Gold;
            this.label13.Location = new System.Drawing.Point(315, 122);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 31);
            this.label13.TabIndex = 57;
            this.label13.Text = "Đơn giá:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Gold;
            this.label20.Location = new System.Drawing.Point(17, 209);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(161, 31);
            this.label20.TabIndex = 58;
            this.label20.Text = "Nhân viên tạo:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = global::HotelManager.Properties.Resources.background_vang_den_toi_gian_082943093;
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txbSearch);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox3.ForeColor = System.Drawing.Color.Gold;
            this.groupBox3.Location = new System.Drawing.Point(9, 80);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(609, 168);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(59, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 31);
            this.label5.TabIndex = 48;
            this.label5.Text = "Số điện thoại đăng ký:";
            // 
            // txbSearch
            // 
            this.txbSearch.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbSearch.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbSearch.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbSearch.BorderThickness = 1;
            this.txbSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearch.ForeColor = System.Drawing.Color.Gold;
            this.txbSearch.isPassword = false;
            this.txbSearch.Location = new System.Drawing.Point(312, 26);
            this.txbSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(262, 45);
            this.txbSearch.TabIndex = 0;
            this.txbSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnSearch
            // 
            this.btnSearch.ActiveBorderThickness = 1;
            this.btnSearch.ActiveCornerRadius = 20;
            this.btnSearch.ActiveFillColor = System.Drawing.Color.Gold;
            this.btnSearch.ActiveForecolor = System.Drawing.Color.Black;
            this.btnSearch.ActiveLineColor = System.Drawing.Color.Gold;
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.ButtonText = "Tìm Kiếm";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Gold;
            this.btnSearch.IdleBorderThickness = 1;
            this.btnSearch.IdleCornerRadius = 20;
            this.btnSearch.IdleFillColor = System.Drawing.Color.Black;
            this.btnSearch.IdleForecolor = System.Drawing.Color.Gold;
            this.btnSearch.IdleLineColor = System.Drawing.Color.Gold;
            this.btnSearch.Location = new System.Drawing.Point(315, 79);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(262, 61);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(315, 79);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(262, 61);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::HotelManager.Properties.Resources.background_vang_den_toi_gian_082943093;
            this.groupBox1.Controls.Add(this.dataGridViewBill);
            this.groupBox1.Controls.Add(this.bindingBill);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.Gold;
            this.groupBox1.Location = new System.Drawing.Point(627, 80);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1437, 709);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Hoá Đơn";
            // 
            // dataGridViewBill
            // 
            this.dataGridViewBill.AllowUserToAddRows = false;
            this.dataGridViewBill.AllowUserToDeleteRows = false;
            this.dataGridViewBill.AllowUserToResizeRows = false;
            this.dataGridViewBill.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridViewBill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewBill.ColumnHeadersHeight = 29;
            this.dataGridViewBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colIdReciveRoom,
            this.colCustomerName,
            this.colStaffsetUp,
            this.coldDateOfCreate,
            this.colStatus,
            this.colPrice,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBill.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBill.GridColor = System.Drawing.Color.Gold;
            this.dataGridViewBill.Location = new System.Drawing.Point(4, 103);
            this.dataGridViewBill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewBill.Name = "dataGridViewBill";
            this.dataGridViewBill.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBill.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewBill.RowHeadersVisible = false;
            this.dataGridViewBill.RowHeadersWidth = 51;
            this.dataGridViewBill.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewBill.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dataGridViewBill.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBill.Size = new System.Drawing.Size(1429, 601);
            this.dataGridViewBill.TabIndex = 28;
            this.dataGridViewBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBill_CellClick);
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colID.DataPropertyName = "id";
            this.colID.FillWeight = 30F;
            this.colID.HeaderText = "MHD";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 106;
            // 
            // colIdReciveRoom
            // 
            this.colIdReciveRoom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colIdReciveRoom.DataPropertyName = "roomName";
            this.colIdReciveRoom.FillWeight = 30F;
            this.colIdReciveRoom.HeaderText = "Tên phòng";
            this.colIdReciveRoom.MinimumWidth = 6;
            this.colIdReciveRoom.Name = "colIdReciveRoom";
            this.colIdReciveRoom.ReadOnly = true;
            this.colIdReciveRoom.Width = 165;
            // 
            // colCustomerName
            // 
            this.colCustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colCustomerName.DataPropertyName = "customername";
            this.colCustomerName.HeaderText = "Tên khách hàng";
            this.colCustomerName.MinimumWidth = 6;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Width = 219;
            // 
            // colStaffsetUp
            // 
            this.colStaffsetUp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStaffsetUp.DataPropertyName = "StaffSetUp";
            this.colStaffsetUp.FillWeight = 30F;
            this.colStaffsetUp.HeaderText = "Nhân viên tạo";
            this.colStaffsetUp.MinimumWidth = 6;
            this.colStaffsetUp.Name = "colStaffsetUp";
            this.colStaffsetUp.ReadOnly = true;
            this.colStaffsetUp.Visible = false;
            this.colStaffsetUp.Width = 201;
            // 
            // coldDateOfCreate
            // 
            this.coldDateOfCreate.DataPropertyName = "DateOfCreate";
            this.coldDateOfCreate.FillWeight = 30F;
            this.coldDateOfCreate.HeaderText = "Ngày tạo";
            this.coldDateOfCreate.MinimumWidth = 6;
            this.coldDateOfCreate.Name = "coldDateOfCreate";
            this.coldDateOfCreate.ReadOnly = true;
            this.coldDateOfCreate.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStatus.DataPropertyName = "name";
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 156;
            // 
            // colPrice
            // 
            this.colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPrice.DataPropertyName = "TotalPrice";
            this.colPrice.FillWeight = 30F;
            this.colPrice.HeaderText = "Đơn giá";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 134;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "discount";
            this.Column1.HeaderText = "Giảm giá";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "finalPrice";
            this.Column2.HeaderText = "Thành tiền";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // txbMaHD
            // 
            this.txbMaHD.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbMaHD.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbMaHD.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbMaHD.BorderThickness = 1;
            this.txbMaHD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMaHD.Enabled = false;
            this.txbMaHD.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaHD.ForeColor = System.Drawing.Color.Gold;
            this.txbMaHD.isPassword = false;
            this.txbMaHD.Location = new System.Drawing.Point(23, 71);
            this.txbMaHD.Margin = new System.Windows.Forms.Padding(0);
            this.txbMaHD.Name = "txbMaHD";
            this.txbMaHD.Size = new System.Drawing.Size(262, 45);
            this.txbMaHD.TabIndex = 72;
            this.txbMaHD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // fBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::HotelManager.Properties.Resources.background_vang_den_toi_gian_082943093;
            this.ClientSize = new System.Drawing.Size(2156, 826);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupService);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fBill";
            ((System.ComponentModel.ISupportInitialize)(this.bindingBill)).EndInit();
            this.bindingBill.ResumeLayout(false);
            this.bindingBill.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupService.ResumeLayout(false);
            this.groupService.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSeenBill;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCLose1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupService;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbName;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbSearch;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSearch;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewBill;
        private System.Windows.Forms.BindingNavigator bindingBill;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.SaveFileDialog saveBill;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbUser;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbStatusRoom;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbDateCreate;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbFinalPrice;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdReciveRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStaffsetUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldDateOfCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbMaHD;
    }
}