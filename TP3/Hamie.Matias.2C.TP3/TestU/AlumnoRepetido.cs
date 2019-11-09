using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestU
{
    [TestClass]
    public class AlumnoRepetido
    {
        [TestMethod]
        public void TestMethod1()
        {
            Universidad universidad = new Universidad();
            Alumno a1 = new Alumno(1, "Matias", "Hamie", "35630323",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(1, "Federico", "Jimenez", "35630323",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);

            universidad += a1;

            try
            {
                universidad += a2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
    }
}
