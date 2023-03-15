using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingScript : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 1, 1) * 1000, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
