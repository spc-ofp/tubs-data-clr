// -----------------------------------------------------------------------
// <copyright file="PortTest.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Tests
{
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class PortTest : BaseTest
    {
        [Test]
        public void TestGetPortList()
        {
            var ports = Session.CreateCriteria(typeof(Port)).List<Port>();
            Assert.NotNull(ports);
            Assert.Greater(ports.Count, 0);
        }

        [Test]
        public void TestGetPort()
        {
            var port = Session.Get<Port>("JPABU");
            Assert.NotNull(port);
            Assert.AreEqual("JPABU", port.PortCode.Trim());
            Assert.AreEqual("ABURATSU", port.Name.Trim());
        }
    }
}
