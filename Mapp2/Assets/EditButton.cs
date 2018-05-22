using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditButton : MonoBehaviour {

    public int userID;
    public string userName;
    public int userIcon;
    public int userPoints;

    private OpenEditUserMenu openMenu;
    private User user;

    // Use this for initialization
    void Start () {
        openMenu = transform.parent.GetComponent<OpenEditUserMenu>();
        user = transform.GetComponent<User>();
        userID = user.userID;
        userName = user.userName;
        userIcon = user.userIconNumber;
        userPoints = user.userPoints;
    }

    public void OpenEditPanel()
    {
        openMenu.OpenEditUser(userID, userName, userIcon, userPoints);
    }
}
