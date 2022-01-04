using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Load_Upgrades : MonoBehaviour
{
    public class Upgrades{
        public List<string> blockUpgrades = new List<string>();
        public List<string> movementUpgrades = new List<string>();

        public Upgrades(){
            blockUpgrades.Add("core");
            blockUpgrades.Add("1");
            blockUpgrades.Add("2");
            blockUpgrades.Add("3");
            blockUpgrades.Add("4");
            blockUpgrades.Add("5");
            blockUpgrades.Add("6");
            blockUpgrades.Add("7");
                        
            movementUpgrades.Add("wheel");
        }
    }

    void PutPartPrefabsOnScreen(List<string> listOfParts){
        foreach(string part in listOfParts){
            GameObject partObject = Instantiate(temp);

            partObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Prefabs/parts/part images/"+part);
            partObject.name = part;
            partObject.transform.position = position;
            partObject.transform.SetParent(parentList);

            objectIndex++;
            if(objectIndex == 4){
                position += new Vector3(-3f,-1f,0);
                objectIndex = 0;
            }
            else{
                position += new Vector3(1f,0f,0);
            }
        }
    }
    
    Upgrades upgrades;
    Vector3 position = new Vector3(1.5f,4.5f,0);
    public GameObject temp;
    public Transform parentList;
    public int objectIndex = 0;
    void Start()
    {
        
         Upgrades obj = new Upgrades();
         File.WriteAllText("Data\\upgrades.json", JsonUtility.ToJson(obj));

        upgrades = JsonUtility.FromJson<Upgrades>(File.ReadAllText("Data/upgrades.json"));
        PutPartPrefabsOnScreen(upgrades.blockUpgrades);
        PutPartPrefabsOnScreen(upgrades.movementUpgrades);
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
