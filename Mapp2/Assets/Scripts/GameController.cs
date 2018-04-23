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

    public void CreateListObject(string namn)
    {
        //efter att en popup anropats (satts till synlig) och användaren lagt in namn samt valt ikon:
        //anropa denna metod med namn och ikon som parametrar
        //skapa nytt objekt av ListKnapp med namnet och den valda ikonen
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

    public void Quit()
    {
        Application.Quit();
    }
}
