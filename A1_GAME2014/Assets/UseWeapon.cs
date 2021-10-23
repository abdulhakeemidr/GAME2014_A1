using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour
{
    public float rotationSpeed;
    private GameObject weapon;
    private GameObject pivotPoint;


    void Start()
    {
        weapon = transform.GetChild(0).gameObject;
        pivotPoint = this.gameObject;
    }

    void Update()
    {
        weapon.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        FlipWeaponImage();
    }

    void FlipWeaponImage()
    {
        var weaponScale = weapon.transform.localScale;
        if (weapon.transform.position.x < pivotPoint.transform.position.x)
        {
            weaponScale.y = -Mathf.Abs(weaponScale.y);
        }
        else if (weapon.transform.position.x > pivotPoint.transform.position.x)
        {
            weaponScale.y = Mathf.Abs(weaponScale.y);
        }

        weapon.transform.localScale = weaponScale;
    }
}
