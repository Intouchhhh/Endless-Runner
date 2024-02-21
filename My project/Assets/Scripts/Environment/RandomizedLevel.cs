using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedSection : MonoBehaviour
{
    public GameObject[] groundSections;
    public float zSpawn = 0;
    public float sectionLength = 99;
    public int numberOfSections = 5;
    public Transform playerTransform;

    private List<GameObject> activeSections = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberOfSections; i++)
        {
            SpawnGroundSection(i > 2);
        }
    }

    void Update()
    {
        // Check if it's time to spawn a new section and delete an old one
        if (playerTransform.position.z - 80 > (zSpawn - (numberOfSections * sectionLength)))
        {
            SpawnGroundSection(true);
            DeleteOldestSection();
        }
    }

    public void SpawnGroundSection(bool spawnRandom)
    {
        int randomIndex = spawnRandom ? Random.Range(0, groundSections.Length) : 0;
        Vector3 spawnPosition = new Vector3(0, 0, zSpawn);
        GameObject section = Instantiate(groundSections[randomIndex], spawnPosition, Quaternion.identity);
        activeSections.Add(section);
        zSpawn += sectionLength;
    }

    void DeleteOldestSection()
    {
        GameObject sectionToRemove = activeSections[0];
        activeSections.RemoveAt(0);
        Destroy(sectionToRemove);
    }
}