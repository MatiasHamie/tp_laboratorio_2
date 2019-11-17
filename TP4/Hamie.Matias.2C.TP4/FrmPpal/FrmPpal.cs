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

        /// <summary>
        /// Muestra informacion del paquete deseado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                rtbMostrar.Text += elemento.MostrarDatos(elemento);
            }
        }

        /// <summary>
        /// Borra los listBox y los actualiza según estado de los paquetes
        /// </summary>
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

        /// <summary>
        /// Agrega paquetes al correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handler del evento InformaEstado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Muestra información de todos los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Muestra información del paquete seleccionado en el rtbMostrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
            //rtbMostrar.Text = "";
            //string paquete =(string)lstEstadoEntregado.SelectedItem;

            //if (paquete!=null)
            //{
            //    rtbMostrar.Text += paquete;
            //}
        }
    }
}
