using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level_object_loader : MonoBehaviour
{


   
    public static scene_storage.LEVEL_OBJECT_SCENES obj_to_load = scene_storage.LEVEL_OBJECT_SCENES.LEVEL_1;


    private AudioSource asource;
    void Awake() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        asource = this.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(scene_storage.get_level_object_scene_name(level_object_loader.obj_to_load), LoadSceneMode.Additive);  
    }


    

   public  void change_level(scene_storage.LEVEL_OBJECT_SCENES _d) {
        level_object_loader.obj_to_load = _d;
        StartCoroutine(wait_for_sound_finish_change_level());
    }

    IEnumerator wait_for_sound_finish_change_level()
    {
        asource.Play();
        yield return new WaitWhile(() => asource.isPlaying);

        SceneManager.LoadScene(scene_storage.get_scene_name(scene_storage.SCENES.GAME_SCENE), LoadSceneMode.Single);
    }

   



    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        if (!scene.name.Contains("level")) {
            return;
        }
       
        main_game_manager.Instance.level_scene_loaded_completly();
       
        foreach (GameObject n in GameObject.FindGameObjectsWithTag("INIT"))
        {
            Debug.Log(n);
           n.GetComponent<tag_initilizer>().on_init();
        }
        main_game_manager.Instance.SetGameState(GameState.RUNNING);


        GameObject.Find("player_ball").GetComponent<player_ball>().spawn();
    }


    IEnumerator SceneLoadingDelay()
    {
        yield return new WaitForSeconds(1);
        main_game_manager.Instance.level_scene_loaded_completly();
    }

}
