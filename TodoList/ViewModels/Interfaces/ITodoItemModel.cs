namespace TodoList.ViewModels
{
    public interface ITodoItemModel
    {
        int CategoryID { get; set; }
        bool Completed { get; set; }
        string CreatedDate { get; set; }
        string Description { get; set; }
        int PersonID { get; set; }
        string Title { get; set; }
        int TodoItemID { get; set; }
    }
}