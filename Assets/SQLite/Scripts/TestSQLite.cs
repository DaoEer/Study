using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class TestSQLite : MonoBehaviour
{
    private const string DatabasePath = "D:/Work/Unity/Study/Assets/SQLite/Database/Test.db";

    private void Start()
    {
        SQLiteConnection connection = new(DatabasePath);
        Member member = connection.Get<Member>(1);
        Debug.Log(member.Name);
    }

    public class Member
    {
        [PrimaryKey, NotNull, AutoIncrement, Unique]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public int Age {  get; set; }
    }
}
