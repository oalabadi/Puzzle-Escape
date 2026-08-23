using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum Direction
{
    up,
    down,
    left,
    right
}

public class ArrowRotation : MonoBehaviour
{
    [SerializeField] private GameObject highliter;
    [SerializeField] private bool isRotating;
    [SerializeField] private Direction direction;
    [SerializeField] Transform player;

    public Vector2 moveDirection;
    PlayerMovement pm;

    public bool touched;

    public int rotation;
    float rotate;
    float vel;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pm = player.GetComponent<PlayerMovement>();
        if (direction == Direction.right)
        {
            rotation = 0;
            moveDirection = new Vector2(1, 0);
        }
        else if (direction == Direction.down)
        {
            rotation = -90;
            moveDirection = new Vector2(0, -1);
        }
        else if (direction == Direction.left)
        {
            rotation = -180;
            moveDirection = new Vector2(-1, 0);
        }
        else if (direction == Direction.up)
        {
            rotation = 90;
            moveDirection = new Vector2(0, 1);
        }

        rotate = rotation;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.RoundToInt(rotate));
    }

    private void OnMouseEnter()
    {
        highliter.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (!isRotating && !pm.start)
        StartCoroutine(RotateObject());
    }

    private void OnMouseExit()
    {
        highliter.SetActive(false);
    }


    void Update()
    {
        //if (rotation == 0)
        //{
        //    moveDirection = new Vector2(1, 0);
        //}
        //else if (rotation == -90)
        //{
        //    moveDirection = new Vector2(0, -1);
        //}
        //else if (rotation == -180)
        //{
        //    moveDirection = new Vector2(-1, 0);
        //}
        //else
        //{
        //    moveDirection = new Vector2(0, 1);
        //}

        if (isRotating)
        {
            rotate = Mathf.Lerp(rotate, rotation, Time.fixedDeltaTime * 1.5f);
            transform.rotation = Quaternion.Euler(0, 0, Mathf.RoundToInt(rotate));
           
        }

        if (Vector2.Distance(player.transform.position, transform.position) <= 0.1f && !touched)
        {
            player.GetComponent<PlayerMovement>().direction = moveDirection;
            player.transform.position = new Vector2(Mathf.Round(player.transform.position.x), Mathf.Round(player.transform.position.y));
            touched = true;
        }
        else if (Vector2.Distance(player.transform.position, transform.position) >= 0.1f)
            touched = false;

    }

    IEnumerator RotateObject()
    {
        rotation -= 90;
        isRotating = true;
        pm.playButton.interactable = false;
        yield return new WaitForSeconds(0.67f);
        if (rotation == -360)
        {
            rotation = 0;
            rotate = 0;
        }
        if (rotation >= -179 && rotation <= -181)
        {
            rotation = 180;
            rotate = 180;
        }
        isRotating = false;
        rotate = Mathf.RoundToInt(rotate);
        pm.playButton.interactable = true;
        if (rotation == 0)
        {
            moveDirection = new Vector2(1, 0);
            direction = Direction.right;
        }
        else if (rotation == -90)
        {
            moveDirection = new Vector2(0, -1);
            direction = Direction.down;
        }
        else if (rotation == -180)
        {
            moveDirection = new Vector2(-1, 0);
            direction = Direction.left;
        }
        else
        {
            moveDirection = new Vector2(0, 1);
            direction = Direction.up;
        }
    }
}
