using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu_ui : MonoBehaviour
{

    public GameObject level_selector_prefab;
    public Vector2 level_selector_offset;
    public Vector2 level_selector_start_pos;
    public int count_row_items = 4;
    // Start is called before the first frame update
    void Start()
    {
        main_game_manager.Instance.SetGameState(GameState.MAIN_MENU);
        int counter = 0;
        foreach (scene_storage.LEVEL_OBJECT_SCENES foo in System.Enum.GetValues(typeof(scene_storage.LEVEL_OBJECT_SCENES))) {
            GameObject go= Instantiate(level_selector_prefab, this.transform);
            go.GetComponent<level_selection_item>().level_scene = foo;
            go.GetComponent<level_selection_item>().mmmenu = this;
            int y =  (int)(counter / count_row_items);
            go.transform.position = new Vector3(level_selector_start_pos.x, level_selector_start_pos.y,0.0f) +new Vector3(level_selector_offset.x * counter, level_selector_offset.y * y, 0.0f);
            go.SetActive(true);
            counter++;
        }



        
    }

   

    public void load_level_one()
    {
        main_game_manager.Instance.load_level(scene_storage.LEVEL_OBJECT_SCENES.LEVEL_1);
    }
    public void load_level_two()
    {
        main_game_manager.Instance.load_level(scene_storage.LEVEL_OBJECT_SCENES.LEVEL_2);
    }

    public void load_level(scene_storage.LEVEL_OBJECT_SCENES _s) {
        Debug.Log("LOADLEVEL MAIN_;ENMU_UI" + _s.ToString());
        main_game_manager.Instance.load_level(_s);
    }
}
