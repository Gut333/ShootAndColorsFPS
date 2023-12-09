using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayerController : MonoBehaviour
{
    public List<WeaponController> startingWeapons = new List<WeaponController>();

    public Transform weaponParent;
    public Transform defaultWeaponPos;
    public Transform aimPos;

    public int activeWeaponIndex { get; private set; }
    private WeaponController[] m_WeaponSlots = new WeaponController[2];

    private void Start()    
    {
        activeWeaponIndex = -1;

        foreach(WeaponController startingWeapon in startingWeapons)
        {
            _AddWeapon(startingWeapon);
        }
    }

    private void _AddWeapon(WeaponController weaponPrefab)
    {
        weaponParent.position = defaultWeaponPos.position;

        for( int i = 0; i < m_WeaponSlots.Length; i++)
        {
            if (m_WeaponSlots[i] == null)
            {
                WeaponController weaponClone = Instantiate(weaponPrefab, weaponParent);
                weaponClone.gameObject.SetActive(true); // false too
                return;
            }
        }
    }

}
