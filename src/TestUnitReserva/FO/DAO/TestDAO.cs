using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FOReserva.DataAccess.DataAccessObject.Common;
using System.Diagnostics;

namespace TestUnitReserva.FO.DAO
{
    [TestClass]
    public class TestDAO
    {
        [TestMethod]
        public void TestDAOExecuteQuery()
        {
            var instanceDAO = new FOReserva.DataAccess.DataAccessObject.Common.DAO();
            DAOResult result = null;

            result = instanceDAO.OpenConnection();
            Debug.WriteLine(String.Format("Message OpenConnection: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

            result = instanceDAO.ExecuteQuery(@"SELECT 'ok' AS ""output""", doThis: (reader) => {
                var output = reader.GetString(0);
                Debug.WriteLine(String.Format("Data from DB: {0}", output));

            });
            Debug.WriteLine(String.Format("Message ExecuteQuery: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

            result = instanceDAO.CloseConnection();
            Debug.WriteLine(String.Format("Message CloseConnection: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

        }

        [TestMethod]
        public void TestDAOExecuteNoQuery()
        {
            var instanceDAO = new FOReserva.DataAccess.DataAccessObject.Common.DAO();
            DAOResult result = null;

            result = instanceDAO.OpenConnection();
            Debug.WriteLine(String.Format("Message OpenConnection: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

            result = instanceDAO.ExecuteNoQuery(String.Format(@"INSERT INTO dbo.TableForTUnit VALUES ('TestRevision at {0}')", DateTime.Now.ToString("dd/MM/yyyy")));
            Debug.WriteLine(String.Format("Message ExecuteQuery: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

            result = instanceDAO.CloseConnection();
            Debug.WriteLine(String.Format("Message CloseConnection: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

        }

        [TestMethod]
        public void TestDAOExecuteStoreProcedure()
        {
            var instanceDAO = new FOReserva.DataAccess.DataAccessObject.Common.DAO();
            DAOResult result = null;

            result = instanceDAO.OpenConnection();
            Debug.WriteLine(String.Format("Message OpenConnection: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

            result = instanceDAO.ExecuteStoreProcedure("M20_TestProcedure", new { thisAt = DateTime.Now.ToString("dd/MM/yyyy") });
            Debug.WriteLine(String.Format("Message ExecuteQuery: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

            result = instanceDAO.CloseConnection();
            Debug.WriteLine(String.Format("Message CloseConnection: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

        }

        [TestMethod]
        public void TestDAOExecuteStoreProcedureWithResult()
        {
            var instanceDAO = new FOReserva.DataAccess.DataAccessObject.Common.DAO();
            DAOResult result = null;

            result = instanceDAO.OpenConnection();
            Debug.WriteLine(String.Format("Message OpenConnection: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

            result = instanceDAO.ExecuteStoreProcedureWithResult("M20_TestProcedure", new { thisAt = DateTime.Now.ToString("dd/MM/yyyy") }, doThis: (reader) => {
                var status = reader.GetInt32(0);
                Debug.WriteLine(String.Format("Data from DB: {0}", status));

            });
            Debug.WriteLine(String.Format("Message ExecuteQuery: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

            result = instanceDAO.CloseConnection();
            Debug.WriteLine(String.Format("Message CloseConnection: {0}", result.Message));
            Assert.IsTrue(result.ProcessFinishCorrectly);

        }

    }
}
