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

    private bool buttonsEnabled = true;
    private bool exitPromptPanelActive = false;
    private bool newListPanelActive = false;

    private void Update()
    {
        //Change this later on so that pressing the back-key while having a window open, closes that window instead.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleExitPromptPanel();
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

    private void ToggleButtons()
    {
        buttonsEnabled = !buttonsEnabled;

        foreach (Button button in menuButtons)
        {
            button.interactable = buttonsEnabled;
        }
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadFamilyScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadPlacementScene()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitApplication()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

}
