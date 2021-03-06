﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Text months;
    public Text gifts;
    public Text monthsPerSecond;
    public List<HireButton> hireButton = null;
    public List<UpgradeButton> upgradeButton = null;
    public List<Text> hireText = null;
    public List<TextMeshProUGUI> NLT = null;

    public SantaHeadScript santaHead = null;
    public Button donateButton = null;

    public GameObject info = null;
    public GameObject settings = null;

    // Start is called before the first frame update
    void Start()
    {
        NLT[0].SetText(Managers.GiftManager.Instance.gifts.ToString());
        NLT[1].SetText(Managers.GiftManager.Instance.NLTGifts.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckHiredButtons(int gifts, int NLTGifts)
    {
        for (int i = 0; i < hireButton.Count; ++i)
            hireButton[i].CheckButton(gifts);
        for (int i = 0; i < upgradeButton.Count; ++i)
            upgradeButton[i].CheckButton(gifts);
        santaHead.CheckSantaColor((float)gifts / NLTGifts);
        CheckDonateButton((float)gifts / NLTGifts);
    }

    private void CheckDonateButton(float percent)
    {
        if (percent > 0.5f) donateButton.interactable = true;
        else donateButton.interactable = false;
    }

    public void SetText(int giftNum, int monthNum, float monthsPerSecond)
    {
        gifts.text = giftNum.ToString() + "\nGifts";
        months.text = monthNum.ToString() + "\nMonths";
        this.monthsPerSecond.text = monthsPerSecond.ToString() + "\nMonths per Second";

        NLT[0].SetText(giftNum.ToString());
    }

    public void UnhireButtons()
    {
        for (int i = 0; i < hireButton.Count; ++i)
            hireButton[i].AddHiring();
    }

    public void UnpurchaseButtons()
    {
        for (int i = 0; i < upgradeButton.Count; ++i)
            upgradeButton[i].AddPurchasing();
    }

    public void OpenScene(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
        if (obj == info && info.activeSelf)
        {
            settings.SetActive(false);
        }

        if (obj == settings && settings.activeSelf)
        {
            info.SetActive(false);
        }
    }

    public void CloseScene(GameObject obj)
    {
        obj.SetActive(false);
    }
}
