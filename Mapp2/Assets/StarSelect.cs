using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarSelect : MonoBehaviour {

    public Toggle[] stars = new Toggle[5];

    public int points = 1;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].isOn = false;
        }

        for (int i = 0; i < stars.Length; i++)
        {
            int closureIndex = i;
            Toggle tog = stars[i].GetComponent<Toggle>();
            tog.onValueChanged.AddListener(delegate
            {
                ToggleValueChanged(closureIndex);
            });
        }
    }
	
    public void ToggleValueChanged(int index)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i <= index)
            {
                stars[i].isOn = true;
                // Debug.Log("Star " + i + ": " + stars[i].isOn);
            }
            else
            {
                stars[i].isOn = false;
            }
        }
        //Debug.Log(index);
        points = index + 1;
        //Debug.Log(points);
    } 
}
