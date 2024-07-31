using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class TestSQLite : MonoBehaviour
{
    private const string DatabasePath = @"E:\Project\SQLite\Database\Test.db";

    private void Start()
    {
        SQLiteConnection connection = new(DatabasePath);
        Student student = connection.Get<Student>(1);
        Debug.Log(student.Name);
    }

    public class Student
    {
        [PrimaryKey, AutoIncrement, NotNull, Unique]
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class Class
    {
        [PrimaryKey, AutoIncrement, NotNull, Unique]
        public int Id { get; set; }

        public string Member { get; set; }
    }
}
