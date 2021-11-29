using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public float Speed;

    bool ate = false;


    List<Transform> tail = new List<Transform>();
    public GameObject tailPrefab;

    Vector2 dir = Vector2.up;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame


    void Move()//(float horizontal, float vertical)
    {
        transform.Translate(dir);
        Vector3 v = transform.position;
        // position.y += vertical * Speed * Time.deltaTime;
        // position.x += horizontal * Speed * Time.deltaTime;
        // transform.position = position;
        if (ate)
        {
            // Load Prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab,
                                                  v,
                                                  Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());

            tail.RemoveAt(tail.Count - 1);
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.tag.StartsWith("food"))
        {
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(coll.gameObject);
        }
        // Collided with Tail or Border
        else
        {
            if (coll.tag.StartsWith("tail"))
            {
                Destroy(gameObject);
            }
        }
    }


}
