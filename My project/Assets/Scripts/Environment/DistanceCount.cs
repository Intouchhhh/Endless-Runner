using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public GameObject disDisplay;
    public int disRun;
    public bool addDis = false;

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
        yield return new WaitForSeconds(0.25f);
        addDis = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // stop when hit with obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StopAllCoroutines();
            addDis = true; 
        }
    }
}
