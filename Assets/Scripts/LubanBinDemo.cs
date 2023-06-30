using System.Collections;
using System.Collections.Generic;
using System.IO;
using Bright.Serialization;
using UnityEngine;
using UnityEngine.Profiling;

public class LubanBinDemo : MonoBehaviour
{
    private static string byteDirPath;
    private cfg.Tables tables;
    private void Start()
    {
#if UNITY_EDITOR
        byteDirPath = "../GenerateDatas/";
#else
		byteDirPath = Application.persistentDataPath + "/";
#endif
    }
    void LoadByteData()
    {
        Profiler.BeginSample("LoadByteData");
        tables = new cfg.Tables(LoadIdxByteBuf, LoadDataByteBuf);
        Profiler.EndSample();
    }


    public void Find()
    {
        Profiler.BeginSample("Find");
        if (tables == null) LoadByteData();
        cfg.buff.Buff buff = tables.TbBuff.Get(5005, 20);
        Debug.Log(string.Format("id = {0}, level = {1}, name = {2}, desc = {3}", buff.Id, buff.Level, buff.Name, buff.Desc));
        Profiler.EndSample();
    }

    private static ByteBuf LoadIdxByteBuf(string file)
    {
        return new ByteBuf(File.ReadAllBytes(byteDirPath + "bidx/buff_tbbuff.bytes"));
    }
    private static ByteBuf LoadDataByteBuf(string file)
    {
        return new ByteBuf(File.ReadAllBytes(byteDirPath + "bytes/buff_tbbuff.bytes"));
    }
}