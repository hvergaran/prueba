using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class CrudColegio : Form
    {
        public CrudColegio()
        {
            InitializeComponent();
        }

        CN_Colegios objetoCN = new CN_Colegios();
        private string idColegio = null;
        private bool Editar = false;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void MostrarColegios()
        {

            CN_Colegios objeto = new CN_Colegios();
            dataGridView1.DataSource = objeto.MostrarColegio();
        }



        private void limpiarForm()
        {
            txtCorreoEnc.Text = "";
            txtNombreEnc.Clear();
            txtRazon.Clear();
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar.ValidaTextBoxVacios(this))
            {
                //INSERTAR
                if (Editar == false)
                {
                    try
                    {
                        objetoCN.InsertarColegio(txtRazon.Text, txtNombreEnc.Text, txtCorreoEnc.Text);
                        MessageBox.Show("Se Inserto Correctamente");
                        MostrarColegios();
                        limpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo insertar los datos por: " + ex);
                    }
                }
                //EDITAR
                if (Editar == true)
                {

                    try
                    {
                        objetoCN.EditarColegio(txtRazon.Text, txtNombreEnc.Text, txtCorreoEnc.Text, idColegio);
                        MessageBox.Show("Se Edito Correctamente");
                        MostrarColegios();
                        limpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo editar los datos por: " + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Favor llenar todos los campos");
            }
        }

        private void CrudColegio_Load(object sender, EventArgs e)
        {
            MostrarColegios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idColegio = dataGridView1.CurrentRow.Cells["ID_COLEGIO"].Value.ToString();
                objetoCN.EliminarColegio(idColegio);
                MessageBox.Show("Eliminado Correctamente");
                MostrarColegios();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtRazon.Text = dataGridView1.CurrentRow.Cells["RAZON_SOCIAL_COLEGIO"].Value.ToString();
                txtNombreEnc.Text = dataGridView1.CurrentRow.Cells["DIRECCION_COLEGIO"].Value.ToString();
                txtCorreoEnc.Text = dataGridView1.CurrentRow.Cells["RUT_SOSTENEDOR"].Value.ToString();
                idColegio = dataGridView1.CurrentRow.Cells["ID_COLEGIO"].Value.ToString();

            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        
        private void txtCorreoEnc_Leave(object sender, EventArgs e)
        {
            if (Validar.ValidarRut(txtCorreoEnc.Text))
            {
                btnGuardar.Focus();
            }
            else
            {
                MessageBox.Show("Rut Invalido");
                txtCorreoEnc.SelectAll();
                txtCorreoEnc.Focus();
            }
        }
    }
}
