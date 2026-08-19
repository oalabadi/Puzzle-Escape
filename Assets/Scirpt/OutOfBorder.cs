using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
           // if (Vector2.Distance(transform.position, collision.transform.position) <= 0.85f)
                collision.GetComponent<PlayerMovement>().StopPlayer();
    }
}
