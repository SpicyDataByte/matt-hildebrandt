namespace DataAccessLibrary.Models;

public class ChoreModel
{
    public int Id { get; set; }
    public string KidName { get; set; }
    public string Task { get; set; }
    public bool IsComplete{ get; set; }
    public DateTime ChoreDate { get; set; }
}
