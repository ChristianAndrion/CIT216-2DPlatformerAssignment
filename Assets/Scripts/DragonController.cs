using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class DragonController : MonoBehaviour
{

    //LERP MOVEMENT
    /*
    private Vector2 pointA;
    private Vector2 pointB;

    public float speed = 2f;
    public float duration = 3f;

    void Start()
    {
        pointA = transform.position;
        pointB = new Vector2(transform.position.x + 5, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
        float t = Mathf.PingPong(Time.time * speed, 1f);
        //float t = Mathf.PingPong(Time.time / duration, 1f);
        transform.position = Vector2.Lerp(pointA, pointB, t);
    }*/

    public float distance = 3f;
    public float movementMultiplier;

    private int counter = 5;

    private void Start()
    {
        StartCoroutine("MoveObject");
    }
    IEnumerator MoveObject()
    {
        while (true)
        {
            transform.Translate(new Vector2(0, distance * movementMultiplier));
            //counter--;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
            Debug.DrawRay(transform.position, Vector2.down, Color.red, 1f);//Draws line in scene for 1 second
            
            if (!hit)
            {
                movementMultiplier *= -1; //Move in opposite direction
                //counter = 5; // Reset counter
            }

            yield return new WaitForSeconds(.25f);
        }
    }
}
