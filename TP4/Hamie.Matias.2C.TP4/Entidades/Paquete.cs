﻿using System;
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
        }
        #endregion

        public void MockCicloDeVida()
        {
            System.Threading.Thread.Sleep(2000);//No olvidar de cambiar los ms

            switch (this.estado)
            {
                case EEstado.Ingresado:
                    this.estado = EEstado.EnViaje;
                    break;
                case EEstado.EnViaje:
                    this.estado = EEstado.Entregado;
                    break;
            }
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;

            return String.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        #region Sobrecarga
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #endregion
    }
}
