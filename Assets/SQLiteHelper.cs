using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SQLiteHelper : MonoBehaviour
{
    private string dbPath;

    private SqliteConnection connection;
    private SqliteCommand command;


    private void Awake()
    {
#if UNITY_ANDROID
        dbPath = "data source = " + Application.persistentDataPath + "/ConfigurationDemo.db";
#else
        dbPath = "data source = " + Application.dataPath + "/ConfigurationDemo.db";
#endif


    }


    private void Start()
    {
        // 建立连接
        connection = new SqliteConnection(dbPath);
        connection.Open();

        // 实例化一个Command
        command = connection.CreateCommand();
    }

    public void SelectDemo()
    {
        //Debug.Log(dbPath);

        UnityEngine.Profiling.Profiler.BeginSample("SQLite Select");
        SelectBuff("5005", "20");
        UnityEngine.Profiling.Profiler.EndSample();
        //SelectNpc("56504");
        //SelectSkill("9055");

    }

    private void SelectSkill(string id)
    {
        //SqliteCommand command = connection.CreateCommand();

        command.CommandText = $"SELECT * FROM skill WHERE id={id}";


        // 执行读取数据
        SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var _id = reader.GetInt32(reader.GetOrdinal("Id"));
            var _note = reader.GetString(reader.GetOrdinal("Note"));
            var _skillname = reader.GetString(reader.GetOrdinal("SkillName"));

            Debug.Log(string.Format("id = {0}, _note = {1}, _skillname = {2}", _id, _note, _skillname));

        }

        // 关闭数据库
        reader.Close();
       // command.Cancel();
    }

    private void SelectBuff(string id, string level)
    {
       // SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM buff WHERE id={id} and level={level}";

        // 执行读取数据
        SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var _id = reader.GetInt32(reader.GetOrdinal("Id"));
            var _level = reader.GetInt32(reader.GetOrdinal("Level"));
            var _name = reader.GetString(reader.GetOrdinal("Name"));
            var _desc = reader.GetString(reader.GetOrdinal("Desc"));

            Debug.Log(string.Format("id = {0}, level = {1}, name = {2}, desc = {3}", _id, _level, _name, _desc));

        }

        reader.Close();
     //   command.Cancel();
    }

    private void SelectAvatar(string id, string level)
    {
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM buff WHERE id={id} and level={level}";

        // 执行读取数据
        SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var _id = reader.GetInt32(reader.GetOrdinal("Id"));
            var _level = reader.GetInt32(reader.GetOrdinal("Level"));
            var _name = reader.GetString(reader.GetOrdinal("Name"));
            var _desc = reader.GetString(reader.GetOrdinal("Desc"));

            Debug.Log(string.Format("id = {0}, level = {1}, name = {2}, desc = {3}", _id, _level, _name, _desc));

        }

        reader.Close();
        command.Cancel();
    }

    private void SelectGoods(string id, string level)
    {
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM buff WHERE id={id} and level={level}";

        // 执行读取数据
        SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var _id = reader.GetInt32(reader.GetOrdinal("Id"));
            var _level = reader.GetInt32(reader.GetOrdinal("Level"));
            var _name = reader.GetString(reader.GetOrdinal("Name"));
            var _desc = reader.GetString(reader.GetOrdinal("Desc"));

            Debug.Log(string.Format("id = {0}, level = {1}, name = {2}, desc = {3}", _id, _level, _name, _desc));

        }

        reader.Close();
        command.Cancel();
    }

    private void SelectNpc(string id)
    {
     //   SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM npc WHERE id={id}";

        // 执行读取数据
        SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var _id = reader.GetInt32(reader.GetOrdinal("ID"));
            var _title = reader.GetString(reader.GetOrdinal("Title"));
            var _name = reader.GetString(reader.GetOrdinal("Name"));
            var _desc = reader.GetString(reader.GetOrdinal("Desc"));

            Debug.Log(string.Format("id = {0}, title = {1}, name = {2}, desc = {3}", _id, _title, _name, _desc));

        }

        reader.Close();
   //     command.Cancel();
    }
}
