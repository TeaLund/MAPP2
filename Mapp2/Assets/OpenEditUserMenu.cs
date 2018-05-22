using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEditUserMenu : MonoBehaviour {

    //public EditUser editUser;
    public GameObject editPanel;
    //public int userID;
    //public string userName;
    //public int userIcon;
    //public int userPoints;

    private void Start()
    {
        //editUser = transform.GetComponent<EditUser>();
        editPanel.SetActive(false);
    }

    public void OpenEditUser(int userID, string userName, int userIcon, int userPoints)
    {
        //print("OpenEditUserMenu " + userID + " " + userName + " " + userIcon + " " + userPoints);

        editPanel.transform.GetComponent<EditUser>().FillInfo(userID, userName, userIcon, userPoints);
        editPanel.SetActive(true);
    }
}
