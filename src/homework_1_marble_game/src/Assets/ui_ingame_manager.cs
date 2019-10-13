using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_ingame_manager : MonoBehaviour
{

    public GameObject ingame_menu_holder;
    public GameObject ingame_ui_holder;




    private main_game_manager gm;

    private void Awake()
    {
        gm = main_game_manager.Instance;
        gm.OnStateChange += update_ui;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void update_ui() {



        Debug.Log("update_ui");
        if (gm.gameState == GameState.PAUSE)
        {
            ingame_menu_holder.SetActive(true);
            ingame_ui_holder.SetActive(false);
        }
        else if (gm.gameState == GameState.RUNNING)
        {
            ingame_menu_holder.SetActive(false);
            ingame_ui_holder.SetActive(true);
        }
       






    }

    public void pause_button_click() {
        Debug.Log("pause_button_click");
        gm.toggle_pause();
    }


   

    public void main_menu_button() {
        gm.load_scene(scene_storage.SCENES.MAIN_MENU);
    }
    
}
