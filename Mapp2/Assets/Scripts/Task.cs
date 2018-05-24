using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{

    public int taskID;
    public int listID;
    public string taskName;
    public int numberOfPoints;
    public int isComplete;

    private MenuController menuController;

    private void Start()
    {
        menuController = transform.parent.parent.parent.parent.parent.GetComponent<MenuController>();
    }

    private void Update()
    {
        if (isComplete == 1)
            transform.GetComponent<TaskDisplay>().isTaskComplete = true;
    }

    public void completeButton(GameObject obj)
    {
        print(obj.name);
        menuController.GetComponent<MenuController>().ToggleCompleteTaskPanel(obj);
    }

}
