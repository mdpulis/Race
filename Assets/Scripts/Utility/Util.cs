using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Util
{
    static Util()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
    }
    
    public static T RandomItem<T>(this List<T> list)
    {        
        if (list.Count == 0)
            return default(T);
        if (list.Count == 1)
            return list[0];        
        return list[(Random.Range(0, list.Count))];
    }

    public static string SecondsToMinutesSeconds(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60);
        seconds %= 60;
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
