﻿namespace DataAccessLibrary.Models;

public class PersonModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[] PlayerImage { get; set; }
}
