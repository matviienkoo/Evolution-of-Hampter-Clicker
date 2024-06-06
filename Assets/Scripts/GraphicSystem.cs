using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GraphicSystem : MonoBehaviour 
{
    private string suffix;

    [Header("Показывает сколько денег снялось")]
    public TextMeshProUGUI MoneyText;
    public float MoneySpecialBonus;
    public float LastTransaction;
    public float MoneyAdd;

    [Header("Добавить/Убавить деньги")]
    public bool MinusMoney;
    public bool PlusMoney;
    public bool SpecialBonus;

    [Header("Скорость")]
    public float speed;

    [Header("Цель до которой движется обьект")]
    public float maxPosUp;
    private Vector2 originalPos;

    private void Start()
    {
        if (MinusMoney == true)
        {
            LastTransaction = PlayerPrefs.GetFloat("LastTransaction");
            float MyLastTransaction = LastTransaction;

            if(MyLastTransaction < 1000){
            suffix = "";
            MoneyText.text = "-" + MyLastTransaction.ToString() + suffix;
            }
            if(MyLastTransaction < 1000000 && MyLastTransaction >= 1000){
            MyLastTransaction = MyLastTransaction/1000;
            suffix = "K";
            MoneyText.text = "-" + MyLastTransaction.ToString("f1") + suffix;
            }
            if(MyLastTransaction < 1000000000 && MyLastTransaction >= 1000000){
            MyLastTransaction = MyLastTransaction/1000000;
            suffix = "M";
            MoneyText.text = "-" + MyLastTransaction.ToString("f1") + suffix;
            }
            if(MyLastTransaction < 1000000000000 && MyLastTransaction >= 1000000000){
            MyLastTransaction = MyLastTransaction/1000000000;
            suffix = "B";
            MoneyText.text = "-" + MyLastTransaction.ToString("f1") + suffix;
            }
            if(MyLastTransaction < 1000000000000000 && MyLastTransaction >= 1000000000000){
            MyLastTransaction = MyLastTransaction/1000000000000;
            suffix = "T";
            MoneyText.text = "-" + MyLastTransaction.ToString("f1") + suffix;
            }
            if(MyLastTransaction < 1000000000000000000 && MyLastTransaction >= 1000000000000000){
            MyLastTransaction = MyLastTransaction/1000000000000000;
            suffix = "Qa";
            MoneyText.text = "-" + MyLastTransaction.ToString("f1") + suffix;
            }

            originalPos = this.transform.localPosition;
        }
        if (PlusMoney == true)
        {
            MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
            float MyMoneyAdd = MoneyAdd;

            if(MyMoneyAdd < 1000){
            suffix = "";
            MoneyText.text = "+" + MyMoneyAdd.ToString() + suffix;
            }
            if(MyMoneyAdd < 1000000 && MyMoneyAdd >= 1000){
            MyMoneyAdd = MyMoneyAdd/1000;
            suffix = "K";
            MoneyText.text = "+" + MyMoneyAdd.ToString("f1") + suffix;
            }
            if(MyMoneyAdd < 1000000000 && MyMoneyAdd >= 1000000){
            MyMoneyAdd = MyMoneyAdd/1000000;
            suffix = "M";
            MoneyText.text = "+" + MyMoneyAdd.ToString("f1") + suffix;
            }
            if(MyMoneyAdd < 1000000000000 && MyMoneyAdd >= 1000000000){
            MyMoneyAdd = MyMoneyAdd/1000000000;
            suffix = "B";
            MoneyText.text = "+" + MyMoneyAdd.ToString("f1") + suffix;
            }
            if(MyMoneyAdd < 1000000000000000 && MyMoneyAdd >= 1000000000000){
            MyMoneyAdd = MyMoneyAdd/1000000000000;
            suffix = "T";
            MoneyText.text = "+" + MyMoneyAdd.ToString("f1") + suffix;
            }
            if(MyMoneyAdd < 1000000000000000000 && MyMoneyAdd >= 1000000000000000){
            MyMoneyAdd = MyMoneyAdd/1000000000000000;
            suffix = "Qa";
            MoneyText.text = "+" + MyMoneyAdd.ToString("f1") + suffix;
            }

            originalPos = this.transform.localPosition;
        }
        if (SpecialBonus == true)
        {
            MoneySpecialBonus = PlayerPrefs.GetFloat("MoneySpecialBonus");
            float MyMoneySpecialBonus = MoneySpecialBonus;

            if(MyMoneySpecialBonus < 1000){
            suffix = "";
            MoneyText.text = "+" + MyMoneySpecialBonus.ToString() + suffix;
            }
            if(MyMoneySpecialBonus < 1000000 && MyMoneySpecialBonus >= 1000){
            MyMoneySpecialBonus = MyMoneySpecialBonus/1000;
            suffix = "K";
            MoneyText.text = "+" + MyMoneySpecialBonus.ToString("f1") + suffix;
            }
            if(MyMoneySpecialBonus < 1000000000 && MyMoneySpecialBonus >= 1000000){
            MyMoneySpecialBonus = MyMoneySpecialBonus/1000000;
            suffix = "M";
            MoneyText.text = "+" + MyMoneySpecialBonus.ToString("f1") + suffix;
            }
            if(MyMoneySpecialBonus < 1000000000000 && MyMoneySpecialBonus >= 1000000000){
            MyMoneySpecialBonus = MyMoneySpecialBonus/1000000000;
            suffix = "B";
            MoneyText.text = "+" + MyMoneySpecialBonus.ToString("f1") + suffix;
            }
            if(MyMoneySpecialBonus < 1000000000000000 && MyMoneySpecialBonus >= 1000000000000){
            MyMoneySpecialBonus = MyMoneySpecialBonus/1000000000000;
            suffix = "T";
            MoneyText.text = "+" + MyMoneySpecialBonus.ToString("f1") + suffix;
            }
            if(MyMoneySpecialBonus < 1000000000000000000 && MyMoneySpecialBonus >= 1000000000000000){
            MyMoneySpecialBonus = MyMoneySpecialBonus/1000000000000000;
            suffix = "Qa";
            MoneyText.text = "+" + MyMoneySpecialBonus.ToString("f1") + suffix;
            }

            originalPos = this.transform.localPosition;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.localPosition.y >= maxPosUp){
            Destroy(gameObject);
        }
    } 
}