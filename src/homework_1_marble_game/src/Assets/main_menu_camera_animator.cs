using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu_camera_animator : MonoBehaviour
{

    public GameObject camera_obj;

    public GameObject center_obj;

    public float speed = 0.3f;
    

    // Update is called once per frame
    void Update()
    {
        camera_obj.transform.LookAt(center_obj.transform.position);
        camera_obj.transform.RotateAround(center_obj.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
