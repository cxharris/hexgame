using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class test : MonoBehaviour
{
    public GameObject textPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Cell cell in HexMap.Instance.GetCellList())
        {
            GameObject textObject = Instantiate(textPrefab);
            textObject.transform.eulerAngles = new Vector3(90, 0, 0);
            RenderLegend(cell, textObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RenderLegend(Cell cell, GameObject textObject)
    {
        //Doing it this way paves the ground for adding more text elements,
        //and accessing these new elements via the index in GetChild().
        TextMeshPro textMesh = textObject.transform.Find("Coords").gameObject.GetComponent<TextMeshPro>();
        textMesh.text = cell.GetCoords().x + "," + cell.GetCoords().z;
        textObject.transform.position = cell.transform.position + new Vector3(0f, 0.01f, 0f); // Nudge it up a bit to avoid z-fighting
    }
}