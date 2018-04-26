using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestModalWindow : MonoBehaviour {

    private ModalPanel modalPanel;
    private DisplayManager displayManager;
    public InputField input;

    private UnityAction myOkAction;
    private UnityAction myExitAction;

    private void Awake()
    {
        modalPanel = ModalPanel.Instance();
        displayManager = DisplayManager.Instance();

        myOkAction = new UnityAction(TestOkFunction);
        myExitAction = new UnityAction(TestExitFunction);
    }
        
    // Send to the modal panel to set up the buttons and functions to call
    public void TestOE()
    {
        modalPanel.Choice("Skriv något.",myOkAction,myExitAction);
    }


    void TestOkFunction()
    {
        displayManager.DisplayMessage(input.text);
        input.text = "";
    }

    void TestExitFunction()
    {
        displayManager.DisplayMessage("Eller inte?");
    }
}
