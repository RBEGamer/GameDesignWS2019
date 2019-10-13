using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tag_initilizer : MonoBehaviour
{
    //FIXING FOR NOT WORKING EVENT SYSTEAM AFTER LOADING AN ADDITIONAL SCENE _INTO TO THE GRAPH
    public void on_init()
    {
        Debug.Log("---");
        if (this.gameObject.GetComponent<player_ball>() != null) {
            this.gameObject.GetComponent<player_ball>().prepare_for_spawn();
        }     
    }
}
