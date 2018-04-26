using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSwitch : MonoBehaviour
{
    public Sprite[] icons = new Sprite[10];

    void icon(int iconnumber)
    {
        GetComponent<Image>().sprite = icons[iconnumber];
    }
}
