using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLManager : MonoBehaviour {

    public static XMLManager man;

	// Use this for initialization
	void Awake() {
        man = this;
	}

    public ListDatabase listDat;

    public void SaveLists()
    {
        XmlSerializer ser = new XmlSerializer(typeof(ListDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/XMLFiles/ListData.xml", FileMode.Create); // måste ändra från .dataPath till presistentDataPath. create överskrider den förra informationen bör ändra den om man ska kunna spara fler gånger!!
        ser.Serialize(stream, listDat);
        stream.Close();
    }

    public void LoadList()
    {

    }
}

[System.Serializable]
public class ListEntry
{
    public string listName;
    public int listIconNumb;
    public List<Task> tasks = new List<Task>();

}

[System.Serializable]
public class ListDatabase
{
    public List<ListEntry> listOflists = new List<ListEntry>();

}
