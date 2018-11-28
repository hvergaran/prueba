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
    public partial class CrudContrato : Form
    {
        public CrudContrato()
        {
            InitializeComponent();
        }


        CN_Contratos objetoCN = new CN_Contratos();
        private string idContrato = null;
        private bool Editar = false;
        String fechaIncorporacion;
        String fechaMeta;
        String fechaFinal;



        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar.ValidaTextBoxVacios(this))
            {
                //INSERTAR
                if (Editar == false)
                {
                    if (Validar.ValidaComboBox(this))
                    {
                        try
                        {
                            fechaIncorporacion = dateTimePicker1.Value.ToShortDateString();
                            fechaMeta = dateTimePicker2.Value.ToShortDateString();
                            fechaFinal = dateTimePicker3.Value.ToShortDateString();
                            objetoCN.InsertarContrato(fechaIncorporacion, fechaMeta, montoMeta.Text, fechaFinal, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), comboBox4.SelectedValue.ToString());
                            MessageBox.Show("Se Inserto Correctamente");
                            MostrarContratos();
                            limpiarForm();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo insertar los datos por: " + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Favor seleccionar item de la lista");
                    }
                }
                //EDITAR
                if (Editar == true)
                {

                    try
                    {
                        fechaIncorporacion = dateTimePicker1.Value.ToShortDateString();
                        fechaMeta = dateTimePicker2.Value.ToShortDateString();
                        fechaFinal = dateTimePicker3.Value.ToShortDateString();
                        objetoCN.EditarContrato(idContrato,fechaIncorporacion, fechaMeta, montoMeta.Text, fechaFinal, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), comboBox4.SelectedValue.ToString());
                        MessageBox.Show("Se Edito Correctamente");
                        MostrarContratos();
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
            montoMeta.Clear();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            dateTimePicker3.ResetText();
            comboBox1.Text = "Seleccione";
            comboBox2.Text = "Seleccione";
            comboBox3.Text = "Seleccione";
            comboBox4.Text = "Seleccione";
        }

        private void MostrarContratos()
        {

            CN_Contratos objeto = new CN_Contratos();
            dataGridView1.DataSource = objeto.MostrarContratos();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            //fechaIncorporacion = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            //fechaMeta = dateTimePicker2.Value;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
           
            //fechaFinal = dateTimePicker3.Value;
            
        }        

        private void CargarCombo()
        {

            CN_Usuarios objeto1 = new CN_Usuarios();

            comboBox2.DataSource = objeto1.MostrarEjecutivo();
            comboBox2.DisplayMember = "nombre_usuario";
            comboBox2.ValueMember = "id_usuario";
            comboBox2.Text = "Seleccione";

            CN_Cursos objeto2 = new CN_Cursos();

            comboBox1.DataSource = objeto2.MostrarCursos();
            comboBox1.DisplayMember = "DESCRIPCION_CURSO";
            comboBox1.ValueMember = "ID_CURSO";
            comboBox1.Text = "Seleccione";

            CN_Usuarios objeto3 = new CN_Usuarios();

            comboBox3.DataSource = objeto3.MostrarEncargado();
            comboBox3.DisplayMember = "nombre_usuario";
            comboBox3.ValueMember = "id_usuario";
            comboBox3.Text = "Seleccione";

            CN_Paquete objeto4 = new CN_Paquete();

            comboBox4.DataSource = objeto4.MostrarPaquetes();
            comboBox4.DisplayMember = "DESCRIPCION";
            comboBox4.ValueMember = "ID_PAQUETE";
            comboBox4.Text = "Seleccione";


        }

        private void CrudContrato_Load(object sender, EventArgs e)
        {
            CargarCombo();
            MostrarContratos();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd-MM-yyyy";

        }

        private void montoMeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void montoActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                montoMeta.Text = dataGridView1.CurrentRow.Cells["MONTO_META"].Value.ToString();
                //montoActual.Text = dataGridView1.CurrentRow.Cells["MONTO_ACTUAL_CONTRATO"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["FECHA_INCORPORACION"].Value.ToString();
                dateTimePicker2.Text = dataGridView1.CurrentRow.Cells["FECHA_META"].Value.ToString();
                dateTimePicker3.Text = dataGridView1.CurrentRow.Cells["FECHA_FINAL"].Value.ToString();
                //dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FECHA_INCORPORACION"].Value);
                //dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[2].Value);
                //dateTimePicker2.Text = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[3].Value.ToString);
                //dateTimePicker3.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[5].Value);
                //txtCorreoEnc.Text = dataGridView1.CurrentRow.Cells["email_encargado_colegio"].Value.ToString();
                // idColegio = dataGridView1.CurrentRow.Cells["id_colegio"].Value.ToString();
                idContrato = dataGridView1.CurrentRow.Cells["ID_CONTRATO"].Value.ToString();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idContrato = dataGridView1.CurrentRow.Cells["ID_CONTRATO"].Value.ToString();
                objetoCN.EliminarContrato(idContrato);
                MessageBox.Show("Eliminado Correctamente");
                MostrarContratos();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }
    }
}
