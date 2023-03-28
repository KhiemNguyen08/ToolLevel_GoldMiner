using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using SimpleJSON;

public class PostData : MonoBehaviour
{
    string URL = "http://servertest.goldminernft.xyz:8880/goldminernft/sfs2x?cmd=level_editor_new_level&map_name=MapDongCo";
    Savalevel save = new Savalevel();
    int tagetPoint;
    int objPoint;
    Newlevel newlevel1 = new Newlevel();
    LoadData loadlevel = new LoadData();
    RandomMap randomMap = new RandomMap();
    int ID = -1;
    int number_small_rock = 0;
    int number_medium_rock = 0;
    int number_big_rock = 0;
    int number_small_gold = 0;
    int number_medium_gold = 0;
    int number_big_gold = 0;
    int number_super_gold = 0;
    int number_small_chest = 0;
    int number_big_chest = 0;
    int number_diamond = 0;
    int number_gift_box = 0;
    int number_dirty_mouse = 0;
    int number_bat = 0;
    int number_snake = 0;
    int number_small_fish = 0;
    int number_electric_eel = 0;
    int number_shark = 0;
    int number_tnt_dynamite = 0;
    int number_spider_web = 0;
    int number_dirty_mouse_diamond = 0;
    int number_bat_diamond = 0;
    int number_snake_diamond = 0;
    int number_small_fish_diamond = 0;
    int number_electric_eel_diamond = 0;
    int number_shark_diamond = 0;

    public int ID1 { get => ID; set => ID = value; }

    public void SaveLevelBtn()
    {
        save = GameController.Ins.savalevel;
        string save1 = JsonUtility.ToJson(save);
        Debug.Log("save" + save1);
        StartCoroutine(Post(URL, save1));
        GameController.Ins.ResetALlBtn();
        // ID = -1;

    }
    public void loadLevelBtn()
    {
       // GameController.Ins.Id.Clear();
        ID1 = -1;
        number_small_rock = 0;
        number_medium_rock = 0;
        number_big_rock = 0;
        number_small_gold = 0;
        number_medium_gold = 0;
        number_big_gold = 0;
        number_super_gold = 0;
        number_small_chest = 0;
        number_big_chest = 0;
        number_diamond = 0;
        number_gift_box = 0;
        number_dirty_mouse = 0;
        number_bat = 0;
        number_snake = 0;
        number_small_fish = 0;
        number_electric_eel = 0;
        number_shark = 0;
        number_tnt_dynamite = 0;
        number_spider_web = 0;
        number_dirty_mouse_diamond = 0;
        number_bat_diamond = 0;
        number_snake_diamond = 0;
        number_small_fish_diamond = 0;
        number_electric_eel_diamond = 0;
        number_shark_diamond = 0;
        GameController.Ins.ResetALlBtn();
        string map_name = GetData.FindObjectOfType<GetData>().map_txt.text;
        int level = int.Parse(GetData.FindObjectOfType<GetData>().level_txt.text);
        loadlevel.cmd = "level_editor_load_level";
        loadlevel.map_name = map_name;
        loadlevel.level_id = level;
        string LoadLevel = JsonUtility.ToJson(loadlevel);
        StartCoroutine(Post_loadLevel(URL, LoadLevel));
    }

