using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ukvdb : MonoBehaviour
{
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    // 导入 native 函数
    [DllImport("__Internal")]
    private static extern void open_kvdb(string dbFile);
    [DllImport("__Internal")]
    private static extern string select(string key);
#elif UNITY_ANDROID
    [DllImport("ukvdb")]
    private static extern void open_kvdb(string dbFile);
    [DllImport("ukvdb")]
    private static extern string select(string key);
#endif
    
    private void Start()
    {
        open_kvdb(System.IO.Path.Combine(Application.persistentDataPath, "kvdb-test.kvdb"));
    }

    public void Select()
    {
        UnityEngine.Profiling.Profiler.BeginSample("SQLite Select");
        string value = select("buff500520");
        UnityEngine.Profiling.Profiler.EndSample();
        Debug.Log($"500520 - {value}");
    }
    
}
