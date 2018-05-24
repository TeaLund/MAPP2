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

        Debug.Log(GetComponentsInChildren<User>().Length);
        //User childObj = transform.GetComponentInChildren<User>();
        foreach(Transform child in transform)
        {
            if (child.GetComponent<User>() == null)
                return;
            User childObj = child.GetComponent<User>();
            Debug.Log("Child" + childObj.name);
            if (childObj.userID == ID)
            {
                childObj.userName = name;
                childObj.userIconNumber = icon;
                childObj.userPoints = points;
                print("UserUpdate hittade user" + childObj.userName);
            }
        }
    }
}
