using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GameState { MAIN_MENU, RUNNING, PAUSE,LEVEL_SPAWN }

public delegate void OnStateChangeHandler();

public class main_game_manager : MonoBehaviour
{
    protected main_game_manager() { }
    private static main_game_manager instance = null;



    public event OnStateChangeHandler OnStateChange;

    public event OnStateChangeHandler OnGameLevelScenesLoaded;


    public GameState gameState { get; private set; }
    public GameState last_gameState { get; private set; }

    public static main_game_manager Instance
    {
        get
        {
            if (main_game_manager.instance == null)
            {       
                main_game_manager.instance = new main_game_manager();
            }
            return main_game_manager.instance;
        }

    }

    public void SetGameState(GameState state)
    {
        Debug.Log(state);
        this.last_gameState = this.gameState;

        this.gameState = state;
        game_state_changed(); //internale state change first
        OnStateChange?.Invoke();
    }

    public void OnApplicationQuit()
    {
        main_game_manager.instance = null;
    }



    public void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            OnStateChange?.Invoke();
        }
    }

    
    void game_state_changed() {
       
        if (main_game_manager.instance.gameState == GameState.PAUSE)
        {
            Time.timeScale = 0.0f;
        }

        if (main_game_manager.instance.gameState == GameState.RUNNING)
        {
            Time.timeScale = 1.0f;
        }
    }


    public void trigger_main_update_event() {
        OnStateChange?.Invoke();

    }

    public void load_level(scene_storage.LEVEL_OBJECT_SCENES _s)
    {
        level_object_loader.obj_to_load = _s;
        SceneManager.LoadScene(scene_storage.get_scene_name(scene_storage.SCENES.GAME_SCENE), LoadSceneMode.Single);
    }

    public void load_scene(scene_storage.SCENES _s) {
        SceneManager.LoadScene(scene_storage.get_scene_name(_s), LoadSceneMode.Single);
    }


    public void level_scene_loaded_completly() {
        OnGameLevelScenesLoaded?.Invoke();

        
    }




  


  



    public void toggle_pause()
    {

        if (main_game_manager.instance.gameState == GameState.PAUSE)
        {
            SetGameState(GameState.RUNNING);
        }
        else
        {
            SetGameState(GameState.PAUSE);
        }
    }


   


}