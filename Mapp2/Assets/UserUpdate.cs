using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserUpdate : MonoBehaviour {

    public int userId;
    public string userName;
    public int userIcon;
    public int userPoints;

    public void UpdateUserOffline(int ID, string name, int icon, int points)
    {
        userId = ID;
        userName = name;
        userIcon = icon;
        userPoints = points;


        //User childObj = transform.GetComponentInChildren<User>();
        foreach(Transform child in transform)
        {
            User childObj = transform.GetComponentInChildren<User>();
            if (child.GetComponent<User>().userID == ID)
            {
                childObj.userName = name;
                childObj.userIconNumber = icon;
                childObj.userPoints = points;
                print("UserUpdate hittade user" + childObj.userName);
            }
        }
    }
}
