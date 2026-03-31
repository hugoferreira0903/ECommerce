using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ECommerceInfrastructure.Data {
    public class DbSession : IDisposable {

        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; private set; }


        public DbSession(IDbConnection connection) {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            if (Connection.State != ConnectionState.Open) Connection.Open();
        }

        // Construtor conveniente para SQL Server a partir de connection string
        public DbSession(string connectionString) {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException("Connection string não pode ser vazia.", nameof(connectionString));
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        // Inicia uma transação (opcionalmente define o IsolationLevel)
        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) {
            if (Connection == null) throw new InvalidOperationException("Conexão não inicializada.");
            if (Connection.State != ConnectionState.Open) Connection.Open();
            Transaction = Connection.BeginTransaction(isolationLevel);
            return Transaction;
        }

        public void Commit() {
            if (Transaction == null) return;
            Transaction.Commit();
            Transaction.Dispose();
            Transaction = null;
        }

        public void Rollback() {
            if (Transaction == null) return;
            Transaction.Rollback();
            Transaction.Dispose();
            Transaction = null;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                
                Transaction?.Dispose();
                Connection.Dispose();
            }
        }
    }
}
