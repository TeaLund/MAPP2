using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditUser : MonoBehaviour {

    public InputField inputName;
    public GameObject editUserPanel;
    public GameObject iconArray;
    public GameObject bakgroundPanel;

    //[HideInInspector]
    public int id;
    public string userName;
    public int inputIcon;
    public int points;


    private UserIconSelected iconSelected;
    public GameObject listUpdate;
    public UserUpdate update;

    private string EditUrl = "https://people.dsv.su.se/~nial0165/MAPP/UpdateUser.php";
    private string RemoveUrl = "https://people.dsv.su.se/~nial0165/MAPP/RemoveUser.php";

    private void Start()
    {
        iconSelected = iconArray.GetComponent<UserIconSelected>();
        update = listUpdate.GetComponent<UserUpdate>();

    }

    //TEST
    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.KeypadEnter))
    //    {
    //        //id = 3;
    //        //userName = "Niclas";
    //        //inputIcon = 5;
    //        //points = 50;
    //        OkButton();
    //    }

    //}
    //TEST

    public void FillInfo(int userID, string name, int userIcon, int userPoints)
    {
        id = userID;
        userName = name;
        inputIcon = userIcon;
        points = userPoints;

        inputName.text = userName;

    }

    public void OkButton()
    {
        userName = inputName.text;
        inputIcon = iconSelected.index;
        Edit(id, userName, inputIcon, points);
        update.UpdateUserOffline(id, userName, inputIcon, points);
        listUpdate.GetComponent<UserUpdate>().UpdateUserOffline(id, userName, inputIcon, points);

        bakgroundPanel.SetActive(false);
        editUserPanel.SetActive(false);
    }

    public void CloseButton()
    {
        bakgroundPanel.SetActive(false);
        editUserPanel.SetActive(false);
    }

    public void RemoveButton()
    {
        WWWForm form = new WWWForm();
        form.AddField("IDPost", id);

        WWW www = new WWW(RemoveUrl, form);

        //StartCoroutine(listUpdate.GetComponent<UserLoader>().UpdateList());
        SceneManager.LoadScene(1);
        bakgroundPanel.SetActive(false);
        editUserPanel.SetActive(false);
    }

    public void Edit(int ID, string name, int icon, int points)
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", ID);
        form.AddField("namePost", name);
        form.AddField("iconPost", icon);
        form.AddField("pointsPost", points);

        WWW www = new WWW(EditUrl, form);

    }

}
