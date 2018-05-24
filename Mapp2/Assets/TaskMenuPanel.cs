using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMenuPanel : MonoBehaviour {

    private int taskID;
    private int listID;
    private int userID;
    private int taskPoints;
    private string url;

    // Use this for initialization
    void Start () {
        url = "https://people.dsv.su.se/~nial0165/MAPP/UpdatePoints.php";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Task(GameObject task)
    {
        taskID = task.GetComponent<Task>().taskID;
        taskPoints = task.GetComponent<Task>().numberOfPoints;
        print(taskID + " " + listID);
    }

    public void User(GameObject user)
    {
        userID = user.GetComponent<User>().userID;
        
    }

    public void CloseButton()
    {

    }

    public void OkButton()
    {
<<<<<<< HEAD
        print("points " + taskPoints);
        print("taskID " + taskID);
        print("userID " + userID);
        WWWForm form = new WWWForm();
        form.AddField("idPost", userID);
        //form.AddField("completePost", 1);
        form.AddField("taskIDPost", taskID);
        form.AddField("pointsPost", userPoints + taskPoints);

        WWW www = new WWW(url, form);
        //taskObj.GetComponent<TaskDisplay>().CompletedTask();
        taskObj.GetComponent<TaskDisplay>().CompletedTask();
        gameObject.SetActive(false);

=======
        WWWForm form = new WWWForm();
        form.AddField("idPost", userID);
        form.AddField("taskIDPost", taskID);
        form.AddField("pointsPost", taskPoints);

        WWW www = new WWW(url, form);
>>>>>>> 780be51d1a7375e57143ab483d28c1e785a8f504
    }
}
