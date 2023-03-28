using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowObj : MonoBehaviour
{
    public void showobj(bool isshow)
    {
        gameObject.SetActive(isshow);
    }
    public void showWarring(bool isshow)
    {
        gameObject.SetActive(isshow);
    }
}
