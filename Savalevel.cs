using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Savalevel
{
    public string cmd;
    public string map_name;
    public int level_id;
    public int total_object_points;
    public int target_point;
    public List<Config1> config;
    public List<Object> objects;
}
[System.Serializable]
public class Config1
{
    public int number_small_rock;
    public int number_medium_rock;
    public int number_big_rock;
    public int number_small_gold;
    public int number_medium_gold;
    public int number_big_gold;
    public int number_super_gold;
    public int number_small_chest;
    public int number_big_chest;
    public int number_diamond;
    public int number_gift_box;
    public int number_dirty_mouse;
    public int number_bat;
    public int number_snake;
    public int number_small_fish;
    public int number_electric_eel;
    public int number_shark;
    public int number_tnt_dynamite;
    public int number_spider_web;
    public int number_dirty_mouse_diamond;
    public int number_bat_diamond;
    public int number_snake_diamond;
    public int number_small_fish_diamond;
    public int number_electric_eel_diamond;
    public int number_shark_diamond;
}
[System.Serializable]
public class Object
{
    public string type;
     public float x;
    public float y;
}

