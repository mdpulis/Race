using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{    
    public static T RandomItem<T>(this List<T> list)
    {
        if (list.Count == 0)
            return default(T);
        if (list.Count == 1)
            return list[0];        
        return list[(Random.Range(0, list.Count))];
    }
}
