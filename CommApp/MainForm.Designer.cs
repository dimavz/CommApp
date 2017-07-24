namespace CommApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dgvServers = new System.Windows.Forms.DataGridView();
            this.SelectServer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StatusImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeoutServer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.pbcQuerySrv = new DevExpress.XtraEditors.ProgressBarControl();
            this.sbClear = new DevExpress.XtraEditors.SimpleButton();
            this.sbRun = new DevExpress.XtraEditors.SimpleButton();
            this.lbMessage = new System.Windows.Forms.Label();
            this.rtbQuery = new System.Windows.Forms.RichTextBox();
            this.gbServers = new System.Windows.Forms.GroupBox();
            this.pbcConnSrv = new DevExpress.XtraEditors.ProgressBarControl();
            this.sbDown = new DevExpress.XtraEditors.SimpleButton();
            this.sbUp = new DevExpress.XtraEditors.SimpleButton();
            this.sbReload = new DevExpress.XtraEditors.SimpleButton();
            this.sbUnchAll = new DevExpress.XtraEditors.SimpleButton();
            this.sbSelAll = new DevExpress.XtraEditors.SimpleButton();
            this.sbDel = new DevExpress.XtraEditors.SimpleButton();
            this.sbEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.sbExportExel = new DevExpress.XtraEditors.SimpleButton();
            this.dgvQueryRows = new System.Windows.Forms.DataGridView();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServers)).BeginInit();
            this.gbQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcQuerySrv.Properties)).BeginInit();
            this.gbServers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcConnSrv.Properties)).BeginInit();
            this.gbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvServers
            // 
            this.dgvServers.AllowUserToAddRows = false;
            this.dgvServers.AllowUserToDeleteRows = false;
            this.dgvServers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectServer,
            this.StatusImg,
            this.Title,
            this.Adress,
            this.port,
            this.NameDB,
            this.User,
            this.timeoutServer,
            this.Password});
            this.dgvServers.Location = new System.Drawing.Point(46, 19);
            this.dgvServers.Name = "dgvServers";
            this.dgvServers.Size = new System.Drawing.Size(698, 150);
            this.dgvServers.TabIndex = 0;
            this.dgvServers.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServers_CellEnter);
            // 
            // SelectServer
            // 
            this.SelectServer.HeaderText = "Выбрать";
            this.SelectServer.Name = "SelectServer";
            this.SelectServer.TrueValue = "";
            this.SelectServer.Width = 55;
            // 
            // StatusImg
            // 
            this.StatusImg.HeaderText = "Подключение";
            this.StatusImg.Image = global::CommApp.Properties.Resources.error_16х16;
            this.StatusImg.Name = "StatusImg";
            this.StatusImg.Width = 65;
            // 
            // Title
            // 
            this.Title.HeaderText = "Название";
            this.Title.Name = "Title";
            // 
            // Adress
            // 
            this.Adress.HeaderText = "IP Адрес";
            this.Adress.Name = "Adress";
            // 
            // port
            // 
            this.port.HeaderText = "Порт";
            this.port.Name = "port";
            this.port.Width = 55;
            // 
            // NameDB
            // 
            this.NameDB.HeaderText = "База Данных";
            this.NameDB.Name = "NameDB";
            // 
            // User
            // 
            this.User.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.User.HeaderText = "Пользователь";
            this.User.Name = "User";
            // 
            // timeoutServer
            // 
            this.timeoutServer.HeaderText = "Таймаут";
            this.timeoutServer.Name = "timeoutServer";
            // 
            // Password
            // 
            this.Password.HeaderText = "Пароль";
            this.Password.Name = "Password";
            this.Password.ToolTipText = "Пароль";
            this.Password.Visible = false;
            this.Password.Width = 87;
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.pbcQuerySrv);
            this.gbQuery.Controls.Add(this.sbClear);
            this.gbQuery.Controls.Add(this.sbRun);
            this.gbQuery.Controls.Add(this.lbMessage);
            this.gbQuery.Controls.Add(this.rtbQuery);
            this.gbQuery.Location = new System.Drawing.Point(12, 283);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Size = new System.Drawing.Size(770, 371);
            this.gbQuery.TabIndex = 0;
            this.gbQuery.TabStop = false;
            this.gbQuery.Text = "Запрос";
            // 
            // pbcQuerySrv
            // 
            this.pbcQuerySrv.Location = new System.Drawing.Point(222, 319);
            this.pbcQuerySrv.Name = "pbcQuerySrv";
            this.pbcQuerySrv.Properties.ShowTitle = true;
            this.pbcQuerySrv.Size = new System.Drawing.Size(292, 18);
            this.pbcQuerySrv.TabIndex = 8;
            this.pbcQuerySrv.Visible = false;
            // 
            // sbClear
            // 
            this.sbClear.Image = global::CommApp.Properties.Resources.clear_32x32;
            this.sbClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.sbClear.Location = new System.Drawing.Point(98, 302);
            this.sbClear.Name = "sbClear";
            this.sbClear.Size = new System.Drawing.Size(67, 55);
            this.sbClear.TabIndex = 7;
            this.sbClear.Text = "Очистить";
            this.sbClear.Click += new System.EventHandler(this.sbClear_Click);
            // 
            // sbRun
            // 
            this.sbRun.Image = global::CommApp.Properties.Resources.play_32x32;
            this.sbRun.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.sbRun.Location = new System.Drawing.Point(25, 302);
            this.sbRun.Name = "sbRun";
            this.sbRun.Size = new System.Drawing.Size(67, 55);
            this.sbRun.TabIndex = 6;
            this.sbRun.Text = "Выполнить";
            this.sbRun.Click += new System.EventHandler(this.sbRun_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(219, 340);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(100, 13);
            this.lbMessage.TabIndex = 5;
            this.lbMessage.Text = "Выполнен запрос ";
            this.lbMessage.Visible = false;
            // 
            // rtbQuery
            // 
            this.rtbQuery.Location = new System.Drawing.Point(25, 19);
            this.rtbQuery.Name = "rtbQuery";
            this.rtbQuery.Size = new System.Drawing.Size(719, 275);
            this.rtbQuery.TabIndex = 3;
            this.rtbQuery.Text = resources.GetString("rtbQuery.Text");
            this.rtbQuery.TextChanged += new System.EventHandler(this.rtbQuery_TextChanged);
            // 
            // gbServers
            // 
            this.gbServers.Controls.Add(this.pbcConnSrv);
            this.gbServers.Controls.Add(this.sbDown);
            this.gbServers.Controls.Add(this.sbUp);
            this.gbServers.Controls.Add(this.sbReload);
            this.gbServers.Controls.Add(this.sbUnchAll);
            this.gbServers.Controls.Add(this.sbSelAll);
            this.gbServers.Controls.Add(this.sbDel);
            this.gbServers.Controls.Add(this.sbEdit);
            this.gbServers.Controls.Add(this.btnAdd2);
            this.gbServers.Controls.Add(this.dgvServers);
            this.gbServers.Location = new System.Drawing.Point(12, 12);
            this.gbServers.Name = "gbServers";
            this.gbServers.Size = new System.Drawing.Size(770, 255);
            this.gbServers.TabIndex = 6;
            this.gbServers.TabStop = false;
            this.gbServers.Text = "Список серверов";
            // 
            // pbcConnSrv
            // 
            this.pbcConnSrv.Location = new System.Drawing.Point(538, 175);
            this.pbcConnSrv.Name = "pbcConnSrv";
            this.pbcConnSrv.Properties.ProgressKind = DevExpress.XtraEditors.Controls.ProgressKind.Vertical;
            this.pbcConnSrv.Properties.ShowTitle = true;
            this.pbcConnSrv.Properties.TextOrientation = DevExpress.Utils.Drawing.TextOrientation.Horizontal;
            this.pbcConnSrv.Size = new System.Drawing.Size(33, 59);
            this.pbcConnSrv.TabIndex = 18;
            this.pbcConnSrv.Visible = false;
            // 
            // sbDown
            // 
            this.sbDown.Image = global::CommApp.Properties.Resources.movedown_32x32;
            this.sbDown.Location = new System.Drawing.Point(6, 84);
            this.sbDown.Name = "sbDown";
            this.sbDown.Size = new System.Drawing.Size(38, 59);
            this.sbDown.TabIndex = 17;
            this.sbDown.Click += new System.EventHandler(this.simpleButton2_Click_1);
            // 
            // sbUp
            // 
            this.sbUp.Image = global::CommApp.Properties.Resources.moveup_32x32;
            this.sbUp.Location = new System.Drawing.Point(6, 19);
            this.sbUp.Name = "sbUp";
            this.sbUp.Size = new System.Drawing.Size(37, 59);
            this.sbUp.TabIndex = 16;
            this.sbUp.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // sbReload
            // 
            this.sbReload.Image = global::CommApp.Properties.Resources.refresh_32x32;
            this.sbReload.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.sbReload.Location = new System.Drawing.Point(455, 175);
            this.sbReload.Name = "sbReload";
            this.sbReload.Size = new System.Drawing.Size(77, 59);
            this.sbReload.TabIndex = 15;
            this.sbReload.Text = "Обновить все";
            this.sbReload.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // sbUnchAll
            // 
            this.sbUnchAll.Image = ((System.Drawing.Image)(resources.GetObject("sbUnchAll.Image")));
            this.sbUnchAll.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.sbUnchAll.Location = new System.Drawing.Point(373, 175);
            this.sbUnchAll.Name = "sbUnchAll";
            this.sbUnchAll.Size = new System.Drawing.Size(75, 59);
            this.sbUnchAll.TabIndex = 14;
            this.sbUnchAll.Text = " Снять все";
            this.sbUnchAll.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // sbSelAll
            // 
            this.sbSelAll.Image = ((System.Drawing.Image)(resources.GetObject("sbSelAll.Image")));
            this.sbSelAll.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.sbSelAll.Location = new System.Drawing.Point(292, 175);
            this.sbSelAll.Name = "sbSelAll";
            this.sbSelAll.Size = new System.Drawing.Size(75, 59);
            this.sbSelAll.TabIndex = 13;
            this.sbSelAll.Text = "Выбрать все";
            this.sbSelAll.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // sbDel
            // 
            this.sbDel.Image = ((System.Drawing.Image)(resources.GetObject("sbDel.Image")));
            this.sbDel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.sbDel.Location = new System.Drawing.Point(210, 175);
            this.sbDel.Name = "sbDel";
            this.sbDel.Size = new System.Drawing.Size(75, 59);
            this.sbDel.TabIndex = 12;
            this.sbDel.Text = "Удалить";
            this.sbDel.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // sbEdit
            // 
            this.sbEdit.Image = ((System.Drawing.Image)(resources.GetObject("sbEdit.Image")));
            this.sbEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.sbEdit.Location = new System.Drawing.Point(128, 175);
            this.sbEdit.Name = "sbEdit";
            this.sbEdit.Size = new System.Drawing.Size(75, 59);
            this.sbEdit.TabIndex = 11;
            this.sbEdit.Text = "Изменить";
            this.sbEdit.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd2.Image")));
            this.btnAdd2.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnAdd2.Location = new System.Drawing.Point(46, 175);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(75, 59);
            this.btnAdd2.TabIndex = 10;
            this.btnAdd2.Text = "Добавить";
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.sbExportExel);
            this.gbResults.Controls.Add(this.dgvQueryRows);
            this.gbResults.Controls.Add(this.dgvResults);
            this.gbResults.Location = new System.Drawing.Point(798, 12);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(757, 642);
            this.gbResults.TabIndex = 7;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Результаты выполнения запроса";
            // 
            // sbExportExel
            // 
            this.sbExportExel.Enabled = false;
            this.sbExportExel.Image = global::CommApp.Properties.Resources.gridcolumnheader_32x32;
            this.sbExportExel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.sbExportExel.Location = new System.Drawing.Point(22, 581);
            this.sbExportExel.Name = "sbExportExel";
            this.sbExportExel.Size = new System.Drawing.Size(100, 55);
            this.sbExportExel.TabIndex = 2;
            this.sbExportExel.Text = "Экспорт в Exel ...";
            this.sbExportExel.Click += new System.EventHandler(this.sbExportExel_Click);
            // 
            // dgvQueryRows
            // 
            this.dgvQueryRows.AllowUserToAddRows = false;
            this.dgvQueryRows.AllowUserToDeleteRows = false;
            this.dgvQueryRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryRows.Location = new System.Drawing.Point(22, 220);
            this.dgvQueryRows.Name = "dgvQueryRows";
            this.dgvQueryRows.ReadOnly = true;
            this.dgvQueryRows.Size = new System.Drawing.Size(714, 356);
            this.dgvQueryRows.TabIndex = 1;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(22, 19);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(714, 179);
            this.dgvResults.TabIndex = 0;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Состояние";
            this.dataGridViewImageColumn1.Image = global::CommApp.Properties.Resources.error_16х16;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 65;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1567, 666);
            this.Controls.Add(this.gbResults);
            this.Controls.Add(this.gbServers);
            this.Controls.Add(this.gbQuery);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Коммуникационники";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServers)).EndInit();
            this.gbQuery.ResumeLayout(false);
            this.gbQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcQuerySrv.Properties)).EndInit();
            this.gbServers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbcConnSrv.Properties)).EndInit();
            this.gbResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        private void SelectServer_Disposed(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServers;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.GroupBox gbServers;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.RichTextBox rtbQuery;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.DataGridView dgvQueryRows;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private DevExpress.XtraEditors.SimpleButton sbEdit;
        private DevExpress.XtraEditors.SimpleButton sbDel;
        private DevExpress.XtraEditors.SimpleButton sbSelAll;
        private DevExpress.XtraEditors.SimpleButton sbUnchAll;
        private DevExpress.XtraEditors.SimpleButton sbReload;
        private DevExpress.XtraEditors.SimpleButton sbUp;
        private DevExpress.XtraEditors.SimpleButton sbDown;
        private DevExpress.XtraEditors.SimpleButton sbExportExel;
        private DevExpress.XtraEditors.SimpleButton sbRun;
        private DevExpress.XtraEditors.SimpleButton sbClear;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectServer;
        private System.Windows.Forms.DataGridViewImageColumn StatusImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adress;
        private System.Windows.Forms.DataGridViewTextBoxColumn port;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeoutServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private DevExpress.XtraEditors.ProgressBarControl pbcConnSrv;
        private DevExpress.XtraEditors.ProgressBarControl pbcQuerySrv;
    }
}

