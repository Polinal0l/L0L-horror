using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItem : MonoBehaviour
{
    [SerializeField]List<Transform> spawnIT = new();
    [SerializeField]List<GameObject> spawnGO = new();
    // Start is called before the first frame update
    void Start()
    {
        if (spawnGO.Count > spawnIT.Count)
        {
            Debug.LogError("Не хватает точек спавна");
            return;
        }
        for (int i = 0; i < spawnGO.Count; i++)
        { int id = Random.Range(0, spawnIT.Count);
            Instantiate(spawnGO[i], spawnIT[id].position, spawnIT[id].rotation);
            spawnIT.RemoveAt(id);
        }
    }

    
}
