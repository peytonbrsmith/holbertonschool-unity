using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().OnApplicationFocus(true);
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            if (GetComponent<Timer>().timerText.color == Color.green)
            {
                GetComponent<Timer>().timerText.color = Color.white;
                GetComponent<Timer>().timerText.fontSize = 48;
                GetComponent<Timer>().enabled = true;
                GetComponent<Timer>().ResetTimer();
                GetComponent<Timer>().enabled = false;
            }
            GetComponent<CharacterController>().enabled = false;
            transform.position = new Vector3(0, 1.25f, 0);
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
