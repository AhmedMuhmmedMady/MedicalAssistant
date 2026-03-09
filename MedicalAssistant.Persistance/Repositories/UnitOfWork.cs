using MedicalAssistant.Domain.Contracts;
using MedicalAssistant.Persistance.Data.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalAssistant.Persistance.Repositories
{
    /// <summary>
    /// Unit of Work implementation.
    /// Manages transactions and ensures all operations execute as a single unit.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicalAssistantDbContext _context;
        private IDbContextTransaction? _transaction;
        private bool _disposed;

        private IPatientRepository? _patients;

        public UnitOfWork(MedicalAssistantDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IPatientRepository Patients => _patients ??= new PatientRepository(_context);

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        /// <inheritdoc/>
        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();

                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        /// <inheritdoc/>
        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <summary>
        /// Disposes resources.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
