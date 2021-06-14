using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugStick : MonoBehaviour
{
    public Transform player;
    private void Update()
    {
        GetComponent<Text>().text = player.position.ToString() + "\r\n" + player.localEulerAngles.ToString() + "\r\n" + player.localScale.ToString();
    }

}