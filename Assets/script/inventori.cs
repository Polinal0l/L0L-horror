using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class inventori : MonoBehaviour
{
    [SerializeField]GameObject help;
    int itemCurrentItem = -1;

    [System.Serializable]
    public class item 
    {
        public GameObject dropItem;
        public GameObject inHand;
        public string itemName;
    }

    [SerializeField] item[] items;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            CollactableItem ci = hit.collider.GetComponent<CollactableItem>();
            if (ci != null)
            {
                help.SetActive(true);
                if (Input.GetKey(KeyCode.E)) 
                {
                 Destroy(hit.collider.gameObject);
                    int itemid = -1;
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].itemName == ci.ItemName)
                            itemid = i;
                    }
                    items[itemid].inHand.SetActive(true);
                }

            }
            else
            {
                help.SetActive(false);
            }
        }
        else
        {
            help.SetActive(false);
        }
    }
}
