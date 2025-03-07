using DataAccessLibrary.Models;
using System;

namespace DataAccessLibrary.Data;

public class ChoreData : IChoreData
{
    private readonly ISqlDataAccess _sql;

    public ChoreData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<IEnumerable<ChoreModel>> GetAllChores()
    {
        var output = await _sql.LoadDataAsync<ChoreModel, dynamic>("dbo.sp_Chores_GetAll", new { });

        return output;
    }

    public async Task<IEnumerable<ChoreModel>> READ_chores()
    {
        var output = await _sql.LoadDataAsync<ChoreModel, dynamic>("dbo.READ_chores", new {
        });

        return output;
    }

    public async Task UpdateChore(ChoreModel chore)
    {
        await _sql.SaveDataAsync("dbo.sp_Chores_Update", new
        {
            Id = chore.Id,
            KidName = chore.KidName,
            Task = chore.Task,
            IsComplete = chore.IsComplete,
            ChoreDate = chore.ChoreDate
        });
    }
    public async Task UPDATE_Chores(ChoreModel chore)
    {
        await _sql.SaveDataAsync("dbo.UPDATE_chores", new
        {
            Id = chore.Id,
            IsComplete = chore.IsComplete,
        });
    }

    public async Task InsertChore(ChoreModel chore)
    {
        await _sql.SaveDataAsync("dbo.sp_Chores_Insert", new { Kid_Name = chore.KidName, Task = chore.Task, Is_Complete = chore.IsComplete, Chore_Date = chore.ChoreDate});
    }

    public async Task DeleteChore (int id)
    {
        await _sql.SaveDataAsync("dbo.sp_Chores_Delete", new { Id = id });
    }

    public async Task InsertChoreData(DateTime ChoreDate)
    {
        await _sql.SaveDataAsync("dbo.InsertFactChores", new { ChoreDate = ChoreDate});
    }

    public async Task DeleteChoreData(DateTime ChoreDate)
    {
        await _sql.SaveDataAsync("dbo.DeleteFactChores", new { ChoreDate = ChoreDate });
    }
}
