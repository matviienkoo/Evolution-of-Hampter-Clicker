using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SpecialObjectSystem : MonoBehaviour 
{
    [Header("Бонус")]
    public GameObject SpecialBonusObject;
    public Animation SpecialBonusAnim;
    [Header("Скрипты")]
    public InstanceSystem InstanceScript;

    private float Money;
    private float MoneySpecialBonus;
    private int Int_Level;

    private void Start (){
        StartCoroutine(IEnumeratorBonusAnim());
    }
    IEnumerator IEnumeratorBonusAnim(){
        yield return new WaitForSeconds(100f);
        SpecialBonusObject.SetActive(true);

        int IntRandom = Random.Range(1, 4);
        if (IntRandom == 1)
        SpecialBonusAnim.Play("CatUpperAnim");
        if (IntRandom == 2)
        SpecialBonusAnim.Play("CatMidleAnim");
        if (IntRandom == 3)
        SpecialBonusAnim.Play("CatLowerAnim");

        StartCoroutine(IEnumeratorBonusAnim()); 
        StartCoroutine(IEnumeratorCloseBonusAnim()); 
    }
    IEnumerator IEnumeratorCloseBonusAnim(){
        yield return new WaitForSeconds(10f);
        SpecialBonusObject.SetActive(false);
    }

    public void BonusAdd ()
    {
        BonusDefinition();
        Money = PlayerPrefs.GetFloat("Money");
        Money += MoneySpecialBonus;
        PlayerPrefs.SetFloat("Money",Money);
        InstanceScript.InstanceSpecialBonus();
        SpecialBonusObject.SetActive(false);
    }
    private void BonusDefinition ()
    {
        Int_Level = PlayerPrefs.GetInt("Int_Level");

        if (Int_Level == 1)
        MoneySpecialBonus = 100;
        if (Int_Level == 2)
        MoneySpecialBonus = 1000;
        if (Int_Level == 3)
        MoneySpecialBonus = 12000;
        if (Int_Level == 4)
        MoneySpecialBonus = 150000;
        if (Int_Level == 5)
        MoneySpecialBonus = 10000000;
        if (Int_Level == 6)
        MoneySpecialBonus = 2000000000;
        if (Int_Level == 7)
        MoneySpecialBonus = 100000000000;

        PlayerPrefs.SetFloat("MoneySpecialBonus",MoneySpecialBonus);
    }
}