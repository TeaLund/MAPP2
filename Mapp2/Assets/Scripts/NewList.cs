using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewList : MonoBehaviour
{
    private string listsURL = "https://people.dsv.su.se/~nial0165/MAPP/InsertList.php";

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
    }

    private IEnumerator CreateNewList()
    {
        WWWForm listForm = new WWWForm();
        listForm.AddField("listNamePost", listName);
        //listForm.AddField("iconNumberPost", iconNumber);

        WWW listData = new WWW(listsURL, listForm);
        yield return listData;

        //Calls on ToggleNewListPanel() in MenuController.cs. Change this after adding stepTwo...
        //gameObject.transform.parent.parent.GetComponent<MenuController>().ToggleNewListPanel();

        StartCoroutine(GameObject.FindGameObjectWithTag("ListLoader").GetComponent<ListLoader>().LoadList(listName));
    }

    //Add more methods for stepTwo later on...

}
