using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerDirection
{
    up,
    down,
    left,
    right
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Vector3 startingPos;
    [SerializeField] public Button playButton;
    [SerializeField] Button stopButton;
    [SerializeField] public PlayerDirection startingDir;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject PlayerDirectionArrow;

    public bool start;

    void Start()
    {
        startingPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public Vector2 direction;
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
        if (startingDir == PlayerDirection.right)
            direction = new Vector2(1, 0);
        else if (startingDir == PlayerDirection.up)
            direction = new Vector2(0, 1);
        else if (startingDir == PlayerDirection.down)
            direction = new Vector2(0, -1);
        else
            direction = new Vector2(-1, 0);
        
        PlayerDirectionArrow.SetActive(false);
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
        PlayerDirectionArrow.SetActive(true);
        for (int i = 0; i < arrows.Length; i++)
            arrows[i].GetComponent<ArrowRotation>().touched = false;
    }
}
