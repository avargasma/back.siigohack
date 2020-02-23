using System;
using System.Collections.Generic;
using System.Text;
namespace ET
{
    using System;

    public abstract class Resultado
    {

        #region Variables
        private bool _logExitoso;
        private Error _error;
        #endregion

        #region Propiedades
        public bool Exitoso
        {
            get { return _logExitoso; }
            set { _logExitoso = value; }
        }
        public Error Error
        {
            get { return _error; }
            set { _error = value; }
        }
        #endregion

    }

    public class Error
    {
        #region Variables
        private string _mensajeUsuario;
        private string _mensaje;
        private string _tipoError;
        private string _fuente;
        private string _pila;
        private string _mensajeInnerException;
        #endregion

        #region Propiedades
        public string MensajeUsuario
        {
            get { return _mensajeUsuario; }
            set { _mensajeUsuario = value; }
        }

        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public string TipoError
        {
            get { return _tipoError; }
            set { _tipoError = value; }
        }

        public string Fuente
        {
            get { return _fuente; }
            set { _fuente = value; }
        }

        public string Pila
        {
            get { return _pila; }
            set { _pila = value; }
        }

        public string MensajeInnerException
        {
            get { return _mensajeInnerException; }
            set { _mensajeInnerException = value; }
        }
        #endregion

        public Error(Exception ex, string strMensajeUsuario)
        {
            this.MensajeUsuario = strMensajeUsuario;
            this.Mensaje = ex.ToString();
            this.Fuente = ex.Source;
            this.Pila = ex.StackTrace;
            if (ex.InnerException != null)
            {
                this.MensajeInnerException = ex.InnerException.Message;
            }
        }
    }

    public class RSV_Global<T> : Resultado
    {
        private T _datos;

        public T Datos
        {
            get { return _datos; }
            set { _datos = value; }
        }

       
    }
}
