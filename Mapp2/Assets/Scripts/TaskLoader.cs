using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskLoader : MonoBehaviour {

    private string[][] tasksData;

    public GameObject taskButtonPrefab;

    private IEnumerator Start()
    {
        WWWForm taskForm = new WWWForm();
        taskForm.AddField("listIDPost", PlayerPrefs.GetInt("ID"));

        WWW getTask = new WWW("https://people.dsv.su.se/~nial0165/MAPP/GetTask.php", taskForm);
        yield return getTask;

        string tasksDataString = getTask.text;

        tasksData = tasksDataString.Split(';').Select(x => x.Split('|')).ToArray();

        GameObject newObj;

        for(int i = 0; i < tasksData.GetLength(0) - 1; i++)
        {
            newObj = (GameObject)Instantiate(taskButtonPrefab, transform);

            Task newObjTask = newObj.GetComponent<Task>();
            newObjTask.taskID = int.Parse(tasksData[i][0]);
            newObjTask.listID = int.Parse(tasksData[i][1]);
            newObjTask.taskName = tasksData[i][2];
            newObjTask.numberOfPoints = int.Parse(tasksData[i][3]);
            //newObjTask.iconNumber = int.Parse(tasksData[i][4]);
            newObjTask.isComplete = int.Parse(tasksData[i][4]);
        }
    }

}
