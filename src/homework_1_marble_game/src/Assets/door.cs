using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{

    public bool door_state = false;
    public bool locked = false;
    public Transform up_point;
    public Transform down_point;
    public GameObject door_obj;
    public float door_mv_speed = 20.0f;       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (door_state && Vector3.Distance(this.transform.position, up_point.position) > 0.1f) {
            door_obj.transform.position = Vector3.Lerp(door_obj.transform.position, up_point.position, door_mv_speed * Time.deltaTime);
        }

        if (!door_state && Vector3.Distance(this.transform.position, down_point.position) > 0.1f)
        {
            door_obj.transform.position = Vector3.Lerp(door_obj.transform.position, down_point.position, door_mv_speed * Time.deltaTime);
        }
    }


    public bool open() {
        if (!door_state && !locked)
        {
            door_state = true;
            locked = true;
            return true;
        }
        else {
            return false;
        }
    }
   
}
