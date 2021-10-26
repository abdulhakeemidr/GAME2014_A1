using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCount : MonoBehaviour
{
    public int TotalAmmo = 59;
    public int loadedAmmo = 7;
    private int maxLoadedAmmo = 7;
    private bool IsLoaded;
    private static AmmoCount ammo;

    public static AmmoCount GetAmmoCount()
    {
        return ammo;
    }

    private void Awake()
    {
        if(ammo == null)
        {
            ammo = this;
        }
        else
        {
        }
    }

    public void ReloadAmmo()
    {
        if(loadedAmmo == 0)
        {
            TotalAmmo -= maxLoadedAmmo;
            loadedAmmo += maxLoadedAmmo;
        }
    }

}
