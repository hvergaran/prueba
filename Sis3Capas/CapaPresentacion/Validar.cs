using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class Validar
    {
        public static void SoloNumeros(KeyPressEventArgs val)
        {
            if (Char.IsDigit(val.KeyChar))
            {
                val.Handled = false;
            }
            else if (Char.IsControl(val.KeyChar))
            {
                val.Handled = false;
            }
            else if (Char.IsSeparator(val.KeyChar))
            {
                val.Handled = false;
            }
            else
            {
                val.Handled = true;
                MessageBox.Show("Debe Ingresar Numeros");
            }
        }

        public static void SoloLetras(KeyPressEventArgs val)
        {
            if (Char.IsLetter(val.KeyChar))
            {
                val.Handled = false;
            }
            else if (Char.IsSeparator(val.KeyChar))
            {
                val.Handled = false;
            }
            else if (Char.IsControl(val.KeyChar))
            {
                val.Handled = false;
            }
            else
            {
                val.Handled = true;
                MessageBox.Show("Debe Ingresar Letras");
            }
        }

        public static bool ValidarEmail(string email)
        {
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool ValidaRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }

        public static bool ValidaRut(string rut, string dv)
        {
            return ValidaRut(rut + "-" + dv);
        }


        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        //Valida Rut sin guion
        public static bool ValidarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        public static bool ValidaTextBoxVacios(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control.GetType().Equals(typeof(TextBox)))
                {
                    if (control.Text.Equals(""))
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        public static bool ValidaTextBoxSoloVacio(TextBox textForm)
        {
            
                if (textForm.GetType().Equals(typeof(TextBox)))
                {
                    if (textForm.Text.Equals(""))
                    {
                        return false;
                    }
                }
            
            return true;
        }

        public static bool ValidaComboBox(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control.GetType().Equals(typeof(ComboBox)))
                {
                    if (control.Text.Equals("Seleccione"))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
