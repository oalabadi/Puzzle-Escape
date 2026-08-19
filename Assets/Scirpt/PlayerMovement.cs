using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Vector3 startingPos;
    [SerializeField] public Button playButton;
    [SerializeField] Button stopButton;
    [SerializeField] public Vector2 direction;
    [SerializeField] Rigidbody2D rb;

    public bool start;

    void Start()
    {
        startingPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (start)
            rb.velocity = direction * speed;

        
    }

    public void StartPlayer()
    {
        playButton.gameObject.SetActive(false);
        stopButton.gameObject.SetActive(true);
        start = true;
        direction = new Vector2(1, 0);
    }

    public void StopPlayer()
    {
        start = false;
        playButton.gameObject.SetActive(true);
        stopButton.gameObject.SetActive(false);
        direction = Vector2.zero;
        rb.velocity = new Vector2(0, 0);
        transform.position = startingPos;
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");
        for (int i = 0; i < arrows.Length; i++)
            arrows[i].GetComponent<ArrowRotation>().touched = false;
    }
}
