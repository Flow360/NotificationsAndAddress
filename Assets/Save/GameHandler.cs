using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject playerGameObject;

    private PlayerToSave unit;

    [SerializeField]
    public List<Vector3> posPlay = new List<Vector3>();

    private void Awake()
    {
        unit = playerGameObject.GetComponent<PlayerToSave>();

        SaveSystem.Init(); //Initiate savesys.
        

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    private void Save()
    {
        Vector3 playerPosition = playerGameObject.transform.position;
        int goldAmount = unit.goldAmount;

        SaveObject saveObject = new SaveObject
        {
            goldAmount = goldAmount,
            playerPosition = playerPosition,
            pos = posPlay
            
        };
        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);
        
    }
    private void Load()
    {
        string saveString = SaveSystem.Load();
        if(saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            playerGameObject.transform.position = saveObject.playerPosition;
            unit.goldAmount = saveObject.goldAmount;
            posPlay = saveObject.pos;
        }
  
        else
        {
            Debug.Log("NO Save");
        }
    }



    private class SaveObject{
        public int goldAmount;
        public Vector3 playerPosition;
        public List<Vector3> pos;

    }

}



