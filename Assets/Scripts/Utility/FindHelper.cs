using UnityEngine;
using System.Linq;

/// <summary>
/// Helps to find objects
/// </summary>
public static class FindHelper
{
    /// <summary>
    /// Finds an object of type even if inactive in the scene
    /// </summary>
    public static T FindObjectOfTypeEvenIfInactive<T>() where T: MonoBehaviour
    {
        return Resources.FindObjectsOfTypeAll<Transform>()
            .Select(
                x => x.GetComponent<T>()).Where(x => x != null && x.gameObject.hideFlags == HideFlags.None
            ).FirstOrDefault();
    }

    /// <summary>
    /// Finds all objects of type even if inactive in the scene
    /// </summary>
    public static T[] FindObjectsOfTypeEvenIfInactive<T>() where T : MonoBehaviour
    {
        return Resources.FindObjectsOfTypeAll<Transform>()
            .Select(
                x => x.GetComponent<T>()).Where(x => x != null && x.gameObject.hideFlags == HideFlags.None
            ).ToArray();
    }
}
