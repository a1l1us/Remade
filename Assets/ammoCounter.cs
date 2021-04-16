using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ammoCounter : MonoBehaviour
{
    public int maxAmmo;
    public int currentAmmo;
    public string ammoCounterDisplay;

    public TextMeshProUGUI ammoText;

    public void SetMaxAmmo(int ammo)
    {
        maxAmmo = ammo;
        currentAmmo = ammo;
        
        ammoCounterDisplay = (currentAmmo + "/" + maxAmmo);
        
        ammoText.text = ammoCounterDisplay.ToString();
    }

    public void SetAmmo(int ammo)
    {
        currentAmmo = ammo;

        ammoCounterDisplay = (currentAmmo + "/" + maxAmmo);

        ammoText.text = ammoCounterDisplay.ToString();
    }
}
