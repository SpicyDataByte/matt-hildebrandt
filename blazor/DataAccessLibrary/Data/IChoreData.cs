using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data;

public interface IChoreData
{
    Task DeleteChore(int id);
    Task<IEnumerable<ChoreModel>> GetAllChores();
    Task<IEnumerable<ChoreModel>> READ_chores();
    Task InsertChore(ChoreModel chore);
    Task UpdateChore(ChoreModel chore);
    Task UPDATE_Chores(ChoreModel chore);
    Task InsertChoreData(DateTime ChoreDate);
    Task DeleteChoreData(DateTime ChoreDate);
}
