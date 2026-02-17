using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PLunes
{   
    public partial class FRMlogin : Form
    {
        public FRMlogin()
        {
            InitializeComponent();
        }

        string passw = "1234";
        private void FRMlogin_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // captura las teclas de funciones
            this.Text = "Login";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button_Salir_Click(object sender, EventArgs e)
        {

        }



        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRMlogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        //=========================== Campos =============================
        // keypress para textbox de username
        private void user01_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (password.Text.Trim() != String.Empty)
                {
                    password.Focus();
                }

            }
        }


        private void user01_Leave(object sender, EventArgs e)
        {
            if (password.Text.Trim() != String.Empty)
            {
                
            }
        }

        // keypress para textbox de password
        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (password.Text.Trim() != String.Empty)
                {
                    button_Entrar.Focus();
                }

            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text.Trim() != String.Empty)
            {
                button_Entrar.PerformClick();
            }
        }

        //=============================botones============================
        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            string _usuario = user01.Text.Trim();
            string _clave = password.Text.Trim();

            if (_usuario == string.Empty)
            {
                MessageBox.Show("revisa el usuario", "Fundamento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (_clave == string.Empty)
            {
                MessageBox.Show("revisa el password", "Fundamento",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                return;
            }
            EntrarApp(_usuario, _clave);
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        private void EntrarApp(string _usuario, string _password)
        {
            string rutaArchivo = @"D:\texto.txt";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("Archivo no encontrado");
                return;
            }

            bool loginCorrecto = false;

            string[] lineas = File.ReadAllLines(rutaArchivo);

            String usuarioArchivo = null;
            String passwordArchivo = null;


            for (int i = 0; i < lineas.Length; i++)
            {
                if (lineas[i].StartsWith("01") && lineas[i + 1].StartsWith("02"))
                {
                    usuarioArchivo = ExtraerValor(lineas[i], "01");
                    passwordArchivo = ExtraerValor(lineas[i], "02");
                }

                if (_usuario == usuarioArchivo && _password == passwordArchivo)
                {
                    loginCorrecto = true;
                    break;
                }
            }

            if (loginCorrecto)
            {
                this.Hide();
                frmMenu frm = new frmMenu();
                frm.ShowDialog();

                user01.Clear();
                password.Clear();
                user01.Focus();

                this.Show();
            }
        }

        private string  ExtraerValor(string _lineas, string _prefijo)
        {
            string contenido = _lineas.Substring(_prefijo.Length);

            int indiceFin = contenido.IndexOf('#');

            if (indiceFin == -1)
            {
                return contenido.Substring(0, indiceFin).Trim();
            }
            else
            {
                return contenido.Trim();
            }
        }
    }
}
