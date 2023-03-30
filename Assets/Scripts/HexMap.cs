using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{

    static readonly float Gap = 0.5f;
    static readonly float Cos30Deg = (float)Mathf.Cos(30.0f * (Mathf.PI / 180.0f));
    public GameObject cellPrefab;
    int columns = 20;
    int rows = 10;

    public static HexMap Instance { get; private set; }
    [SerializeField] private List<Cell> cellList;

    private void Awake()
    {
        // Code to ensure this is a singleton. One Hex Map in the game. Sounds OK for now.
        if (Instance != null)
        {
            Debug.LogError("There's more than one HexMap! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        cellList = new List<Cell>();
    }

    // Start is called before the first frame update
    void Start()
    {
        BuildMap();
    }

    /// <summary>
    /// <Method> <c>BuildMap</c> creates <c>Cell Prefab</c> instances for each co-ordinate,
    /// assigns them a set of grid co-ordinates (<c>GridPosition</c>) and then adds the new
    /// <c>cellPrefab</c> to the <c>List<Cell></c>.
    /// </summary>
    private void BuildMap()
    {
        float newX;
        float newZ;

        for (int x = 0; x < columns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                newZ = (float)(z * (1.5f + Gap * Cos30Deg));

                if (z % 2 == 0)
                {
                    newX = x * (2 * Cos30Deg + Gap);
                }
                else
                {
                    newX = x * (2 * Cos30Deg + Gap) + Cos30Deg + Gap / 2.0f;
                }

                GameObject cellPrefabInstance = GameObject.Instantiate(cellPrefab, new Vector3(newX, 0, newZ), Quaternion.identity) as GameObject;

                if (cellPrefabInstance != null)
                {
                    // Get a reference to the 'Cell' script - scripts are components!
                    var cellScriptReference = cellPrefabInstance.GetComponent<Cell>();
                    // Set the co-ordinates
                    cellScriptReference.SetCoords(x, z);
                }

                cellPrefabInstance.transform.parent = transform;
                cellList.Add(cellPrefabInstance.GetComponent<Cell>());
            }
        }
    }

    /// <summary>
    /// <Method> <c>GetCellList</c> returns a <c>List</c> containing every Cell in the <c>HexMap</c>
    /// </summary>
    public List<Cell> GetCellList()
    {
        return cellList != null ? cellList : null;
    }


}
