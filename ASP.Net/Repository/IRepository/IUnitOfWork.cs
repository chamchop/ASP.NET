using ASP.Net.DataAccess.Repository.IRepository;

namespace ASP.Net.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepository CoverType { get; }

        void Save();
    }
}