    public void newlevel()
    {

        string map_name = GetData.FindObjectOfType<GetData>().map_txt.text;
        newlevel1.cmd = "level_editor_new_level";
        newlevel1.map_name = map_name;
        string Newlevel = JsonUtility.ToJson(newlevel1);
        StartCoroutine(Post(URL, Newlevel));
    }
    public void randommap()
    {
      //  GameController.Ins.Id.Clear();
        ID1 = -1;
        
        GameController.Ins.ClearObjBtn();
        try
        {
            tagetPoint = int.Parse(UIManager.Ins.tagetPoint_txt.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            objPoint = int.Parse(UIManager.Ins.ObjectsPoint_txt.GetComponent<InputField>().text);
        }
        catch { }
        if (tagetPoint > objPoint)
        {
            GameController.Ins.show_warring.showWarring(true);
            return;

        }

        string map_name = GetData.FindObjectOfType<GetData>().map_txt.text;

        randomMap.cmd = "level_editor_random_map";
        randomMap.map_name = map_name;
        int level = int.Parse(GetData.FindObjectOfType<GetData>().level_txt.text);
        randomMap.level_id = level;
        #region xu ly ngoai le
        try
        {
            randomMap.total_object_points = int.Parse(UIManager.Ins.ObjectsPoint_txt.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_small_rock = int.Parse(UIManager.Ins.smallRock.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_medium_rock = int.Parse(UIManager.Ins.mediumRock.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_big_rock = int.Parse(UIManager.Ins.bigRock.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_small_gold = int.Parse(UIManager.Ins.smallGold.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_medium_gold = int.Parse(UIManager.Ins.mediumGold.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_big_gold = int.Parse(UIManager.Ins.bigGold.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_super_gold = int.Parse(UIManager.Ins.superGold.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_small_chest = int.Parse(UIManager.Ins.smallChest.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_big_chest = int.Parse(UIManager.Ins.bigChest.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_diamond = int.Parse(UIManager.Ins.diamond.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_medium_rock = int.Parse(UIManager.Ins.mediumRock.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_medium_rock = int.Parse(UIManager.Ins.mediumRock.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_gift_box = int.Parse(UIManager.Ins.gift_Box.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_dirty_mouse = int.Parse(UIManager.Ins.dirty_Mouse.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_bat = int.Parse(UIManager.Ins.bat.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_snake = int.Parse(UIManager.Ins.snake.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_small_fish = int.Parse(UIManager.Ins.small_Fish.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_electric_eel = int.Parse(UIManager.Ins.electric_eel.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_shark = int.Parse(UIManager.Ins.shark.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_spider_web = int.Parse(UIManager.Ins.spider_web.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_dirty_mouse_diamond = int.Parse(UIManager.Ins.dirty_mouse_diamond.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_bat_diamond = int.Parse(UIManager.Ins.bat_diamond.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_snake_diamond = int.Parse(UIManager.Ins.snake_diamond.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_tnt_dynamite = int.Parse(UIManager.Ins.TNTDynamite.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_small_fish_diamond = int.Parse(UIManager.Ins.small_fish_diamond.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_electric_eel_diamond = int.Parse(UIManager.Ins.electric_eel_diamond.GetComponent<InputField>().text);
        }
        catch { }
        try
        {
            randomMap.number_shark_diamond = int.Parse(UIManager.Ins.shark_diamond.GetComponent<InputField>().text);
        }
        catch { }
        #endregion
        string random_map = JsonUtility.ToJson(randomMap);
        StartCoroutine(Post_randomMap(URL, random_map));
    }
    IEnumerator Post(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        Debug.Log("Request: " + bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);
        Debug.Log(request.downloadHandler.text);
    }
    IEnumerator Post_randomMap(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        Debug.Log("Request: " + bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);
        Debug.Log(request.downloadHandler.text);
        JSONNode data = JSON.Parse(request.downloadHandler.text);
        Debug.Log(data["objects"].Count);
        for (int i = 0; i < data["objects"].Count; i++)
        {
            if (data["objects"][i]["type"] == "small_rock")
            {
                Object Obj = new Object();
                Instantiate(GameController.Ins.minerals[0], new Vector3(data["objects"][i]["x"], data["objects"][i]["y"]), Quaternion.identity);
                Obj.type = data["objects"][i]["type"];
                Obj.x = data["objects"][i]["x"];
                Obj.y = data["objects"][i]["y"];
                GameController.Ins.Newconfig.number_small_rock++;
                GameController.Ins.savalevel.objects.Add(Obj);
                ID1++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }

            if (data["objects"][i]["type"] == "medium_rock")
            {
                Object Obj1 = new Object();
                Instantiate(GameController.Ins.minerals[1], new Vector3(data["objects"][i]["x"], data["objects"][i]["y"]), Quaternion.identity);
                Obj1.type = data["objects"][i]["type"];
                Obj1.x = data["objects"][i]["x"];
                Obj1.y = data["objects"][i]["y"];
                GameController.Ins.Newconfig.number_medium_rock++;
                GameController.Ins.savalevel.objects.Add(Obj1);
                ID1++;

                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);

            }
            if (data["objects"][i]["type"] == "big_rock")
            {
                Object Obj2 = new Object();

                Instantiate(GameController.Ins.minerals[2], new Vector3(data["objects"][i]["x"], data["objects"][i]["y"]), Quaternion.identity);
                Obj2.type = data["objects"][i]["type"];
                Obj2.x = data["objects"][i]["x"];
                Obj2.y = data["objects"][i]["y"];
                GameController.Ins.Newconfig.number_big_rock++;
                GameController.Ins.savalevel.objects.Add(Obj2);
                ID1++;
                GameController.Ins.Id.Add(ID);
                Debug.Log(ID);

            }
            if (data["objects"][i]["type"] == "small_gold")
            {
                Object Obj3 = new Object();

                Instantiate(GameController.Ins.minerals[3], new Vector3(data["objects"][i]["x"], data["objects"][i]["y"]), Quaternion.identity);
                Obj3.type = data["objects"][i]["type"];
                Obj3.x = data["objects"][i]["x"];
                Obj3.y = data["objects"][i]["y"];
                GameController.Ins.Newconfig.number_small_gold++;
                GameController.Ins.savalevel.objects.Add(Obj3);
                ID1++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);

            }
            if (data["objects"][i]["type"] == "medium_gold")
            {
                Object Obj4 = new Object();

                Instantiate(GameController.Ins.minerals[4], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj4.type = data["objects"][i]["type"];
                Obj4.x = data["objects"][i]["x"];
                Obj4.y = data["objects"][i]["y"];
                GameController.Ins.Newconfig.number_medium_gold++;
                GameController.Ins.savalevel.objects.Add(Obj4);
                ID1++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["objects"][i]["type"] == "big_gold")
            {
                Object Obj5 = new Object();
                Instantiate(GameController.Ins.minerals[5], new Vector3(data["objects"][i]["x"], data["objects"][i]["y"]), Quaternion.identity);
                Obj5.type = data["objects"][i]["type"];
                Obj5.x = data["objects"][i]["x"];
                Obj5.y = data["objects"][i]["y"];
                GameController.Ins.Newconfig.number_big_gold++;
                GameController.Ins.savalevel.objects.Add(Obj5);
                ID1++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["objects"][i]["type"] == "super_gold")
            {
                Object Obj6 = new Object();

                Instantiate(GameController.Ins.minerals[6], new Vector3(data["objects"][i]["x"], data["objects"][i]["y"]), Quaternion.identity);
                Obj6.type = data["objects"][i]["type"];
                Obj6.x = data["objects"][i]["x"];
                Obj6.y = data["objects"][i]["y"];
                GameController.Ins.Newconfig.number_super_gold++;
                GameController.Ins.savalevel.objects.Add(Obj6);
                ID1++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["objects"][i]["type"] == "diamond")
            {
                Object Obj7 = new Object();
                Instantiate(GameController.Ins.minerals[7], new Vector3(data["objects"][i]["x"], data["objects"][i]["y"]), Quaternion.identity);
                Obj7.type = data["objects"][i]["type"];
                Obj7.x = data["objects"][i]["x"];
                Obj7.y = data["objects"][i]["y"];
                GameController.Ins.Newconfig.number_diamond++;
                GameController.Ins.savalevel.objects.Add(Obj7);
                ID1++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
        }
        GameController.Ins.randomBtn();
    }
    IEnumerator Post_loadLevel(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        Debug.Log("Request: " + bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);
        Debug.Log(request.downloadHandler.text);
        JSONNode data = JSON.Parse(request.downloadHandler.text);
        Debug.Log(data["data"]["objects"].Count);

        for (int i = 0; i < data["data"]["objects"].Count; i++)
        {
            Debug.Log(data["data"]["objects"][i]["type"]);
            Debug.Log(data["data"]["objects"][i]["x"]);
            Debug.Log(data["data"]["objects"][i]["y"]);

            if (data["data"]["objects"][i]["type"] == "small_rock")
            {
                Object Obj = new Object();
                Instantiate(GameController.Ins.minerals[0], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj.type = data["data"]["objects"][i]["type"];
                Obj.x = data["data"]["objects"][i]["x"];
                Obj.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_small_rock++;
                GameController.Ins.savalevel.objects.Add(Obj);
                ID1++;
                GameController.Ins.Id.Add(ID1);
                number_small_rock++;
                // UIManager.Ins.Set_smallRock(smallRock.ToString());

                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "medium_rock")
            {
                Object Obj1 = new Object();
                Instantiate(GameController.Ins.minerals[1], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj1.type = data["data"]["objects"][i]["type"];
                Obj1.x = data["data"]["objects"][i]["x"];
                Obj1.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_medium_rock++;
                GameController.Ins.savalevel.objects.Add(Obj1);
                ID1++;
                number_medium_rock++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);

            }
            if (data["data"]["objects"][i]["type"] == "big_rock")
            {
                Object Obj2 = new Object();
                Instantiate(GameController.Ins.minerals[2], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj2.type = data["data"]["objects"][i]["type"];
                Obj2.x = data["data"]["objects"][i]["x"];
                Obj2.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_big_rock++;
                GameController.Ins.savalevel.objects.Add(Obj2);
                ID1++;
                number_big_rock++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "small_gold")
            {
                Object Obj3 = new Object();
                Instantiate(GameController.Ins.minerals[3], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj3.type = data["data"]["objects"][i]["type"];
                Obj3.x = data["data"]["objects"][i]["x"];
                Obj3.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_small_gold++;
                GameController.Ins.savalevel.objects.Add(Obj3);
                ID1++;
                number_small_gold++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "medium_gold")
            {
                Object Obj4 = new Object();

                Instantiate(GameController.Ins.minerals[4], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj4.type = data["data"]["objects"][i]["type"];
                Obj4.x = data["data"]["objects"][i]["x"];
                Obj4.y = data["data"]["objects"][i]["y"];
                GameController.Ins.savalevel.objects.Add(Obj4);
                GameController.Ins.Newconfig.number_medium_gold++;
                ID1++;
                number_medium_gold++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "big_gold")
            {
                Object Obj5 = new Object();

                Instantiate(GameController.Ins.minerals[5], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj5.type = data["data"]["objects"][i]["type"];
                Obj5.x = data["data"]["objects"][i]["x"];
                Obj5.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_big_gold++;

                GameController.Ins.savalevel.objects.Add(Obj5);
                ID1++;
                number_big_gold++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "super_gold")
            {
                Object Obj6 = new Object();

                Instantiate(GameController.Ins.minerals[6], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj6.type = data["data"]["objects"][i]["type"];
                Obj6.x = data["data"]["objects"][i]["x"];
                Obj6.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_super_gold++;

                GameController.Ins.savalevel.objects.Add(Obj6);
                ID1++;
                number_super_gold++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "diamond")
            {
                Object Obj7 = new Object();

                Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj7.type = data["data"]["objects"][i]["type"];
                Obj7.x = data["data"]["objects"][i]["x"];
                Obj7.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_diamond++;

                GameController.Ins.savalevel.objects.Add(Obj7);
                ID1++;
                number_diamond++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "gift_box")
            {
                Object Obj8 = new Object();

              //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj8.type = data["data"]["objects"][i]["type"];
                Obj8.x = data["data"]["objects"][i]["x"];
                Obj8.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_gift_box++;

                GameController.Ins.savalevel.objects.Add(Obj8);
                ID1++;
                number_gift_box++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "dirty_mouse")
            {
                Object Obj9 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj9.type = data["data"]["objects"][i]["type"];
                Obj9.x = data["data"]["objects"][i]["x"];
                Obj9.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_dirty_mouse++;

                GameController.Ins.savalevel.objects.Add(Obj9);
                ID1++;
                number_dirty_mouse++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "bat")
            {
                Object Obj10 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj10.type = data["data"]["objects"][i]["type"];
                Obj10.x = data["data"]["objects"][i]["x"];
                Obj10.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_bat++;

                GameController.Ins.savalevel.objects.Add(Obj10);
                ID1++;
                number_bat++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "snake")
            {
                Object Obj11 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj11.type = data["data"]["objects"][i]["type"];
                Obj11.x = data["data"]["objects"][i]["x"];
                Obj11.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_snake++;

                GameController.Ins.savalevel.objects.Add(Obj11);
                ID1++;
                number_snake++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "small_fish")
            {
                Object Obj12 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj12.type = data["data"]["objects"][i]["type"];
                Obj12.x = data["data"]["objects"][i]["x"];
                Obj12.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_small_fish++;

                GameController.Ins.savalevel.objects.Add(Obj12);
                ID1++;
                number_small_fish++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "shark")
            {
                Object Obj13 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj13.type = data["data"]["objects"][i]["type"];
                Obj13.x = data["data"]["objects"][i]["x"];
                Obj13.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_shark++;

                GameController.Ins.savalevel.objects.Add(Obj13);
                ID1++;
                number_shark++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "electric_eel")
            {
                Object Obj14 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj14.type = data["data"]["objects"][i]["type"];
                Obj14.x = data["data"]["objects"][i]["x"];
                Obj14.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_electric_eel++;

                GameController.Ins.savalevel.objects.Add(Obj14);
                ID1++;
                number_electric_eel++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "tnt_dynamite")
            {
                Object Obj15 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj15.type = data["data"]["objects"][i]["type"];
                Obj15.x = data["data"]["objects"][i]["x"];
                Obj15.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_tnt_dynamite++;

                GameController.Ins.savalevel.objects.Add(Obj15);
                ID1++;
                number_tnt_dynamite++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "spider_web")
            {
                Object Obj16 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj16.type = data["data"]["objects"][i]["type"];
                Obj16.x = data["data"]["objects"][i]["x"];
                Obj16.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_spider_web++;

                GameController.Ins.savalevel.objects.Add(Obj16);
                ID1++;
                number_spider_web++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "dirty_mouse_diamond")
            {
                Object Obj17 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj17.type = data["data"]["objects"][i]["type"];
                Obj17.x = data["data"]["objects"][i]["x"];
                Obj17.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_dirty_mouse_diamond++;

                GameController.Ins.savalevel.objects.Add(Obj17);
                ID1++;
                number_dirty_mouse_diamond++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "bat_diamond")
            {
                Object Obj18 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj18.type = data["data"]["objects"][i]["type"];
                Obj18.x = data["data"]["objects"][i]["x"];
                Obj18.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_bat_diamond++;

                GameController.Ins.savalevel.objects.Add(Obj18);
                ID1++;
                number_bat_diamond++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "snake_diamond")
            {
                Object Obj19 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj19.type = data["data"]["objects"][i]["type"];
                Obj19.x = data["data"]["objects"][i]["x"];
                Obj19.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_snake_diamond++;

                GameController.Ins.savalevel.objects.Add(Obj19);
                ID1++;
                number_snake_diamond++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "small_fish_diamond")
            {
                Object Obj20 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj20.type = data["data"]["objects"][i]["type"];
                Obj20.x = data["data"]["objects"][i]["x"];
                Obj20.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_small_fish_diamond++;

                GameController.Ins.savalevel.objects.Add(Obj20);
                ID1++;
                number_small_fish_diamond++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "electric_eel_diamond")
            {
                Object Obj21 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj21.type = data["data"]["objects"][i]["type"];
                Obj21.x = data["data"]["objects"][i]["x"];
                Obj21.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_electric_eel_diamond++;

                GameController.Ins.savalevel.objects.Add(Obj21);
                ID1++;
                number_electric_eel_diamond++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
            if (data["data"]["objects"][i]["type"] == "shark_diamond")
            {
                Object Obj22 = new Object();

                //  Instantiate(GameController.Ins.minerals[7], new Vector3(data["data"]["objects"][i]["x"], data["data"]["objects"][i]["y"]), Quaternion.identity);
                Obj22.type = data["data"]["objects"][i]["type"];
                Obj22.x = data["data"]["objects"][i]["x"];
                Obj22.y = data["data"]["objects"][i]["y"];
                GameController.Ins.Newconfig.number_shark_diamond++;

                GameController.Ins.savalevel.objects.Add(Obj22);
                ID1++;
                number_shark_diamond++;
                GameController.Ins.Id.Add(ID1);
                Debug.Log(ID1);
            }
        }

        GameController.Ins.randomBtn();
        UIManager.Ins.SetObjectPointTxt(data["data"]["total_object_points"]);
       // UIManager.Ins.SetCurrentPointTxt(data["data"]["total_object_points"]);
        UIManager.Ins.Set_smallRock(number_small_rock.ToString());
        UIManager.Ins.Set_mediumRock(number_medium_rock.ToString());
        UIManager.Ins.Set_bigRock(number_big_rock.ToString());
        UIManager.Ins.Set_smallGold(number_small_gold.ToString());
        UIManager.Ins.Set_mediumGold(number_medium_gold.ToString());
        UIManager.Ins.Set_bigGold(number_big_gold.ToString());
        UIManager.Ins.Set_superGold(number_super_gold.ToString());
        UIManager.Ins.Set_Diamond(number_diamond.ToString());
        UIManager.Ins.Set_smallCHest(number_small_chest.ToString());
        UIManager.Ins.Set_bigChest(number_big_chest.ToString());
        UIManager.Ins.Set_giftBox(number_gift_box.ToString());
        UIManager.Ins.Set_mouse(number_dirty_mouse.ToString());
        UIManager.Ins.Set_bat(number_bat.ToString());
        UIManager.Ins.Set_smallFish(number_small_fish.ToString());
        UIManager.Ins.Set_eel(number_electric_eel.ToString());
        UIManager.Ins.Set_shark(number_shark.ToString());
        UIManager.Ins.Set_snake(number_snake.ToString());
        UIManager.Ins.Set_TNTDynamite(number_tnt_dynamite.ToString());
        UIManager.Ins.Set_spider_web(number_spider_web.ToString());
        UIManager.Ins.Set_dirty_mouse_diamond(number_dirty_mouse_diamond.ToString());
        UIManager.Ins.Set_bat_diamond(number_bat_diamond.ToString());
        UIManager.Ins.Set_snake_diamond(number_snake_diamond.ToString());
        UIManager.Ins.Set_small_fish_diamond(number_small_fish_diamond.ToString());
        UIManager.Ins.Set_electric_eel_diamond(number_electric_eel_diamond.ToString());
        UIManager.Ins.Set_shark_diamond(number_shark_diamond.ToString());

    }
}
