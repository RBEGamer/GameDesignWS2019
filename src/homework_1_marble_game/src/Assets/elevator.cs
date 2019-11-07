using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public event Action<bool> Elevator_State_Change_Event;

    public bool cycling = true;
    public float wait_time = 5.0f;
    private float curr_wait_time = 5.0f;
    public float mv_speed = 1.0f;
    public Transform up_pos;
    public Transform down_pos;
    public bool time_counting = false;
    public bool elev_state = false;
    public Transform elev_obj;
    // Start is called before the first frame update
    void Start()
    {
        elev_obj.position = down_pos.position;
        curr_wait_time = wait_time;
        time_counting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!time_counting)
        {
            if (elev_state && Vector3.Distance(elev_obj.position, up_pos.position) > 0.1f)
            {
                elev_obj.transform.position = Vector3.Lerp(elev_obj.transform.position, up_pos.position, mv_speed * Time.deltaTime);
            }
            else if (!elev_state && Vector3.Distance(elev_obj.position, down_pos.position) > 0.1f)
            {
                elev_obj.transform.position = Vector3.Lerp(elev_obj.transform.position, down_pos.position, mv_speed * Time.deltaTime);

            }
            else {
                curr_wait_time = wait_time;
                time_counting = true;
                Elevator_State_Change_Event.Invoke(elev_state);

            }

         
        }

        if (time_counting) {
            curr_wait_time -= Time.deltaTime;
            if (curr_wait_time <= 0.0f) {
                time_counting = false;
                elev_state = !elev_state;
            }
        }
     
        
       
    }
}
