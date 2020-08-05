using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != Player.position.x || transform.position.y != Player.position.y)
        {
            transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
        }
        //transform.position = new Vector3()
    }
}
