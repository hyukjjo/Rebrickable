using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public Player pb;

    // Start is called before the first frame update
    void Start()
    {
        if (pb != null)
            pb.PlayerInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
