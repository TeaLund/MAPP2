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

        WWW getTask = new WWW("http://localhost/family_chores/GetTask.php", taskForm);
        yield return getTask;
        string tasksDataString = getTask.text;

        tasksData = tasksDataString.Split(';').Select(x => x.Split('|')).ToArray();

        GameObject newObj;

<<<<<<< HEAD

        for (int i = 0; i < tasksData.GetLength(0) - 1; i++)
=======
        for(int i = 0; i < tasksData.GetLength(0) - 1; i++)
>>>>>>> 780be51d1a7375e57143ab483d28c1e785a8f504
        {
            newObj = (GameObject)Instantiate(taskButtonPrefab, transform);

            Task newObjTask = newObj.GetComponent<Task>();
            newObjTask.taskID = int.Parse(tasksData[i][0]);
            newObjTask.listID = int.Parse(tasksData[i][1]);
            newObjTask.taskName = tasksData[i][2];
            newObjTask.numberOfPoints = int.Parse(tasksData[i][3]);
            newObjTask.iconNumber = int.Parse(tasksData[i][4]);
        }
    }

}
