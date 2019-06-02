using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class miniGame : MonoBehaviour
{
    [SerializeField]
    Image[] images;

    List<float> values;
    List<string> string_val;

    int count, counter;
    int number, str_num;

    float[] valuess;
    string[] strinngss;
    // Start is called before the first frame update


    void Start()
    {

        values = new List<float>();
        string_val = new List<string>();

        count = 0;
        counter = 0;

        number = values.Count;
        str_num = string_val.Count;

        valuess = new float[2] { -1f, 1f };
        strinngss = new string[2] { "Y", "X" };
    }

    //Update is called once per frame
    void Update()
    {
        Debug.Log("num_input: " + count);

        Debug.Log(values.Count + " " + string_val.Count);
        if(values.Count < 5 || string_val.Count < 5)
        {

            if (values.Count != 5)
            {
                int rand = Random.Range(0, 3);

                if (rand != 0)
                {

                    if (rand == 1)
                    {
                        values.Add(valuess[1]);
                    }
                    else
                    {
                        values.Add(valuess[0]);
                    }
                }
            }

            if (string_val.Count != 5)
            {
                int Srand = Random.Range(0, 3);

                if (Srand != 0)
                {
                    if (Srand == 1)
                    {
                        string_val.Add(strinngss[1]);

                    }
                    else
                    {
                        string_val.Add(strinngss[0]);
                    }
                }
            }

        }

        if (values.Count == 5 && string_val.Count == 5)
        {
            for (int i = 0; i < 5; i++)
            {
                if (values[i] == 1)
                {
                    if (string_val[i] == "X")
                    {
                        images[i].rectTransform.localEulerAngles = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        images[i].rectTransform.localEulerAngles = new Vector3(0, 0, 90);
                    }
                }
                else
                {
                    if (string_val[i] == "X")
                    {
                        images[i].rectTransform.localEulerAngles = new Vector3(0, 0, 180);
                    }
                    else
                    {
                        images[i].rectTransform.localEulerAngles = new Vector3(0, 0, 270);
                    }
                }

            }
        }

        if (values.Count == 5 && string_val.Count == 5)
        {
            
            //Debug.Log(string_val[count] + " " + values[count] + " " + count);
            if (count != 5)
            {
                if (string_val[count] == "Y")
                {
                    if (Input.GetAxis("DpadV") < 0 || Input.GetAxis("DpadV") > 0)
                    {
                        if (Input.GetAxis("DpadV") == values[count])
                        {
                            
                                count++;
                            
                        }
                    }
                }

                if (string_val[count] == "X")
                {
                    if (Input.GetAxis("DpadH_R") < 0 || Input.GetAxis("DpadH_R") > 0)
                    {
                        if (Input.GetAxis("DpadH_R") == values[count])
                        {
                            
                                count++;
                            
                        }
                    }
                }

                if (string_val[count] == "Y")
                {
                    if (Input.GetAxis("DpadH_S") < 0 || Input.GetAxis("DpadH_S") > 0)
                    {
                        if (Input.GetAxis("DpadH_S") == values[count])
                        {

                            count++;

                        }
                    }
                }

                if (string_val[count] == "X")
                {
                    if (Input.GetAxis("DpadB") < 0 || Input.GetAxis("DpadB") > 0)
                    {
                        if (Input.GetAxis("DpadB") == values[count])
                        {
                            
                            count++;

                        }
                    }
                }

            }


            if (count > 4)
            {
                transform.parent.GetComponent<Tire_Stats>().G_One = true;
                Destroy(gameObject);
            }
        }

    }


}
