using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListViewer : MonoBehaviour {

    public GameObject listPrefab;

	// Use this for initialization
	void Start () {
        Display();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Display()
    {
        /*foreach (ListEntry list in XMLManager.man.listDat.listOflists)
        {
            //GameObject newList = Instantiate(listPrefab, this.transform);
            //ListObj lo = newList.GetComponent<ListObj>();

            //newList.transform.SetParent(transform, false);
            //lo.Display(list);
        }*/

    }
}
