using System;
using System.Windows.Forms;

namespace RegVentas
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Opcional: configuraciones de carga inicial
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportesAnaliticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
