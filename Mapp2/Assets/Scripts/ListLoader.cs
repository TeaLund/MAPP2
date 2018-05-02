﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListLoader : MonoBehaviour
{
    private string[][] listsData;

    public GameObject listButtonPrefab;

    private IEnumerator Start()
    {
        //Set getList to the .php with the same name, then wait for it to load before proceeding
        WWW getList = new WWW("http://localhost/family_chores/GetList.php");
        yield return getList;

        //Receives data from the .php
        string listsDataString = getList.text;

        //Splits the data into a multidimensional array, String string[][] = { {id, listName, iconNumber} , {...}, ... };
        listsData = listsDataString.Split(';').Select(x => x.Split('|')).ToArray();

        GameObject newObj;

        //Creates a new button from the listButtonPrefab and then adds the correct values to it
        for(int i = 0; i < listsData.GetLength(0) - 1; i++)
        {
            newObj = (GameObject)Instantiate(listButtonPrefab, transform);

            List newObjList = newObj.GetComponent<List>();
            newObjList.id = int.Parse(listsData[i][0]);
            newObjList.listName = listsData[i][1];
            newObjList.iconNumber = int.Parse(listsData[i][2]);
        }
    }
}
