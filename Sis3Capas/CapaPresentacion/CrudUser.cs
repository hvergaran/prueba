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
    public partial class CrudUser : Form
    {
        public CrudUser()
        {
            InitializeComponent();
        }

        private void btnEMPLEADOS_Click(object sender, EventArgs e)
        {

        }

        CN_Usuarios objetoCN = new CN_Usuarios();
        private string idUser = null;
        private bool Editar = false;



       





        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Validar.ValidaTextBoxVacios(this))
            {
                if (Editar == false)
                {
                    try
                    {
                        objetoCN.InsertarUser(txtNombre.Text, txtApelldio.Text, txtCorreo.Text, txtPassword.Text, comboBox1.SelectedValue.ToString());
                        MessageBox.Show("Se Inserto Correctamente");
                        MostrarUsuarios();
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
                        objetoCN.EditarUser(txtNombre.Text, txtApelldio.Text, txtCorreo.Text, txtPassword.Text, comboBox1.SelectedValue.ToString(), idUser);
                        MessageBox.Show("Se Edito Correctamente");
                        MostrarUsuarios();
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
                MessageBox.Show("Debe completar todos los campos");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MostrarUsuarios()
        {

            CN_Usuarios objeto = new CN_Usuarios();
            dataGridView1.DataSource = objeto.MostrarUser();
        }



        private void limpiarForm()
        {
            txtApelldio.Clear();
            txtCorreo.Clear();
            txtPassword.Clear();
            comboBox1.Text = "Seleccione";

            txtNombre.Clear();
        }


        private void CrudUser_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
            CargarCombo();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idUser = dataGridView1.CurrentRow.Cells["id_usuario"].Value.ToString();
                objetoCN.EliminarUser(idUser);
                MessageBox.Show("Eliminado Correctamente");
                MostrarUsuarios();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre_usuario"].Value.ToString();
                txtApelldio.Text = dataGridView1.CurrentRow.Cells["apellido_usuario"].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells["correo_usuario"].Value.ToString();
                txtPassword.Text = dataGridView1.CurrentRow.Cells["password_usuario"].Value.ToString();
                //txtIdPerfil.Text = dataGridView1.CurrentRow.Cells["fk_id_perfil"].Value.ToString();
                idUser = dataGridView1.CurrentRow.Cells["id_usuario"].Value.ToString();

            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CargarCombo()
        {

            CN_Perfil objeto1 = new CN_Perfil();

            comboBox1.DataSource = objeto1.MostrarPerfil();
            comboBox1.DisplayMember = "DESCRIPCION_PERFIL";
            comboBox1.ValueMember = "ID_PERFIL";
            comboBox1.Text = "Seleccione";

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void txtApelldio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (Validar.ValidarEmail(txtCorreo.Text))
            {
                txtPassword.Focus();
            }
            else
            {
                MessageBox.Show("Correo Electronico no Valido");
                txtCorreo.SelectAll();
                txtCorreo.Focus();
            }
        }

        private void txtIdPerfil_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
