using System;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEngine;
using System.Diagnostics;
using System.Linq;

public class TestSQLiteEditor : EditorWindow
{
    private static Stopwatch stopwatch = new();
    private static SQLiteConnection connection;

    [MenuItem("Study/SQLite")]
    public static void ShowWindow()
    {
        GetWindow<TestSQLiteEditor>("SQLite");
        connection = new(@"E:\Project\SQLite\Database\Test_2.db");
        CalculateTime(() =>
        {
            StaticData.LoadOneData<StaticData.Student>(@"E:\Project\Study\Assets\SQLite\Table\Output\Binary\Student.bytes");
        });
    }

    private void OnGUI()
    {
        if (GUILayout.Button("SQLiteRead"))
        {
            SQLiteRead();
        }
        if (GUILayout.Button("TableToolRead"))
        {
            TableToolRead();
        }
    }

    private void SQLiteRead()
    {
        CalculateTime(() =>
        {
            UnityEngine.Debug.Log(connection.Table<TestSQLite.Student>().First(student => student.Name.Equals("Óá°ËÈý°Ë")).Id);
        });
    }

    private void TableToolRead()
    {
        CalculateTime(() =>
        {
            UnityEngine.Debug.Log(StaticData.Student.NameToData["Óá°ËÈý°Ë"].Id);
        });
    }

    private static void CalculateTime(Action action)
    {
        stopwatch.Restart();
        action?.Invoke();
        stopwatch.Stop();
        UnityEngine.Debug.Log($"{action} Operation took {stopwatch.ElapsedMilliseconds} ms");
    }
}
