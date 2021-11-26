using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField]
    float forceMagnitude;

    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>(); //access other script as an instance
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //function gets called whenever the character controller collides with anything
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if(rigidbody != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position; //position of character minus position  of obstacle
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spikeball 1"))
        {
            Debug.Log($"Colliding with {gameObject.tag} , you are taking initial 3 collision damage!");
            /*players receives 3 damage on initial collision
             * players take more damage if collision lingers
             * (i.e. Some obstacles are designed to be movable and a player accidentally pushing an obstacle may cause them damage over time!)*/
            player.TakeDamageOverTime(3, 1);
        }
        if (collision.gameObject.CompareTag("Spikeball 2"))
        {
            Debug.Log($"Colliding with {gameObject.tag} , you are taking initial 5 collision damage!");
            /*players receives 5 damage on initial collision
             * players take more damage if collision lingers
             * (i.e. Some obstacles are designed to be movable and a player accidentally pushing an obstacle may cause them damage over time!)*/
            player.TakeDamageOverTime(5, 1);
        }

        if (collision.gameObject.CompareTag("Enemy Titan"))
        {
            Debug.Log($"Colliding with {gameObject.tag} , you are taking initial 20collision damage!");
            /*players receives 3 damage on initial collision
             * players take more damage if collision lingers
             * (i.e. Some obstacles are designed to be movable and a player accidentally pushing an obstacle may cause them damage over time!)*/
            player.TakeDamage(5);
        }
        if (collision.gameObject.CompareTag("Player")) //(other.gameObject.CompareTag("LeftDoor1"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (collision.gameObject.CompareTag("RightDoor1"))
        {
            SceneManager.LoadScene("SampleScene1");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //(other.gameObject.CompareTag("LeftDoor1"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene1");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //slow down character speed over  time based  on the objects in the screen
        //also do damage over time
        
    }
}
