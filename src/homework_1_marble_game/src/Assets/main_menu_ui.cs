using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu_ui : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        main_game_manager.Instance.SetGameState(GameState.MAIN_MENU);
    }

   

    public void load_level_one()
    {
        main_game_manager.Instance.load_level(scene_storage.LEVEL_OBJECT_SCENES.LEVEL_1);
    }
    public void load_level_two()
    {
        main_game_manager.Instance.load_level(scene_storage.LEVEL_OBJECT_SCENES.LEVEL_2);

    }
}
