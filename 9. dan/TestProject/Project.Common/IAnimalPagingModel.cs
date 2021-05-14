namespace Project.Common
{
    public interface IAnimalPagingModel
    {
        int DataPerPage { get; set; }
        int Page { get; set; }
    }
}