using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListObj : MonoBehaviour {
//    public string name;
//    public int iconNumb;

    public Text name, iconNumb;

    public void Display(ListEntry list)
    {
        name.text = list.listName;
        iconNumb.text = list.listIconNumb.ToString();
    }
}
