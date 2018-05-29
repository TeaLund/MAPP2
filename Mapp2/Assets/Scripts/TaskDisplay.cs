using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskDisplay : MonoBehaviour {

    public Task task;
    public Text nameText;
    public Text numberOfPointsText;
    public Image iconImage;
    public Toggle isCompleted;
    public GameObject completedTaskDisplay;

    //private bool isTaskComplete = false;
    private TaskMenuPanel completePanel;

    private void Start()
    {
        nameText.text = task.taskName;
        numberOfPointsText.text = task.numberOfPoints.ToString();
        //iconImage.sprite = icons[task.iconNumber]
    }

    public void CompletedTask()
    {
        //isTaskComplete = !isTaskComplete;
        completedTaskDisplay.SetActive(true);
    }
}
