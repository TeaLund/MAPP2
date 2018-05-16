using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceScript : MonoBehaviour {

    public GameObject firstPlace;
    public GameObject secondPlace;
    public GameObject thirdPlace;

    public UserLoader userLoader;
    
    

    // Use this for initialization
    void Start () {

        // importera användarlista
        // sortera lista på poängordning. poängen kan tas ur UserLoaders "users" variabel med en for-loop som går något "for (int i = 0; i < users.Length; i++)" och print(users[i][3]) blabla

        // skicka namn, poäng och avatar på dom första tre användarna till place-objekten
        // skicka namn och poäng på resten av användarna till textfältet

    }




}
