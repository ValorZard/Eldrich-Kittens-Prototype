using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D garbage)
    {
    /*
     * Basically, this function collects all of the notes that falls down here and then 
     * destroys them. If they belong to someone, it resets their multiplier
     */
        if (garbage.gameObject.tag == "Notes")
        {
            Destroy(garbage.gameObject);
        }
    }
}
