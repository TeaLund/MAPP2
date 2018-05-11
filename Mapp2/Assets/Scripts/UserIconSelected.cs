using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserIconSelected : MonoBehaviour {

    public Button[] icons = new Button[10];
    public int index;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < icons.Length; i++)
        {
            int closureIndex = i;
            Button btn = icons[i].GetComponent<Button>();
            btn.onClick.AddListener( () => OnClick(closureIndex));
        }
	}

    public void OnClick(int buttonIndex)
    {
        index = buttonIndex;
        Debug.Log(index);
    }
}
