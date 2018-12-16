using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler {
    public static List<ShipInfo> shipsList = new List<ShipInfo>();
}
public class ShipInfo {
    public int Id;
    public int Size;
    public int Parts;

    public ShipInfo(int id, int size)
    {
        Id = id;
        Size = size;
        Parts = size;
    }

    public void Damage()
    {
        if (Parts > 0)
            Parts--;
    }

    public bool IsAlive()
    {
        return (Parts > 0);
    }



}
