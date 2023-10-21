using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ObjectData
{
    public GameObject toSpawn;
    public int weight;
}

public class Randomizer : MonoBehaviour
{
    public List<ObjectData> data = new();

    private int _sum;

    // Start is called before the first frame update
    void Start()
    {
        _sum = 0;
        foreach (ObjectData obj in data)
        {
            _sum += obj.weight;
        }

        Instantiate(GetToSpawn(), transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    GameObject GetToSpawn()
    {
        int weightLeft = Random.Range(0, _sum);
        int index = 0;
        while (weightLeft >= 0)
        {
            weightLeft -= data[index].weight;
            index++;
        }
        return data[index - 1].toSpawn;
    }
}
