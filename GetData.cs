using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class GetData : MonoBehaviour
{
    public Text map_txt;
    public Dropdown dropdownMap;
    public Dropdown dropdownLevel;
    public Text level_txt;

    Newlevel newlevel = new Newlevel();
    
    string URL = "http://servertest.goldminernft.xyz:8880/goldminernft/sfs2x?cmd=level_editor_list_level";
    string URL_LoadLevel = "http://servertest.goldminernft.xyz:8880/goldminernft/sfs2x?cmd=level_editor_new_level&map_name=MapDongCo";
    private void Start()
    {
        StartCoroutine(GetDataCoroutine(URL));
        
    }


    IEnumerator GetDataNewLevel(string url)
    {
        newlevel.cmd = "level_editor_new_level";
        newlevel.map_name = map_txt.text;
        string Newlevel = JsonUtility.ToJson(newlevel);
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("error");
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
           JSONNode data = JSON.Parse(request.downloadHandler.text);

        }
    }
    IEnumerator GetDataCoroutine(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("error");
        }
        else
        {
            JSONNode data = JSON.Parse(request.downloadHandler.text);
            dropdownMap.options.Clear();
            foreach (var i in data["data"].AsArray.Children)
            {
                //   Debug.Log(i);
                foreach (var j in i)
                {
                    if (j.Value)
                    {
                        dropdownMap.options.Add(new Dropdown.OptionData() { text = j.Value });
                    }

                }

            }
            DropdownValueChanged(dropdownMap);
            dropdownMap.onValueChanged.AddListener(DataSelectEvent);
            DataSelectEvent(0);

            DropdownValueChangedLevel(dropdownLevel);
            void DropdownValueChanged(Dropdown change)
            {
                int index = change.value;
                map_txt.text = change.options[index].text;

                DropdownValueChangedLevel(dropdownLevel);
            }
            void DropdownValueChangedLevel(Dropdown change)
            {
                level_txt.text = change.options[0].text;

            }
            void DataSelectEvent(int index)
            {
                dropdownLevel.options.Clear();
                for (int i = 1; i <= data["data"][index][1].Count; i++)
                {
                    if (i <= 20)
                    {
                        dropdownLevel.options.Add(new Dropdown.OptionData() { text = i.ToString() });

                    }
                }
            }
        }
    }
}

