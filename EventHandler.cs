using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventHandler : MonoBehaviour {
    public GameObject panel;
    public Transform ship;
    public GameObject prefab;
    public Transform[] cells;
    static public float scale = 0.2f;
    static int k = 20; //ships count

    [Tooltip("Размер поля")]
    public int GridSize;


	void Start () {
        CreateMainGrid();
        
        
        float positionX = -55f;
        float positionZ = 0;
        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                positionX += 5.3f;
                Transform parent = GameObject.Find("GameObject").GetComponent<Transform>();
                GameObject plane = Instantiate(prefab, parent).gameObject;
                plane.name = string.Format("Cell[{0},{1}]", i, j);

                plane.GetComponent<CellController>().id = i * GridSize + j;
                plane.transform.position = new Vector3(positionX, 0, positionZ);
            }
            positionX = -55f;
            positionZ += 5.3f;
        }

        CreateShips();
       


        NetShipsInfo MyShips = new NetShipsInfo();

        NetMessage MyMsg = new NetMessage();
        MyMsg.x = JsonConvert.SerializeObject(MyShips);
        //SendMessage(MyMsg.x);

        GameObject game = GameObject.Find("GameObject");
        game.GetComponent<Transform>().localScale = new Vector3(1f * scale, 1f * scale, 1f * scale);
        game.transform.position = new Vector3(0f, 0f, -5f);
	}


    private void CreateMainGrid()
    {
        float positionX = 0;
        float positionZ = 0;
        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                positionX += 5.3f;
                Transform parent = GameObject.Find("GameObject").GetComponent<Transform>();
                GameObject plane = Instantiate(prefab, parent).gameObject;
                plane.name = string.Format("Cell[{0},{1}]", i, j);

                plane.GetComponent<CellController>().id = i * GridSize + j;
                plane.transform.position = new Vector3(positionX, 0, positionZ);
            }
            positionX = 0;
            positionZ += 5.3f;
        }
    }

    private void CreateShips()
    {
        List<int> currentShips = new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1  };

        List<ShipPlacement> ships = GetListOfShips(GridSize, currentShips);

        int shipId = 0;

        foreach (ShipPlacement shipPlacement in ships)
        {

            Transform planeTrFirst = GameObject.Find(string.Format("Cell[{0},{1}]", shipPlacement.startX, shipPlacement.startY)).transform;
            Transform planeTrSecond = GameObject.Find(string.Format("Cell[{0},{1}]", shipPlacement.endX, shipPlacement.endY)).transform;

            GameObject ship = Instantiate(cells[shipPlacement.size - 1], planeTrFirst, true).gameObject;
            ship.name = string.Format("Ship[{0},{1}][{2},{3}]", shipPlacement.startX, shipPlacement.startY, shipPlacement.endX, shipPlacement.endY);

            Vector3 COOLP0SITI0N = Vector3.Lerp(planeTrFirst.position, planeTrSecond.position, 0.5f);

            if (shipPlacement.rotate == 0)
            {
                ship.transform.Rotate(new Vector3(0, 90, 0));
            }



            int partNum = 0;
            if (shipPlacement.rotate == 0)
            {
                partNum = shipPlacement.size - 1;
            }

            for (int x = shipPlacement.startX; x <= shipPlacement.endX; x++)
            {
                for (int y = shipPlacement.startY; y <= shipPlacement.endY; y++)
                {
                    CellController cell = GameObject.Find(string.Format("Cell[{0},{1}]", x, y)).GetComponent<CellController>(); 
                    cell.IsShip = true;
                    cell.IsDamaged = false;
                    if (shipPlacement.rotate == 0)
                        cell.ShipPartNumber = partNum--;
                    else
                        cell.ShipPartNumber = partNum++;
                    cell.ShipObject = ship;
                    cell.ShipId = shipId;
                }
            }

            ship.transform.position = new Vector3(COOLP0SITI0N.x, 2.2f, COOLP0SITI0N.z);
            ShipHandler.shipsList.Add(new ShipInfo(shipId, shipPlacement.size));

            shipId ++;
        }
    }




    public void ToggleValueChanged(bool change)
    {
        panel.SetActive(change);
        Debug.Log(change.ToString());
    }
	// Update is called once per frame
	void Update () {
	}

    /// <summary>
    /// Ставит на матрицу GRID корабль размером TYPE
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    ShipPlacement FindShipPlacement(int[] grid, int type)
    {
        System.Random random = new System.Random();

        int SIZE = GridSize;

	    int x = 0, y = 0, rotate = 0;
	    bool fl = true;
	    while (fl) //выбор начальной координаты
	    {
		    int s = 0;
            rotate = random.Next(2);
		    if (rotate == 0)
		    {
                y = random.Next(SIZE);
                x = random.Next(SIZE - type);
                for (int i = 0; i < type; i++) s += grid[(x + i) * SIZE + y];
			    if (s == 0) fl = false;
		    }
		    else
		    {
                x = random.Next(SIZE);
                y = random.Next(SIZE - type);
                for (int i = 0; i < type; i++) s += grid[x * SIZE + y + i];
			    if (s == 0) fl = false;
		    }
	    }

	    int parameter;
	    if (rotate == 0)
	    {
		    for (parameter = 0; parameter<type; parameter++) //установка занятости клеток
		    {
                grid[(x + parameter) * SIZE + y] = type;
                if (y + 1 < SIZE) 
                    grid[(x + parameter) * SIZE + y + 1] = 5;
                if (y - 1 >= 0)
                    grid[(x + parameter) * SIZE + y - 1] = 5;
		    }
            if (x + parameter < SIZE)
		    for (int j = -1; j<2; j++)
                if (y + j >= 0 && y + j < SIZE) 
                    grid[(x + parameter) * SIZE + y + j] = 5;
		    if (x - 1 >= 0)
		    for (int j = -1; j<2; j++)
                if (y + j >= 0 && y + j < SIZE) 
                    grid[(x - 1) * SIZE + y + j] = 5;
	    }
	    else
	    {
		    for (parameter = 0; parameter<type; parameter++) //установка занятости клеток
		    {
                grid[x * SIZE + y + parameter] = type;
                if (x + 1 < SIZE) 
                    grid[(x + 1) * SIZE + y + parameter] = 5;
                if (x - 1 >= 0) 
                    grid[(x - 1) * SIZE + y + parameter] = 5;
		    }
            if (y + parameter < SIZE)
		        for (int j = -1; j<2; j++)
                    if (x + j >= 0 && x + j < SIZE)
                        grid[(x + j) * SIZE + y + parameter] = 5;
		    if (y - 1 >= 0)
		        for (int j = -1; j<2; j++)
                    if (x + j >= 0 && x + j < SIZE)
                        grid[(x + j) * SIZE + y - 1] = 5;
	    }

        return new ShipPlacement(type, rotate, x, y, (rotate ==  0) ? (x + type - 1) : (x), (rotate ==  0) ? (y) : (y + type - 1));
    }

    List<ShipPlacement> GetListOfShips(int size, List<int> shipList)
    {
	    int[] grid = new int[size * size];
        List<ShipPlacement> listOfShips = new List<ShipPlacement>();

        foreach (int shipSize in shipList)
        {
            listOfShips.Add(FindShipPlacement(grid, shipSize));
        }
	   return listOfShips;
    }
}

public class ShipPlacement {
    public int size;
    public int rotate;
    public int startX;
    public int startY;
    public int endX;
    public int endY;

    public ShipPlacement(int size, int rotate, int startX, int startY, int endX, int endY) {
        this.size = size;
        this.rotate = rotate;
        this.startX = startX;
        this.startY = startY;
        this.endX = endX;
        this.endY = endY;
    }
}
