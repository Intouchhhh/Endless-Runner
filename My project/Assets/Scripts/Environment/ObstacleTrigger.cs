using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public GameObject LevelControl;

    // when hit trigger these
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerController>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
        LevelControl.GetComponent<DistanceCount>().enabled = false;
        LevelControl.GetComponent<EndRunSequence>().enabled = true; 
    }
   
}
