//using System;
//using Unity.VisualScripting.Dependencies.Sqlite;
//using UnityEditor;
//using UnityEngine;
//using System.Diagnostics;
//using System.Linq;

//public class TestSQLiteEditor : EditorWindow
//{
//    private static Stopwatch stopwatch = new();
//    private static SQLiteConnection connection;

//    [MenuItem("Study/SQLite")]
//    public static void ShowWindow()
//    {
//        GetWindow<TestSQLiteEditor>("SQLite");
//        connection = new(@"E:\Project\SQLite\Database\Test_2.db");
//        CalculateTime(() =>
//        {
//            StaticData.LoadOneData<StaticData.Student>(@"E:\Project\Study\Assets\SQLite\Table\Output\Binary\Student.bytes");
//        });
//    }

//    private void OnGUI()
//    {
//        if (GUILayout.Button("SQLiteRead"))
//        {
//            SQLiteRead();
//        }
//        if (GUILayout.Button("TableToolRead"))
//        {
//            TableToolRead();
//        }
//    }

//    private void SQLiteRead()
//    {
//        CalculateTime(() =>
//        {
//            UnityEngine.Debug.Log(connection.Table<Student>().First(student => student.Name.Equals("�������")).Id);
//        });
//    }

//    private void TableToolRead()
//    {
//        CalculateTime(() =>
//        {
//            UnityEngine.Debug.Log(StaticData.Student.NameToData["�������"].Id);
//        });
//    }

//    private static void CalculateTime(Action action)
//    {
//        stopwatch.Restart();
//        action?.Invoke();
//        stopwatch.Stop();
//        UnityEngine.Debug.Log($"{action} Operation took {stopwatch.ElapsedMilliseconds} ms");
//    }

//    public class Student
//    {
//        [PrimaryKey, AutoIncrement, NotNull, Unique]
//        public int Id { get; set; }

//        [NotNull]
//        public string Name { get; set; }

//        public int Age { get; set; }
//    }

//    public class Class
//    {
//        [PrimaryKey, AutoIncrement, NotNull, Unique]
//        public int Id { get; set; }

//        public string Member { get; set; }
//    }
//}
