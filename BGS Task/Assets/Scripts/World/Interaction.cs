using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider != null && collider.GetComponentInParent<PlayerMovement>())
        {
            Debug.Log("Player enter interaction collider");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider != null && collider.GetComponentInParent<PlayerMovement>())
        {
            Debug.Log("Player exit interaction collider");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
