using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    
    [HideInInspector]
    public GameObject turretGo;//保存当前cube上的炮台
    // Start is called before the first frame update
    public GameObject buildEffect;

    private Renderer renderer;
    void  Start()
    {
        renderer = GetComponent<Renderer>();
    }




    public void BuildTurret(GameObject turretPrefab){
        turretGo = GameObject.Instantiate(turretPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);

    }
    void OnMouseEnter()
    {
        if (turretGo==null && EventSystem.current.IsPointerOverGameObject()==false){
            renderer.material.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
