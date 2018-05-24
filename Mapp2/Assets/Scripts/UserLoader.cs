using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserLoader : MonoBehaviour
{

    public string[][] users;
    public GameObject userPrefab;

    private WWW userData;
    private string url = "https://people.dsv.su.se/~nial0165/MAPP/UserData.php";
    //public Arraylst<GameObject> userObjects;

    void Start()
    {
        //WWW userData = new WWW("http://localhost/MAPP2_Users/UserData.php");
        


        StartCoroutine(UpdateList());
    }

    public IEnumerator UpdateList()
    {

        print("star Uppdate");
        userData = new WWW(url);
        yield return userData;
        //print(userData.text);
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

    //public void UpdateUser(int id)
    //{
    //    //foreach (Transform child in this.transform)
    //    //{
    //    //    if (child.GetComponent<UserDisplay>() == null)
    //    //        continue;
    //    //    UserDisplay childObj = child.GetComponent<UserDisplay>();
    //    //    //Debug.Log("Child" + childObj.name);
    //    //    if (childObj.user.userID == id)
    //    //    {

    //    //    }
    //    //}
    //}
}
