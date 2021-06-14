using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    public Vector3 pos;
    public float offset, distance;
    public GameObject parent;
    public GameObject piece()
    {
        return DataStore().piece;
    }
    public bool main;
    private bool used;
    private DataStore DataStore()
    {
        return GameObject.FindGameObjectWithTag("dataStore").GetComponent<DataStore>();
    }
    private void Start()
    {
        parent = GameObject.FindGameObjectWithTag("parent");
        if(main)
        {
            for (int i = 0; i < offset + 1f; i++)
            {
                if(i != 0)
                {
                    GameObject instance = Instantiate(piece(), new Vector3(pos.x + (distance * i), pos.y, pos.z), Quaternion.identity, parent.transform);
                    DataStore().cams++;
                    Text t = instance.GetComponentInChildren<Text>();
                    t.text = DataStore().cams.ToString();
                }
                else
                {
                    DataStore().cams++;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!used)
        {
            GameObject instance = Instantiate(piece(), new Vector3(pos.x + (distance * DataStore().cams), pos.y, pos.z), Quaternion.identity, parent.transform);
            DataStore().cams++;
            Text t = instance.GetComponentInChildren<Text>();
            t.text = DataStore().cams.ToString();
            used = true;
        }
    }
}
