using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TranslateItem : MonoBehaviour
{
   [Header("Выбор Языка")]
   public string Language;
   TextMeshProUGUI Text;
    
   [Header("Перевод")]
   public string TextRussian;
   public string TextEnglish;
   public string TextTurkish;

   private void Awake()
   {
      Text = GetComponent<TextMeshProUGUI>();
   }

   private void FixedUpdate ()
   {
      Language = PlayerPrefs.GetString("Lang");

      if(Language == "" || Language == "English")
      {
         Text.text = TextEnglish;
      }
        
      if (Language == "Russia")
      {
         Text.text = TextRussian;
      }
        
      if (Language == "Turkish")
      {
         Text.text = TextTurkish;
      }
   }
}