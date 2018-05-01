﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewList : MonoBehaviour
{
    private string listsURL = "http://localhost/family_chores/InsertList.php";

    //Add stepTwo later on...
    public GameObject stepOne/*, stepTwo*/;

    private string listName;
    //private int iconNumber;

    private bool stepOneActive = true;
    //private bool stepTwoActive = false;

    private InputField input;

    public void ToggleStepOne()
    {
        stepOneActive = !stepOneActive;

        gameObject.SetActive(stepOneActive);
    }

    /*public void ToggleStepTwo()
    {
        stepTwoActive = !stepTwoActive;
        
        gameObject.SetActive(stepTwoActive);
    }*/

    private void Awake()
    {
        input = gameObject.GetComponentInChildren<InputField>();
        input.onEndEdit.AddListener(InputFieldListener);
    }

    public void InputFieldListener(string inputText)
    {
        listName = inputText;
    }

    public void ConfirmButton()
    {
        StartCoroutine(CreateNewList());
    }

    public void ClearInputField()
    {
        input.text = null;
        Debug.Log("InputField cleared!");
    }

    private IEnumerator CreateNewList()
    {
        Debug.Log("CreateNewList: " + listName);

        WWWForm listForm = new WWWForm();
        listForm.AddField("listNamePost", listName);
        //listForm.AddField("iconNumberPost", iconNumber);

        WWW listData = new WWW(listsURL, listForm);
        yield return listData;

        //Calls on ToggleNewListPanel() in MenuController.cs. Change this after adding stepTwo...
        gameObject.transform.parent.parent.GetComponent<MenuController>().ToggleNewListPanel();
    }

    //Add more methods for stepTwo later on...

}