using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPainting : MonoBehaviour
{
    public Material[] materials;
    private void Start()
    {
        this.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];
    }
}
