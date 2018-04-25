using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ModalPanel : MonoBehaviour {

    public Text question;
    public Button okButton;
    public Button cancelButton;
    public GameObject modalPanelObject;
    public InputField input;
    

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return modalPanel;
    }

    public void Choice (string question,UnityAction okEvent,UnityAction exitEvent)
    {
        modalPanelObject.SetActive(true);

        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(okEvent);
        okButton.onClick.AddListener(ClosePanel);

        cancelButton.onClick.RemoveAllListeners();
        cancelButton.onClick.AddListener(exitEvent);
        cancelButton.onClick.AddListener(ClosePanel);

        this.question.text = question;

        okButton.gameObject.SetActive(true);
        cancelButton.gameObject.SetActive(true);
    }

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}
