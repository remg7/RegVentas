using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RegVentas
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            // Reporte 1: Valores iniciales
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today.AddDays(1).AddSeconds(-1);
            cmbAgrupado.SelectedIndex = 0; // Diario

            // Reporte 3: Valores iniciales
            cmbFiltroTipo.SelectedIndex = 0; // Por Cliente
            CargarFiltroValores();

            // Cargar por defecto Reporte 2
            EjecutarReporteInventario();
        }

        #region Reporte 1: Ventas por Rango de Fechas
        private void btnCargarReporte1_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
            string tipoAgrupado = cmbAgrupado.SelectedItem.ToString();

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string sql = "";
                    if (tipoAgrupado == "Diario")
                    {
                        sql = "SELECT DATE_FORMAT(Fecha, '%Y/%m/%d') AS `Fecha Dia`, " +
                              "COUNT(ID_Venta) AS `Cantidad Facturas`, " +
                              "SUM(Total) AS `Monto Total` " +
                              "FROM Ventas " +
                              "WHERE Fecha >= @Desde AND Fecha <= @Hasta " +
                              "GROUP BY DATE_FORMAT(Fecha, '%Y/%m/%d') " +
                              "ORDER BY `Fecha Dia`";
                    }
                    else // Mensual
                    {
                        sql = "SELECT DATE_FORMAT(Fecha, '%Y/%m') AS `Mes`, " +
                              "COUNT(ID_Venta) AS `Cantidad Facturas`, " +
                              "SUM(Total) AS `Monto Total` " +
                              "FROM Ventas " +
                              "WHERE Fecha >= @Desde AND Fecha <= @Hasta " +
                              "GROUP BY DATE_FORMAT(Fecha, '%Y/%m') " +
                              "ORDER BY `Mes`";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Desde", desde);
                        cmd.Parameters.AddWithValue("@Hasta", hasta);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvReporte1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar Reporte de Ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Reporte 2: Alerta de Inventario Crítico
        private void btnRefrescarInventario_Click(object sender, EventArgs e)
        {
            EjecutarReporteInventario();
        }

        private void EjecutarReporteInventario()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string sql = "SELECT ID_Producto, Nombre AS `Nombre Producto`, Precio, Stock AS `Stock Actual`, StockMinimo AS `Stock Minimo` " +
                                 "FROM Productos " +
                                 "WHERE Stock <= StockMinimo " +
                                 "ORDER BY Stock ASC";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvReporte2.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar Alerta de Inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Reporte 3: Historial de Facturación por Cliente / Cajero
        private void cmbFiltroTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFiltroValores();
        }

        private void CargarFiltroValores()
        {
            if (cmbFiltroTipo.SelectedItem == null) return;
            string tipo = cmbFiltroTipo.SelectedItem.ToString();

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string sql = "";
                    if (tipo == "Por Cliente")
                    {
                        sql = "SELECT ID_Cliente AS ID, Nombre FROM Clientes ORDER BY Nombre";
                    }
                    else // Por Cajero
                    {
                        sql = "SELECT ID_Usuario AS ID, Username AS Nombre FROM Usuarios ORDER BY Username";
                    }

                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbFiltroValor.DataSource = dt;
                        cmbFiltroValor.ValueMember = "ID";
                        cmbFiltroValor.DisplayMember = "Nombre";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar filtros secundarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarReporte3_Click(object sender, EventArgs e)
        {
            if (cmbFiltroValor.SelectedValue == null) return;

            string tipo = cmbFiltroTipo.SelectedItem.ToString();
            int idFiltro = Convert.ToInt32(cmbFiltroValor.SelectedValue);

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string sql = "";
                    if (tipo == "Por Cliente")
                    {
                        sql = "SELECT V.NumeroFactura AS `N° Factura`, V.Fecha, U.Username AS `Cajero / Operario`, V.Total " +
                              "FROM Ventas V " +
                              "INNER JOIN Usuarios U ON V.ID_Usuario = U.ID_Usuario " +
                              "WHERE V.ID_Cliente = @IDFiltro " +
                              "ORDER BY V.Fecha DESC";
                    }
                    else // Por Cajero
                    {
                        sql = "SELECT V.NumeroFactura AS `N° Factura`, V.Fecha, C.Nombre AS `Cliente`, V.Total " +
                              "FROM Ventas V " +
                              "INNER JOIN Clientes C ON V.ID_Cliente = C.ID_Cliente " +
                              "WHERE V.ID_Usuario = @IDFiltro " +
                              "ORDER BY V.Fecha DESC";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDFiltro", idFiltro);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvReporte3.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial detallado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
