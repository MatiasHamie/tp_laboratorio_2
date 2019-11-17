using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        #region Campos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Delegado y Evento
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region Tipos anidados
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region Métodos

        #region Constructores
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = Paquete.EEstado.Ingresado;
        }
        #endregion

        /// <summary>
        /// Actualiza cada 4 segundos el estado del paquete
        /// Pasando por Ingresado -> EnViaje -> Entregado
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != Paquete.EEstado.Entregado)
            {
                System.Threading.Thread.Sleep(4000);

                switch (this.estado)
                {
                    case EEstado.Ingresado:
                        this.estado = EEstado.EnViaje;
                        break;
                    case EEstado.EnViaje:
                        this.estado = EEstado.Entregado;
                        break;
                }
                InformaEstado.Invoke(this,null);
            }
            
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Muestra datos del paquete
        /// </summary>
        /// <returns>string datosPaquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Retorna informacion del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>string datosPaquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;

            return String.Format("{0} para {1}\n", p.trackingID, p.direccionEntrega);
        }

        #region Sobrecarga
        /// <summary>
        /// Dos paquetes serán iguales si tienen el mismo trackingID
        /// </summary>
        /// <param name="p1">Paquete 1</param>
        /// <param name="p2">Paquete 2</param>
        /// <returns>true si son iguales, caso contrario false</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        /// <summary>
        /// Dos paquetes serán distintos si no tienen el mismo trackingID
        /// </summary>
        /// <param name="p1">Paquete 1</param>
        /// <param name="p2">Paquete 2</param>
        /// <returns>true si son iguales, caso contrario false</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #endregion
    }
}
