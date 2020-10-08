using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TurretData
{
    public GameObject turretPrefab;
    public int cost;
    public GameObject updateTurretPrefab;
    public int updateCost;
    public TurretType turretType;
}

public enum TurretType{
    laserTurret,
    missleTurret,
    standardTurret
}
