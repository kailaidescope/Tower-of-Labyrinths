using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestScript : MonoBehaviour
{
    Rigidbody rb3d;
    // Start is called before the first frame update
    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Enter Battle");
        }
    }
}
