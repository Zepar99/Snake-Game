using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public Vector2Int snakeMoveDirection;
    public Vector2Int snakePosition;
    private float snakeMoveTimer;
    private float snakeMoveTimerMax;
    // Start is called before the first frame update
    private void Awake()
    {
        snakePosition = new Vector2Int(10, 10);
        snakeMoveTimerMax = 0.05f;
        snakeMoveTimer = snakeMoveTimerMax;
        snakeMoveDirection = new Vector2Int(0, 1);
    }

    private void Update()
    {
        snakeController();
        snakeAutoMovement();
    }
    // Update is called once per frame
    private void snakeController()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (snakeMoveDirection.y != -1)
            {
                snakeMoveDirection.x = 0;
                snakeMoveDirection.y = +1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (snakeMoveDirection.y != +1)
            {
                snakeMoveDirection.x = 0;
                snakeMoveDirection.y = -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (snakeMoveDirection.x != +1)
            {
                snakeMoveDirection.x = -1;
                snakeMoveDirection.y = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (snakeMoveDirection.x != -1)
            {
                snakeMoveDirection.x = +1;
                snakeMoveDirection.y = 0;
            }
        }
    }

    private void snakeAutoMovement()
    {
        snakeMoveTimer += Time.deltaTime;
        if (snakeMoveTimer >= snakeMoveTimerMax)
        {
            snakePosition += snakeMoveDirection;
            snakeMoveTimer -= snakeMoveTimerMax;
        }

        transform.position = new Vector3(snakePosition.x, snakePosition.y);
        transform.eulerAngles = new Vector3(0, 0, getSnakeFaceAngleFromVector(snakeMoveDirection) - 90);
    }

    private float getSnakeFaceAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
