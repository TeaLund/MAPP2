using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Button[] menuButtons;

    public GameObject exitPromptPanel;
    public GameObject newListPanel;
    public GameObject newTaskPanel;
    public GameObject completeTaskPanel;
    public GameObject removeListPanel;

    private bool buttonsEnabled;
    private bool exitPromptPanelActive;
    private bool newListPanelActive;
    private bool newTaskPanelActive;
    private bool completePanelActive;
    private bool removeListPanelActive;

    private void Awake()
    {
        buttonsEnabled = true;
        exitPromptPanelActive = false;
        newListPanelActive = false;
        newTaskPanelActive = false;
        completePanelActive = false;
    }

    private void Update()
    {
        //Change this later on so that pressing the back-key while having a window open, closes that window instead.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("MainMenu")))
            {
                ToggleExitPromptPanel();
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void ToggleExitPromptPanel()
    {
        exitPromptPanelActive = !exitPromptPanelActive;
        exitPromptPanel.SetActive(exitPromptPanelActive);

        ToggleButtons();
    }

    public void ToggleNewListPanel()
    {
        newListPanelActive = !newListPanelActive;
        newListPanel.SetActive(newListPanelActive);

        //Clears the input field
        newListPanel.GetComponentInChildren<NewList>().ClearInputField();

        ToggleButtons();
    }

    public void ToggleNewTaskPanel()
    {
        newTaskPanelActive = !newTaskPanelActive;
        newTaskPanel.SetActive(newTaskPanelActive);

        ToggleButtons();
    }

    private void ToggleButtons()
    {
        buttonsEnabled = !buttonsEnabled;

        foreach (Button button in menuButtons)
        {
            button.interactable = buttonsEnabled;
        }
    }

    //TaskScene
    public void CompleteTaskUserButton(GameObject userObject)
    {
        completeTaskPanel.GetComponent<TaskMenuPanel>().User(userObject);
    }
    public void ToggleCompleteTaskPanel(GameObject taskObject)
    {
        completeTaskPanel.GetComponent<TaskMenuPanel>().Task(taskObject);
        completePanelActive = !completePanelActive;
        completeTaskPanel.SetActive(completePanelActive);

        //ToggleButtons();
    }

    public void ToggleRemoveListPanel()
    {
        removeListPanelActive = !removeListPanelActive;
        removeListPanel.SetActive(removeListPanelActive);

        ToggleButtons();
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadFamilyScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadPlacementScene()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitApplication()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

}
