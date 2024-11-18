using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem  
{

    public static void SaveData(CurrencyManager currencyManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "Currency.Data";

        FileStream stream = new FileStream(path, FileMode.Create);

        CurrencyData data = new CurrencyData(currencyManager);

        formatter.Serialize(stream,data);  
        stream.Close();

    }

    public static CurrencyData LoadData()
    {
        string path = Application.persistentDataPath + "Currency.Data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CurrencyData data = formatter.Deserialize(stream) as CurrencyData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save File not found "+path);
            return null;
        }
         
    }




   
}
