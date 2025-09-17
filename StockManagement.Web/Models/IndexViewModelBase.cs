namespace StockManagement.Web.Models
{
    public abstract class IndexViewModelBase
    {
        public int TotalItems { get; set; }
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
    }

    public abstract class IndexViewModelBase<T>: IndexViewModelBase
    {
        public IEnumerable<T> Results { get; set; } = [];

        public IndexViewModelBase()
        {

        }

        public IndexViewModelBase(IEnumerable<T> results)
        {
            Results = results;
        }
    }
}
