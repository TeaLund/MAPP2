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

    [HideInInspector]
    public bool isTaskComplete = false;
    private TaskMenuPanel completePanel;

    private void Start()
    {
        nameText.text = task.taskName;
        numberOfPointsText.text = task.numberOfPoints.ToString();
        //iconImage.sprite = icons[task.iconNumber]
    }

    private void Update()
    {
        if (isTaskComplete)
            CompletedTask();
    }

    public void CompletedTask()
    {
        isTaskComplete = !isTaskComplete;

        completedTaskDisplay.SetActive(isTaskComplete);
    }
}
