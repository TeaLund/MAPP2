using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPointsUpdate : MonoBehaviour {

    private string url = "https://people.dsv.su.se/~nial0165/MAPP/UpdatePoints.php";
    public GameObject completePanel;

    private void Start()
    {
        
    }

    public void UpdatePoints(int id, int points)
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        form.AddField("pointsPost", points);

        WWW www = new WWW(url, form);
    }
}
