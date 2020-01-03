using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDestroyer : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
    }
}
