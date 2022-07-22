using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinForm
{
    public partial class frmTipoCliente : Form
    {
        public frmTipoCliente()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            // Creamos la instancia del adaptador
            var adaptador = new dsAppTableAdapters.TipoClienteTableAdapter();
            //Obtenemos el objeto datatable
            var tabla = adaptador.GetData();
            //
            dgvDatos.DataSource = tabla;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //frmTipoClienteEdit frm;
            var frm = new frmTipoClienteEdit();
            frm.ShowDialog();
            cargarDatos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                var frm = new frmTipoClienteEdit(id);
                frm.ShowDialog();
                cargarDatos();
            }else
            {
                MessageBox.Show("Seleccione un ID valido", "Sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int getId()
        {
            try
            {
                //¿Que queremos procesar?
                DataGridViewRow filaActual = dgvDatos.CurrentRow;
                if (filaActual == null)
                {
                    return 0;
                }
                return int.Parse(dgvDatos.Rows[filaActual.Index].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                //¿Que hacer en caso de error?
                return 0;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistemas",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                //Eliminar el registro
                MessageBox.Show("Registro Eliminado", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
