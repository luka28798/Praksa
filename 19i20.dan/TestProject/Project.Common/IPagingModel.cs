namespace Project.Common
{
    public interface IPagingModel
    {
        int DataPerPage { get; set; }
        int Page { get; set; }
    }
}