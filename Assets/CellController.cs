using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    public int id;


    public bool IsShip { get; set; }
    public bool IsDamaged { get; set; }

    public GameObject ShipObject { get; set; }
    public int ShipPartNumber { get; set; }
    public int ShipId { get; set; }

    void OnMouseDown()
    {
        GameObject.Find("IfClicked").GetComponent<Text>().text = "Clicked: " + id + "\nIs ship: " + IsShip.ToString();

        if (IsShip && !IsDamaged)
        {
            IsDamaged = true;
            ShipHandler.shipsList.Find(t => t.Id == ShipId).Damage();
            ShipObject.GetComponent<SOMETHING>().DAMAGE_PART(ShipPartNumber);
        }
    }
}
