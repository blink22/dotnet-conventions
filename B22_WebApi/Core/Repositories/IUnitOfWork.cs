namespace Core.Repositories
{

    // Unit Of Work Interface, Read More About Unit Of Work pattern Here : https://dotnettutorials.net/lesson/unit-of-work-csharp-mvc/#:~:text=The%20Unit%20of%20Work%20Pattern,will%20roll%20back%20the%20transaction.
    public interface IUnitOfWork : IDisposable
    {
        IExampleRepository ExampleRepository { get; }

        Task<int> CommitAsync();
    }
}
