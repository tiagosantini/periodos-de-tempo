using Periodos.LibraryClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Periodos.Tests
{
    [TestClass]
    public class PeriodoTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NaoDeveSerDataValida()
        {
            _ = new Periodo("aaaa");
        }

        [TestMethod]
        public void DeveRetornarDiaHoje()
        {
            Periodo data = new Periodo("27/05/2021 09:05");

            Assert.AreEqual("Hoje às 09:05", data.TempoDecorrido);
        }

        [TestMethod]
        public void DeveRetornarDiasDecorridos()
        {
            Periodo data = new Periodo("25/05/2021");

            Assert.AreEqual("Dois dias atrás", data.TempoDecorrido);
        }

        [TestMethod]
        public void DeveRetornarSemanasDecorridas()
        {
            Periodo data = new Periodo("20/05/2021");

            Assert.AreEqual("Uma semana atrás", data.TempoDecorrido);
        }

        [TestMethod]
        public void DeveRetornarMesesDecorridos()
        {
            Periodo data = new Periodo("20/04/2021");

            Assert.AreEqual("Dois meses e uma semana atrás", data.TempoDecorrido);
        }

        [TestMethod]
        public void DeveRetornarAnosDecorridos()
        {
            Periodo data = new Periodo("27/05/2011");

            Assert.AreEqual("Dez anos atrás", data.TempoDecorrido);
        }

    }
}
