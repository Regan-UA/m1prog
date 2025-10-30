using System;
using System.Data;
using System.Transactions;
using Microsoft.Data.Sqlite;
class Program
{
    static string dbPath = @"C:\mediaCollege\M1Prog\Sqlite\opdracht1\opdracht_1.db";
    static string connString => $"Data Source={dbPath}";
    static void Main()
    {
        using var connection = new SqliteConnection(connString);
        connection.Open();

        while (true)
        {
            Instructions();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CheckValues(connection);
                    break;
                case "2":
                    Console.WriteLine("\nEnter values - Name of ingredient, Have, Bought, Used (Use 1 space or 1 comma to separate values): ");
                    string values = Console.ReadLine();
                    string[] splitValues = values.Split(' ', ',');
                    UpdateValues(connection, splitValues[0], float.Parse(splitValues[1]), float.Parse(splitValues[2]), float.Parse(splitValues[3]));
                    break;
                case "3":
                    Console.WriteLine("Enter the name of the table to delete: ");
                    string tableName = Console.ReadLine();
                    DeleteIngredient(connection, tableName);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
    public static void Instructions()
    {
        Console.WriteLine("\nEnter command: 1 - Check Values, 2 - Update Values, 3 - Delete Table, 4 - Exit.: ");
    }
    public static void CheckValues(SqliteConnection connection)
    {
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Ingredients";

        using var reader = command.ExecuteReader();

        for (int i = 0; i < reader.FieldCount; i++)
            Console.Write(reader.GetName(i) + "\t");
        Console.WriteLine();

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write(reader.GetValue(i) + "\t");
            Console.WriteLine();
        }
    }
    public static void UpdateValues(SqliteConnection connection, string name, float have, float bought, float used)
    {
        using var command = connection.CreateCommand();

        CreateTable(connection);

        command.CommandText = @"
        INSERT INTO Ingredients (name, have, bought, used)
        VALUES (@name, @have, @bought, @used)
        ON CONFLICT(name) DO UPDATE SET
            have = excluded.have,
            bought = excluded.bought,
            used = excluded.used
    ";
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@have", have);
        command.Parameters.AddWithValue("@bought", bought);
        command.Parameters.AddWithValue("@used", used);

        int rowsAffected = command.ExecuteNonQuery();
        Console.WriteLine($"{rowsAffected} row(s) inserted or updated.");
    }
    public static void CreateTable(SqliteConnection connection)
    {
        using var command = connection.CreateCommand();
        command.CommandText = @"
        CREATE TABLE IF NOT EXISTS Ingredients (
            name TEXT PRIMARY KEY,
            have REAL,
            bought REAL,
            used REAL
        )";
        command.ExecuteNonQuery();
    }
    public static void DeleteIngredient(SqliteConnection connection, string name)
{
    using var command = connection.CreateCommand();
    command.CommandText = "DELETE FROM Ingredients WHERE name = @name";
    command.Parameters.AddWithValue("@name", name);

    int rowsAffected = command.ExecuteNonQuery();
    if (rowsAffected > 0)
        Console.WriteLine($"Ingredient '{name}' was deleted successfully.");
    else
        Console.WriteLine($"Ingredient '{name}' was not found.");
}
}
