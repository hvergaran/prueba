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
    public partial class CrudEstados : Form
    {
        public CrudEstados()
        {
            InitializeComponent();
        }

        CN_EstadoContrato objetoCNEstadoContrato = new CN_EstadoContrato();
        CN_EstadoCuota objetoCNEstadoCuota = new CN_EstadoCuota();
        CN_EstadoEvento objetoCNEstadoEvento = new CN_EstadoEvento();
        private string idEstadoContrato = null;
        private string idEstadoCuota = null;
        private string idEstadoEvento = null;
        private bool Editar = false;


        private void MostrarEstados()
        {

            CN_EstadoContrato objeto = new CN_EstadoContrato();
            CN_EstadoCuota objeto2 = new CN_EstadoCuota();
            CN_EstadoEvento objeto3 = new CN_EstadoEvento();
            dataGridView1.DataSource = objeto.MostrarEstadoContrato();
            dataGridView2.DataSource = objeto2.MostrarEstadoCuota();
            dataGridView3.DataSource = objeto3.MostrarEstadoEvento();
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            if (Validar.ValidaTextBoxSoloVacio(textBox1))
            {
                //INSERTAR
                if (Editar == false)
                {
                    try
                    {
                        objetoCNEstadoContrato.InsertarEstadoContrato(textBox1.Text);
                        MessageBox.Show("Se Inserto Correctamente");
                        MostrarEstados();
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
                        objetoCNEstadoContrato.EditarEstadoContrato(textBox1.Text, idEstadoContrato);
                        MessageBox.Show("Se Edito Correctamente");
                        MostrarEstados();
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
                MessageBox.Show("Favor llenar campo: "+label4.Text);
            }
        }

        private void limpiarForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                textBox1.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();

                idEstadoContrato = dataGridView1.CurrentRow.Cells["ID_CONTRATO"].Value.ToString();

            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void CrudEstados_Load(object sender, EventArgs e)
        {
            MostrarEstados();
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            if (Validar.ValidaTextBoxSoloVacio(textBox2))
            {
                //INSERTAR
                if (Editar == false)
                {
                    try
                    {
                        objetoCNEstadoCuota.InsertarEstadoCuota(textBox2.Text);
                        MessageBox.Show("Se Inserto Correctamente");
                        MostrarEstados();
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
                        objetoCNEstadoCuota.EditarEstadoCuota(textBox2.Text, idEstadoCuota);
                        MessageBox.Show("Se Edito Correctamente");
                        MostrarEstados();
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
                MessageBox.Show("Favor llenar campo: " + label5.Text);
            }
        }

        private void btnEditar2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                Editar = true;
                textBox2.Text = dataGridView2.CurrentRow.Cells["DESCRIPCION_ESTADO_CUOTA"].Value.ToString();

                idEstadoCuota = dataGridView2.CurrentRow.Cells["ID_ESTADO_CUOTA"].Value.ToString();

            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btnGuardar3_Click(object sender, EventArgs e)
        {
            if (Validar.ValidaTextBoxSoloVacio(textBox3))
            {
                //INSERTAR
                if (Editar == false)
                {
                    try
                    {
                        objetoCNEstadoEvento.InsertarEstadoEvento(textBox3.Text);
                        MessageBox.Show("Se Inserto Correctamente");
                        MostrarEstados();
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
                        objetoCNEstadoEvento.EditarEstadoEvento(textBox3.Text, idEstadoEvento);
                        MessageBox.Show("Se Edito Correctamente");
                        MostrarEstados();
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
                MessageBox.Show("Favor llenar campo: " + label6.Text);
            }
        }

        private void btnEditar3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                Editar = true;
                textBox3.Text = dataGridView3.CurrentRow.Cells["DESCRIPCION_ESTADO_EVENTO"].Value.ToString();

                idEstadoEvento = dataGridView3.CurrentRow.Cells["ID_ESTADO_EVENTO"].Value.ToString();

            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idEstadoContrato = dataGridView1.CurrentRow.Cells["ID_CONTRATO"].Value.ToString();
                objetoCNEstadoContrato.EliminarEstadoContrato(idEstadoContrato);
                MessageBox.Show("Eliminado Correctamente");
                MostrarEstados();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                idEstadoCuota = dataGridView2.CurrentRow.Cells["ID_ESTADO_CUOTA"].Value.ToString();
                objetoCNEstadoCuota.EliminarEstadoCuota(idEstadoCuota);
                MessageBox.Show("Eliminado Correctamente");
                MostrarEstados();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btnEliminar3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                idEstadoEvento = dataGridView3.CurrentRow.Cells["ID_ESTADO_EVENTO"].Value.ToString();
                objetoCNEstadoEvento.EliminarEstadoEvento(idEstadoEvento);
                MessageBox.Show("Eliminado Correctamente");
                MostrarEstados();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
