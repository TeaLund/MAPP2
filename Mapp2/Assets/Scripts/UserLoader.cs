using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserLoader : MonoBehaviour {

    public string[][] users;
    public GameObject userPrefab;

	IEnumerator Start() {
        //WWW userData = new WWW("http://localhost/MAPP2_Users/UserData.php");
        WWW userData = new WWW("https://people.dsv.su.se/~nial0165/MAPP/UserData.php");
        yield return userData;
        //users = userDataString.Split(';');
        //print(GetDataValue(users[0], "Points:"));

        string userDataString = userData.text;

        users = userDataString.Split(';').Select(x => x.Split('|')).ToArray();

        GameObject newObj;

        print("antal users: "+users.Length);

        for (int i = 0; i < users.Length; i++)
        //for (int i = 0; i < users.GetLength(0) - 1; i++)
        {
            print(users[i][0]);
            print(users[i][1]);
            print(users[i][2]);
            print(users[i][3]);
            newObj = (GameObject)Instantiate(userPrefab, transform);

            User newObjUser = newObj.GetComponent<User>();
            newObjUser.userID = int.Parse(users[i][0]);
            newObjUser.userName = users[i][1];
            newObjUser.userIconNumber = int.Parse(users[i][2]);
            newObjUser.userPoints = int.Parse(users[i][3]);
        }
    }
}
