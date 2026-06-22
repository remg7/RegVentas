using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RegVentas
{
    public partial class FrmVentas : Form
    {
        private DataTable dtDetalle;

        public FrmVentas()
        {
            InitializeComponent();
            InicializarDetalleTable();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarUsuarios();
            CargarProductos();
            GenerarNumeroFactura();
            LimpiarVenta();
        }

        private void InicializarDetalleTable()
        {
            dtDetalle = new DataTable();
            dtDetalle.Columns.Add("ID_Producto", typeof(int));
            dtDetalle.Columns.Add("Producto", typeof(string));
            dtDetalle.Columns.Add("Cantidad", typeof(int));
            dtDetalle.Columns.Add("PrecioUnitario", typeof(decimal));
            dtDetalle.Columns.Add("Subtotal", typeof(decimal));
            dgvDetalle.DataSource = dtDetalle;

            // Ajustar columnas
            dgvDetalle.Columns["ID_Producto"].Visible = false;
        }

        private void CargarClientes()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT ID_Cliente, Nombre FROM Clientes ORDER BY Nombre";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbCliente.DataSource = dt;
                        cmbCliente.ValueMember = "ID_Cliente";
                        cmbCliente.DisplayMember = "Nombre";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT ID_Usuario, Username FROM Usuarios WHERE Estado = 1 ORDER BY Username";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbUsuario.DataSource = dt;
                        cmbUsuario.ValueMember = "ID_Usuario";
                        cmbUsuario.DisplayMember = "Username";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cajeros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT ID_Producto, Nombre, Precio, Stock FROM Productos ORDER BY Nombre";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbProducto.DataSource = dt;
                        cmbProducto.ValueMember = "ID_Producto";
                        cmbProducto.DisplayMember = "Nombre";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarNumeroFactura()
        {
            Random r = new Random();
            txtFactura.Text = "F-" + DateTime.Now.ToString("yyMMdd") + "-" + r.Next(1000, 9999);
        }

        private void LimpiarVenta()
        {
            dtDetalle.Clear();
            txtCantidad.Text = "1";
            txtTotal.Text = "0.00";
            GenerarNumeroFactura();
            if (cmbCliente.Items.Count > 0) cmbCliente.SelectedIndex = 0;
            if (cmbUsuario.Items.Count > 0) cmbUsuario.SelectedIndex = 0;
            if (cmbProducto.Items.Count > 0) cmbProducto.SelectedIndex = 0;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem != null)
            {
                DataRowView rowView = (DataRowView)cmbProducto.SelectedItem;
                txtPrecio.Text = Convert.ToDecimal(rowView["Precio"]).ToString("0.00");
                lblStockDisp.Text = "Stock: " + rowView["Stock"].ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null) return;
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProd = Convert.ToInt32(cmbProducto.SelectedValue);
            string nombreProd = cmbProducto.Text;
            decimal precio = Convert.ToDecimal(txtPrecio.Text);

            // Obtener el stock disponible de la combobox
            DataRowView rowView = (DataRowView)cmbProducto.SelectedItem;
            int stockDisp = Convert.ToInt32(rowView["Stock"]);

            if (cantidad > stockDisp)
            {
                MessageBox.Show($"Stock insuficiente. Solo quedan {stockDisp} unidades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar si el producto ya está en la grilla
            foreach (DataRow row in dtDetalle.Rows)
            {
                if (Convert.ToInt32(row["ID_Producto"]) == idProd)
                {
                    int nuevaCant = Convert.ToInt32(row["Cantidad"]) + cantidad;
                    if (nuevaCant > stockDisp)
                    {
                        MessageBox.Show($"Stock insuficiente al acumular la cantidad. Stock disponible: {stockDisp}.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    row["Cantidad"] = nuevaCant;
                    row["Subtotal"] = nuevaCant * precio;
                    CalcularTotal();
                    return;
                }
            }

            // Agregar fila
            dtDetalle.Rows.Add(idProd, nombreProd, cantidad, precio, cantidad * precio);
            CalcularTotal();
        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
                {
                    dgvDetalle.Rows.Remove(row);
                }
                CalcularTotal();
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataRow row in dtDetalle.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }
            txtTotal.Text = total.ToString("0.00");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCliente.SelectedValue == null || cmbUsuario.SelectedValue == null)
            {
                MessageBox.Show("Cliente o Cajero inválido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
            int idUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);
            string facturaNum = txtFactura.Text.Trim();
            decimal totalFactura = Convert.ToDecimal(txtTotal.Text);

            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Insertar la Cabecera de la Venta
                    string queryVenta = "INSERT INTO Ventas (NumeroFactura, Fecha, ID_Cliente, ID_Usuario, Total) " +
                                        "VALUES (@NumeroFactura, @Fecha, @ID_Cliente, @ID_Usuario, @Total); " +
                                        "SELECT LAST_INSERT_ID();";
                    
                    int idVenta;
                    using (MySqlCommand cmdV = new MySqlCommand(queryVenta, conn, trans))
                    {
                        cmdV.Parameters.AddWithValue("@NumeroFactura", facturaNum);
                        cmdV.Parameters.AddWithValue("@Fecha", dtpFecha.Value);
                        cmdV.Parameters.AddWithValue("@ID_Cliente", idCliente);
                        cmdV.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                        cmdV.Parameters.AddWithValue("@Total", totalFactura);
                        idVenta = Convert.ToInt32(cmdV.ExecuteScalar());
                    }

                    // 2. Insertar Detalles de la Venta y decrementar Stock de Productos
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        int idProd = Convert.ToInt32(row["ID_Producto"]);
                        int cantidad = Convert.ToInt32(row["Cantidad"]);
                        decimal precioUnit = Convert.ToDecimal(row["PrecioUnitario"]);

                        // Verificar Stock actual directo desde la base de datos (con bloqueo FOR UPDATE para concurrencia)
                        string queryCheckStock = "SELECT Stock FROM Productos WHERE ID_Producto = @ID_Producto FOR UPDATE";
                        int currentStock = 0;
                        using (MySqlCommand cmdCheck = new MySqlCommand(queryCheckStock, conn, trans))
                        {
                            cmdCheck.Parameters.AddWithValue("@ID_Producto", idProd);
                            object res = cmdCheck.ExecuteScalar();
                            if (res == null)
                            {
                                throw new Exception($"El producto '{row["Producto"]}' ya no existe.");
                            }
                            currentStock = Convert.ToInt32(res);
                        }

                        if (cantidad > currentStock)
                        {
                            throw new Exception($"Stock insuficiente para '{row["Producto"]}'. Stock actual: {currentStock}, Solicitado: {cantidad}.");
                        }

                        // Decrementar Stock
                        string queryUpdateStock = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE ID_Producto = @ID_Producto";
                        using (MySqlCommand cmdStock = new MySqlCommand(queryUpdateStock, conn, trans))
                        {
                            cmdStock.Parameters.AddWithValue("@Cantidad", cantidad);
                            cmdStock.Parameters.AddWithValue("@ID_Producto", idProd);
                            cmdStock.ExecuteNonQuery();
                        }

                        // Insertar detalle
                        string queryDetalle = "INSERT INTO DetalleVenta (ID_Venta, ID_Producto, Cantidad, PrecioUnitario) " +
                                              "VALUES (@ID_Venta, @ID_Producto, @Cantidad, @PrecioUnitario)";
                        using (MySqlCommand cmdD = new MySqlCommand(queryDetalle, conn, trans))
                        {
                            cmdD.Parameters.AddWithValue("@ID_Venta", idVenta);
                            cmdD.Parameters.AddWithValue("@ID_Producto", idProd);
                            cmdD.Parameters.AddWithValue("@Cantidad", cantidad);
                            cmdD.Parameters.AddWithValue("@PrecioUnitario", precioUnit);
                            cmdD.ExecuteNonQuery();
                        }
                    }

                    // Confirmar Transacción
                    trans.Commit();
                    MessageBox.Show("Los datos se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refrescar combos y limpiar
                    CargarProductos();
                    LimpiarVenta();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error en la transacción de venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
