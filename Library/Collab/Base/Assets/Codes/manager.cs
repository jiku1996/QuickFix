using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    
    List<string> fault_name;

    private void Awake()
    {
        fault_name = new List<string>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fault_name[0].
    }

    public void addFault(int k, string f)
    {
        if (!fault_name.Contains(k + f))
        {
            fault_name.Add(k + f);
        }
    }

    public void remFault(int k, string f)
    {
        if (!fault_name.Contains(k + f))
        {
            fault_name.Remove(k + f);
        }
    }
}
