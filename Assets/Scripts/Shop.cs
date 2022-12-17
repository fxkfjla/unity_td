using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;

    private BuildManager buildManager;
    private WaveSpawner waveSpawner;

    void Start()
    {
        buildManager = BuildManager.instance;
        waveSpawner = WaveSpawner.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SetTurretToBuild(standardTurret);
    }

    public void SelectSellTurret()
    {
        buildManager.SetSellTurret(true);
    }

    public void PlayNextWave()
    {
        waveSpawner.SpawnNextWave();
    }
}