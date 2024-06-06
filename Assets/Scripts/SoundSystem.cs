using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SoundSystem : MonoBehaviour 
{
    private int Music_Int;

    public AudioSource AudioButton;
    public AudioSource AudioBuyObject;
    public AudioSource AudioSpecialBonus;
    public AudioSource AudioUpgrade;

    public void Sound_ClickButton (){
        Music_Int = PlayerPrefs.GetInt("Music_Int");
        if (Music_Int == 0 || Music_Int == 2)
        AudioButton.Play();
    }
    public void Sound_BuyShop (){
        Music_Int = PlayerPrefs.GetInt("Music_Int");
        if (Music_Int == 0 || Music_Int == 2)
        AudioBuyObject.Play();
    }
    public void Sound_SpecialBonus (){
        Music_Int = PlayerPrefs.GetInt("Music_Int");
        if (Music_Int == 0 || Music_Int == 2)
        AudioSpecialBonus.Play();
    }
    public void Sound_Upgrade (){
        Music_Int = PlayerPrefs.GetInt("Music_Int");
        if (Music_Int == 0 || Music_Int == 2)
        AudioUpgrade.Play();
    }
}