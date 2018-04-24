using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour {

    // Use this for initialization
    private void OnEnable()
    {
        transform.SetAsLastSibling();

    }
}
