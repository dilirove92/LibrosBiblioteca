using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Salir_btn : Form
    {
        public Salir_btn()
        {
            InitializeComponent();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTextoLibre.Text = "";
            txtAutor.Text="";
            txtTitulo.Text="";
            txtEditor.Text="";
            Materias_cbx.Text="";
            descriptores_cbx.Text="";
            CumplirTodo_rbtn.AutoCheck = false;
            NoCumplirTodo_rbtn.AutoCheck = false;
            Formato_cbx.Text = "";
            Idioma_cbx.Text = "";
            txtfecha.Text = "";
            EnGrupos_cbx.Text = "";
            OrdenadoPor_cbx.Text = "";

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Buscar_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
