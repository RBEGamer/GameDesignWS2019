using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_storage : MonoBehaviour
{


    public enum SCENES
    {
        GAME_SCENE,
        LEVEL_1_SCENE,
        LEVEL_2_SCENE,
        MAIN_MENU
    }


    public enum LEVEL_OBJECT_SCENES
    {
        LEVEL_1,
        LEVEL_2
    }

    public static LEVEL_OBJECT_SCENES get_next_level(LEVEL_OBJECT_SCENES _current) {
        if (_current == LEVEL_OBJECT_SCENES.LEVEL_1) {
            return LEVEL_OBJECT_SCENES.LEVEL_2;
        }        
            return LEVEL_OBJECT_SCENES.LEVEL_1;

    }
    public static string get_scene_name(SCENES _s) {
        string _t = "";

        switch (_s)
        {
            case SCENES.LEVEL_1_SCENE:
                _t = "level_1";
                break ;
            case SCENES.LEVEL_2_SCENE:
                _t = "level_2";
                break;
            case SCENES.GAME_SCENE:
                _t = "game_scene";
                break;
            case SCENES.MAIN_MENU:
                _t = "main_menu";
                break;
            default:
                break;
        }

        return _t;
    }


    public static string get_level_object_scene_name(LEVEL_OBJECT_SCENES _s)
    {  
        return _s.ToString().ToLower();
    }
   
}
