using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class User : MonoBehaviour {

    public int userID;
    public string userName;
    public int userIconNumber;
    public int userPoints;

    private MenuController menuController;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
            menuController = transform.parent.parent.parent.parent.parent.parent.GetComponent<MenuController>();
        return;

    }

    public void completeUserButton(GameObject obj)
    {
       menuController.CompleteTaskUserButton(obj);
    }
}
