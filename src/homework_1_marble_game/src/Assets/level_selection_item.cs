using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level_selection_item : MonoBehaviour
{
    public scene_storage.LEVEL_OBJECT_SCENES level_scene;

    public GameObject star_1;
    public GameObject star_2;
    public GameObject star_3;

    public Sprite star_gold;
    public Sprite star_black;
    // Start is called before the first frame update
    void Start()
    {
        int tmp  = stats.get_score_by_scene(level_scene);


        Debug.Log(tmp);
        if (tmp > 15)
        {
            star_1.GetComponent<Image>().sprite = star_gold;
        }
        else {
            star_1.GetComponent<Image>().sprite = star_black;
        }

        if (tmp > 48)
        {
            star_2.GetComponent<Image>().sprite = star_gold;
        }
        else
        {
            star_2.GetComponent<Image>().sprite = star_black;
        }

        if (tmp > 81)
        {
            star_3.GetComponent<Image>().sprite = star_gold;
        }
        else
        {
            star_3.GetComponent<Image>().sprite = star_black;
        }


    }
}
