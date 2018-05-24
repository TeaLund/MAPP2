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

    private WWW userData;
    private string url;

    //public Arraylst<GameObject> userObjects;

    void Start()
    {
        //WWW userData = new WWW("http://localhost/MAPP2_Users/UserData.php");
        url = "https://people.dsv.su.se/~nial0165/MAPP/UserData.php";
        if (SceneManager.GetActiveScene().buildIndex == 2)
            url = "https://people.dsv.su.se/~nial0165/MAPP/UserScore.php";


        StartCoroutine(UpdateList());
    }

    public IEnumerator UpdateList()
    {

        print("star Uppdate");
        userData = new WWW(url);
        yield return userData;
        print(userData.text);
        string userDataString = userData.text;
        users = userDataString.Split(';').Select(x => x.Split('|')).ToArray();
        print("print data");

        foreach (Transform child in this.transform)
        {
            if (child.GetComponent<User>() == null)
                continue;
            Destroy(child.gameObject);
            print("destroy");
        }

        GameObject newObj;

        for (int i = 0; i < users.GetLength(0) - 1; i++)
        {
            newObj = (GameObject)Instantiate(userPrefab, transform);

            //userObjects.Add(newObj);

            User newObjUser = newObj.GetComponent<User>();
            int.TryParse(users[i][0], out newObjUser.userID);
            newObjUser.userName = users[i][1];
            newObjUser.userIconNumber = int.Parse(users[i][2]);
            newObjUser.userPoints = int.Parse(users[i][3]);
        }
        print("listan har uppdaterats");
    }

    public void PodiumPlacement()
    {
        GameObject newObj;
        for (int i = 0; i < 2; i++)
        {
            newObj = (GameObject)Instantiate(userPrefab, transform);

            User newObjUser = newObj.GetComponent<User>();
            int.TryParse(users[i][0], out newObjUser.userID);
            newObjUser.userName = users[i][1];
            newObjUser.userIconNumber = int.Parse(users[i][2]);
            newObjUser.userPoints = int.Parse(users[i][3]);
        }
    }
}
