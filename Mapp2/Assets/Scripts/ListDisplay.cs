using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListDisplay : MonoBehaviour {

    public List list;

    public Text nameText;

    public Image iconImage;

    private void Start()
    {
        list = GetComponent<List>();

        nameText.text = list.listName;

        //iconImage.sprite = icons[list.iconNumber];
    }

}
