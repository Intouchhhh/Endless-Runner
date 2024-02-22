using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCount : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public int disRun;
    public bool addDis = false;
    public float disDelay = 0.35f;

    void Update()
    {
        if (addDis == false)
        {
            addDis = true;
            StartCoroutine(AddDis());
        }
    }
    IEnumerator AddDis()
    {
        disRun +=1;
        disDisplay.GetComponent<Text>().text = "" + disRun;
        disEndDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(disDelay);
        addDis = false;
    }

}
