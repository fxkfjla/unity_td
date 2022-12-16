using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // singleton and access build manager without referance
    public static BuildManager instance; 

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    
    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }

        instance = this;
    }
}