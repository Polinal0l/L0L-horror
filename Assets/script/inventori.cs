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
    [SerializeField] Transform drop;
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
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    if (itemCurrentItem >= 0)
                    {
                        GameObject dropitem = Instantiate(items[itemCurrentItem].dropItem);
                        dropitem.transform.position = drop.position;
                        items[itemCurrentItem].inHand.SetActive(false);
                        itemCurrentItem = -1;
                    }
                    Destroy(hit.collider.gameObject);
                    int itemid = -1;
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].itemName == ci.ItemName)
                            itemid = i;
                    }
                    items[itemid].inHand.SetActive(true);
                    itemCurrentItem = itemid;
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
        if (Input.GetKeyDown(KeyCode.Q) && itemCurrentItem >= 0) 
        {
            GameObject dropitem = Instantiate(items[itemCurrentItem].dropItem);
            dropitem.transform.position = drop.position;
            items[itemCurrentItem].inHand.SetActive(false);
            itemCurrentItem = -1; 
        }
    }
}
