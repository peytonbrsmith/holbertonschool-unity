using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Timer>().enabled = false;
            other.gameObject.GetComponent<Timer>().timerText.color = Color.green;
            other.gameObject.GetComponent<Timer>().timerText.fontSize = 60;
        }
    }
}
