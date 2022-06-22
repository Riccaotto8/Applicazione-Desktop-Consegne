namespace ServizioConsegne
{
    partial class Menu
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
            this.button1 = new System.Windows.Forms.Button();
            this.home = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prodottoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomeProdottoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoProdottoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImmagineProdotto = new System.Windows.Forms.DataGridViewImageColumn();
            this.Aggiungi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.assistenza);
            this.panel1.Controls.Add(this.carrello);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.home);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 568);
            this.panel1.TabIndex = 0;
            // 
            // assistenza
            // 
            this.assistenza.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.assistenza.FlatAppearance.BorderSize = 0;
            this.assistenza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assistenza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assistenza.ForeColor = System.Drawing.Color.White;
            this.assistenza.Location = new System.Drawing.Point(0, 375);
            this.assistenza.Name = "assistenza";
            this.assistenza.Size = new System.Drawing.Size(163, 48);
            this.assistenza.TabIndex = 4;
            this.assistenza.Text = "Assistenza";
            this.assistenza.UseVisualStyleBackColor = true;
            this.assistenza.Click += new System.EventHandler(this.Assistance_Click);
            // 
            // carrello
            // 
            this.carrello.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.carrello.FlatAppearance.BorderSize = 0;
            this.carrello.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.carrello.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carrello.ForeColor = System.Drawing.Color.White;
            this.carrello.Location = new System.Drawing.Point(0, 281);
            this.carrello.Name = "carrello";
            this.carrello.Size = new System.Drawing.Size(163, 48);
            this.carrello.TabIndex = 3;
            this.carrello.Text = "Carrello";
            this.carrello.UseVisualStyleBackColor = true;
            this.carrello.Click += new System.EventHandler(this.Cart_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // home
            // 
            this.home.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.home.FlatAppearance.BorderSize = 0;
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home.ForeColor = System.Drawing.Color.White;
            this.home.Location = new System.Drawing.Point(0, 81);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(163, 48);
            this.home.TabIndex = 1;
            this.home.Text = "Home";
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.Home_Click);
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
            this.ImmagineProdotto,
            this.Aggiungi});
            this.dataGridView1.DataSource = this.prodottoBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(163, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(843, 568);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(163, 468);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(843, 100);
            this.panel2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(164, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(82, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantità";
            // 
            // prodottoBindingSource
            // 
            this.prodottoBindingSource.DataSource = typeof(ServizioConsegne.Prodotto);
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
            // ImmagineProdotto
            // 
            this.ImmagineProdotto.DataPropertyName = "ImmagineProdotto";
            this.ImmagineProdotto.HeaderText = "ImmagineProdotto";
            this.ImmagineProdotto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ImmagineProdotto.Name = "ImmagineProdotto";
            this.ImmagineProdotto.ReadOnly = true;
            // 
            // Aggiungi
            // 
            this.Aggiungi.HeaderText = "Aggiungi";
            this.Aggiungi.Name = "Aggiungi";
            this.Aggiungi.ReadOnly = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 568);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button home;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button carrello;
        private System.Windows.Forms.Button assistenza;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource prodottoBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProdottoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoProdottoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn ImmagineProdotto;
        private System.Windows.Forms.DataGridViewButtonColumn Aggiungi;
    }
}