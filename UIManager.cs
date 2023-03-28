using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : Singleton<UIManager>
{

    public Text map_txt;
    public Dropdown m_dropdownMap;
    public Text level_txt;
    public Dropdown m_dropdownLevel;
    public InputField tagetPoint_txt;
    public InputField ObjectsPoint_txt;
    public Text currentPoint_txt;
    public Text configPoint_txt;
    public InputField smallRock;
    public InputField mediumRock;
    public InputField bigRock;
    public InputField smallGold;
    public InputField mediumGold;
    public InputField bigGold;
    public InputField superGold;
    public InputField smallChest;
    public InputField bigChest;
    public InputField diamond;
    public InputField gift_Box;
    public InputField dirty_Mouse;
    public InputField bat;
    public InputField snake;
    public InputField small_Fish;
    public InputField electric_eel;
    public InputField shark;
    public InputField TNTDynamite;
    public InputField spider_web;
    public InputField dirty_mouse_diamond;
    public InputField bat_diamond;
    public InputField snake_diamond;
    public InputField small_fish_diamond;
    public InputField electric_eel_diamond;
    public InputField shark_diamond;


    //  InputField iField = gameobject.GetComponent<InputField>();
    public void Set_smallRock(string amount)
    {
        
        if (smallRock)
            smallRock.text = amount;
    }
    public void Set_mediumRock(string amount)
    {
        if (mediumRock)
            mediumRock.text = amount;
    }
    public void Set_bigRock(string amount)
    {
        if (bigRock)
            bigRock.text = amount;
    }
    public void Set_smallGold(string amount)
    {
        if (smallGold)
            smallGold.text = amount;
    }
    public void Set_mediumGold(string amount)
    {
        if (mediumGold)
            mediumGold.text = amount;
    }
    public void Set_bigGold(string amount)
    {
        if (bigGold)
            bigGold.text = amount;
    } 
    public void Set_superGold(string amount)
    {
        if (superGold)
            superGold.text = amount;
    }public void Set_smallCHest(string amount)
    {
        if (smallChest)
            smallChest.text = amount;
    }public void Set_bigChest(string amount)
    {
        if (bigChest)
            bigChest.text = amount;
    }public void Set_Diamond(string amount)
    {
        if (diamond)
            diamond.text = amount;
    }public void Set_bat(string amount)
    {
        if (bat)
            bat.text = amount;
    }public void Set_giftBox(string amount)
    {
        if (gift_Box)
            gift_Box.text = amount;
    }public void Set_mouse(string amount)
    {
        if (dirty_Mouse)
            dirty_Mouse.text = amount;
    }public void Set_snake(string amount)
    {
        if (snake)
            snake.text = amount;
    }public void Set_smallFish(string amount)
    {
        if (small_Fish)
            small_Fish.text = amount;
    }public void Set_eel(string amount)
    {
        if (electric_eel)
            electric_eel.text = amount;
    }public void Set_shark(string amount)
    {
        if (shark)
            shark.text = amount;
    }public void Set_TNTDynamite(string amount)
    {
        if (TNTDynamite)
            TNTDynamite.text = amount;
    }public void Set_spider_web(string amount)
    {
        if (spider_web)
            spider_web.text = amount;
    }public void Set_dirty_mouse_diamond(string amount)
    {
        if (dirty_mouse_diamond)
            dirty_mouse_diamond.text = amount;
    }public void Set_bat_diamond(string amount)
    {
        if (bat_diamond)
            bat_diamond.text = amount;
    }public void Set_snake_diamond(string amount)
    {
        if (snake_diamond)
            snake_diamond.text = amount;
    }public void Set_small_fish_diamond(string amount)
    {
        if (small_fish_diamond)
            small_fish_diamond.text = amount;
    }public void Set_electric_eel_diamond(string amount)
    {
        if (electric_eel_diamond)
            electric_eel_diamond.text = amount;
    }public void Set_shark_diamond(string amount)
    {
        if (shark_diamond)
            shark_diamond.text = amount;
    }



    public void SetCurrentPointTxt(string currentPoint)
    {
        if (currentPoint_txt)
            currentPoint_txt.text = currentPoint;
    }
    public void SetConfigPointTxt(string configPoint)
    {
        if (configPoint_txt)
            configPoint_txt.text = configPoint;
    }
    public void SetObjectPointTxt(string objectPoint)
    {
        if (ObjectsPoint_txt)
            ObjectsPoint_txt.text = objectPoint;
    } public void SetTagetPointTxt(string tagetPoint)
    {
        if (tagetPoint_txt)
            tagetPoint_txt.text = tagetPoint;
    }
  

    
}
