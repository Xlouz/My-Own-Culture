using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public Text damageText;

    private void Start()
    {
        Destroy(gameObject, 1);
    }
}
