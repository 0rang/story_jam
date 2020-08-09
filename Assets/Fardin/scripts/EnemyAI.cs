using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private Transform thisTransform;

    private Ray2D ray;

    [SerializeField] Vector2 rayDirection;
    [SerializeField] Vector2 vectorToPlayer;

    public float moveSpeed;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        moveToPlayer();
    }

    void moveToPlayer()
    {
        vectorToPlayer = player.position - this.transform.position;
        ray = new Ray2D(this.transform.position, vectorToPlayer);
        rayDirection = ray.direction;
        RaycastHit2D[] rayCastHit = Physics2D.RaycastAll(ray.origin, vectorToPlayer);
        if (rayCastHit.Length == 0)
        {
            Debug.Log("Found nothing");
        }
        else
        {
            Debug.Log("didn't find nothing");
            for (int i = 0; i < rayCastHit.Length; i++)
            {
                Debug.Log(rayCastHit[i].collider.name);
                if (rayCastHit[i].collider.tag == "Player")
                {
                    Debug.Log("Found Player");
                    Vector3 velocity = vectorToPlayer.normalized * moveSpeed * Time.deltaTime;
                    thisTransform.position += velocity;
                    break;
                }
            }
        }
    }

    void idle()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction);
    }
}
