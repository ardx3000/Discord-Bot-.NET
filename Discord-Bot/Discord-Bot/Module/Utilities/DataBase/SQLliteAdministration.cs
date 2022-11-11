using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Discord_Bot.Module.Utilities;

public class SQLliteAdministration: DbContext
{
     string path = Environment.GetEnvironmentVariable("Path");
     
     protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={path}");
    
}