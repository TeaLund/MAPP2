using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {    
	
	void Start () {
		
	}	
	
	void Update () {
		
	}

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadList()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadFamily()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadPodium()
    {
        SceneManager.LoadScene(3);
    }
}
