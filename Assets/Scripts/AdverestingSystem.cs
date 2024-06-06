using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GamePush;

public class AdverestingSystem : MonoBehaviour
{
   private string Language;
   private float Money;

   [Header("Реклама вознагрожденные. Удвоенные капитала")]
   public Button ButtonRewardAds;
   public Animation AnimBonus;

   [Header("Реклама полноэкранная. Показывается через время")]
   public GameObject TimerAdveresting;
   public TextMeshProUGUI TextAdveresting;
   public bool BoolTimer;
   public float CountTimer = 3;

   // ------ [Система FullScreen баннера] ------
   private void Start ()
   {
      StartCoroutine(IEnumeratorTimerFullScreen());
   }
   IEnumerator IEnumeratorTimerFullScreen(){
      yield return new WaitForSeconds(120f);
      TimerAdveresting.SetActive(true);
      StartCoroutine(IEnumeratorTimerThreeSecond());
   }
   IEnumerator IEnumeratorTimerThreeSecond(){
      CountTimer = 3;yield return new WaitForSeconds(1f);
      CountTimer = 2;yield return new WaitForSeconds(1f);
      CountTimer = 1;yield return new WaitForSeconds(1f);
      CountTimer = 0;
      ShowFullscreen();
   }
   public void ShowFullscreen() => GP_Ads.ShowFullscreen(OnFullscreenStart, OnFullscreenClose);
   private void OnFullscreenStart() => Debug.Log("ON FULLSCREEN START");
   private void OnFullscreenClose(bool success)
   {
      TimerAdveresting.SetActive(false); CountTimer = 3;
      StartCoroutine(IEnumeratorTimerFullScreen());
   }

   // ------ [Система Rewarded баннера] ------
   public void ShowRewarded() => GP_Ads.ShowRewarded("IncreaseMoney", OnRewardedReward, OnRewardedStart, OnRewardedClose);
   private void OnRewardedStart() => Debug.Log("ON REWARDED: START");
   private void OnRewardedReward(string value)
   {
      Money = PlayerPrefs.GetFloat("Money");

      float BonusMoney = Money * 2;
      BonusMoney.ToString("f0");
      Money = BonusMoney;
      PlayerPrefs.SetFloat("Money",Money);
      AnimBonus.Play();
   }
   private void OnRewardedClose(bool success) => Debug.Log("ON REWARDED: CLOSE");
   private void FixedUpdate ()
   {
      Money = PlayerPrefs.GetFloat("Money");
      Language = PlayerPrefs.GetString("Lang");

      if (Language == "Russia" || Language == ""){
      TextAdveresting.text = "Реклама через " + CountTimer.ToString() + "..";
      }
      if (Language == "English"){
      TextAdveresting.text = "Advertising in " + CountTimer.ToString() + "..";
      }
      if (Language == "Turkish"){
      TextAdveresting.text = CountTimer.ToString() + " saniyede reklam";
      }
      if (Money == 0){
      ButtonRewardAds.interactable = false;
      }
      else{
      ButtonRewardAds.interactable = true;
      }
   }
}