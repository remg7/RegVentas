using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RegVentas
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            LimpiarCampos();
        }

        private void CargarClientes()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT ID_Cliente, Cedula, Nombre, Telefono, Direccion FROM Clientes";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvClientes.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtCedula.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            btnEliminar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, complete la cédula y el nombre completo del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    if (string.IsNullOrEmpty(txtId.Text))
                    {
                        // Insertar nuevo cliente
                        string query = "INSERT INTO Clientes (Cedula, Nombre, Telefono, Direccion) VALUES (@Cedula, @Nombre, @Telefono, @Direccion)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text.Trim());
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(txtTelefono.Text) ? (object)DBNull.Value : txtTelefono.Text.Trim());
                            cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(txtDireccion.Text) ? (object)DBNull.Value : txtDireccion.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Actualizar cliente existente
                        string query = "UPDATE Clientes SET Cedula = @Cedula, Nombre = @Nombre, Telefono = @Telefono, Direccion = @Direccion WHERE ID_Cliente = @ID_Cliente";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_Cliente", Convert.ToInt32(txtId.Text));
                            cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text.Trim());
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(txtTelefono.Text) ? (object)DBNull.Value : txtTelefono.Text.Trim());
                            cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(txtDireccion.Text) ? (object)DBNull.Value : txtDireccion.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Los datos se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                    {
                        conn.Open();
                        string query = "DELETE FROM Clientes WHERE ID_Cliente = @ID_Cliente";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_Cliente", Convert.ToInt32(txtId.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("El cliente ha sido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente (puede estar relacionado a alguna venta): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClientes.Rows[e.RowIndex];
                txtId.Text = row.Cells["ID_Cliente"].Value.ToString();
                txtCedula.Text = row.Cells["Cedula"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                btnEliminar.Enabled = true;
            }
        }
    }
}
