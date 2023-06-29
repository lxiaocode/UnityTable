using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SQLiteHelper : MonoBehaviour
{
    private void Start()
    {
        Debug.Log($"persistentDataPath = {Application.persistentDataPath}");
        Debug.Log($"dataPath = {Application.dataPath}");
        Debug.Log($"streamingAssetsPath = {Application.streamingAssetsPath}");
    }

    public void SelectDemo()
    {
        string dbPath = "data source = " + Application.dataPath + "/ConfigurationDemo.db";
        Debug.Log(dbPath);
        // 建立连接
        SqliteConnection connection = new SqliteConnection(dbPath);
        connection.Open();

        // 实例化一个Command
        SqliteCommand command = connection.CreateCommand();


        // 赋值sql语句
        // command.CommandText = "SELECT * FROM buff WHERE Id=5005 and LEVEL=20";
        // SELECT name FROM sqlite_master
        command.CommandText = "SELECT name FROM sqlite_master";


        // 执行读取数据
        SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            /**
            var id = reader.GetInt32(reader.GetOrdinal("Id"));
            var level = reader.GetInt32(reader.GetOrdinal("Level"));
            var name = reader.GetString(reader.GetOrdinal("Name"));
            var desc = reader.GetString(reader.GetOrdinal("Desc"));

            Debug.Log(string.Format("id = {0}, level = {1}, name = {2}, desc = {3}", id, level, name, desc));
            **/
            var name = reader.GetString(reader.GetOrdinal("name"));
            Debug.Log(name);
        }


        // 关闭数据库
        reader.Close();
        command.Cancel();
        connection.Close();
    }
}
