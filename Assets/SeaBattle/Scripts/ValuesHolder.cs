using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuesHolder {
    public readonly int GRID_SIZE = 10;
    public readonly List<int> SHIPS_LIST = new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };


    /// <summary>
    /// Singleton 
    /// </summary>
    private static ValuesHolder instance;
    public static ValuesHolder Instance { get
        {
            if (instance == null)
                instance = new ValuesHolder();
            return instance;
        } }
    private ValuesHolder() { }


}
