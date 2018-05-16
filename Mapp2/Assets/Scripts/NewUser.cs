using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUser : MonoBehaviour {

    public InputField inputName;
    public GameObject newUserPanel;
    public GameObject iconArray;
    public int inputIcon;

    //private string url = "http://localhost/MAPP2_Users/InsertUser.php";
    private string url = "https://people.dsv.su.se/~nial0165/MAPP/InsertUser.php";
    private UserIconSelected iconSelected;
    public UserLoader listUpdate;

    // Use this for initialization
    void Start () {
        iconSelected = iconArray.GetComponent<UserIconSelected>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) CreateUser(inputName.text, inputIcon);
		
	}

    public void OpenUserPanel()
    {
        newUserPanel.SetActive(true);
    }

    public void CloseUserPanel()
    {
        inputName.text = "";
        newUserPanel.SetActive(false);
    }

    public void CreateButton()
    {
        string name = inputName.text;
        inputIcon = iconSelected.index;
        CreateUser(name, inputIcon);
        newUserPanel.SetActive(false);
        listUpdate.UpdateList();
    }

    public void CreateUser(string name, int icon)
    {
        WWWForm form = new WWWForm();
        form.AddField("namePost", name);
        form.AddField("iconPost", icon);
        form.AddField("pointsPost", 0);

        WWW www = new WWW(url, form);
    }
}
