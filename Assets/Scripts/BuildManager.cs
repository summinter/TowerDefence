using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TurretData laserTurret;
    public TurretData missileTurret;
    public TurretData standardTurret;
    private TurretData selectedTurretData;
    public Text moneyText;
    public Animator moneyAnimator;

    private int money = 1000;
    void changeMoney(int change=0){
        money += change;
        moneyText.text = money + "元";
    }
    //要建造的炮台
    public void Update(){
        if (Input.GetMouseButtonDown(0)){
            if (EventSystem.current.IsPointerOverGameObject()==false){
                //开发炮台的建造   
                Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapLayer")); 
                if (isCollider){
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();//得到点击的mapcube
                    if(selectedTurretData!=null && mapCube.turretGo == null){
                        //可以创建
                        if (money>selectedTurretData.cost){
                            changeMoney(-selectedTurretData.cost);
                            mapCube.BuildTurret(selectedTurretData.turretPrefab);
                        }else{
                            //TODO 提示钱不够
                            moneyAnimator.SetTrigger("Flicker");
                        }


                    }
                    else if (mapCube.turretGo == null){
                        //TODO 升级处理
                    }
                }
            }
        }
    }
    public void OnLaserSelected(bool isOn){
        if (isOn){
            selectedTurretData = laserTurret;
        }
    }
    public void OnMissileSelected(bool isOn){
        if (isOn){
            selectedTurretData = missileTurret;
        }
    }
    public void OnStandardSelected(bool isOn){
        if (isOn){
            selectedTurretData = standardTurret;
        }
    }
    
}
