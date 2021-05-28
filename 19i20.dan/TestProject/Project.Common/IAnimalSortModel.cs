namespace Project.Common
{
    public interface IAnimalSortModel
    {
        string SortOrder { get; set; }
        string SortParameter { get; set; }

        //bool ValidInput(); 
    }
}