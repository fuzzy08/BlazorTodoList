namespace TodoList.ViewModels
{
    public interface ICategoryModel
    {
        int CategoryID { get; set; }
        string Description { get; set; }
        int PersonID { get; set; }
        string Title { get; set; }
    }
}