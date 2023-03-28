
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : Singleton<GameController>
{
    public List<Gold> minerals = new List<Gold>();
    int sum = 0;
    public ShowObj show_obj;
    public ShowObj show_warring;
    public Gold selectedObject;
    Vector3 offset;
    public RandomMap newlevel = new RandomMap();
    public Savalevel savalevel = new Savalevel();
    Config1 newconfig = new Config1();
    //Object selecobject = new Object();
    public Material outline;
    public Material outline1;
    int a = 0;

    public Config1 Newconfig { get => newconfig; set => newconfig = value; }
    public List<int> Id { get => id; set => id = value; }

    List<int> id = new List<int>();

    public override void Awake()
    {
        UIManager.Ins.SetTagetPointTxt(null);
        UIManager.Ins.SetObjectPointTxt(null);
        UIManager.Ins.Set_smallRock(null);
        UIManager.Ins.SetCurrentPointTxt(null);
        UIManager.Ins.SetConfigPointTxt(null);
        UIManager.Ins.Set_mediumRock(null);
        UIManager.Ins.Set_bigRock(null);
        UIManager.Ins.Set_smallGold(null);
        UIManager.Ins.Set_mediumGold(null);
        UIManager.Ins.Set_bigGold(null);
        UIManager.Ins.Set_superGold(null);
        UIManager.Ins.Set_smallCHest(null);
        UIManager.Ins.Set_bigChest(null);
        UIManager.Ins.Set_Diamond(null);
        UIManager.Ins.Set_giftBox(null);
        UIManager.Ins.Set_mouse(null);
        UIManager.Ins.Set_bat(null);
        UIManager.Ins.Set_snake(null);
        UIManager.Ins.Set_smallFish(null);
        UIManager.Ins.Set_eel(null);
        UIManager.Ins.Set_shark(null);
        UIManager.Ins.Set_TNTDynamite(null);
        UIManager.Ins.Set_spider_web(null);
        UIManager.Ins.Set_dirty_mouse_diamond(null);
        UIManager.Ins.Set_bat_diamond(null);
        UIManager.Ins.Set_snake_diamond(null);
        UIManager.Ins.Set_small_fish_diamond(null);
        UIManager.Ins.Set_electric_eel_diamond(null);
        UIManager.Ins.Set_shark_diamond(null);
    }

    public override void Update()
    {

        try
        {
            UIManager.Ins.SetConfigPointTxt((int.Parse(UIManager.Ins.mediumRock.GetComponent<InputField>().text) * minerals[1].Score).ToString());
        }
        catch
        { }
        try
        {
            UIManager.Ins.SetConfigPointTxt((int.Parse(UIManager.Ins.smallRock.GetComponent<InputField>().text) * minerals[0].Score).ToString());
        }
        catch
        {
        }
        try
        {
            UIManager.Ins.SetConfigPointTxt((
                  int.Parse(UIManager.Ins.smallRock.GetComponent<InputField>().text) * minerals[0].Score
                + int.Parse(UIManager.Ins.mediumRock.GetComponent<InputField>().text) * minerals[1].Score
                + int.Parse(UIManager.Ins.bigRock.GetComponent<InputField>().text) * minerals[2].Score
                + int.Parse(UIManager.Ins.smallGold.GetComponent<InputField>().text) * minerals[3].Score
                + int.Parse(UIManager.Ins.mediumGold.GetComponent<InputField>().text) * minerals[4].Score
                + int.Parse(UIManager.Ins.bigGold.GetComponent<InputField>().text) * minerals[5].Score
                + int.Parse(UIManager.Ins.superGold.GetComponent<InputField>().text) * minerals[6].Score
                + int.Parse(UIManager.Ins.diamond.GetComponent<InputField>().text) * minerals[7].Score
                //+ number_small_chest
                //+number_big_chest
                //+number_gift_box
                //+number_dirty_mouse
                //+number_bat
                //+number_snake
                //+number_small_fish
                //+number_shark
                //+number_electric_eel
                //+number_tnt_dynamite
                ).ToString());
        }
        catch { }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Clone");
        for (int i = 0; i < allObjects.Length; i++)
        {
            allObjects[i].GetComponent<Gold>().Id = Id[i];
        }
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject.GetComponent<Gold>();
                offset = selectedObject.transform.position - mousePosition;

            }
        }
        //di chuyen OBJ
        try
        {
            if (selectedObject)
            {
                int moveSpeed = 5;
                float xDir = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                if ((xDir < 0 && selectedObject.transform.position.x <= -8.5f) || (xDir > 0 && selectedObject.transform.position.x >= 8.5f) || (vertical < 0 && selectedObject.transform.position.y <= -4.5f) || (vertical > 0 && selectedObject.transform.position.y >= 0.6f))
                    return;
                selectedObject.transform.position = selectedObject.transform.position + moveSpeed * Vector3.right * xDir * Time.deltaTime;
                selectedObject.transform.position = selectedObject.transform.position + moveSpeed * Vector3.up * vertical * Time.deltaTime;
                if (selectedObject.Id != a)
                {
                    Debug.Log("a");
                    for (int i = 0; i < allObjects.Length; i++)
                    {
                        if (allObjects[i].GetComponent<Gold>().Id == a)
                        {
                            allObjects[i].GetComponent<Renderer>().material = outline1;
                            a = selectedObject.Id;
                        }
                    }
                }
                for (int i = 0; i < allObjects.Length; i++)
                {
                    if (selectedObject.Id == allObjects[i].GetComponent<Gold>().Id)
                    {
                        selectedObject.GetComponent<Renderer>().material = outline;
                        a = selectedObject.Id;
                        Debug.Log("selectedObject.Id" + selectedObject.Id);
                        savalevel.objects[selectedObject.Id].x = selectedObject.transform.position.x;
                        savalevel.objects[selectedObject.Id].y = selectedObject.transform.position.y;
                    }
                }
            }
        }
        catch { }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            selectedObject.GetComponent<Renderer>().material = outline1;

            selectedObject = null;
        }

        if (Input.GetKeyDown(KeyCode.Delete) && selectedObject)
        {
            DeleteBtn();
        }
        UIManager.Ins.SetCurrentPointTxt(sum.ToString());
    }

    public void OK()
    {
        show_warring.showWarring(false);
    }

    public void randomBtn()
    {
        savalevel.cmd = "level_editor_save_level";
        savalevel.map_name = UIManager.Ins.map_txt.text;
        savalevel.level_id = int.Parse(UIManager.Ins.level_txt.text);
        savalevel.total_object_points = sum;
        savalevel.config.Add(newconfig);
    }
    //public void AddMirenal(int mirenal)
    //{
    //    sum = sum + minerals[mirenal].Score;
    //    switch (mirenal)
    //    {
    //        case 0:
    //            //savalevel.objects.Add(obj);
    //            //newconfig.number_small_rock++;
    //            object_smallRock();
    //            // object_mirenal(mirenal);
    //            break;
    //        case 1:

    //            //  savalevel.objects.Add(obj1);
    //            // object_mirenal(mirenal);
    //            object_mediumRock();
    //            break;
    //        case 2:

    //            // savalevel.objects.Add(obj2);
    //            object_bigRock();
    //            //object_mirenal(mirenal);
    //            break;
    //        case 3:

    //            // savalevel.objects.Add(obj3);
    //            object_smallGold();
    //            // object_mirenal(mirenal);
    //            break;
    //        case 4:

    //            // savalevel.objects.Add(obj4);
    //            object_mediumGold();
    //            //object_mirenal(mirenal);
    //            break;
    //        case 5:
    //            // savalevel.objects.Add(obj5);
    //            object_bigGold();
    //            // object_mirenal(mirenal);
    //            break;
    //        case 6:

    //            // savalevel.objects.Add(obj6);
    //            object_superGold();
    //            //object_mirenal(mirenal);
    //            break;
    //        case 7:

    //            // savalevel.objects.Add(obj7);
    //            object_Diamond();
    //            //  object_mirenal(mirenal);
    //            break;
    //    }
    //    // object_mirenal(mirenal);
    //    // show_obj.showobj(false);
    //}

    public void AddSmallRock()
    {
        float randomX = Random.Range(-8, 8);
        float randomY = Random.Range(-4.5f, 0.5f);
        Instantiate(minerals[0], new Vector3(randomX, randomY), Quaternion.identity);
        sum = sum + minerals[0].Score;

        newconfig.number_small_rock++;
        // object_smallRock();
        Object obj = new Object();
        obj.type = "small_rock";
        obj.x = randomX;
        obj.y = randomY;
        savalevel.objects.Add(obj);
        show_obj.showobj(false);
        PostData.FindObjectOfType<PostData>().ID1++;
        Id.Add(PostData.FindObjectOfType<PostData>().ID1);
        // object_smallRock();
    }
    public void AddMediumRock()
    {
        float randomX = Random.Range(-8, 8);
        float randomY = Random.Range(-4.5f, 0.5f);
        Instantiate(minerals[1], new Vector3(randomX, randomY), Quaternion.identity);
        sum = sum + minerals[1].Score;
        newconfig.number_medium_rock++;
        //object_mediumRock();
        Object obj1 = new Object();
        obj1.type = "medium_rock";
        obj1.x = randomX;
        obj1.y = randomY;
        savalevel.objects.Add(obj1);
        show_obj.showobj(false);
        PostData.FindObjectOfType<PostData>().ID1++;
        Id.Add(PostData.FindObjectOfType<PostData>().ID1);
    }
    public void AddBigRock()
    {
        float randomX = Random.Range(-8, 8);
        float randomY = Random.Range(-4.5f, 0.5f);
        Instantiate(minerals[2], new Vector3(randomX, randomY), Quaternion.identity);
        sum = sum + minerals[2].Score;
        newconfig.number_big_rock++;
        // object_bigRock();
        Object obj2 = new Object();
        obj2.type = "big_rock";
        obj2.x = randomX;
        obj2.y = randomY;
        savalevel.objects.Add(obj2);
        show_obj.showobj(false);
        PostData.FindObjectOfType<PostData>().ID1++;
        Id.Add(PostData.FindObjectOfType<PostData>().ID1);

    }
    public void AddSmallGold()
    {
        float randomX = Random.Range(-8, 8);
        float randomY = Random.Range(-4.5f, 0.5f);
        Instantiate(minerals[3], new Vector3(randomX, randomY), Quaternion.identity);
        sum = sum + minerals[3].Score;
        newconfig.number_small_gold++;
        // object_smallGold();
        Object obj3 = new Object();
        obj3.type = "small_gold";
        obj3.x = randomX;
        obj3.y = randomY;
        savalevel.objects.Add(obj3);
        show_obj.showobj(false);
        PostData.FindObjectOfType<PostData>().ID1++;
        Id.Add(PostData.FindObjectOfType<PostData>().ID1);

    }
    public void AddMediumGold()
    {
        float randomX = Random.Range(-8, 8);
        float randomY = Random.Range(-4.5f, 0.5f);
        Instantiate(minerals[4], new Vector3(randomX, randomY), Quaternion.identity);
        sum = sum + minerals[4].Score;
        newconfig.number_medium_gold++;
        // object_mediumGold();
        Object obj4 = new Object();
        obj4.type = "medium_gold";
        obj4.x = randomX;
        obj4.y = randomY;
        savalevel.objects.Add(obj4);
        show_obj.showobj(false);
        PostData.FindObjectOfType<PostData>().ID1++;
        Id.Add(PostData.FindObjectOfType<PostData>().ID1);

    }
    public void AddBigGold()
    {
        float randomX = Random.Range(-8, 8);
        float randomY = Random.Range(-4.5f, 0.5f);
        Instantiate(minerals[5], new Vector3(randomX, randomY), Quaternion.identity);
        sum = sum + minerals[5].Score;
        newconfig.number_big_gold++;
        //object_bigGold();
        Object obj5 = new Object();
        obj5.type = "big_gold";
        obj5.x = randomX;
        obj5.y = randomY;
        savalevel.objects.Add(obj5);
        show_obj.showobj(false);
        PostData.FindObjectOfType<PostData>().ID1++;
        Id.Add(PostData.FindObjectOfType<PostData>().ID1);

    }
    public void AddSuperGold()
    {
        float randomX = Random.Range(-8, 8);
        float randomY = Random.Range(-4.5f, 0.5f);
        Instantiate(minerals[6], new Vector3(randomX, randomY), Quaternion.identity);
        sum = sum + minerals[6].Score;
        newconfig.number_super_gold++;
        //object_superGold();
        Object obj6 = new Object();
        obj6.type = "super_gold";
        obj6.x = randomX;
        obj6.y = randomY;
        savalevel.objects.Add(obj6);
        show_obj.showobj(false);
        PostData.FindObjectOfType<PostData>().ID1++;
        Id.Add(PostData.FindObjectOfType<PostData>().ID1);

    }
    public void AddDiamond()
    {
        float randomX = Random.Range(-8, 8);
        float randomY = Random.Range(-4.5f, 0.5f);
        Instantiate(minerals[7], new Vector3(randomX, randomY), Quaternion.identity);
        sum = sum + minerals[7].Score;
        newconfig.number_diamond++;
        Object obj7 = new Object();
        obj7.type = "diamond";
        obj7.x = randomX;
        obj7.y = randomY;
        savalevel.objects.Add(obj7);
        show_obj.showobj(false);
        PostData.FindObjectOfType<PostData>().ID1++;
        Id.Add(PostData.FindObjectOfType<PostData>().ID1);

    }
    public void DeleteBtn()
    {
        if (selectedObject)
        {
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Clone");
            for (int i = 0; i < allObjects.Length; i++)
            {
                sum = sum - allObjects[i].GetComponent<Gold>().Score;
                switch (selectedObject.name)
                {
                    case "small_rock":
                        newconfig.number_small_rock--;
                        break;
                    case "medium_rock":
                        newconfig.number_medium_rock--;
                        break;
                    case "big_rock":
                        newconfig.number_big_rock--;
                        break;
                    case "small_gold":
                        newconfig.number_small_gold--;
                        break;
                    case "medium_gold":
                        newconfig.number_medium_gold--;
                        break;
                    case "big_gold":
                        newconfig.number_big_gold--;
                        break;
                    case "super_gold":
                        newconfig.number_super_gold--;
                        break;
                    case "diamond":
                        newconfig.number_diamond--;
                        break;
                    case "spider_web":
                        newconfig.number_spider_web--;
                        break;
                    case "dirty_mouse_diamond":
                        newconfig.number_dirty_mouse_diamond--;
                        break;
                    case "bat_diamond":
                        newconfig.number_bat_diamond--;
                        break;
                    case "snake_diamond":
                        newconfig.number_snake_diamond--;
                        break;
                    case "small_fish_diamond":
                        newconfig.number_small_fish_diamond--;
                        break;
                    case "electric_eel_diamond":
                        newconfig.number_electric_eel_diamond--;
                        break;
                    case "shark_diamond":
                        newconfig.number_shark_diamond--;
                        break;
                }

            }
            savalevel.objects.RemoveAt(selectedObject.Id);
            Destroy(selectedObject.gameObject);
        }
    }
    public void ClearObjBtn()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject obj in allObjects)
        {
            Destroy(obj);
        }
        sum = 0;
        savalevel.config.Remove(newconfig);
        savalevel.objects.Clear();
        newconfig.number_small_rock = 0;
        newconfig.number_medium_rock = 0;
        newconfig.number_big_rock = 0;
        newconfig.number_small_gold = 0;
        newconfig.number_medium_gold = 0;
        newconfig.number_big_gold = 0;
        newconfig.number_super_gold = 0;
        newconfig.number_diamond = 0;
        newconfig.number_spider_web = 0;
        newconfig.number_dirty_mouse_diamond = 0;
        newconfig.number_bat_diamond = 0;
        newconfig.number_snake_diamond = 0;
        newconfig.number_small_fish_diamond = 0;
        newconfig.number_electric_eel_diamond = 0;
        newconfig.number_shark_diamond = 0;

    }
    public void ResetALlBtn()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject obj in allObjects)
        {
            Destroy(obj);
        }
        sum = 0;
        // UIManager.Ins.ObjectsPoint_txt.GetComponent<InputField>().text = null;
        UIManager.Ins.SetTagetPointTxt(null);
        UIManager.Ins.SetObjectPointTxt(null);
        UIManager.Ins.Set_smallRock(null);
        UIManager.Ins.SetCurrentPointTxt(null);
        UIManager.Ins.SetConfigPointTxt(null);
        UIManager.Ins.Set_mediumRock(null);
        UIManager.Ins.Set_bigRock(null);
        UIManager.Ins.Set_smallGold(null);
        UIManager.Ins.Set_mediumGold(null);
        UIManager.Ins.Set_bigGold(null);
        UIManager.Ins.Set_superGold(null);
        UIManager.Ins.Set_smallCHest(null);
        UIManager.Ins.Set_bigChest(null);
        UIManager.Ins.Set_Diamond(null);
        UIManager.Ins.Set_giftBox(null);
        UIManager.Ins.Set_mouse(null);
        UIManager.Ins.Set_bat(null);
        UIManager.Ins.Set_snake(null);
        UIManager.Ins.Set_smallFish(null);
        UIManager.Ins.Set_eel(null);
        UIManager.Ins.Set_shark(null);
        UIManager.Ins.Set_TNTDynamite(null);
        UIManager.Ins.Set_spider_web(null);
        UIManager.Ins.Set_dirty_mouse_diamond(null);
        UIManager.Ins.Set_bat_diamond(null);
        UIManager.Ins.Set_snake_diamond(null);
        UIManager.Ins.Set_small_fish_diamond(null);
        UIManager.Ins.Set_electric_eel_diamond(null);
        UIManager.Ins.Set_shark_diamond(null);
        savalevel.config.Remove(newconfig);
        newconfig.number_small_rock = 0;
        newconfig.number_medium_rock = 0;
        newconfig.number_big_rock = 0;
        newconfig.number_small_gold = 0;
        newconfig.number_medium_gold = 0;
        newconfig.number_big_gold = 0;
        newconfig.number_super_gold = 0;
        newconfig.number_diamond = 0;
        newconfig.number_spider_web = 0;
        newconfig.number_dirty_mouse_diamond = 0;
        newconfig.number_bat_diamond = 0;
        newconfig.number_snake_diamond = 0;
        newconfig.number_small_fish_diamond = 0;
        newconfig.number_electric_eel_diamond = 0;
        newconfig.number_shark_diamond = 0;
        savalevel.objects.Clear();
    }
    public void ObJect()
    {
        show_obj.showobj(true);
    }
    public void X()
    {
        show_obj.showobj(false);
    }
}
