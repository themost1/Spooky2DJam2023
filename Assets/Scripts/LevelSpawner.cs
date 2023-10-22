using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject levelRandomizer;
    public float offset;
    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        SpawnLevel(-1);
        SpawnLevel(0);
        _index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = PlayerMovement.instance.transform.position.x;
        Vector2 currSpawnLoc = GetLocForIndex(_index);
        if (playerX > currSpawnLoc.x)
        {
            SpawnLevel(++_index);
        }
    }

    Vector2 GetLocForIndex(int index)
    {
        Vector2 spawnLoc = transform.position;
        spawnLoc.x += offset * index;
        return spawnLoc;
    }

    void SpawnLevel(int index)
    {
        Vector2 spawnLoc = GetLocForIndex(index);
        Instantiate(levelRandomizer, spawnLoc, transform.rotation);
    }
}
