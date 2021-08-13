using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
    Vector3 mousePosition;
    private Fish Fish;
    // Start is called before the first frame update
    void Start()
    {
        Fish = this.GetComponent<Fish>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("clicked on UI");
            }
            else
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                Vector3 direction = Vector3.Normalize(mousePosition - this.transform.position);
                this.transform.position += direction * Fish.GetSpeed() * Time.deltaTime;
            }
        }
        else
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(h, v, 0);
            this.transform.position +=  Vector3.Normalize(direction) * Fish.GetSpeed() * Time.deltaTime;
        }
    }
}
