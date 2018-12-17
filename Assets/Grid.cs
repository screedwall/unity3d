using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public Transform prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    static public void CreateMainGrid(Transform prefab, Transform parent, int player, int GridSize=10)
    {
        float positionX = 0;
        float positionZ = 0;
        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                positionX += 5.3f;
                GameObject plane = Instantiate(prefab, parent).gameObject;
                plane.name = string.Format("Cell[{0},{1}]", i, j);

                plane.GetComponent<CellController>().id = i * GridSize + j;
                plane.transform.position = new Vector3(positionX, 0, positionZ);
            }
            positionX = 0;
            positionZ += 5.3f;
        }
    }
}
