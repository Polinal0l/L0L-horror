using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    Rigidbody[] rbs;
    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        Chengrb(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Chengrb(bool v)
    {
        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].isKinematic = v;
        }
    }
}
