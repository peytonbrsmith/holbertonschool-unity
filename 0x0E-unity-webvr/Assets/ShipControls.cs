using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    public GameObject Fire;
    public GameObject Warp;
    public GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void warp()
    {
        StartCoroutine("startWarp");
    }

    public void fire()
    {
        StartCoroutine("startFire");
    }

    IEnumerator startWarp()
    {
        Debug.Log("Warping");
        Warp.SetActive(true);
        Canvas.SetActive(false);
        yield return new WaitForSeconds(5);
        Warp.SetActive(false);
        Canvas.SetActive(true);
    }

    IEnumerator startFire()
    {
        Debug.Log("Firing");
        Fire.SetActive(true);
        Canvas.SetActive(false);
        yield return new WaitForSeconds(5);
        Fire.SetActive(false);
        Canvas.SetActive(true);
    }
}
