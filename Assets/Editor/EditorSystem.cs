using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(AdministartorScript))]
public class EditorSystem : Editor 
{
    private float Money;
    private int MoneyAdd;
    private string myString_Money;

    public override void OnInspectorGUI()
    {
        GUILayout.Label("Добавить Деньги", EditorStyles.boldLabel);
        myString_Money = EditorGUILayout.TextField(myString_Money);
        if (GUILayout.Button("Нажать")){
            int.TryParse(myString_Money, out MoneyAdd);
            Money = PlayerPrefs.GetFloat("Money");
            Money = Money + MoneyAdd;
            PlayerPrefs.SetFloat("Money",Money);
        }
        GUILayout.Space( 20f );
        if (GUILayout.Button("Удалить все"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}