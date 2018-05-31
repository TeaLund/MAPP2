using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ListDisplay : MonoBehaviour {

    public List list;
    public Text nameText;
    public Image iconImage;
    public Sprite[] icons = new Sprite[10];

    private void Update()
    {
        list = GetComponent<List>();
        nameText.text = list.listName;
        if(SceneManager.GetActiveScene().buildIndex == 0)
            iconImage.sprite = icons[list.iconNumber];
    }

}
