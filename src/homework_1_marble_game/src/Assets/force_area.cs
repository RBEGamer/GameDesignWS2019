using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force_area : MonoBehaviour
{
    public Vector3 force_added;
    public float strenght = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }




    public Vector3 get_force(string _tag) {
        force_added = new Vector3(-this.gameObject.transform.forward.z, this.gameObject.transform.forward.y, this.gameObject.transform.forward.x) * strenght;
        return force_added;
        
    }
}
