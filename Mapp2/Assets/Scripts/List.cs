using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class List : MonoBehaviour {

    public int id;
    public string listName;
    public int iconNumber;

    private string[] listData;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("GetValue") == 1)
        {
            id = PlayerPrefs.GetInt("ID");
            PlayerPrefs.SetInt("GetValue", 0);
            StartCoroutine(LoadData());
        }
    }

    public void LoadList()
    {
        PlayerPrefs.SetInt("ID", id);
        PlayerPrefs.SetInt("GetValue", 1);

        SceneManager.LoadScene(3);
    }

    public void LoadList(int id)
    {
        PlayerPrefs.SetInt("ID", id);
        PlayerPrefs.SetInt("GetValue", 1);

        SceneManager.LoadScene(3);
    }

    private IEnumerator LoadData()
    {
        WWWForm listForm = new WWWForm();
        listForm.AddField("listIDPost", id);

        WWW getListData = new WWW("https://people.dsv.su.se/~nial0165/MAPP/GetListData.php", listForm);
        yield return getListData;

        string listDataString = getListData.text;

        listData = listDataString.Split('|');

        listName = listData[1];
        iconNumber = int.Parse(listData[2]);
    }
}