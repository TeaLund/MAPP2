﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDisplay : MonoBehaviour {

    public User user;
    public Text nameText;
    public Text pointsText;
    public Image iconImage;

    public Sprite[] icons = new Sprite[10];

	void Start () {
        nameText.text = user.userName;
        pointsText.text = user.userPoints.ToString();
        iconImage.sprite = icons[user.userIconNumber];

        //print(user.userID);
        //print(user.userName);
        //print(user.userIconNumber);
        //print(user.userPoints);
    }
}