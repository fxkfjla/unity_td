using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void BuyStandardTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
}
