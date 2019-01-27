﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public PlayerTakeEKW playerTakeEKW;
    public HoboHome hoboHome;

    public void interact()
    {
        if (playerTakeEKW.take()) {
            return;
        }
        if (Vector3.Distance(hoboHome.transform.position, transform.position) < 6 && hoboHome.Upgrade()) {
            return;
        }
        //player Attack;
    }
}