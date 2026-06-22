using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RegVentas
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
            LimpiarCampos();
        }

        private void CargarProductos()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT ID_Producto, Nombre, Precio, Stock, StockMinimo FROM Productos";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvProductos.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtStockMinimo.Clear();
            btnEliminar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || 
                string.IsNullOrWhiteSpace(txtPrecio.Text) || 
                string.IsNullOrWhiteSpace(txtStock.Text) || 
                string.IsNullOrWhiteSpace(txtStockMinimo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validaciones numéricas
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio debe ser un número válido mayor o igual a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock actual debe ser un número entero mayor o igual a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStockMinimo.Text, out int stockMinimo) || stockMinimo < 0)
            {
                MessageBox.Show("El stock mínimo debe ser un número entero mayor o igual a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    if (string.IsNullOrEmpty(txtId.Text))
                    {
                        // Insertar nuevo producto
                        string query = "INSERT INTO Productos (Nombre, Precio, Stock, StockMinimo) VALUES (@Nombre, @Precio, @Stock, @StockMinimo)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@Precio", precio);
                            cmd.Parameters.AddWithValue("@Stock", stock);
                            cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Actualizar producto existente
                        string query = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock, StockMinimo = @StockMinimo WHERE ID_Producto = @ID_Producto";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_Producto", Convert.ToInt32(txtId.Text));
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@Precio", precio);
                            cmd.Parameters.AddWithValue("@Stock", stock);
                            cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Los datos se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                    {
                        conn.Open();
                        string query = "DELETE FROM Productos WHERE ID_Producto = @ID_Producto";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_Producto", Convert.ToInt32(txtId.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("El producto ha sido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar producto (puede estar relacionado a alguna factura de venta): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                txtId.Text = row.Cells["ID_Producto"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
                txtStockMinimo.Text = row.Cells["StockMinimo"].Value.ToString();
                btnEliminar.Enabled = true;
            }
        }
    }
}
