using UnityEngine;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

public class CSVDeserializer : MonoBehaviour
{
    public string csvFilePath;
    private Dictionary<string, Buff> dataObjects;// CSV文件路径


    public void DeserializeCSV()
    {
        dataObjects = new Dictionary<string, Buff>();
        using (StreamReader reader = new StreamReader(csvFilePath))
        using (CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
        {
            while (csvReader.Read())
            {
                Buff dataObject = csvReader.GetRecord<Buff>();
                dataObjects.Add(string.Format("{0}/{1}", dataObject.Id, dataObject.Level), dataObject);
            }
        }
        Debug.Log("DeserializeCSV sucess");
    }

    public void FindDemo()
    {
        if (dataObjects == null) DeserializeCSV();
        var dataObject = dataObjects[string.Format("{0}/{1}", 5005, 20)];
        Debug.Log(string.Format("id = {0}, level = {1}, name = {2}, desc = {3}", dataObject.Id, dataObject.Level, dataObject.Name, dataObject.Desc));
        
    }
}