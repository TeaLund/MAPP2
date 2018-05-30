using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class UserLoader : MonoBehaviour
{

    public string[][] users;
    public GameObject userPrefab;

    public GameObject podiumUserPrefab;
    public GameObject firstPlace;
    public GameObject secondPlace;
    public GameObject thirdPlace;

    private WWW userData;
    private string url;


    void Start()
    {
        url = "https://people.dsv.su.se/~nial0165/MAPP/UserData.php";
        if (SceneManager.GetActiveScene().buildIndex == 2)
            url = "https://people.dsv.su.se/~nial0165/MAPP/UserScore.php";


        StartCoroutine(ListInfo());
    }

    public IEnumerator ListInfo()
    {
        userData = new WWW(url);
        yield return userData;
        string userDataString = userData.text;
        users = userDataString.Split(';').Select(x => x.Split('|')).ToArray();


        if (SceneManager.GetActiveScene().buildIndex == 2)
            PodiumPlacement();
        else
            UpdateList();
    }

    public void UpdateList()
    {
        foreach (Transform child in this.transform)
        {
            if (child.GetComponent<User>() == null)
                continue;
            Destroy(child.gameObject);
        }

        GameObject newObj;

        for (int i = 0; i < users.GetLength(0) - 1; i++)
        {
            newObj = (GameObject)Instantiate(userPrefab, transform);
            User newObjUser = newObj.GetComponent<User>();

            SetUserInfo(newObjUser, users[i][0], users[i][1], users[i][2], users[i][3]);
        }
        print("listan har uppdaterats");
    }

    public void SetUserInfo(User user, string id, string name, string icon, string points)
    {
        int.TryParse(id, out user.userID);
        user.userName = name;
        user.userIconNumber = int.Parse(icon);
        user.userPoints = int.Parse(points);
    }

    public void PodiumPlacement()
    {
        float podiumPrefabScale = 12f;

        GameObject podiumObj;
        GameObject newObj;

        foreach (Transform child in this.transform)
        {
            if (child.GetComponent<User>() == null)
                continue;
            Destroy(child.gameObject);
        }

        for (int i = 0; i < users.GetLength(0) - 1; i++)
        {
            if (i == 0)
            {
                podiumObj = (GameObject)Instantiate(podiumUserPrefab, firstPlace.transform);
                podiumObj.transform.localScale = new Vector3(podiumPrefabScale, podiumPrefabScale, 0);
                User newObjUser = podiumObj.GetComponent<User>();
                SetUserInfo(newObjUser, users[i][0], users[i][1], users[i][2], users[i][3]);
            }
            else if (i == 1)
            {
                podiumObj = (GameObject)Instantiate(podiumUserPrefab, secondPlace.transform);
                podiumObj.transform.localScale = new Vector3(podiumPrefabScale, podiumPrefabScale, 0);
                User newObjUser = podiumObj.GetComponent<User>();
                SetUserInfo(newObjUser, users[i][0], users[i][1], users[i][2], users[i][3]);
            }

            else if (i == 2)
            {
                podiumObj = (GameObject)Instantiate(podiumUserPrefab, thirdPlace.transform);
                podiumObj.transform.localScale = new Vector3(podiumPrefabScale, podiumPrefabScale, 0);
                User newObjUser = podiumObj.GetComponent<User>();
                SetUserInfo(newObjUser, users[i][0], users[i][1], users[i][2], users[i][3]);
            }

            else if (i > 2)
            {
                newObj = (GameObject)Instantiate(userPrefab, transform);
                User newObjUser = newObj.GetComponent<User>();
                SetUserInfo(newObjUser, users[i][0], users[i][1], users[i][2], users[i][3]);
            }
        }
    }
}
