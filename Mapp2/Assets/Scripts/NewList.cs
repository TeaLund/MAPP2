using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NewList : MonoBehaviour {
    public InputField input;

    private ModalPanel modalPanel;

    private UnityAction okAction;
    private UnityAction cancelAction;

    private void Awake()
    {
        modalPanel = ModalPanel.Instance();

        okAction = new UnityAction(ok);
        cancelAction = new UnityAction(cancel);
    }

    // Send to the modal panel to set up the buttons and functions to call
    public void newList()
    {
        modalPanel.Choice("Vad ska listan heta?", okAction, cancelAction);
    }


    void ok()
    {
        // använd input.text här
        print(input.text);
        input.text = "";
        // aktivera nästa popup
    }


    void cancel()
    {
        print("Cancelled");
    }


}
