using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstanceSystem : MonoBehaviour 
{
    [Header("Графика, минус деньги")]
    public Transform MyParent_Minus;
    public GameObject MyChild_Minus;

    [Header("Графика, плюс деньги")]
    public Transform MyParent_Plus;
    public GameObject MyChild_Plus;

    [Header("Графика, специальнный бонус")]
    public Transform MyParent_SpecialBonus;
    public GameObject MyChild_SpecialBonus;

    public void InstanceMinusMoney (){
        GameObject mChild_Minus = Instantiate(MyChild_Minus);
        mChild_Minus.transform.SetParent(MyParent_Minus, false);
    }
    public void InstancePlusMoney (){
        GameObject mChild_Plus = Instantiate(MyChild_Plus);
        mChild_Plus.transform.SetParent(MyParent_Plus, false);
    }
    public void InstanceSpecialBonus (){
        GameObject mChild_SpecialBonus = Instantiate(MyChild_SpecialBonus);
        mChild_SpecialBonus.transform.SetParent(MyParent_SpecialBonus, false);
    }
}