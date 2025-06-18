using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointHUD : MonoBehaviour
{
    [SerializeField] Text pointText;

    private int initPoint = 0;

    // field
    private int point;

    private void Awake()
    {
        LoadTextComponent();

        // init value of point
        point = initPoint;
        UpdateUI();
    }

    // property
    public int Point
    {
        get
        {
            return point;
        }
        
        set
        {
            point = value;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        pointText.text = point.ToString();
    }

    private void LoadTextComponent()
    {
        pointText = gameObject.GetComponent<Text>();
    }
}
