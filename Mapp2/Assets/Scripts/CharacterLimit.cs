using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLimit : MonoBehaviour {

    public InputField input;
    public Text text;

	void Start () {
        input.characterLimit = 75;
	}
	
    // leta efter en mer resurseffektiv lösning?
	void Update () {
        text.text = remainingNumbers().ToString();
	}

    public int remainingNumbers()
    {
        return input.characterLimit - input.text.Length;
    }

    

}
