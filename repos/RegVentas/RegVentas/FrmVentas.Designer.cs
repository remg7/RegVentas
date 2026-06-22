namespace RegVentas
{
    partial class FrmVentas
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
            this.groupBoxCabecera = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFactura = new System.Windows.Forms.Label();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.groupBoxDetalle = new System.Windows.Forms.GroupBox();
            this.lblStockDisp = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnEliminarFila = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBoxCabecera.SuspendLayout();
            this.groupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCabecera
            // 
            this.groupBoxCabecera.Controls.Add(this.lblUsuario);
            this.groupBoxCabecera.Controls.Add(this.cmbUsuario);
            this.groupBoxCabecera.Controls.Add(this.lblCliente);
            this.groupBoxCabecera.Controls.Add(this.cmbCliente);
            this.groupBoxCabecera.Controls.Add(this.lblFecha);
            this.groupBoxCabecera.Controls.Add(this.dtpFecha);
            this.groupBoxCabecera.Controls.Add(this.lblFactura);
            this.groupBoxCabecera.Controls.Add(this.txtFactura);
            this.groupBoxCabecera.Location = new System.Drawing.Point(20, 15);
            this.groupBoxCabecera.Name = "groupBoxCabecera";
            this.groupBoxCabecera.Size = new System.Drawing.Size(850, 100);
            this.groupBoxCabecera.TabIndex = 0;
            this.groupBoxCabecera.TabStop = false;
            this.groupBoxCabecera.Text = "Datos de la Factura";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(580, 63);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(40, 13);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "Cajero:";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(640, 60);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(190, 21);
            this.cmbUsuario.TabIndex = 6;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(20, 63);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 5;
            this.lblCliente.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(90, 60);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(460, 21);
            this.cmbCliente.TabIndex = 4;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(580, 27);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(640, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(190, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Location = new System.Drawing.Point(20, 27);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(61, 13);
            this.lblFactura.TabIndex = 1;
            this.lblFactura.Text = "N° Factura:";
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(90, 24);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.ReadOnly = true;
            this.txtFactura.Size = new System.Drawing.Size(150, 20);
            this.txtFactura.TabIndex = 0;
            // 
            // groupBoxDetalle
            // 
            this.groupBoxDetalle.Controls.Add(this.lblStockDisp);
            this.groupBoxDetalle.Controls.Add(this.btnAgregar);
            this.groupBoxDetalle.Controls.Add(this.lblPrecio);
            this.groupBoxDetalle.Controls.Add(this.txtPrecio);
            this.groupBoxDetalle.Controls.Add(this.lblCantidad);
            this.groupBoxDetalle.Controls.Add(this.txtCantidad);
            this.groupBoxDetalle.Controls.Add(this.lblProducto);
            this.groupBoxDetalle.Controls.Add(this.cmbProducto);
            this.groupBoxDetalle.Location = new System.Drawing.Point(20, 130);
            this.groupBoxDetalle.Name = "groupBoxDetalle";
            this.groupBoxDetalle.Size = new System.Drawing.Size(850, 80);
            this.groupBoxDetalle.TabIndex = 1;
            this.groupBoxDetalle.TabStop = false;
            this.groupBoxDetalle.Text = "Agregar Producto";
            // 
            // lblStockDisp
            // 
            this.lblStockDisp.AutoSize = true;
            this.lblStockDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockDisp.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblStockDisp.Location = new System.Drawing.Point(340, 52);
            this.lblStockDisp.Name = "lblStockDisp";
            this.lblStockDisp.Size = new System.Drawing.Size(59, 13);
            this.lblStockDisp.TabIndex = 7;
            this.lblStockDisp.Text = "Stock: --";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(720, 25);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(110, 30);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(540, 33);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 5;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(590, 30);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 4;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(390, 33);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(450, 30);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(70, 20);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.Text = "1";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(20, 33);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(53, 13);
            this.lblProducto.TabIndex = 1;
            this.lblProducto.Text = "Producto:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(90, 30);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(240, 21);
            this.cmbProducto.TabIndex = 0;
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.cmbProducto_SelectedIndexChanged);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(20, 225);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(850, 200);
            this.dgvDetalle.TabIndex = 2;
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.Location = new System.Drawing.Point(20, 440);
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.Size = new System.Drawing.Size(120, 30);
            this.btnEliminarFila.TabIndex = 3;
            this.btnEliminarFila.Text = "Quitar Seleccionado";
            this.btnEliminarFila.UseVisualStyleBackColor = true;
            this.btnEliminarFila.Click += new System.EventHandler(this.btnEliminarFila_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(680, 447);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(52, 16);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total: ";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(740, 444);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(130, 22);
            this.txtTotal.TabIndex = 5;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(300, 490);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(140, 40);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar Venta";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(460, 490);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(140, 40);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 550);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnEliminarFila);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.groupBoxDetalle);
            this.Controls.Add(this.groupBoxCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Transacciones Comerciales (Facturación)";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            this.groupBoxCabecera.ResumeLayout(false);
            this.groupBoxCabecera.PerformLayout();
            this.groupBoxDetalle.ResumeLayout(false);
            this.groupBoxDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCabecera;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.GroupBox groupBoxDetalle;
        private System.Windows.Forms.Label lblStockDisp;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnEliminarFila;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnCerrar;
    }
}
