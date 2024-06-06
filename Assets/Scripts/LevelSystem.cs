using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LevelSystem : MonoBehaviour 
{
    private string Language;

    [Header("Уровень")]
    [Range(1, 10)]
    public int Int_Level = 1;
    public int Level;
    public Image ImgLevel;
    public TextMeshProUGUI LevelText;

    private float lerpSpeed;
    public float Current_Level, Max_Level = 100;

    [Header("Графика при обновленные уровня")]
    public GameObject Flash_GameObject;
    public Animation Flash_Animation;

    [Header("Скрипты")]
    public SoundSystem SoundScript;

    [Header("Система обновлений уровней")]
    public Image Img_Hampter;
    public Sprite[] Sprite_Hampter;

    private void Start ()
    {
        Int_Level = PlayerPrefs.GetInt("Int_Level");
        if (Int_Level == 0){
        Int_Level = 1; 
        Max_Level = 10;
        PlayerPrefs.SetFloat("Max_Level",Max_Level);
        PlayerPrefs.SetInt("Int_Level",Int_Level);
        }

        UpdatePlayer();
    }

    public void UpdatePlayer ()
    {
        Int_Level = PlayerPrefs.GetInt("Int_Level");

        if (Int_Level == 2){
        Img_Hampter.sprite = Sprite_Hampter[Int_Level];
        Max_Level = 100;
        PlayerPrefs.SetFloat("Max_Level",Max_Level);
        }

        if (Int_Level == 3){
        Img_Hampter.sprite = Sprite_Hampter[Int_Level];
        Max_Level = 250;
        PlayerPrefs.SetFloat("Max_Level",Max_Level);
        }

        if (Int_Level == 4){
        Img_Hampter.sprite = Sprite_Hampter[Int_Level];
        Max_Level = 500;
        PlayerPrefs.SetFloat("Max_Level",Max_Level);
        }

        if (Int_Level == 5){
        Img_Hampter.sprite = Sprite_Hampter[Int_Level];
        Max_Level = 1000;
        PlayerPrefs.SetFloat("Max_Level",Max_Level);
        }

        if (Int_Level == 6){
        Img_Hampter.sprite = Sprite_Hampter[Int_Level];
        Max_Level = 1500;
        PlayerPrefs.SetFloat("Max_Level",Max_Level);
        }

        if (Int_Level == 7){
        Img_Hampter.sprite = Sprite_Hampter[Int_Level];
        Current_Level = Max_Level;
        PlayerPrefs.SetFloat("Current_Level",Current_Level);
        }
    }
    public void FlashUpdatePlayer ()
    {
        Flash_GameObject.SetActive(true);
        Flash_Animation.Play();
        SoundScript.Sound_Upgrade();
        StartCoroutine(IEnumeratorFlash());
    }
    IEnumerator IEnumeratorFlash(){
        yield return new WaitForSeconds(0.5f);
        Current_Level = 0;
        PlayerPrefs.SetFloat("Current_Level",Current_Level);
        int Int_Level = Int_Level = PlayerPrefs.GetInt("Int_Level");
        Int_Level ++; PlayerPrefs.SetInt("Int_Level",Int_Level);
        if (Int_Level == 7){
        Current_Level = Max_Level;
        PlayerPrefs.SetFloat("Current_Level",Current_Level);
        }
        UpdatePlayer();
        yield return new WaitForSeconds(0.5f);
        Flash_GameObject.SetActive(false);
    }

    private void Update ()
    {
        Current_Level = PlayerPrefs.GetFloat("Current_Level");
        Max_Level = PlayerPrefs.GetFloat("Max_Level");
        Int_Level = PlayerPrefs.GetInt("Int_Level");

        Language = PlayerPrefs.GetString("Lang");
        if (Int_Level < 7)
        {
            if (Language == "Russia"){
            LevelText.text = "Уровень " + Int_Level.ToString();
            }
            if (Language == "English" || Language == ""){
            LevelText.text = "Level " + Int_Level.ToString();
            }
            if (Language == "Turkish"){
            LevelText.text = "Seviye " + Int_Level.ToString();
            }
        }
        else
        {
            if (Language == "Russia"){
            LevelText.text = "Максимальный";
            }
            if (Language == "English" || Language == ""){
            LevelText.text = "Maximum";
            }
            if (Language == "Turkish"){
            LevelText.text = "Maksimum";
            }
        }

        ImgLevel.fillAmount = Mathf.Lerp(ImgLevel.fillAmount, (Current_Level / Max_Level), lerpSpeed);
        lerpSpeed = 2f * Time.deltaTime;
    }
}