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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RefreshButton = new System.Windows.Forms.Button();
            this.UkazatelCasu = new System.Windows.Forms.Label();
            this.Kontrolka = new System.Windows.Forms.PictureBox();
            this.GrafButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.TabulkaCommitu = new System.Windows.Forms.DataGridView();
            this.UlozitButton = new System.Windows.Forms.Button();
            this.notifikace = new System.Windows.Forms.Label();
            this.posledniRefresh = new System.Windows.Forms.Label();
            this.noveSoubory = new System.Windows.Forms.Label();
            this.pocetRadku = new System.Windows.Forms.Label();
            this.nazev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Kontrolka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabulkaCommitu)).BeginInit();
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Enabled = false;
            this.RefreshButton.Location = new System.Drawing.Point(575, 449);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(102, 22);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "Aktualizace";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // UkazatelCasu
            // 
            this.UkazatelCasu.AutoSize = true;
            this.UkazatelCasu.Location = new System.Drawing.Point(60, 453);
            this.UkazatelCasu.Name = "UkazatelCasu";
            this.UkazatelCasu.Size = new System.Drawing.Size(62, 13);
            this.UkazatelCasu.TabIndex = 4;
            this.UkazatelCasu.Text = "0h 00m 00s";
            this.UkazatelCasu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Kontrolka
            // 
            this.Kontrolka.BackColor = System.Drawing.Color.Red;
            this.Kontrolka.Location = new System.Drawing.Point(-40, 477);
            this.Kontrolka.Name = "Kontrolka";
            this.Kontrolka.Size = new System.Drawing.Size(1034, 14);
            this.Kontrolka.TabIndex = 7;
            this.Kontrolka.TabStop = false;
            // 
            // GrafButton
            // 
            this.GrafButton.Enabled = false;
            this.GrafButton.Location = new System.Drawing.Point(273, 448);
            this.GrafButton.Name = "GrafButton";
            this.GrafButton.Size = new System.Drawing.Size(75, 23);
            this.GrafButton.TabIndex = 8;
            this.GrafButton.Text = "Vytvoř graf";
            this.GrafButton.UseVisualStyleBackColor = true;
            this.GrafButton.Click += new System.EventHandler(this.GrafButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Enabled = false;
            this.ExportButton.Location = new System.Drawing.Point(449, 448);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(110, 23);
            this.ExportButton.TabIndex = 12;
            this.ExportButton.Text = "Exportuj změny";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // TabulkaCommitu
            // 
            this.TabulkaCommitu.AllowUserToAddRows = false;
            this.TabulkaCommitu.AllowUserToDeleteRows = false;
            this.TabulkaCommitu.AllowUserToResizeRows = false;
            this.TabulkaCommitu.BackgroundColor = System.Drawing.Color.Gray;
            this.TabulkaCommitu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TabulkaCommitu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nazev,
            this.deleted,
            this.datum,
            this.sha});
            this.TabulkaCommitu.Location = new System.Drawing.Point(-2, 57);
            this.TabulkaCommitu.MultiSelect = false;
            this.TabulkaCommitu.Name = "TabulkaCommitu";
            this.TabulkaCommitu.ReadOnly = true;
            this.TabulkaCommitu.RowHeadersVisible = false;
            this.TabulkaCommitu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TabulkaCommitu.Size = new System.Drawing.Size(982, 386);
            this.TabulkaCommitu.TabIndex = 13;
            this.TabulkaCommitu.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.TabulkaCommitu.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.TabulkaCommitu.SelectionChanged += new System.EventHandler(this.TabulkaCommitu_SelectionChanged);
            // 
            // UlozitButton
            // 
            this.UlozitButton.Enabled = false;
            this.UlozitButton.Location = new System.Drawing.Point(354, 448);
            this.UlozitButton.Name = "UlozitButton";
            this.UlozitButton.Size = new System.Drawing.Size(89, 23);
            this.UlozitButton.TabIndex = 14;
            this.UlozitButton.Text = "Uložit soubor";
            this.UlozitButton.UseVisualStyleBackColor = true;
            this.UlozitButton.Click += new System.EventHandler(this.UlozitButon_Click);
            // 
            // notifikace
            // 
            this.notifikace.AutoSize = true;
            this.notifikace.Location = new System.Drawing.Point(377, 25);
            this.notifikace.Name = "notifikace";
            this.notifikace.Size = new System.Drawing.Size(53, 13);
            this.notifikace.TabIndex = 15;
            this.notifikace.Text = "notifikace";
            // 
            // posledniRefresh
            // 
            this.posledniRefresh.AutoSize = true;
            this.posledniRefresh.Location = new System.Drawing.Point(12, 9);
            this.posledniRefresh.Name = "posledniRefresh";
            this.posledniRefresh.Size = new System.Drawing.Size(10, 13);
            this.posledniRefresh.TabIndex = 16;
            this.posledniRefresh.Text = ".";
            // 
            // noveSoubory
            // 
            this.noveSoubory.AutoSize = true;
            this.noveSoubory.Location = new System.Drawing.Point(12, 24);
            this.noveSoubory.Name = "noveSoubory";
            this.noveSoubory.Size = new System.Drawing.Size(76, 13);
            this.noveSoubory.TabIndex = 17;
            this.noveSoubory.Text = "Nové soubory:";
            // 
            // pocetRadku
            // 
            this.pocetRadku.AutoSize = true;
            this.pocetRadku.Location = new System.Drawing.Point(12, 41);
            this.pocetRadku.Name = "pocetRadku";
            this.pocetRadku.Size = new System.Drawing.Size(68, 13);
            this.pocetRadku.TabIndex = 18;
            this.pocetRadku.Text = "Počty řádků:";
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
            // deleted
            // 
            this.deleted.HeaderText = "smazáno?";
            this.deleted.Name = "deleted";
            this.deleted.ReadOnly = true;
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
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(978, 483);
            this.Controls.Add(this.pocetRadku);
            this.Controls.Add(this.noveSoubory);
            this.Controls.Add(this.posledniRefresh);
            this.Controls.Add(this.notifikace);
            this.Controls.Add(this.UlozitButton);
            this.Controls.Add(this.TabulkaCommitu);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.GrafButton);
            this.Controls.Add(this.Kontrolka);
            this.Controls.Add(this.UkazatelCasu);
            this.Controls.Add(this.RefreshButton);
            this.Name = "MainForm";
            this.Text = "Checker";
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
        private System.Windows.Forms.Label notifikace;
        private System.Windows.Forms.Label posledniRefresh;
        private System.Windows.Forms.Label noveSoubory;
        private System.Windows.Forms.Label pocetRadku;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazev;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn sha;
    }
}

