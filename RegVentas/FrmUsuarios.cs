using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RegVentas
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            LimpiarCampos();
        }

        private void CargarUsuarios()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT ID_Usuario, Username, Rol, Estado FROM Usuarios";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvUsuarios.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRol.SelectedIndex = 0;
            chkEstado.Checked = true;
            btnEliminar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, complete el nombre de usuario y la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    if (string.IsNullOrEmpty(txtId.Text))
                    {
                        // Insertar nuevo usuario
                        string query = "INSERT INTO Usuarios (Username, Password, Rol, Estado) VALUES (@Username, @Password, @Rol, @Estado)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim()); // En producción usar hash
                            cmd.Parameters.AddWithValue("@Rol", cmbRol.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Actualizar usuario existente
                        string query = "UPDATE Usuarios SET Username = @Username, Password = @Password, Rol = @Rol, Estado = @Estado WHERE ID_Usuario = @ID_Usuario";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_Usuario", Convert.ToInt32(txtId.Text));
                            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@Rol", cmbRol.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Los datos se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                    {
                        conn.Open();
                        string query = "DELETE FROM Usuarios WHERE ID_Usuario = @ID_Usuario";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_Usuario", Convert.ToInt32(txtId.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("El usuario ha sido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar usuario (puede estar relacionado a alguna venta): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                txtId.Text = row.Cells["ID_Usuario"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                cmbRol.SelectedItem = row.Cells["Rol"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(row.Cells["Estado"].Value);
                txtPassword.Text = "********"; // Simulación por seguridad
                btnEliminar.Enabled = true;
            }
        }
    }
}
