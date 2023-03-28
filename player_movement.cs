using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class player_movement : MonoBehaviour
{
   
    // private variables
    private float speed = 10.0f;
    private float turnSpeed = 30.0f;
    private float horizontalInput;
    private float forwardInput;

    public float distance = 0.2f;
    public List<Transform> Balls = new List<Transform>();
    public Transform Spawnpoint;
    public GameObject Prefab;

   
    

    // Start is called before the first frame update
    void Start()
    {
        
       
    }
 
    // Update is called once per frame
    void Update()
    {
       
        // using unity's in-built input controls for movement instead of specifying keys induvidually
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // we move the spheres forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // we rotate the spheres to turn
        transform.Rotate(Vector3.up* Time.deltaTime * turnSpeed * horizontalInput);
    }
    // Function to spawn new objects on collision
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "power-up")
        {
            // Spawns a new segment prefab everytime player collides with power-up capsule
            Instantiate(Prefab,Spawnpoint.position,Spawnpoint.rotation);
        }
    }
   
}
