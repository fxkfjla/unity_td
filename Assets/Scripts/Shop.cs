using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;

    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SetTurretToBuild(standardTurret);
    }
}