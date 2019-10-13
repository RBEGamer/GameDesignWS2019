using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public static Dictionary<string, int> lv_stats =new Dictionary<string, int>();

    public static int get_score_by_scene(scene_storage.LEVEL_OBJECT_SCENES _s)
    {
        int val_out = 0;
        if (lv_stats.TryGetValue(scene_storage.get_level_object_scene_name(_s),out val_out))
        {
            return val_out;
        }
            return -1;
    }

	public static void set_score_for_scene(scene_storage.LEVEL_OBJECT_SCENES _s, int _percentage) {
        lv_stats[scene_storage.get_level_object_scene_name(_s)] = _percentage;
    }

	
}
