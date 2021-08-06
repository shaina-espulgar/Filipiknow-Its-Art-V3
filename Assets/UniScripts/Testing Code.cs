using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestingCode : MonoBehaviour
{
    [SerializeField] Text packageName;

    public void GetPackageName()
    {
        packageName.text = Application.identifier;
    }
}
