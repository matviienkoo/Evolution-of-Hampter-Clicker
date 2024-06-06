using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ShopSystem : MonoBehaviour 
{
    private float LastTransaction;

    [Header("Индикаторы")]
    public float Money;
    public float MoneyAdd;
    public float MoneyInSec;

    [Header("Показывает какие апгрейды открыты")]
    public int Int_LevelShop;

    [Header("Скрипты")]
    public InstanceSystem InstanceScript;

    [Header("Автоклик (Defualt)")]
    public float PriceAutoClick = 15;
    public float Add_AutoClick = 1;
    public GameObject AutoClick_Block;
    public GameObject AutoClick_DontOpen;
    public Button AutoClick_Button;
    [Header("Курсор (Defualt)")]
    public float PriceCursor = 100;
    public float Add_Cursor = 1;
    public GameObject AutoCursor_Block;
    public GameObject AutoCursor_DontOpen;
    public Button Cursor_Button;
    [Header("Грустный хомяк")]
    public float PriceEatBurger = 1500;
    public float Add_EatBurger = 25;
    public GameObject EatBurger_Block;
    public GameObject EatBurger_DontOpen;
    public Button EatBurger_Button;
    [Header("Стальной курсор")]
    public float PriceSteelCursor = 10000;
    public float Add_SteelCursor = 50;
    public GameObject SteelCursor_Block;
    public GameObject SteelCursor_DontOpen;
    public Button SteelCursor_Button;
    [Header("Семья хомяков")]
    public float PriceLitrCider = 110000;
    public float Add_LitrCider = 2000;
    public GameObject LitrCider_Block;
    public GameObject LitrCider_DontOpen;
    public Button LitrCider_Button;
    [Header("Ферма хомяков")]
    public float PriceBuyNewGame = 1000000;
    public float Add_BuyNewGame = 25000;
    public GameObject BuyNewGame_Block;
    public GameObject BuyNewGame_DontOpen;
    public Button BuyNewGame_Button;
    [Header("Храм хомяков")]
    public float PriceUpgradeComputer = 15000000;
    public float Add_UpgradeComputer = 200000;
    public GameObject UpgradeComputer_Block;
    public GameObject UpgradeComputer_DontOpen;
    public Button UpgradeComputer_Button;
    [Header("Золотой курсор")]
    public float PriceGoldCursor = 200000000;
    public float Add_GoldCursor = 500000;
    public GameObject GoldCursor_Block;
    public GameObject GoldCursor_DontOpen;
    public Button GoldCursor_Button;
    [Header("Город хомяков")]
    public float PriceAnimeMaraphon = 3000000000;
    public float Add_AnimeMaraphon = 45000000;
    public GameObject AnimeMaraphon_Block;
    public GameObject AnimeMaraphon_DontOpen;
    public Button AnimeMaraphon_Button;
    [Header("Континент хомяков")]
    public float PriceSadMusic = 50000000000;
    public float Add_SadMusic = 650000000;
    public GameObject SadMusic_Block;
    public GameObject SadMusic_DontOpen;
    public Button SadMusic_Button;
    [Header("Алмазный курсор")]
    public float PriceDiamondCursor = 750000000000;
    public float Add_DiamondCursor = 800000000;
    public GameObject DiamondCursor_Block;
    public GameObject DiamondCursor_DontOpen;
    public Button DiamondCursor_Button;
    [Header("Планета хомяков")]
    public float PriceThinkLong = 10000000000000;
    public float Add_ThinkLong =  10000000000;
    public GameObject ThinkLong_Block;
    public GameObject ThinkLong_DontOpen;
    public Button ThinkLong_Button;
    [Header("Галатика хомяков")]
    public float PriceForestHouse = 25000000000000;
    public float Add_ForestHouse = 300000000000;
    public GameObject ForestHouse_Block;
    public GameObject ForestHouse_DontOpen;
    public Button ForestHouse_Button;
    [Header("Бог хомяков")]
    public float PriceEmptiness = 5000000000000000;
    public float Add_Emptiness = 10000000000000;
    public GameObject Emptiness_Block;
    public GameObject Emptiness_DontOpen;
    public Button Emptiness_Button;

    private void Start ()
    {
        CheckUpgrade();
    }

    [Tooltip("Прокачка")] 
    public void AutoClickBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceAutoClick)
        {
            Money -= PriceAutoClick;
            MoneyInSec += Add_AutoClick;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyInSec",MoneyInSec);
        }
        LastTransaction = PriceAutoClick;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void CursorBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceCursor)
        {
            Money -= PriceCursor;
            MoneyAdd += Add_Cursor;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyAdd",MoneyAdd);
        }
        int Int_Shop = 1;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceCursor;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void EatBurgerBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceEatBurger)
        {
            Money -= PriceEatBurger;
            MoneyInSec += Add_EatBurger;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyInSec",MoneyInSec);
        }
        int Int_Shop = 2;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceEatBurger;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void SteelCursorBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceSteelCursor)
        {
            Money -= PriceSteelCursor;
            MoneyAdd += Add_SteelCursor;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyAdd",MoneyAdd);
        }
        int Int_Shop = 3;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceSteelCursor;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void LitrCiderBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceLitrCider)
        {
            Money -= PriceLitrCider;
            MoneyInSec += Add_LitrCider;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyInSec",MoneyInSec);
        }
        int Int_Shop = 4;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceLitrCider;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void NewGameBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceBuyNewGame)
        {
            Money -= PriceBuyNewGame;
            MoneyInSec += Add_BuyNewGame;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyInSec",MoneyInSec);
        }
        int Int_Shop = 5;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceBuyNewGame;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void UpgradeComputerBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceUpgradeComputer)
        {
            Money -= PriceUpgradeComputer;
            MoneyInSec += Add_UpgradeComputer;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyInSec",MoneyInSec);
        }
        int Int_Shop = 6;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceUpgradeComputer;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void GoldCursorBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceGoldCursor)
        {
            Money -= PriceGoldCursor;
            MoneyAdd += Add_GoldCursor;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyAdd",MoneyAdd);
        }
        int Int_Shop = 7;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceGoldCursor;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void AnimeMaraphonBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceAnimeMaraphon)
        {
            Money -= PriceAnimeMaraphon;
            MoneyInSec += Add_AnimeMaraphon;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyInSec",MoneyInSec);
        }
        int Int_Shop = 8;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceAnimeMaraphon;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void SadMusicBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceSadMusic)
        {
            Money -= PriceSadMusic;
            MoneyInSec += Add_SadMusic;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyInSec",MoneyInSec);
        }
        int Int_Shop = 9;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceSadMusic;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void DiamondCursorBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceDiamondCursor)
        {
            Money -= PriceDiamondCursor;
            MoneyInSec += Add_DiamondCursor;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyAdd",MoneyAdd);
        }
        int Int_Shop = 10;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceDiamondCursor;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void LongThoughtBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceThinkLong)
        {
            Money -= PriceThinkLong;
            MoneyInSec += Add_ThinkLong;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyInSec",MoneyInSec);
        }
        int Int_Shop = 11;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceThinkLong;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void HouseForestBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceForestHouse)
        {
            Money -= PriceForestHouse;
            MoneyInSec += Add_ForestHouse;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyInSec",MoneyInSec);
        }
        int Int_Shop = 12;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceForestHouse;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }
    public void EmptinessBuy (){
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");
        MoneyInSec = PlayerPrefs.GetFloat("MoneyInSec");
        MoneyAdd = PlayerPrefs.GetFloat("MoneyAdd");
        Money = PlayerPrefs.GetFloat("Money");
        if (Money >= PriceEmptiness)
        {
            Money -= PriceEmptiness;
            MoneyInSec += Add_Emptiness;
            PlayerPrefs.SetFloat("Money",Money);
            PlayerPrefs.SetFloat("MoneyInSec",MoneyInSec);
        }
        int Int_Shop = 13;
        if (Int_LevelShop < Int_Shop){
        Int_LevelShop = Int_Shop;
        PlayerPrefs.SetInt("Int_LevelShop",Int_LevelShop);
        CheckUpgrade();
        }
        LastTransaction = PriceEmptiness;
        PlayerPrefs.SetFloat("LastTransaction",LastTransaction);
        InstanceScript.InstanceMinusMoney();
    }

    [Tooltip("Проверка возможности прокачки")]
    private void CheckUpgrade ()
    {
        Int_LevelShop = PlayerPrefs.GetInt("Int_LevelShop");

        if (Int_LevelShop >= 1)
        EatBurger_DontOpen.SetActive(false);
        if (Int_LevelShop >= 2)
        SteelCursor_DontOpen.SetActive(false);
        if (Int_LevelShop >= 3)
        LitrCider_DontOpen.SetActive(false);
        if (Int_LevelShop >= 4)
        BuyNewGame_DontOpen.SetActive(false);
        if (Int_LevelShop >= 5)
        UpgradeComputer_DontOpen.SetActive(false);
        if (Int_LevelShop >= 6)
        GoldCursor_DontOpen.SetActive(false);
        if (Int_LevelShop >= 7)
        AnimeMaraphon_DontOpen.SetActive(false);
        if (Int_LevelShop >= 8)
        SadMusic_DontOpen.SetActive(false);
        if (Int_LevelShop >= 9)
        DiamondCursor_DontOpen.SetActive(false);
        if (Int_LevelShop >= 10)
        ThinkLong_DontOpen.SetActive(false);
        if (Int_LevelShop >= 11)
        ForestHouse_DontOpen.SetActive(false);
        if (Int_LevelShop >= 12)
        Emptiness_DontOpen.SetActive(false);
    }

    [Tooltip("Система обновлений данных")]
    private void FixedUpdate ()
    {
        Money = PlayerPrefs.GetFloat("Money");

        // --- 1
        if (PriceAutoClick > Money){
        AutoClick_Block.SetActive(true);
        AutoClick_Button.enabled = false;
        }
        else{
        AutoClick_Block.SetActive(false);
        AutoClick_Button.enabled = true;
        }
        // --- 2
        if (PriceCursor > Money){
        AutoCursor_Block.SetActive(true);
        Cursor_Button.enabled = false;
        }
        else{
        AutoCursor_Block.SetActive(false);
        Cursor_Button.enabled = true;
        }
        // --- 3
        if (PriceEatBurger > Money){
        EatBurger_Block.SetActive(true);
        EatBurger_Button.enabled = false;
        }
        else{
        EatBurger_Block.SetActive(false);
        EatBurger_Button.enabled = true;
        }
        // --- 4
        if (PriceSteelCursor > Money){
        SteelCursor_Block.SetActive(true);
        SteelCursor_Button.enabled = false;
        }
        else{
        SteelCursor_Block.SetActive(false);
        SteelCursor_Button.enabled = true;
        }
        // --- 5
        if (PriceLitrCider > Money){
        LitrCider_Block.SetActive(true);
        LitrCider_Button.enabled = false;
        }
        else{
        LitrCider_Block.SetActive(false);
        LitrCider_Button.enabled = true;
        }
        // --- 6
        if (PriceBuyNewGame > Money){
        BuyNewGame_Block.SetActive(true);
        BuyNewGame_Button.enabled = false;
        }
        else{
        BuyNewGame_Block.SetActive(false);
        BuyNewGame_Button.enabled = true;
        }
        // --- 7
        if (PriceUpgradeComputer > Money){
        UpgradeComputer_Block.SetActive(true);
        UpgradeComputer_Button.enabled = false;
        }
        else{
        UpgradeComputer_Block.SetActive(false);
        UpgradeComputer_Button.enabled = true;
        }
        // --- 8
        if (PriceGoldCursor > Money){
        GoldCursor_Block.SetActive(true);
        GoldCursor_Button.enabled = false;
        }
        else{
        GoldCursor_Block.SetActive(false);
        GoldCursor_Button.enabled = true;
        }
        // --- 9
        if (PriceAnimeMaraphon > Money){
        AnimeMaraphon_Block.SetActive(true);
        AnimeMaraphon_Button.enabled = false;
        }
        else{
        AnimeMaraphon_Block.SetActive(false);
        AnimeMaraphon_Button.enabled = true;
        }
        // --- 10
        if (PriceSadMusic > Money){
        SadMusic_Block.SetActive(true);
        SadMusic_Button.enabled = false;
        }
        else{
        SadMusic_Block.SetActive(false);
        SadMusic_Button.enabled = true;
        }
        // --- 11
        if (PriceDiamondCursor > Money){
        DiamondCursor_Block.SetActive(true);
        DiamondCursor_Button.enabled = false;
        }
        else{
        DiamondCursor_Block.SetActive(false);
        DiamondCursor_Button.enabled = true;
        }
        // --- 12
        if (PriceThinkLong > Money){
        ThinkLong_Block.SetActive(true);
        ThinkLong_Button.enabled = false;
        }
        else{
        ThinkLong_Block.SetActive(false);
        ThinkLong_Button.enabled = true;
        }
        // --- 13
        if (PriceForestHouse > Money){
        ForestHouse_Block.SetActive(true);
        ForestHouse_Button.enabled = false;
        }
        else{
        ForestHouse_Block.SetActive(false);
        ForestHouse_Button.enabled = true;
        }
        // --- 14
        if (PriceEmptiness > Money){
        Emptiness_Block.SetActive(true);
        Emptiness_Button.enabled = false;
        }
        else{
        Emptiness_Block.SetActive(false);
        Emptiness_Button.enabled = true;
        }
    }
}