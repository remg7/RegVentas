namespace RegVentas
{
    partial class FrmReportes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabReportes = new System.Windows.Forms.TabControl();
            this.tpVentasFecha = new System.Windows.Forms.TabPage();
            this.dgvReporte1 = new System.Windows.Forms.DataGridView();
            this.btnCargarReporte1 = new System.Windows.Forms.Button();
            this.lblAgrupado = new System.Windows.Forms.Label();
            this.cmbAgrupado = new System.Windows.Forms.ComboBox();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.tpInventarioCritico = new System.Windows.Forms.TabPage();
            this.lblExplicacionCritico = new System.Windows.Forms.Label();
            this.btnRefrescarInventario = new System.Windows.Forms.Button();
            this.dgvReporte2 = new System.Windows.Forms.DataGridView();
            this.tpHistorial = new System.Windows.Forms.TabPage();
            this.dgvReporte3 = new System.Windows.Forms.DataGridView();
            this.btnCargarReporte3 = new System.Windows.Forms.Button();
            this.lblFiltroValor = new System.Windows.Forms.Label();
            this.cmbFiltroValor = new System.Windows.Forms.ComboBox();
            this.lblFiltroTipo = new System.Windows.Forms.Label();
            this.cmbFiltroTipo = new System.Windows.Forms.ComboBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tabReportes.SuspendLayout();
            this.tpVentasFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte1)).BeginInit();
            this.tpInventarioCritico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte2)).BeginInit();
            this.tpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabReportes
            // 
            this.tabReportes.Controls.Add(this.tpVentasFecha);
            this.tabReportes.Controls.Add(this.tpInventarioCritico);
            this.tabReportes.Controls.Add(this.tpHistorial);
            this.tabReportes.Location = new System.Drawing.Point(12, 12);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.SelectedIndex = 0;
            this.tabReportes.Size = new System.Drawing.Size(860, 430);
            this.tabReportes.TabIndex = 0;
            // 
            // tpVentasFecha
            // 
            this.tpVentasFecha.Controls.Add(this.dgvReporte1);
            this.tpVentasFecha.Controls.Add(this.btnCargarReporte1);
            this.tpVentasFecha.Controls.Add(this.lblAgrupado);
            this.tpVentasFecha.Controls.Add(this.cmbAgrupado);
            this.tpVentasFecha.Controls.Add(this.lblHasta);
            this.tpVentasFecha.Controls.Add(this.dtpHasta);
            this.tpVentasFecha.Controls.Add(this.lblDesde);
            this.tpVentasFecha.Controls.Add(this.dtpDesde);
            this.tpVentasFecha.Location = new System.Drawing.Point(4, 22);
            this.tpVentasFecha.Name = "tpVentasFecha";
            this.tpVentasFecha.Padding = new System.Windows.Forms.Padding(3);
            this.tpVentasFecha.Size = new System.Drawing.Size(852, 404);
            this.tpVentasFecha.TabIndex = 0;
            this.tpVentasFecha.Text = "Reporte 1: Ventas por Fechas";
            this.tpVentasFecha.UseVisualStyleBackColor = true;
            // 
            // dgvReporte1
            // 
            this.dgvReporte1.AllowUserToAddRows = false;
            this.dgvReporte1.AllowUserToDeleteRows = false;
            this.dgvReporte1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte1.Location = new System.Drawing.Point(15, 60);
            this.dgvReporte1.Name = "dgvReporte1";
            this.dgvReporte1.ReadOnly = true;
            this.dgvReporte1.RowHeadersVisible = false;
            this.dgvReporte1.Size = new System.Drawing.Size(820, 325);
            this.dgvReporte1.TabIndex = 7;
            // 
            // btnCargarReporte1
            // 
            this.btnCargarReporte1.Location = new System.Drawing.Point(705, 13);
            this.btnCargarReporte1.Name = "btnCargarReporte1";
            this.btnCargarReporte1.Size = new System.Drawing.Size(130, 25);
            this.btnCargarReporte1.TabIndex = 6;
            this.btnCargarReporte1.Text = "Generar Reporte";
            this.btnCargarReporte1.UseVisualStyleBackColor = true;
            this.btnCargarReporte1.Click += new System.EventHandler(this.btnCargarReporte1_Click);
            // 
            // lblAgrupado
            // 
            this.lblAgrupado.AutoSize = true;
            this.lblAgrupado.Location = new System.Drawing.Point(440, 18);
            this.lblAgrupado.Name = "lblAgrupado";
            this.lblAgrupado.Size = new System.Drawing.Size(72, 13);
            this.lblAgrupado.TabIndex = 5;
            this.lblAgrupado.Text = "Agrupado por:";
            // 
            // cmbAgrupado
            // 
            this.cmbAgrupado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgrupado.FormattingEnabled = true;
            this.cmbAgrupado.Items.AddRange(new object[] {
            "Diario",
            "Mensual"});
            this.cmbAgrupado.Location = new System.Drawing.Point(520, 15);
            this.cmbAgrupado.Name = "cmbAgrupado";
            this.cmbAgrupado.Size = new System.Drawing.Size(140, 21);
            this.cmbAgrupado.TabIndex = 4;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(230, 18);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(280, 15);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(15, 18);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 1;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(70, 15);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 20);
            this.dtpDesde.TabIndex = 0;
            // 
            // tpInventarioCritico
            // 
            this.tpInventarioCritico.Controls.Add(this.lblExplicacionCritico);
            this.tpInventarioCritico.Controls.Add(this.btnRefrescarInventario);
            this.tpInventarioCritico.Controls.Add(this.dgvReporte2);
            this.tpInventarioCritico.Location = new System.Drawing.Point(4, 22);
            this.tpInventarioCritico.Name = "tpInventarioCritico";
            this.tpInventarioCritico.Padding = new System.Windows.Forms.Padding(3);
            this.tpInventarioCritico.Size = new System.Drawing.Size(852, 404);
            this.tpInventarioCritico.TabIndex = 1;
            this.tpInventarioCritico.Text = "Reporte 2: Inventario Crítico";
            this.tpInventarioCritico.UseVisualStyleBackColor = true;
            // 
            // lblExplicacionCritico
            // 
            this.lblExplicacionCritico.AutoSize = true;
            this.lblExplicacionCritico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplicacionCritico.ForeColor = System.Drawing.Color.DarkRed;
            this.lblExplicacionCritico.Location = new System.Drawing.Point(15, 20);
            this.lblExplicacionCritico.Name = "lblExplicacionCritico";
            this.lblExplicacionCritico.Size = new System.Drawing.Size(457, 15);
            this.lblExplicacionCritico.TabIndex = 9;
            this.lblExplicacionCritico.Text = "Alerta: Listado de productos cuyos niveles de Stock están por debajo del mínimo.";
            // 
            // btnRefrescarInventario
            // 
            this.btnRefrescarInventario.Location = new System.Drawing.Point(705, 15);
            this.btnRefrescarInventario.Name = "btnRefrescarInventario";
            this.btnRefrescarInventario.Size = new System.Drawing.Size(130, 25);
            this.btnRefrescarInventario.TabIndex = 8;
            this.btnRefrescarInventario.Text = "Refrescar Alertas";
            this.btnRefrescarInventario.UseVisualStyleBackColor = true;
            this.btnRefrescarInventario.Click += new System.EventHandler(this.btnRefrescarInventario_Click);
            // 
            // dgvReporte2
            // 
            this.dgvReporte2.AllowUserToAddRows = false;
            this.dgvReporte2.AllowUserToDeleteRows = false;
            this.dgvReporte2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte2.Location = new System.Drawing.Point(15, 60);
            this.dgvReporte2.Name = "dgvReporte2";
            this.dgvReporte2.ReadOnly = true;
            this.dgvReporte2.RowHeadersVisible = false;
            this.dgvReporte2.Size = new System.Drawing.Size(820, 325);
            this.dgvReporte2.TabIndex = 7;
            // 
            // tpHistorial
            // 
            this.tpHistorial.Controls.Add(this.dgvReporte3);
            this.tpHistorial.Controls.Add(this.btnCargarReporte3);
            this.tpHistorial.Controls.Add(this.lblFiltroValor);
            this.tpHistorial.Controls.Add(this.cmbFiltroValor);
            this.tpHistorial.Controls.Add(this.lblFiltroTipo);
            this.tpHistorial.Controls.Add(this.cmbFiltroTipo);
            this.tpHistorial.Location = new System.Drawing.Point(4, 22);
            this.tpHistorial.Name = "tpHistorial";
            this.tpHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tpHistorial.Size = new System.Drawing.Size(852, 404);
            this.tpHistorial.TabIndex = 2;
            this.tpHistorial.Text = "Reporte 3: Historial Detallado";
            this.tpHistorial.UseVisualStyleBackColor = true;
            // 
            // dgvReporte3
            // 
            this.dgvReporte3.AllowUserToAddRows = false;
            this.dgvReporte3.AllowUserToDeleteRows = false;
            this.dgvReporte3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte3.Location = new System.Drawing.Point(15, 60);
            this.dgvReporte3.Name = "dgvReporte3";
            this.dgvReporte3.ReadOnly = true;
            this.dgvReporte3.RowHeadersVisible = false;
            this.dgvReporte3.Size = new System.Drawing.Size(820, 325);
            this.dgvReporte3.TabIndex = 13;
            // 
            // btnCargarReporte3
            // 
            this.btnCargarReporte3.Location = new System.Drawing.Point(705, 13);
            this.btnCargarReporte3.Name = "btnCargarReporte3";
            this.btnCargarReporte3.Size = new System.Drawing.Size(130, 25);
            this.btnCargarReporte3.TabIndex = 12;
            this.btnCargarReporte3.Text = "Buscar Facturas";
            this.btnCargarReporte3.UseVisualStyleBackColor = true;
            this.btnCargarReporte3.Click += new System.EventHandler(this.btnCargarReporte3_Click);
            // 
            // lblFiltroValor
            // 
            this.lblFiltroValor.AutoSize = true;
            this.lblFiltroValor.Location = new System.Drawing.Point(260, 18);
            this.lblFiltroValor.Name = "lblFiltroValor";
            this.lblFiltroValor.Size = new System.Drawing.Size(65, 13);
            this.lblFiltroValor.TabIndex = 11;
            this.lblFiltroValor.Text = "Seleccionar:";
            // 
            // cmbFiltroValor
            // 
            this.cmbFiltroValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroValor.FormattingEnabled = true;
            this.cmbFiltroValor.Location = new System.Drawing.Point(340, 15);
            this.cmbFiltroValor.Name = "cmbFiltroValor";
            this.cmbFiltroValor.Size = new System.Drawing.Size(320, 21);
            this.cmbFiltroValor.TabIndex = 10;
            // 
            // lblFiltroTipo
            // 
            this.lblFiltroTipo.AutoSize = true;
            this.lblFiltroTipo.Location = new System.Drawing.Point(15, 18);
            this.lblFiltroTipo.Name = "lblFiltroTipo";
            this.lblFiltroTipo.Size = new System.Drawing.Size(53, 13);
            this.lblFiltroTipo.TabIndex = 9;
            this.lblFiltroTipo.Text = "Filtrar por:";
            // 
            // cmbFiltroTipo
            // 
            this.cmbFiltroTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroTipo.FormattingEnabled = true;
            this.cmbFiltroTipo.Items.AddRange(new object[] {
            "Por Cliente",
            "Por Cajero"});
            this.cmbFiltroTipo.Location = new System.Drawing.Point(85, 15);
            this.cmbFiltroTipo.Name = "cmbFiltroTipo";
            this.cmbFiltroTipo.Size = new System.Drawing.Size(140, 21);
            this.cmbFiltroTipo.TabIndex = 8;
            this.cmbFiltroTipo.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroTipo_SelectedIndexChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(380, 452);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(130, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 492);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.tabReportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módulo de Analítica y Reportes de Ventas";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.tabReportes.ResumeLayout(false);
            this.tpVentasFecha.ResumeLayout(false);
            this.tpVentasFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte1)).EndInit();
            this.tpInventarioCritico.ResumeLayout(false);
            this.tpInventarioCritico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte2)).EndInit();
            this.tpHistorial.ResumeLayout(false);
            this.tpHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabReportes;
        private System.Windows.Forms.TabPage tpVentasFecha;
        private System.Windows.Forms.TabPage tpInventarioCritico;
        private System.Windows.Forms.TabPage tpHistorial;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblAgrupado;
        private System.Windows.Forms.ComboBox cmbAgrupado;
        private System.Windows.Forms.Button btnCargarReporte1;
        private System.Windows.Forms.DataGridView dgvReporte1;
        private System.Windows.Forms.Label lblExplicacionCritico;
        private System.Windows.Forms.Button btnRefrescarInventario;
        private System.Windows.Forms.DataGridView dgvReporte2;
        private System.Windows.Forms.DataGridView dgvReporte3;
        private System.Windows.Forms.Button btnCargarReporte3;
        private System.Windows.Forms.Label lblFiltroValor;
        private System.Windows.Forms.ComboBox cmbFiltroValor;
        private System.Windows.Forms.Label lblFiltroTipo;
        private System.Windows.Forms.ComboBox cmbFiltroTipo;
    }
}
