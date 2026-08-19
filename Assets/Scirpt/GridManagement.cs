using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagement : MonoBehaviour
{
    [SerializeField] public int width, height;

    [SerializeField] public Tile tile;
    [SerializeField] public Camera cam;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            DestroyImmediate(transform.GetChild(i).gameObject);

        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnTile = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                spawnTile.name = $"Tile {x} {y}";
                spawnTile.transform.SetParent(transform);

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnTile.Offset(isOffset);
            }
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        transform.name = "GridManagement" + ": " + transform.childCount;
    }

    

    public void ResetGrid()
    {
        for (int i = 0; i < transform.childCount; i++)
            DestroyImmediate(transform.GetChild(i).gameObject);

        GenerateGrid();
    }
}
