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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelit = new System.Windows.Forms.Button();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.pbExequteQuery = new System.Windows.Forms.ProgressBar();
            this.rtbQuery = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.gbServers = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.btReload = new System.Windows.Forms.Button();
            this.btClearAll = new System.Windows.Forms.Button();
            this.btSelAll = new System.Windows.Forms.Button();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lbMessage = new System.Windows.Forms.Label();
            this.dgvQueryRows = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServers)).BeginInit();
            this.gbQuery.SuspendLayout();
            this.gbServers.SuspendLayout();
            this.gbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryRows)).BeginInit();
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
            this.StatusImg.HeaderText = "Состояние";
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(46, 175);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(127, 175);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelit
            // 
            this.btnDelit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelit.Location = new System.Drawing.Point(208, 175);
            this.btnDelit.Name = "btnDelit";
            this.btnDelit.Size = new System.Drawing.Size(75, 23);
            this.btnDelit.TabIndex = 4;
            this.btnDelit.Text = "Удалить";
            this.btnDelit.UseVisualStyleBackColor = true;
            this.btnDelit.Click += new System.EventHandler(this.btnDelit_Click);
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.lbMessage);
            this.gbQuery.Controls.Add(this.pbExequteQuery);
            this.gbQuery.Controls.Add(this.rtbQuery);
            this.gbQuery.Controls.Add(this.btnClear);
            this.gbQuery.Controls.Add(this.btnRun);
            this.gbQuery.Location = new System.Drawing.Point(12, 250);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Size = new System.Drawing.Size(770, 371);
            this.gbQuery.TabIndex = 0;
            this.gbQuery.TabStop = false;
            this.gbQuery.Text = "Запрос";
            // 
            // pbExequteQuery
            // 
            this.pbExequteQuery.Location = new System.Drawing.Point(253, 310);
            this.pbExequteQuery.Name = "pbExequteQuery";
            this.pbExequteQuery.Size = new System.Drawing.Size(292, 23);
            this.pbExequteQuery.TabIndex = 4;
            this.pbExequteQuery.Visible = false;
            // 
            // rtbQuery
            // 
            this.rtbQuery.Location = new System.Drawing.Point(25, 30);
            this.rtbQuery.Name = "rtbQuery";
            this.rtbQuery.Size = new System.Drawing.Size(719, 275);
            this.rtbQuery.TabIndex = 3;
            this.rtbQuery.Text = resources.GetString("rtbQuery.Text");
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(106, 311);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(25, 311);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Выполнить";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // gbServers
            // 
            this.gbServers.Controls.Add(this.button1);
            this.gbServers.Controls.Add(this.btUp);
            this.gbServers.Controls.Add(this.btReload);
            this.gbServers.Controls.Add(this.btClearAll);
            this.gbServers.Controls.Add(this.btSelAll);
            this.gbServers.Controls.Add(this.dgvServers);
            this.gbServers.Controls.Add(this.btnAdd);
            this.gbServers.Controls.Add(this.btnDelit);
            this.gbServers.Controls.Add(this.btnEdit);
            this.gbServers.Location = new System.Drawing.Point(12, 12);
            this.gbServers.Name = "gbServers";
            this.gbServers.Size = new System.Drawing.Size(770, 218);
            this.gbServers.TabIndex = 6;
            this.gbServers.TabStop = false;
            this.gbServers.Text = "Серверы";
            // 
            // button1
            // 
            this.button1.Image = global::CommApp.Properties.Resources.arroyDown_16x16;
            this.button1.Location = new System.Drawing.Point(7, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btUp
            // 
            this.btUp.Image = global::CommApp.Properties.Resources.arroyUp_16x16;
            this.btUp.Location = new System.Drawing.Point(7, 53);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(33, 23);
            this.btUp.TabIndex = 8;
            this.btUp.UseVisualStyleBackColor = true;
            // 
            // btReload
            // 
            this.btReload.Cursor = System.Windows.Forms.Cursors.Default;
            this.btReload.Location = new System.Drawing.Point(461, 175);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(120, 23);
            this.btReload.TabIndex = 7;
            this.btReload.Text = "Обновить состояние";
            this.btReload.UseVisualStyleBackColor = true;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // btClearAll
            // 
            this.btClearAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.btClearAll.Location = new System.Drawing.Point(375, 175);
            this.btClearAll.Name = "btClearAll";
            this.btClearAll.Size = new System.Drawing.Size(80, 23);
            this.btClearAll.TabIndex = 6;
            this.btClearAll.Text = "Снять все";
            this.btClearAll.UseVisualStyleBackColor = true;
            this.btClearAll.Click += new System.EventHandler(this.btClearAll_Click);
            // 
            // btSelAll
            // 
            this.btSelAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.btSelAll.Location = new System.Drawing.Point(289, 175);
            this.btSelAll.Name = "btSelAll";
            this.btSelAll.Size = new System.Drawing.Size(80, 23);
            this.btSelAll.TabIndex = 5;
            this.btSelAll.Text = "Выбрать все";
            this.btSelAll.UseVisualStyleBackColor = true;
            this.btSelAll.Click += new System.EventHandler(this.btSelAll_Click);
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.dgvQueryRows);
            this.gbResults.Controls.Add(this.dgvResults);
            this.gbResults.Location = new System.Drawing.Point(798, 12);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(757, 642);
            this.gbResults.TabIndex = 7;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Результаты выполнения запроса";
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(22, 19);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(714, 255);
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
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(253, 340);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(195, 13);
            this.lbMessage.TabIndex = 5;
            this.lbMessage.Text = "Выполнен запрос на 3 серверах из 5";
            this.lbMessage.Visible = false;
            // 
            // dgvQueryRows
            // 
            this.dgvQueryRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryRows.Location = new System.Drawing.Point(22, 306);
            this.dgvQueryRows.Name = "dgvQueryRows";
            this.dgvQueryRows.Size = new System.Drawing.Size(714, 303);
            this.dgvQueryRows.TabIndex = 1;
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
            this.gbServers.ResumeLayout(false);
            this.gbResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryRows)).EndInit();
            this.ResumeLayout(false);

        }

        private void SelectServer_Disposed(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServers;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelit;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox gbServers;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.RichTextBox rtbQuery;
        private System.Windows.Forms.Button btReload;
        private System.Windows.Forms.Button btClearAll;
        private System.Windows.Forms.Button btSelAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectServer;
        private System.Windows.Forms.DataGridViewImageColumn StatusImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adress;
        private System.Windows.Forms.DataGridViewTextBoxColumn port;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeoutServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.ProgressBar pbExequteQuery;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.DataGridView dgvQueryRows;
    }
}

