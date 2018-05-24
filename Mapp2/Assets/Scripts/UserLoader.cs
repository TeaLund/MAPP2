using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserLoader : MonoBehaviour
{

    public string[][] users;
    public GameObject userPrefab;

    private WWW userData;
    //public Arraylst<GameObject> userObjects;

    void Start()
    {
        //WWW userData = new WWW("http://localhost/MAPP2_Users/UserData.php");
        userData = new WWW("https://people.dsv.su.se/~nial0165/MAPP/UserData.php");

        StartCoroutine(UpdateList());
    }

    public IEnumerator UpdateList()
    {
        yield return userData;
        string userDataString = userData.text;
        users = userDataString.Split(';').Select(x => x.Split('|')).ToArray();

        //foreach (Transform child in transform)
        //{
        //    Destroy(child.gameObject);
        //}

        GameObject newObj;

        for (int i = 0; i < users.GetLength(0) - 1; i++)
        {
            //print(users[i][0]);
            //print(users[i][1]);
            //print(users[i][2]);
            //print(users[i][3]);
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

    //public void UpdateUser(int id)
    //{
    //    for(int i = 0; i > userObjects.))
    //    userObjects.
    //}
}
