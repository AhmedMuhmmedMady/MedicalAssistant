namespace MedicalAssistant.Domain.Contracts
{
    /// <summary>
    /// Unit of Work interface.
    /// Used for managing transactions and ensuring all operations execute as a single unit.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Patient repository.
        /// </summary>
        IPatientRepository Patients { get; }

        /// <summary>
        /// Saves all changes to the database.
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Begins a new transaction.
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Commits the transaction and saves changes.
        /// </summary>
        Task CommitTransactionAsync();

        /// <summary>
        /// Rolls back the transaction.
        /// </summary>
        Task RollbackTransactionAsync();
    }
}
