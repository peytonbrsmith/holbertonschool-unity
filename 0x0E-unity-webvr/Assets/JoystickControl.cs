using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    public Transform topOfJoystick;
    [SerializeField]
    private float forwardBackwardTilt = 0;
    [SerializeField]
    private float sideToSideTilt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void onTriggerStay(Collider other)
    {
        if (other.CompareTag("hand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
