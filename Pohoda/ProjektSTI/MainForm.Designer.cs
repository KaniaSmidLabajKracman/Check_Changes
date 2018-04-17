namespace ProjektSTI
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.RefreshButton = new System.Windows.Forms.Button();
            this.UkazatelCasu = new System.Windows.Forms.Label();
            this.Kontrolka = new System.Windows.Forms.PictureBox();
            this.GrafButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.TabulkaCommitu = new System.Windows.Forms.DataGridView();
            this.UlozitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.pocetRadku = new System.Windows.Forms.Label();
            this.pocetCommitu = new System.Windows.Forms.Label();
            this.casCommitu = new System.Windows.Forms.Label();
            this.nazev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Kontrolka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabulkaCommitu)).BeginInit();
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Enabled = false;
            this.RefreshButton.Location = new System.Drawing.Point(471, 432);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(52, 23);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // UkazatelCasu
            // 
            this.UkazatelCasu.AutoSize = true;
            this.UkazatelCasu.Location = new System.Drawing.Point(22, 437);
            this.UkazatelCasu.Name = "UkazatelCasu";
            this.UkazatelCasu.Size = new System.Drawing.Size(148, 13);
            this.UkazatelCasu.TabIndex = 4;
            this.UkazatelCasu.Text = "Další kontrola za: 0h 00m 00s";
            this.UkazatelCasu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Kontrolka
            // 
            this.Kontrolka.BackColor = System.Drawing.Color.Red;
            this.Kontrolka.Location = new System.Drawing.Point(-4, 477);
            this.Kontrolka.Name = "Kontrolka";
            this.Kontrolka.Size = new System.Drawing.Size(702, 10);
            this.Kontrolka.TabIndex = 7;
            this.Kontrolka.TabStop = false;
            // 
            // GrafButton
            // 
            this.GrafButton.Enabled = false;
            this.GrafButton.Location = new System.Drawing.Point(228, 432);
            this.GrafButton.Name = "GrafButton";
            this.GrafButton.Size = new System.Drawing.Size(75, 23);
            this.GrafButton.TabIndex = 8;
            this.GrafButton.Text = "Graf";
            this.GrafButton.UseVisualStyleBackColor = true;
            this.GrafButton.Click += new System.EventHandler(this.GrafButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Enabled = false;
            this.ExportButton.Location = new System.Drawing.Point(390, 432);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 12;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // TabulkaCommitu
            // 
            this.TabulkaCommitu.AllowUserToAddRows = false;
            this.TabulkaCommitu.AllowUserToDeleteRows = false;
            this.TabulkaCommitu.AllowUserToResizeRows = false;
            this.TabulkaCommitu.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TabulkaCommitu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TabulkaCommitu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nazev,
            this.datum,
            this.count,
            this.sha});
            this.TabulkaCommitu.Location = new System.Drawing.Point(12, 57);
            this.TabulkaCommitu.MultiSelect = false;
            this.TabulkaCommitu.Name = "TabulkaCommitu";
            this.TabulkaCommitu.ReadOnly = true;
            this.TabulkaCommitu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TabulkaCommitu.Size = new System.Drawing.Size(661, 369);
            this.TabulkaCommitu.TabIndex = 13;
            this.TabulkaCommitu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TabulkaCommitu_CellContentClick);
            this.TabulkaCommitu.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.TabulkaCommitu.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.TabulkaCommitu.SelectionChanged += new System.EventHandler(this.TabulkaCommitu_SelectionChanged);
            // 
            // UlozitButton
            // 
            this.UlozitButton.Enabled = false;
            this.UlozitButton.Location = new System.Drawing.Point(309, 432);
            this.UlozitButton.Name = "UlozitButton";
            this.UlozitButton.Size = new System.Drawing.Size(75, 23);
            this.UlozitButton.TabIndex = 14;
            this.UlozitButton.Text = "Uložit";
            this.UlozitButton.UseVisualStyleBackColor = true;
            this.UlozitButton.Click += new System.EventHandler(this.UlozitButon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 15;
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(337, 28);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(10, 13);
            this.info.TabIndex = 16;
            this.info.Text = ".";
            // 
            // pocetRadku
            // 
            this.pocetRadku.AutoSize = true;
            this.pocetRadku.Location = new System.Drawing.Point(12, 41);
            this.pocetRadku.Name = "pocetRadku";
            this.pocetRadku.Size = new System.Drawing.Size(109, 13);
            this.pocetRadku.TabIndex = 17;
            this.pocetRadku.Text = "Celkový počet řádků:";
            // 
            // pocetCommitu
            // 
            this.pocetCommitu.AutoSize = true;
            this.pocetCommitu.Location = new System.Drawing.Point(12, 28);
            this.pocetCommitu.Name = "pocetCommitu";
            this.pocetCommitu.Size = new System.Drawing.Size(120, 13);
            this.pocetCommitu.TabIndex = 18;
            this.pocetCommitu.Text = "Celkový počet commitů:";
            // 
            // casCommitu
            // 
            this.casCommitu.AutoSize = true;
            this.casCommitu.Location = new System.Drawing.Point(13, 9);
            this.casCommitu.Name = "casCommitu";
            this.casCommitu.Size = new System.Drawing.Size(123, 13);
            this.casCommitu.TabIndex = 19;
            this.casCommitu.Text = "Čas posledního commitu";
            // 
            // nazev
            // 
            this.nazev.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nazev.HeaderText = "Název souboru";
            this.nazev.Name = "nazev";
            this.nazev.ReadOnly = true;
            this.nazev.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nazev.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // datum
            // 
            this.datum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datum.HeaderText = "Datum";
            this.datum.Name = "datum";
            this.datum.ReadOnly = true;
            this.datum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.datum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // count
            // 
            this.count.HeaderText = "Počet řádků";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // sha
            // 
            this.sha.HeaderText = "SHA";
            this.sha.Name = "sha";
            this.sha.ReadOnly = true;
            this.sha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sha.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(683, 483);
            this.Controls.Add(this.casCommitu);
            this.Controls.Add(this.pocetCommitu);
            this.Controls.Add(this.pocetRadku);
            this.Controls.Add(this.info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UlozitButton);
            this.Controls.Add(this.TabulkaCommitu);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.GrafButton);
            this.Controls.Add(this.Kontrolka);
            this.Controls.Add(this.UkazatelCasu);
            this.Controls.Add(this.RefreshButton);
            this.Name = "MainForm";
            this.Text = "Projekt STI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Kontrolka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabulkaCommitu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Label UkazatelCasu;
        private System.Windows.Forms.PictureBox Kontrolka;
        private System.Windows.Forms.Button GrafButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.DataGridView TabulkaCommitu;
        private System.Windows.Forms.Button UlozitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Label pocetRadku;
        private System.Windows.Forms.Label pocetCommitu;
        private System.Windows.Forms.Label casCommitu;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazev;
        private System.Windows.Forms.DataGridViewTextBoxColumn datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn sha;
    }
}

