using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewTask : MonoBehaviour
{
    private string tasksURL = "http://localhost/family_chores/InsertTask.php";

    //Add stepThree later on...
    public GameObject stepOne, stepTwo/*, stepThree*/;

    public InputField stepOneInput;
    public InputField stepTwoInput;

    private string taskName;
    private int numberOfPoints;
    //private int iconNumber;

    private bool stepOneActive = true;
    private bool stepTwoActive = false;
    //private bool stepThreeActive = false;

    private void Start()
    {
        stepOneInput.onEndEdit.AddListener(SubmitString);
        stepTwoInput.onEndEdit.AddListener(SubmitInt);
    }

    public void ToggleStepOne()
    {
        stepOneActive = !stepOneActive;

        stepOne.SetActive(stepOneActive);
    }

    public void ToggleStepTwo()
    {
        stepTwoActive = !stepTwoActive;
        
        stepTwo.SetActive(stepTwoActive);
    }

    /*public void ToggleStepThree()
    {
        stepThreeActive = !stepThreeActive;

        gameObject.SetActive(stepThreeActive);
    }*/

    public void SubmitString(string inputString)
    {
        taskName = inputString;
    }

    public void SubmitInt(string inputInt)
    {
        numberOfPoints = int.Parse(inputInt);
    }

    public void ConfirmButton()
    {
        if (stepOneActive)
        {
            ToggleStepOne();
            ToggleStepTwo();
            ClearInputField();
        }
        else if (stepTwoActive)
        {
            StartCoroutine(CreateNewTask());
        }
    }

    public void ClearInputField()
    {
        stepOneInput.text = null;
        stepTwoInput.text = null;
    }

    private IEnumerator CreateNewTask()
    {
        WWWForm taskForm = new WWWForm();
        taskForm.AddField("listIDPost", PlayerPrefs.GetInt("ID"));
        taskForm.AddField("taskNamePost", taskName);
        taskForm.AddField("numberOfPoints", numberOfPoints);
        //taskForm.AddField("iconNumberPost", iconNumber);

        WWW taskData = new WWW(tasksURL, taskForm);
        yield return taskData;

        //Calls on ToggleNewTaskPanel() in MenuController.cs. Change this after adding stepThree...
        gameObject.transform.parent.parent.GetComponent<MenuController>().ToggleNewTaskPanel();

        ToggleStepOne();
        ToggleStepTwo();
        ClearInputField();

        PlayerPrefs.SetInt("GetValue", 1);
        SceneManager.LoadScene(4);
    }

    //Add more methods for stepThree later on...

}
