using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListObj : MonoBehaviour {
//    public string name;
//    public int iconNumb;

    public Text text, iconNumb;

    public void Display(ListEntry list)
    {
        text.text = list.listName;
        iconNumb.text = list.listIconNumb.ToString();
    }
}
