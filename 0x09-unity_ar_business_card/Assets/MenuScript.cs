using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/peytons0606/");
    }

    public void LinkedIn()
    {
        Application.OpenURL("https://www.linkedin.com/in/peyton-smith-65b113187/");
    }

    public void Website()
    {
        Application.OpenURL("https://peytonsmith.dev/");
    }

    public void GitHub()
    {
        Application.OpenURL("https://github.com/peytonbrsmith/");
    }
}
