using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    // can be accessed but not edited by all classes in the project.
    public static LevelManager Instance { get; private set; }

    private List<GameObject> _rooms;
 

    public int numbRooms;

    public int endRooms;
    private Generation_1 end;

    void Update()
    {
        end = GetComponent<Generation_1>();
        numbRooms = rooms.Count;

        //tring to stop the generation of new rooms after an amount determind by endRooms int;
        if (rooms.Count > endRooms)
        {
            end.enabled = false;
        }
    }

    public List<GameObject> rooms
    {
        get
        {
            if (_rooms == null) _rooms = new List<GameObject>();
            return _rooms;
        }
        set
        {
            _rooms = value;
        }
    }

    void Awake()
    {
        // If there is no other levelmanager, this is the chosen one.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // there is already a level manager, erase this new one.
            DestroyImmediate(this);
        }
    }

    // when the level manager is destroyed, we need to remove the instance as well.
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
