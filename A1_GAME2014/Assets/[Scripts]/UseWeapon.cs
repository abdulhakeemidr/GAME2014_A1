/* 
 * Full Name        : Abdulhakeem Idris
 * StudentID        : 101278361
 * Date Modified    : October 19, 2021
 * File             : UseWeapon.cs
 * Description      : This is the Weapon Controller Script
 * Revision History : Version02
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour
{
    public float rotationSpeed = 10;
    private GameObject weapon;
    private GameObject pivotPoint;
    private Animator animator;
    private Vector3 m_touchesEnded;
    //public RectTransform joystickArea;


    void Start()
    {
        pivotPoint = transform.GetChild(0).gameObject;
        weapon = transform.GetChild(0).GetChild(0).gameObject;
        animator = weapon.GetComponent<Animator>();
    }

    void Update()
    {
        RotateWeaponToTouchDir();
        
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

    void RotateWeaponToTouchDir()
    {
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            Vector3 direction = worldTouch - pivotPoint.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            pivotPoint.transform.rotation = Quaternion.Slerp(pivotPoint.transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            AnimateShoot();
        }
        
    }

    void AnimateShoot()
    {
        animator.SetTrigger("TapToShoot");
    }
}
