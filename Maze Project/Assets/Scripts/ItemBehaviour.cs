using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{

    [SerializeField] private string name;
    [SerializeField] private int count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerBehaviour>().AddItem(new Item(name, count));
            Destroy(gameObject);
        }
    }

}
