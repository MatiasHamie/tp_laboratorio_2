using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestU
{
    [TestClass]
    public class DniInvalido
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestMethod1()
        {
            Alumno a = new Alumno(7, "Matias", "Hamie", "asd12345", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
        }
    }
}
