using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int itemId;
    public int quantity = 1;
    private EventManager eventManager;
    // Start is called before the first frame update
    void Start()
    {

        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            eventManager.PickUpItemEvent(this.itemId, this.quantity);
            Destroy(gameObject);

        }
    }
}
