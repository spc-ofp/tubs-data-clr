// -----------------------------------------------------------------------
// <copyright file="DataServiceTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
namespace Spc.Ofp.Tubs.DAL.Tests
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class DataServiceTest : BaseTest
    {
        [Test]
        public void TestExecuteQuery()
        {
            IList results = TubsDataService.Execute(@"select GETDATE() AS Foo, GETDATE() AS Bar");
            Assert.NotNull(results);
            Console.WriteLine("Result Count: " + results.Count);
            foreach (object result in results)
            {
                Console.WriteLine("Result is of type: " + result.GetType());
            }
        }

        [Test]
        public void TestExecuteWithParams()
        {
            string query = @"select COUNT(*) from [TUBS_MASTER_ENTRY].[obsv].[s_day] WHERE obstrip_id = ?";
            IList results = TubsDataService.Execute(query, 70);
            Assert.NotNull(results);
            Assert.AreEqual(1, results.Count);
            Assert.IsInstanceOf<int>(results[0]);
            Assert.AreEqual(20, (int)results[0]);
        }
    }
}
