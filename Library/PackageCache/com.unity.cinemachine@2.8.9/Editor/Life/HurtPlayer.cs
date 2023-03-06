using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public void Hurt()
    {
        LifeSystem.Instance.HurtPlayer(1);
        LifeSystem.Instance.UpdateHealthUI();
    }
}
