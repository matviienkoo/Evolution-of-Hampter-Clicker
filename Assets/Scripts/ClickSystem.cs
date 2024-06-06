using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ClickSystem : MonoBehaviour 
{
    private bool ClickBool;
    private int Int_Level;

    [Header("Деньги")]
    public float Money;
    public float MoneyAdd;

    [Header("Деньги в секунду")]
    public float MoneyInSec;
    private float Current_Level, Max_Level;

    [Header("То что меняет размеры")]
    public Transform ObjectImg;

    [Header("Скрипты")]
    public InstanceSystem InstanceScript;
    public LevelSystem LevelScript;

    private void Start ()
    {
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        if (MoneyAdd <= 0)
        MoneyAdd = 1;
        PlayerPrefs.SetFloat("MoneyAdd",MoneyAdd);
        StartCoroutine(IEnumeratorAddSecMoney());
    }

    public void ClickButton ()
    {   
        if(Input.touchCount < 10)
        {
            Current_Level = PlayerPrefs.GetFloat("Current_Level");
            Max_Level = PlayerPrefs.GetFloat("Max_Level");

            // Увеличивает деньги
            Money += MoneyAdd;
            PlayerPrefs.SetFloat("Money",Money);

            // Увеличивает уровень
            if (Current_Level < Max_Level && Int_Level < 7)
            {
                Current_Level += 1;
                PlayerPrefs.SetFloat("Current_Level",Current_Level);
            }
            else{
            if (Int_Level < 7)
            {
                LevelScript.FlashUpdatePlayer();
            }
            }

            // Графический элемент
            InstanceScript.InstancePlusMoney();
            if (ClickBool == false){
            ObjectImg.GetComponent<RectTransform>().localScale = new Vector3(12.0002f, 11.3962f, 0f);
            StartCoroutine(IEnumeratorAnimSkuf());
            ClickBool = true;
            }
        }
    }
    IEnumerator IEnumeratorAnimSkuf(){
        ObjectImg.GetComponent<RectTransform>().localScale = new Vector3(11.3962f, 10.80763f, 0f);
        yield return new WaitForSeconds(0.1f);
        ObjectImg.GetComponent<RectTransform>().localScale = new Vector3(12.0002f, 11.3962f, 0f);
        ClickBool = false;
    }
    IEnumerator IEnumeratorAddSecMoney(){
        yield return new WaitForSeconds(1f);
        Money += MoneyInSec;
        PlayerPrefs.SetFloat("Money",Money);
        StartCoroutine(IEnumeratorAddSecMoney());
    }

    private void Update ()
    {
        Int_Level = PlayerPrefs.GetInt("Int_Level");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
    }
}
