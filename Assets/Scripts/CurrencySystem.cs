using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CurrencySystem : MonoBehaviour 
{
    private string suffix;

    [Header("Количество денег")]
    public float Money;
    public TextMeshProUGUI Money_Text;

    [Header("Деньги в секунду")]
    public float MoneyInSec;
    public TextMeshProUGUI MoneyInSec_Text;

    private void FixedUpdate ()
    {
        // [AMOUNT MONEY]
        Money = PlayerPrefs.GetFloat("Money");
        float MyMoney = Money;

        if(MyMoney < 1000){
        suffix = "";
        Money_Text.text = MyMoney.ToString() + suffix;
        }
        if(MyMoney < 1000000 && MyMoney >= 1000){
        MyMoney = MyMoney/1000;
        suffix = "K";
        Money_Text.text = MyMoney.ToString("f2") + suffix;
        }
        if(MyMoney < 1000000000 && MyMoney >= 1000000){
        MyMoney = MyMoney/1000000;
        suffix = "M";
        Money_Text.text = MyMoney.ToString("f2") + suffix;
        }
        if(MyMoney < 1000000000000 && MyMoney >= 1000000000){
        MyMoney = MyMoney/1000000000;
        suffix = "B";
        Money_Text.text = MyMoney.ToString("f1") + suffix;
        }
        if(MyMoney < 1000000000000000 && MyMoney >= 1000000000000){
        MyMoney = MyMoney/1000000000000;
        suffix = "T";
        Money_Text.text = MyMoney.ToString("f1") + suffix;
        }
        if(MyMoney < 1000000000000000000 && MyMoney >= 1000000000000000){
        MyMoney = MyMoney/1000000000000000;
        suffix = "Qa";
        Money_Text.text = MyMoney.ToString("f1") + suffix;
        }

        // [MONEY IN SEC]
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        float MyMoneyInSec = MoneyInSec;

        if(MyMoneyInSec < 1000){
        suffix = "";
        MoneyInSec_Text.text = MyMoneyInSec.ToString() + suffix;
        }
        if(MyMoneyInSec < 1000000 && MyMoneyInSec >= 1000){
        MyMoneyInSec = MyMoneyInSec/1000;
        suffix = "K";
        MoneyInSec_Text.text = MyMoneyInSec.ToString("f2") + suffix;
        }
        if(MyMoneyInSec < 1000000000 && MyMoneyInSec >= 1000000){
        MyMoneyInSec = MyMoneyInSec/1000000;
        suffix = "M";
        MoneyInSec_Text.text = MyMoneyInSec.ToString("f2") + suffix;
        }
        if(MyMoneyInSec < 1000000000000 && MyMoneyInSec >= 1000000000){
        MyMoneyInSec = MyMoneyInSec/1000000000;
        suffix = "B";
        MoneyInSec_Text.text = MyMoneyInSec.ToString("f1") + suffix;
        }
        if(MyMoneyInSec < 1000000000000000 && MyMoneyInSec >= 1000000000000){
        MyMoneyInSec = MyMoneyInSec/1000000000000;
        suffix = "T";
        MoneyInSec_Text.text = MyMoneyInSec.ToString("f1") + suffix;
        }
        if(MyMoneyInSec < 1000000000000000000 && MyMoneyInSec >= 1000000000000000){
        MyMoneyInSec = MyMoneyInSec/1000000000000000;
        suffix = "Qa";
        MoneyInSec_Text.text = MyMoneyInSec.ToString("f1") + suffix;
        }
    }
}