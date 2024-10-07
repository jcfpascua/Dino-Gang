using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : MonoBehaviour
{
    // public GameObject self;
    public void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.tag == "Pitfall") {
                Debug.Log("I'M BACK IN THE FUCKING BUILDING AGAIN");
            } 
        // else if (other.gameObject.CompareTag("Finish")) {
        //     Debug.Log("martha i'm coming home sweetie");
        // }
        // Debug.Log("FUUUUUUUUUUUCK");
    }
}
