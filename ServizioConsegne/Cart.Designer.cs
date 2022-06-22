namespace ServizioConsegne
{
    partial class Cart
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.assistenza = new System.Windows.Forms.Button();
            this.carrello = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Button();
            this.home = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ImmagineProdotto = new System.Windows.Forms.DataGridViewImageColumn();
            this.nomeProdottoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoProdottoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodottoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.assistenza);
            this.panel1.Controls.Add(this.carrello);
            this.panel1.Controls.Add(this.menu);
            this.panel1.Controls.Add(this.home);
            this.panel1.Controls.Add(this.Login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 568);
            this.panel1.TabIndex = 0;
            // 
            // assistenza
            // 
            this.assistenza.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.assistenza.FlatAppearance.BorderSize = 0;
            this.assistenza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assistenza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assistenza.ForeColor = System.Drawing.Color.White;
            this.assistenza.Location = new System.Drawing.Point(0, 398);
            this.assistenza.Name = "assistenza";
            this.assistenza.Size = new System.Drawing.Size(163, 48);
            this.assistenza.TabIndex = 4;
            this.assistenza.Text = "Assistenza";
            this.assistenza.UseVisualStyleBackColor = true;
            this.assistenza.Click += new System.EventHandler(this.Assistenza_Click);
            // 
            // carrello
            // 
            this.carrello.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.carrello.FlatAppearance.BorderSize = 0;
            this.carrello.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.carrello.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carrello.ForeColor = System.Drawing.Color.White;
            this.carrello.Location = new System.Drawing.Point(0, 296);
            this.carrello.Name = "carrello";
            this.carrello.Size = new System.Drawing.Size(163, 48);
            this.carrello.TabIndex = 3;
            this.carrello.Text = "Carrello";
            this.carrello.UseVisualStyleBackColor = true;
            this.carrello.Click += new System.EventHandler(this.Cart_Click);
            // 
            // menu
            // 
            this.menu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.menu.FlatAppearance.BorderSize = 0;
            this.menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.ForeColor = System.Drawing.Color.White;
            this.menu.Location = new System.Drawing.Point(0, 207);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(163, 48);
            this.menu.TabIndex = 2;
            this.menu.Text = "Menu";
            this.menu.UseVisualStyleBackColor = true;
            this.menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // home
            // 
            this.home.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.home.FlatAppearance.BorderSize = 0;
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home.ForeColor = System.Drawing.Color.White;
            this.home.Location = new System.Drawing.Point(0, 126);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(163, 48);
            this.home.TabIndex = 1;
            this.home.Text = "Home";
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(40, 26);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Log_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(157, 439);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(849, 129);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Importo Totale";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(151, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeProdottoDataGridViewTextBoxColumn,
            this.prezzoProdottoDataGridViewTextBoxColumn,
            this.ImmagineProdotto});
            this.dataGridView1.DataSource = this.prodottoBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(157, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(849, 439);
            this.dataGridView1.TabIndex = 2;
            // 
            // ImmagineProdotto
            // 
            this.ImmagineProdotto.DataPropertyName = "ImmagineProdotto";
            this.ImmagineProdotto.HeaderText = "ImmagineProdotto";
            this.ImmagineProdotto.Name = "ImmagineProdotto";
            this.ImmagineProdotto.ReadOnly = true;
            // 
            // nomeProdottoDataGridViewTextBoxColumn
            // 
            this.nomeProdottoDataGridViewTextBoxColumn.DataPropertyName = "NomeProdotto";
            this.nomeProdottoDataGridViewTextBoxColumn.HeaderText = "NomeProdotto";
            this.nomeProdottoDataGridViewTextBoxColumn.Name = "nomeProdottoDataGridViewTextBoxColumn";
            this.nomeProdottoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prezzoProdottoDataGridViewTextBoxColumn
            // 
            this.prezzoProdottoDataGridViewTextBoxColumn.DataPropertyName = "PrezzoProdotto";
            this.prezzoProdottoDataGridViewTextBoxColumn.HeaderText = "PrezzoProdotto";
            this.prezzoProdottoDataGridViewTextBoxColumn.Name = "prezzoProdottoDataGridViewTextBoxColumn";
            this.prezzoProdottoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prodottoBindingSource
            // 
            this.prodottoBindingSource.DataSource = typeof(ServizioConsegne.Prodotto);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(326, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Elimina dal carrello";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 568);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Cart";
            this.Text = "Cart";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button home;
        private System.Windows.Forms.Button menu;
        private System.Windows.Forms.Button carrello;
        private System.Windows.Forms.Button assistenza;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProdottoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoProdottoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource prodottoBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn ImmagineProdotto;
        private System.Windows.Forms.Button button1;
    }
}