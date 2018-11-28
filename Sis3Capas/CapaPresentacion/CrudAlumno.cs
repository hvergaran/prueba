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
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class CrudAlumno : Form
    {
        public CrudAlumno()
        {
            InitializeComponent();
        }

        CN_Alumnos objetoCN = new CN_Alumnos();
        private string idAlumno = null;
        private bool Editar = false;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar.ValidaTextBoxVacios(this))
            {
                if (Editar == false)
                {
                    if (Validar.ValidaComboBox(this))
                    {


                        try
                        {
                            objetoCN.InsertarAlumno(txtNombre.Text, txtApellido.Text, txtRut.Text, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString());
                            MessageBox.Show("Se Inserto Correctamente");
                            MostrarAlumnos();
                            limpiarForm();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("no se pudo insertar los datos por: " + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Favor seleccione opción de lista");
                    }
                }
                if (Editar == true)
                {
                    try
                    {
                        objetoCN.EditarAlumno(txtNombre.Text, txtApellido.Text, txtRut.Text, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), idAlumno);
                        MessageBox.Show("Se Edito Correctamente");
                        MostrarAlumnos();
                        limpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no se pudo editar los datos por: " + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Favor llenar todos los campos");
            }
        }

        private void limpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtRut.Clear();
            comboBox1.Text = "Seleccione";
            comboBox2.Text = "Seleccione";
        }

        private void MostrarAlumnos()
        {
            CN_Alumnos objeto = new CN_Alumnos();
            dataGridView1.DataSource = objeto.MostrarAlumnos();
        }

        private void CargarCombo()
        {
            CN_Usuarios objeto1 = new CN_Usuarios();

            comboBox1.DataSource = objeto1.MostrarApoderados();
            comboBox1.DisplayMember = "nombre_usuario";
            comboBox1.ValueMember = "id_usuario";
            comboBox1.Text = "Seleccione";

            CN_Contratos objeto2 = new CN_Contratos();

            comboBox2.DataSource = objeto2.MostrarContratos();
            comboBox2.DisplayMember = "ID_CONTRATO";
            comboBox2.ValueMember = "ID_CONTRATO";
            comboBox2.Text = "Seleccione";
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idAlumno = dataGridView1.CurrentRow.Cells["ID_ALUMNO"].Value.ToString();
                objetoCN.EliminarALumno(idAlumno);
                MessageBox.Show("Eliminado Correctamente");
                MostrarAlumnos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE_ALUMNO"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["APELLIDO_ALUMNO"].Value.ToString();
                txtRut.Text = dataGridView1.CurrentRow.Cells["RUT_ALUMNO"].Value.ToString();
                idAlumno = dataGridView1.CurrentRow.Cells["ID_ALUMNO"].Value.ToString();
                CargarCombo();
                
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void CrudAlumno_Load(object sender, EventArgs e)
        {
            CargarCombo();
            MostrarAlumnos();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void txtRut_Leave(object sender, EventArgs e)
        {
            if(Validar.ValidarRut(txtRut.Text))
            {
                comboBox1.Focus();
            }
            else
            {
                MessageBox.Show("Rut Invalido");
                txtRut.SelectAll();
                txtRut.Focus();
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }
    }
}
