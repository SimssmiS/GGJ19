﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    public SpawnItemObject[] initSpawnItemObjects;
    private List<InGameInventoryObject> spawnItemObjects = new List<InGameInventoryObject>();
    public float spawnByDayChance = 0.5f;
    public InGameInventoryObject child;

    void Awake()
    {
        foreach (SpawnItemObject item in initSpawnItemObjects) {
            for (int i = 0; i < item.priority; i++) {
                spawnItemObjects.Add(item.item);
            }
        }

        System.Action action = null;
        action = () =>
        {
            TimeSystem.pInstance.SubscribeEvent(TimeSystem.pInstance.time.AddHours(3), action);
            spawnRandomObject();
        };

        action.Invoke();
    }

    public bool spawnRandomObject()
    {
        if (child == null && spawnByDayChance>Random.Range(0.0f,1.0f)) {
            child = Instantiate<InGameInventoryObject>(getRandomObject(),transform);
            return true;
        }
        return false;
    }

    public InGameInventoryObject take()
    {
        InGameInventoryObject output = child;
        child = null;
        return output;
    }

    private InGameInventoryObject getRandomObject()
    {
        return spawnItemObjects[Random.Range(0, spawnItemObjects.Count)];
    }
}
