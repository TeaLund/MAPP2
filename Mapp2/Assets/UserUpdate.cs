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
        foreach (Transform child in this.transform)
        {
            if (child.GetComponent<User>() == null)
                continue;
            User childObj = child.GetComponent<User>();
            if (childObj.userID == ID)
            {
                childObj.userName = name;
                childObj.userIconNumber = icon;
                childObj.userPoints = points;
            }
        }
    }
}
