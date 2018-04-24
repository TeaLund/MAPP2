using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestModalWindow : MonoBehaviour {

    private ModalPanel modalPanel;
    private DisplayManager displayManager;

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
        modalPanel.Choice("Fina knappar.\nVad tycker du?",myOkAction,myExitAction);
    }


    void TestOkFunction()
    {
        displayManager.DisplayMessage("Ja okej");
    }

    void TestExitFunction()
    {
        displayManager.DisplayMessage("Ut försvinn");
    }
}
