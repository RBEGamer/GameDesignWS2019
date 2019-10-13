using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{

    AudioSource asource;
    // Start is called before the first frame update
    public Vector3 roation_speed = Vector3.forward;

   private void Awake()
    {
        asource = this.GetComponent<AudioSource>();
    }
    void Start()
    {
        GameObject.Find("player_ball").GetComponent<player_ball>().max_bonus++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(roation_speed.x * Time.deltaTime, roation_speed.y * Time.deltaTime, roation_speed.z * Time.deltaTime);
    }


    public void collected() {

        StartCoroutine(wait_for_finish());

    }


    IEnumerator wait_for_finish()
    {
        asource.Play();
        while (asource.isPlaying)
        {
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
