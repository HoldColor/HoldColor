using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;
using UnityEngine.UI;

public class OccupyBarController : MonoBehaviour {
    public Color NowCamp;
    public int TotalValue;
    public int CurrentValue;
    private Slider Bar;
    private Image Fill;
	// Use this for initialization
	private void Awake () {
        Bar = gameObject.transform.Find("bar").GetComponent<Slider>();
        TotalValue = SFConfig._TotalValue;
        Bar.value = 0;
        CurrentValue = 0;
        NowCamp = CampDefine.Campless;
        gameObject.transform.Find("bar/Background").GetComponent<Image>().color = CampDefine.Campless;
        Fill = gameObject.transform.Find("bar/Fill Area/Fill").GetComponent<Image>();
	}
	
	public bool Occupy(int point, Color camp)
    {
       if (NowCamp == CampDefine.Campless || NowCamp == camp)
        {
            NowCamp = camp;
            Fill.color = camp;
            if (CurrentValue + point >= TotalValue)
            {
                CurrentValue = TotalValue;
                RefreshInfo();
                gameObject.GetComponentInParent<SFController>().GameBody.GetComponent<SpriteRenderer>().color = camp;
                return true;
            } else
            {
                CurrentValue += point;
                RefreshInfo();
                return false;
            }
        } else
        {
            if (CurrentValue - point <= 0)
            {
                CurrentValue = 0;
                RefreshInfo();
                gameObject.GetComponentInParent<SFController>().GameBody.GetComponent<SpriteRenderer>().color = CampDefine.Campless;
                NowCamp = camp;
                Fill.color = camp;
                return false;
            } else
            {
                CurrentValue -= point;
                RefreshInfo();
                return false;
            }
        }
    }
    
    private void RefreshInfo()
    {
        Bar.value = ((float)CurrentValue / (float)TotalValue);
    }
}
