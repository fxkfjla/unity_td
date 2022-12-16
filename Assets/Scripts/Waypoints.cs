using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;

    void Awake()
    {
        // Transform array
        waypoints = new Transform[transform.childCount];

        for(int i = 0; i < waypoints.Length; i++)
        {
            // assign following prefab waypoints to Tranfsorm array
            waypoints[i] = transform.GetChild(i);
        }
    }
}
