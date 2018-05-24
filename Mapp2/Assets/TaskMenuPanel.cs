using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMenuPanel : MonoBehaviour {

    private int taskID;
    private int listID;
    private int userID;
    private int userPoints;
    private int taskPoints;
    private string url;
    private GameObject taskObj;
    private MenuController menuController;

    // Use this for initialization
    void Start () {
        url = "https://people.dsv.su.se/~nial0165/MAPP/UpdatePoints.php";
        menuController = transform.parent.parent.GetComponent<MenuController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Task(GameObject task)
    {
        print("task "+task.name);
        taskObj = task;
        taskID = task.GetComponent<Task>().taskID;
        taskPoints = task.GetComponent<Task>().numberOfPoints;

    }

    public void User(GameObject user)
    {
        print("user " + user.name);
        userID = user.GetComponent<User>().userID;
        userPoints = user.GetComponent<User>().userPoints;
        OkButton();
        //menuController.ToggleCompleteTaskPanel(null);
    }

    public void CloseButton()
    {
        //menuController.ToggleCompleteTaskPanel(null);
        gameObject.SetActive(false);
    }

    public void OkButton()
    {
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

    }
}
