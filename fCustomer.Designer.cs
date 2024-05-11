﻿namespace HotelManager
{
    partial class fCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCustomer));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.groupCustomer = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txbAddress = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txbPhoneNumber = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbFullName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.datepickerDateOfBirth = new Bunifu.Framework.UI.BunifuDatepicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbIDCard = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridCus = new System.Windows.Forms.DataGridView();
            this.bindingCustomer = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCustomerSearch = new MetroFramework.Controls.MetroComboBox();
            this.txbSearch = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnCancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.SaveCustomer = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose1 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnUpdate = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnAddCustomer = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label6 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.txbIDCustomer = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.comboBoxCustomerType = new MetroFramework.Controls.MetroComboBox();
            this.comboBoxSex = new MetroFramework.Controls.MetroComboBox();
            this.txbNationality = new MetroFramework.Controls.MetroComboBox();
            this.groupCustomer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCustomer)).BeginInit();
            this.bindingCustomer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // groupCustomer
            // 
            this.groupCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupCustomer.BackgroundImage")));
            this.groupCustomer.Controls.Add(this.comboBoxSex);
            this.groupCustomer.Controls.Add(this.txbIDCustomer);
            this.groupCustomer.Controls.Add(this.comboBoxCustomerType);
            this.groupCustomer.Controls.Add(this.txbNationality);
            this.groupCustomer.Controls.Add(this.label14);
            this.groupCustomer.Controls.Add(this.txbAddress);
            this.groupCustomer.Controls.Add(this.txbPhoneNumber);
            this.groupCustomer.Controls.Add(this.label11);
            this.groupCustomer.Controls.Add(this.label12);
            this.groupCustomer.Controls.Add(this.label2);
            this.groupCustomer.Controls.Add(this.txbFullName);
            this.groupCustomer.Controls.Add(this.datepickerDateOfBirth);
            this.groupCustomer.Controls.Add(this.label13);
            this.groupCustomer.Controls.Add(this.label20);
            this.groupCustomer.Controls.Add(this.label15);
            this.groupCustomer.Controls.Add(this.label1);
            this.groupCustomer.Controls.Add(this.txbIDCard);
            this.groupCustomer.Controls.Add(this.label16);
            this.groupCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupCustomer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupCustomer.ForeColor = System.Drawing.Color.Gold;
            this.groupCustomer.Location = new System.Drawing.Point(5, 175);
            this.groupCustomer.Name = "groupCustomer";
            this.groupCustomer.Size = new System.Drawing.Size(414, 314);
            this.groupCustomer.TabIndex = 1;
            this.groupCustomer.TabStop = false;
            this.groupCustomer.Text = "Thông tin khách hàng";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label14.ForeColor = System.Drawing.Color.Gold;
            this.label14.Location = new System.Drawing.Point(216, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 25);
            this.label14.TabIndex = 55;
            this.label14.Text = "Số điện thoại:";
            // 
            // txbAddress
            // 
            this.txbAddress.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbAddress.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbAddress.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbAddress.BorderThickness = 1;
            this.txbAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAddress.ForeColor = System.Drawing.Color.Gold;
            this.txbAddress.isPassword = false;
            this.txbAddress.Location = new System.Drawing.Point(216, 155);
            this.txbAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(175, 29);
            this.txbAddress.TabIndex = 53;
            this.txbAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txbPhoneNumber
            // 
            this.txbPhoneNumber.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbPhoneNumber.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbPhoneNumber.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbPhoneNumber.BorderThickness = 1;
            this.txbPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPhoneNumber.ForeColor = System.Drawing.Color.Gold;
            this.txbPhoneNumber.isPassword = false;
            this.txbPhoneNumber.Location = new System.Drawing.Point(216, 99);
            this.txbPhoneNumber.Margin = new System.Windows.Forms.Padding(0);
            this.txbPhoneNumber.Name = "txbPhoneNumber";
            this.txbPhoneNumber.Size = new System.Drawing.Size(175, 29);
            this.txbPhoneNumber.TabIndex = 52;
            this.txbPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label11.ForeColor = System.Drawing.Color.Gold;
            this.label11.Location = new System.Drawing.Point(216, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 25);
            this.label11.TabIndex = 57;
            this.label11.Text = "Địa chỉ:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label12.ForeColor = System.Drawing.Color.Gold;
            this.label12.Location = new System.Drawing.Point(216, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 25);
            this.label12.TabIndex = 56;
            this.label12.Text = "Quốc tịch:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 51;
            this.label2.Text = "Mã khách hàng:";
            // 
            // txbFullName
            // 
            this.txbFullName.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbFullName.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbFullName.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbFullName.BorderThickness = 1;
            this.txbFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbFullName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFullName.ForeColor = System.Drawing.Color.Gold;
            this.txbFullName.isPassword = false;
            this.txbFullName.Location = new System.Drawing.Point(12, 99);
            this.txbFullName.Margin = new System.Windows.Forms.Padding(0);
            this.txbFullName.Name = "txbFullName";
            this.txbFullName.Size = new System.Drawing.Size(175, 29);
            this.txbFullName.TabIndex = 1;
            this.txbFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // datepickerDateOfBirth
            // 
            this.datepickerDateOfBirth.BackColor = System.Drawing.Color.Black;
            this.datepickerDateOfBirth.BorderRadius = 0;
            this.datepickerDateOfBirth.ForeColor = System.Drawing.Color.Gold;
            this.datepickerDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datepickerDateOfBirth.FormatCustom = null;
            this.datepickerDateOfBirth.Location = new System.Drawing.Point(216, 44);
            this.datepickerDateOfBirth.Margin = new System.Windows.Forms.Padding(48, 79, 48, 79);
            this.datepickerDateOfBirth.Name = "datepickerDateOfBirth";
            this.datepickerDateOfBirth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.datepickerDateOfBirth.Size = new System.Drawing.Size(176, 30);
            this.datepickerDateOfBirth.TabIndex = 5;
            this.datepickerDateOfBirth.Value = new System.DateTime(2018, 2, 23, 23, 29, 57, 962);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label13.ForeColor = System.Drawing.Color.Gold;
            this.label13.Location = new System.Drawing.Point(12, 244);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 25);
            this.label13.TabIndex = 28;
            this.label13.Text = "Giới tính:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label20.ForeColor = System.Drawing.Color.Gold;
            this.label20.Location = new System.Drawing.Point(12, 188);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(154, 25);
            this.label20.TabIndex = 41;
            this.label20.Text = "Loại khách hàng:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label15.ForeColor = System.Drawing.Color.Gold;
            this.label15.Location = new System.Drawing.Point(12, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 25);
            this.label15.TabIndex = 24;
            this.label15.Text = "Số CMND:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(216, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 49;
            this.label1.Text = "Ngày sinh:";
            // 
            // txbIDCard
            // 
            this.txbIDCard.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbIDCard.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbIDCard.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbIDCard.BorderThickness = 1;
            this.txbIDCard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbIDCard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbIDCard.ForeColor = System.Drawing.Color.Gold;
            this.txbIDCard.isPassword = false;
            this.txbIDCard.Location = new System.Drawing.Point(12, 159);
            this.txbIDCard.Margin = new System.Windows.Forms.Padding(0);
            this.txbIDCard.Name = "txbIDCard";
            this.txbIDCard.Size = new System.Drawing.Size(175, 29);
            this.txbIDCard.TabIndex = 2;
            this.txbIDCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label16.ForeColor = System.Drawing.Color.Gold;
            this.label16.Location = new System.Drawing.Point(12, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 25);
            this.label16.TabIndex = 22;
            this.label16.Text = "Họ và tên:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::HotelManager.Properties.Resources.background_vang_den_toi_gian_082943093;
            this.groupBox1.Controls.Add(this.dataGridCus);
            this.groupBox1.Controls.Add(this.bindingCustomer);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.Gold;
            this.groupBox1.Location = new System.Drawing.Point(431, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1096, 555);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Khách Hàng";
            // 
            // dataGridCus
            // 
            this.dataGridCus.AllowUserToAddRows = false;
            this.dataGridCus.AllowUserToDeleteRows = false;
            this.dataGridCus.AllowUserToResizeRows = false;
            this.dataGridCus.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridCus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridCus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridCus.ColumnHeadersHeight = 29;
            this.dataGridCus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridCus.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridCus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridCus.GridColor = System.Drawing.Color.Gold;
            this.dataGridCus.Location = new System.Drawing.Point(3, 73);
            this.dataGridCus.Name = "dataGridCus";
            this.dataGridCus.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridCus.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridCus.RowHeadersVisible = false;
            this.dataGridCus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridCus.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridCus.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridCus.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridCus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCus.Size = new System.Drawing.Size(1090, 479);
            this.dataGridCus.TabIndex = 30;
            // 
            // bindingCustomer
            // 
            this.bindingCustomer.AddNewItem = null;
            this.bindingCustomer.AutoSize = false;
            this.bindingCustomer.BackColor = System.Drawing.Color.Transparent;
            this.bindingCustomer.CountItem = this.bindingNavigatorCountItem;
            this.bindingCustomer.CountItemFormat = "của {0}";
            this.bindingCustomer.DeleteItem = null;
            this.bindingCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingCustomer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingCustomer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingCustomer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.toolStripLabel1});
            this.bindingCustomer.Location = new System.Drawing.Point(3, 30);
            this.bindingCustomer.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingCustomer.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingCustomer.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingCustomer.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingCustomer.Name = "bindingCustomer";
            this.bindingCustomer.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingCustomer.Size = new System.Drawing.Size(1090, 43);
            this.bindingCustomer.TabIndex = 29;
            this.bindingCustomer.Text = "binding";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.ForeColor = System.Drawing.Color.Gold;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(61, 40);
            this.bindingNavigatorCountItem.Text = "của {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Tổng số khách hàng";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AutoSize = false;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "Khách hàng đầu tiên";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AutoSize = false;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.ToolTipText = "Khách hàng trước đó";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 43);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Vị trí khách hàng";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AutoSize = false;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.ToolTipText = "Khách hàng kế tiếp";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AutoSize = false;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.ToolTipText = "Khách hàng cuối cùng";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Gold;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 40);
            this.toolStripLabel1.Text = "Xuất";
            this.toolStripLabel1.ToolTipText = "Xuất";
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.BackgroundImage")));
            this.groupBox3.Controls.Add(this.cbCustomerSearch);
            this.groupBox3.Controls.Add(this.txbSearch);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox3.ForeColor = System.Drawing.Color.Gold;
            this.groupBox3.Location = new System.Drawing.Point(5, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 115);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // cbCustomerSearch
            // 
            this.cbCustomerSearch.BackColor = System.Drawing.Color.Transparent;
            this.cbCustomerSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCustomerSearch.ForeColor = System.Drawing.Color.Gold;
            this.cbCustomerSearch.FormattingEnabled = true;
            this.cbCustomerSearch.ItemHeight = 24;
            this.cbCustomerSearch.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cbCustomerSearch.Location = new System.Drawing.Point(12, 71);
            this.cbCustomerSearch.Name = "cbCustomerSearch";
            this.cbCustomerSearch.Size = new System.Drawing.Size(179, 30);
            this.cbCustomerSearch.Style = MetroFramework.MetroColorStyle.Yellow;
            this.cbCustomerSearch.TabIndex = 60;
            this.cbCustomerSearch.UseCustomBackColor = true;
            this.cbCustomerSearch.UseCustomForeColor = true;
            this.cbCustomerSearch.UseSelectable = true;
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
            this.txbSearch.Location = new System.Drawing.Point(220, 26);
            this.txbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(175, 29);
            this.txbSearch.TabIndex = 0;
            this.txbSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(12, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 26);
            this.label5.TabIndex = 28;
            this.label5.Text = "Tìm kiếm theo:";
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
            this.btnSearch.Location = new System.Drawing.Point(220, 62);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(175, 40);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnCancel.Location = new System.Drawing.Point(220, 61);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 40);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Visible = false;
            // 
            // SaveCustomer
            // 
            this.SaveCustomer.FileName = "Danh Sách Khách hàng";
            this.SaveCustomer.Filter = "Excel File(*.xls)|*.xls|Excel File (*.xlsx) |.xlsx|PDF File(*.pdf)|*.pdf";
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.Controls.Add(this.btnClose1);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnAddCustomer);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.Gold;
            this.groupBox2.Location = new System.Drawing.Point(5, 491);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 118);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // btnClose1
            // 
            this.btnClose1.ActiveBorderThickness = 1;
            this.btnClose1.ActiveCornerRadius = 20;
            this.btnClose1.ActiveFillColor = System.Drawing.Color.Gold;
            this.btnClose1.ActiveForecolor = System.Drawing.Color.Black;
            this.btnClose1.ActiveLineColor = System.Drawing.Color.Gold;
            this.btnClose1.BackColor = System.Drawing.Color.Black;
            this.btnClose1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose1.BackgroundImage")));
            this.btnClose1.ButtonText = "Đóng";
            this.btnClose1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose1.ForeColor = System.Drawing.Color.Gold;
            this.btnClose1.IdleBorderThickness = 1;
            this.btnClose1.IdleCornerRadius = 20;
            this.btnClose1.IdleFillColor = System.Drawing.Color.Black;
            this.btnClose1.IdleForecolor = System.Drawing.Color.Gold;
            this.btnClose1.IdleLineColor = System.Drawing.Color.Gold;
            this.btnClose1.Location = new System.Drawing.Point(12, 70);
            this.btnClose1.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(175, 40);
            this.btnClose1.TabIndex = 52;
            this.btnClose1.TabStop = false;
            this.btnClose1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ActiveBorderThickness = 1;
            this.btnUpdate.ActiveCornerRadius = 20;
            this.btnUpdate.ActiveFillColor = System.Drawing.Color.Gold;
            this.btnUpdate.ActiveForecolor = System.Drawing.Color.Black;
            this.btnUpdate.ActiveLineColor = System.Drawing.Color.Gold;
            this.btnUpdate.BackColor = System.Drawing.Color.Black;
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.ButtonText = "Cập Nhật";
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Gold;
            this.btnUpdate.IdleBorderThickness = 1;
            this.btnUpdate.IdleCornerRadius = 20;
            this.btnUpdate.IdleFillColor = System.Drawing.Color.Black;
            this.btnUpdate.IdleForecolor = System.Drawing.Color.Gold;
            this.btnUpdate.IdleLineColor = System.Drawing.Color.Gold;
            this.btnUpdate.Location = new System.Drawing.Point(12, 25);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(175, 40);
            this.btnUpdate.TabIndex = 51;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.ActiveBorderThickness = 1;
            this.btnAddCustomer.ActiveCornerRadius = 20;
            this.btnAddCustomer.ActiveFillColor = System.Drawing.Color.Gold;
            this.btnAddCustomer.ActiveForecolor = System.Drawing.Color.Black;
            this.btnAddCustomer.ActiveLineColor = System.Drawing.Color.Gold;
            this.btnAddCustomer.BackColor = System.Drawing.Color.Black;
            this.btnAddCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCustomer.BackgroundImage")));
            this.btnAddCustomer.ButtonText = "Thêm";
            this.btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.ForeColor = System.Drawing.Color.Gold;
            this.btnAddCustomer.IdleBorderThickness = 1;
            this.btnAddCustomer.IdleCornerRadius = 20;
            this.btnAddCustomer.IdleFillColor = System.Drawing.Color.Black;
            this.btnAddCustomer.IdleForecolor = System.Drawing.Color.Gold;
            this.btnAddCustomer.IdleLineColor = System.Drawing.Color.Gold;
            this.btnAddCustomer.Location = new System.Drawing.Point(216, 25);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(175, 40);
            this.btnAddCustomer.TabIndex = 8;
            this.btnAddCustomer.TabStop = false;
            this.btnAddCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(9, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(323, 46);
            this.label6.TabIndex = 42;
            this.label6.Text = "Quản Lí Khách Hàng";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(5, 34);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1522, 10);
            this.bunifuSeparator1.TabIndex = 56;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(1102, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 26;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txbIDCustomer
            // 
            this.txbIDCustomer.BorderColorFocused = System.Drawing.Color.Gold;
            this.txbIDCustomer.BorderColorIdle = System.Drawing.Color.Gold;
            this.txbIDCustomer.BorderColorMouseHover = System.Drawing.Color.Gold;
            this.txbIDCustomer.BorderThickness = 1;
            this.txbIDCustomer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbIDCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbIDCustomer.ForeColor = System.Drawing.Color.Gold;
            this.txbIDCustomer.isPassword = false;
            this.txbIDCustomer.Location = new System.Drawing.Point(12, 44);
            this.txbIDCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.txbIDCustomer.Name = "txbIDCustomer";
            this.txbIDCustomer.Size = new System.Drawing.Size(175, 29);
            this.txbIDCustomer.TabIndex = 60;
            this.txbIDCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // comboBoxCustomerType
            // 
            this.comboBoxCustomerType.BackColor = System.Drawing.Color.Black;
            this.comboBoxCustomerType.ForeColor = System.Drawing.Color.Gold;
            this.comboBoxCustomerType.FormattingEnabled = true;
            this.comboBoxCustomerType.ItemHeight = 24;
            this.comboBoxCustomerType.Location = new System.Drawing.Point(12, 216);
            this.comboBoxCustomerType.Name = "comboBoxCustomerType";
            this.comboBoxCustomerType.Size = new System.Drawing.Size(175, 30);
            this.comboBoxCustomerType.Style = MetroFramework.MetroColorStyle.Blue;
            this.comboBoxCustomerType.TabIndex = 59;
            this.comboBoxCustomerType.UseSelectable = true;
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.BackColor = System.Drawing.Color.Black;
            this.comboBoxSex.ForeColor = System.Drawing.Color.Gold;
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.ItemHeight = 24;
            this.comboBoxSex.Location = new System.Drawing.Point(12, 272);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(175, 30);
            this.comboBoxSex.Style = MetroFramework.MetroColorStyle.Blue;
            this.comboBoxSex.TabIndex = 61;
            this.comboBoxSex.UseSelectable = true;
            // 
            // txbNationality
            // 
            this.txbNationality.BackColor = System.Drawing.Color.Black;
            this.txbNationality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txbNationality.ForeColor = System.Drawing.Color.Gold;
            this.txbNationality.FormattingEnabled = true;
            this.txbNationality.ItemHeight = 24;
            this.txbNationality.Items.AddRange(new object[] {
            "Việt Nam",
            "Trung Quốc",
            "Hàn Quốc",
            "Nhật Bản",
            "Đài Loan",
            "Malaysia",
            "Thái Lan",
            "Singapore",
            "Nga",
            "Anh",
            "Pháp",
            "Đức",
            "Hoa Kỳ",
            "Hà Lan",
            "Tây Ban Nha",
            "Ý",
            "Khác"});
            this.txbNationality.Location = new System.Drawing.Point(216, 211);
            this.txbNationality.Name = "txbNationality";
            this.txbNationality.Size = new System.Drawing.Size(179, 30);
            this.txbNationality.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbNationality.TabIndex = 58;
            this.txbNationality.UseSelectable = true;
            // 
            // fCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::HotelManager.Properties.Resources.background_vang_den_toi_gian_082943093;
            this.ClientSize = new System.Drawing.Size(1123, 614);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupCustomer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "fCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fCustomer";
            this.Load += new System.EventHandler(this.fCustomer_Load);
            this.groupCustomer.ResumeLayout(false);
            this.groupCustomer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCustomer)).EndInit();
            this.bindingCustomer.ResumeLayout(false);
            this.bindingCustomer.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.GroupBox groupCustomer;
        private Bunifu.Framework.UI.BunifuDatepicker datepickerDateOfBirth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label13;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbIDCard;
        private System.Windows.Forms.Label label15;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbFullName;
        private System.Windows.Forms.Label label16;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingNavigator bindingCustomer;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSearch;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SaveFileDialog SaveCustomer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnUpdate;
        private Bunifu.Framework.UI.BunifuThinButton2 btnClose1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCancel;
        private System.Windows.Forms.Label label14;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbAddress;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbPhoneNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridCus;
        private MetroFramework.Controls.MetroComboBox cbCustomerSearch;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbIDCustomer;
        private MetroFramework.Controls.MetroComboBox comboBoxSex;
        private MetroFramework.Controls.MetroComboBox comboBoxCustomerType;
        private MetroFramework.Controls.MetroComboBox txbNationality;
    }
}