using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{

    List<string> faultList;
    // Start is called before the first frame update
    void Start()
    {
        faultList = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addFault(string n)
    {
        faultList.Add(n);
    }

    public void remFault(string n)
    {
        faultList.Remove(n);
    }
}
