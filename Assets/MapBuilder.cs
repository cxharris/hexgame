using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
    {
    public GameObject HexPrefab;

    static int columns = 20;
    static int rows = 10;
    static readonly float gap = 0.5f;
    static readonly float cos30Deg = (float)Mathf.Cos(30.0f * (Mathf.PI / 180.0f));

    // Start is called before the first frame update
    void Start()
        {
        BuildMap();
        }

    void BuildMap()
        {
        for (int x = 0; x < columns; x++)
            {
            for (int z = 0; z < rows; z++)
                {
                GameObject GO = Instantiate(HexPrefab);
                
                if (z % 2 == 0)
                    {
                    GO.transform.position = new Vector3(x * (2 * cos30Deg + gap), 
                                                        0, 
                                                        (float)(z * (1.5f + gap * cos30Deg)));
                    }
                else
                    {
                    GO.transform.position = new Vector3(x * (2 * cos30Deg + gap) + cos30Deg + gap / 2.0f, 
                                                        0, 
                                                        (float)(z * (1.5f + gap * cos30Deg)));
                    }
                
                    GO.transform.parent = transform;
                }

            }
        }
    }