using UnityEngine;
using System.Collections;

public class PlatformTranslate : MonoBehaviour
{
    private float initTime;
    public float TimeMoving;
    private int speed;
    private Vector3 Movement;
    public float MoveX;
    public float MoveY;

    void Start()
    {
        initTime = TimeMoving;
        Movement = new Vector3(MoveX * speed, MoveY * speed, 0);
        speed = 1;
    }

    void FixedUpdate()
    {
        transform.position += Movement;
        TimeMoving -= Time.deltaTime;
        if (TimeMoving < 0)
        {
            TimeMoving = initTime;
            speed = speed * -1;
            Movement = new Vector3(MoveX * speed, MoveY * speed, 0);
        }
    }
}