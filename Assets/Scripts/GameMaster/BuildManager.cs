using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // singleton and access build manager without referance
    public static BuildManager instance; 

    private TurretBlueprint turretToBuild;

   void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }

        instance = this;
    }

    public void BuildTurretOn(Tile tile)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money"!);
            // cannot afford turret, so null
            SetTurretToBuild(null);
            // tile no longer needs to glow
            tile.MakeNotGlow();
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        tile.turret = (GameObject)Instantiate
        (
            turretToBuild.prefab, 
            tile.GetBuildPosition(), 
            tile.transform.rotation
        );
        
        // turret was build, no more turrets to build, so null
        SetTurretToBuild(null);
        // player is no longer able to build on this tile
        tile.gameObject.tag = "NotBuildable";
        // tile no longer needs to glow
        tile.MakeNotGlow();
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public bool CanBuildOn(Tile tile)
    {
        return turretToBuild != null && tile.gameObject.tag == "Buildable";
    }
}
