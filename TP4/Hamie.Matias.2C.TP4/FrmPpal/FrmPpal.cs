using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        Correo correo = new Correo();

        public FrmPpal()
        {
            InitializeComponent();
        }

        #region Métodos

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            rtbMostrar.Text = "";
            foreach (Paquete paquete in this.correo.Paquetes)
            {
                rtbMostrar.Text += paquete.ToString();
            }

            GuardaString.Guardar(rtbMostrar.Text, "salida.txt");
        }

        private void ActualizarEstados()
        {
            string infoDelPaquete = "";

            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in this.correo.Paquetes)
            {
                infoDelPaquete = paquete.ToString();

                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(infoDelPaquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(infoDelPaquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(infoDelPaquete);
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            try
            {
                this.correo += p;
                p.InformaEstado += paq_InformaEstado;
                this.ActualizarEstados();
            }
            catch (TrackingIdRepetidoException)
            {
                MessageBox.Show("Paquete Repetido!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {

        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMostrar.Text = "";
            string paquete =(string)lstEstadoEntregado.SelectedItem;

            if (paquete!=null)
            {
                rtbMostrar.Text += paquete;
            }
        }
    }
}
