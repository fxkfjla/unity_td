using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // singleton and access build manager without referance
    public static BuildManager instance; 

    private TurretBlueprint turretToBuild;
    private bool sellTurret = false;

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

    public void SellTurretOn(Tile tile)
    {
        PlayerStats.money += (int)(tile.turret.GetComponent<Turret>().cost / 2);

        Destroy(tile.turret.gameObject);
        tile.turret = null;
        // player is now able to build on this tile
        tile.gameObject.tag = "Buildable";
        // tile no longer needs to glow
        tile.MakeNotGlow();
        // we are no longer selling turrets
        SetSellTurret(false);
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void SetSellTurret(bool expr)
    {
        sellTurret = expr;
    }

    public bool TurretSelected()
    {
        return turretToBuild != null;
    }

    public bool SellSelected()
    {
        return sellTurret;
    }

    public bool CanBuildOn(Tile tile)
    {
        return turretToBuild != null && tile.gameObject.tag == "Buildable";
    }

    public bool CanSellOn(Tile tile)
    {
        return turretToBuild == null && tile.gameObject.tag == "NotBuildable" && tile.turret != null && sellTurret == true;
    }
}
