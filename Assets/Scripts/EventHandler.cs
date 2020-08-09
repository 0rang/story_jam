using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler instance;
    public static bool isBusy;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isBusy = false;
    }

}
