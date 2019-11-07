using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_ball : MonoBehaviour
{

    public Transform spawn_pos;
    public Transform storing_point;
    public player_stats psats;

    public GameObject ingame_ui;
    public bool spawned = false;
    public bool disable_movement = false;
    public int collected_bonus = 0;
    public int max_bonus = 0;
    public int key_count = 0;

    private void GM_EVENTS() {

        Debug.Log("24232423");
    }

    
    public void spawn() {
        spawn_pos = GameObject.FindGameObjectWithTag(tag_storage.get_tag_name(tag_storage.TAGS.SPAWN_POS)).transform;
        if (spawn_pos == null)
        {
            Debug.LogError("cant find tag tag_storage.TAGS.SPAWN_POS");
            return;
        }
        this.transform.position = spawn_pos.transform.position;
        this.collider.enabled = true;
        rigidbody.useGravity = true;
        spawned = true;
        disable_movement = false;
        collected_bonus = 0;
        key_count = 0;
        ingame_ui.GetComponent<ui_ingame_manager>().update_ui();
        this.rigidbody.velocity = Vector3.zero;


    }

    public void goto_parking() {
        this.rigidbody.velocity = Vector3.zero;
        this.collider.enabled = false;
        rigidbody.useGravity = false;
        spawned = false;    
        storing_point = GameObject.FindGameObjectWithTag(tag_storage.get_tag_name(tag_storage.TAGS.PARK_POS)).transform;
        if (storing_point == null) {
            Debug.LogError("cant find tag tag_storage.TAGS.PARK_POS");
            return;
        }
        this.transform.position = storing_point.transform.position;
        disable_movement = true;
    }

    
    Rigidbody rigidbody;
    SphereCollider collider;
    public float speed = 4.0f;

    public GameObject cam;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody  = this.GetComponent<Rigidbody>();
        collider = this.GetComponent<SphereCollider>();
       
    
    }

    private void OnEnable()
    {
        main_game_manager.Instance.OnStateChange += GM_EVENTS;
    }



    public  void prepare_for_spawn() {

        Debug.Log("PREP SPAWN");
        main_game_manager.Instance.OnStateChange += GM_EVENTS;

        spawn_pos = GameObject.FindGameObjectWithTag(tag_storage.get_tag_name(tag_storage.TAGS.SPAWN_POS)).transform;
        storing_point = GameObject.FindGameObjectWithTag(tag_storage.get_tag_name(tag_storage.TAGS.PARK_POS)).transform;
        goto_parking();
    }

    private void Start()
    {
        this.collider.enabled = false;
        rigidbody.useGravity = false;

        main_game_manager.Instance.OnStateChange += GM_EVENTS;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!spawned || disable_movement) {
            rigidbody.velocity = Vector3.zero;
        }
        // Get directions relative to camera
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        // Project forward and right direction on the horizontal plane (not up and down), then
        // normalize to get magnitude of 1
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Set the direction for the player to move
        Vector3 dir = right * Input.GetAxis("Horizontal") + forward * Input.GetAxis("Vertical");
        dir.Normalize();

        
        rigidbody.AddForce(dir * speed);
        // Set rotation to direction of movement if moving
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(forward), 0.2f);
        }


        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        //LEVEL FAILED
        if (other.tag == tag_storage.get_tag_name(tag_storage.TAGS.OUT_OF_MAP_COLLIDER)) {
            stats.set_score_for_scene(level_object_loader.obj_to_load,0); // 0%
            goto_parking();
            GameObject.Find("LEVEL_SCENE_LOADER").GetComponent<level_object_loader>().change_level(level_object_loader.obj_to_load);
        }
        //LEVEL WON
        if (other.tag == tag_storage.get_tag_name(tag_storage.TAGS.GOAL_COLLIDER))
        {
            
            stats.set_score_for_scene(level_object_loader.obj_to_load, (int)(((1.0f*collected_bonus)/(1.0f*max_bonus))*100)); // 0%
            GameObject.Find("LEVEL_SCENE_LOADER").GetComponent<level_object_loader>().change_level(scene_storage.get_next_level(level_object_loader.obj_to_load));
            disable_movement = true;
        }




        //BONUS COLLECTED
        if (other.tag == tag_storage.get_tag_name(tag_storage.TAGS.bonus)) {
            collected_bonus++;
            psats.score_level++;
            main_game_manager.Instance.trigger_main_update_event();
            other.gameObject.GetComponent<bonus>().collected();
            ingame_ui.GetComponent<ui_ingame_manager>().update_ui();
        }

        //SPIKE COLLECTED
        if (other.tag == tag_storage.get_tag_name(tag_storage.TAGS.SPIKE))
        {
            collected_bonus = 0;
            psats.score_level = 0;
            spawn();
        }

        //KEY COLLECTED
        if (other.tag == tag_storage.get_tag_name(tag_storage.TAGS.KEY))
        {
            key_count++;
            psats.key_count = key_count;
            other.GetComponent<key>().collected();
            ingame_ui.GetComponent<ui_ingame_manager>().update_ui();
        }

        //DOOR TOUCHED
        if (other.tag == tag_storage.get_tag_name(tag_storage.TAGS.DOOR))
        {    
            if (key_count > 0 && other.GetComponent<door>().open()) {
                key_count--;
                psats.key_count = key_count;
                ingame_ui.GetComponent<ui_ingame_manager>().update_ui();
            }
            
        }

    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == tag_storage.get_tag_name(tag_storage.TAGS.FORCE_AREA))
        {
            this.rigidbody.AddForce(other.GetComponent<force_area>().get_force(this.gameObject.tag));
        //    Debug.Log("--- ADDED FORCE ---");
        }
    }

}
