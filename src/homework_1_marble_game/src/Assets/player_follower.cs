using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_follower : MonoBehaviour
{

    public Transform following_obj = null;
    public bool active = true;

    public float speed = 2.0f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if (following_obj == null) {
            Debug.Log("following_obj == null");
            active = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!active) { return; }
        this.transform.LookAt(following_obj.transform);
    }

    void LateUpdate()
    {
        float interpolation = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position,following_obj.transform.position + offset, interpolation);
    }

}
