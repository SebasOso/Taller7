using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ManagerMenu : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button buttom;
    public void OnButton()
    {
        buttom.Select();
    }
}
