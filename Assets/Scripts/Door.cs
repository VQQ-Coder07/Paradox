using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject openText()
    {
        return GameObject.FindGameObjectWithTag("openText");
    }    
    public GameObject portal()
    {
        return GameObject.Find("Portal 1");
    }
    public Transform demo()
    {
        return transform.parent.parent.GetChild(0).GetChild(0).transform;
    }
    
    public Text camNumb()
    {
        return GetComponentInChildren<Text>();
    }
    //[HideInInspector]
    public bool once = true, opened = true, ready = true;
    public GameObject pickup()
    {
        return GameObject.FindGameObjectWithTag("pickup");
    }
    private DataStore dataStore()
    {
        return GameObject.FindGameObjectWithTag("dataStore").GetComponent<DataStore>();
    }
    private void Start()
    {
        if(camNumb().text == "0") camNumb().text = dataStore().cams.ToString();
    }
    private Animator anim()
    {
        return this.transform.parent.gameObject.GetComponent<Animator>();
    }
    private void Switch()
    {
        if (opened && !once)
        {
            anim().Play("DoorClose");
            Invoke("CountReady", 1f);
            once = true;
        }
        else if(!opened && !once)
        {
            portal().transform.position = demo().position;
            anim().Play("DoorOpen");
            Invoke("CountReady", 1f);
            once = true;
        }
        ready = false;
    }
    private void CloseText()
    {
        openText().GetComponent<Text>().enabled = false;
    }
    private void CountReady()
    {
        ready = true;
    }
    private void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.E) && ready)
        {
            if(opened)
            {
                GameObject[] doors = GameObject.FindGameObjectsWithTag("door");
                foreach (GameObject door in doors)
                {
                    Door dr = door.transform.GetChild(0).gameObject.GetComponent<Door>();
                    if (!dr.opened)
                    {
                        openText().GetComponent<Text>().enabled = true;
                        Invoke("CloseText", 1.0f);
                        return;
                    }
                }
            }
            once = false;
            ready = false;
            opened = !opened;
            Switch();
        }
        pickup().GetComponent<RawImage>().enabled = true;
    }
    private void OnMouseExit()
    {
        pickup().GetComponent<RawImage>().enabled = false;
    }
}
