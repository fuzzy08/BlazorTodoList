namespace TodoList.ViewModels
{
    public interface IPersonModel
    {
        string BirthDate { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int PersonID { get; set; }
    }
}