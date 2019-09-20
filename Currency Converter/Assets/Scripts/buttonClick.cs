using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonClick : MonoBehaviour
{
    // storing the current Id and currency name of this specific currency for use later when we change currency
    public string currentId;
    public string currentCurrencyName;
    public int idNum;

    // sub id is the first two characters of the currency to get them from our image files
    string subId;

    private void Start()
    {

        subId = currentId[0].ToString() + currentId[1].ToString();

        GetComponent<Button>().onClick.AddListener(ChangeCurr);

        var texture2 = Resources.Load<Texture2D>("Textures/" + subId);
        //gameObject.transform.GetChild(1).GetComponentInChildren<RawImage>().texture = DataSaver.Instance.images[idNum];
        gameObject.transform.GetChild(1).GetComponentInChildren<RawImage>().texture = texture2;

    }
    private void Update()
    {
     


    }

    public void ChangeCurr()
    {
        // using this function make sure we know what currency the user has chosen
        // this makes it easier to keep track of the choices and what to display on main panel

        //StartCoroutine(DataSaver.Instance.GetTexture("dz"));
        if (HandleUI.Instance.currButton == 1)
        {

            starter.Instance.currIdfrom.text = currentId;
            starter.Instance.currnamefrom.text = currentCurrencyName;
            var texture2 = Resources.Load<Texture2D>("Textures/" + subId);
            //gameObject.transform.GetChild(1).GetComponentInChildren<RawImage>().texture = DataSaver.Instance.images[idNum];
           
            starter.Instance.imgfrom.GetComponent<RawImage>().texture = texture2;
            //string idcurr = currentId[0].ToString() + currentId[1].ToString();
            //StartCoroutine(DataSaver.Instance.GetTexture(idcurr));
        }
        else
        {
            starter.Instance.currIdTo.text = currentId;
            starter.Instance.currnameTo.text = currentCurrencyName;
            var texture2 = Resources.Load<Texture2D>("Textures/" + subId);
            starter.Instance.imgTo.GetComponent<RawImage>().texture = texture2;
            // string idcurr = currentId[0].ToString() + currentId[1].ToString();
            //StartCoroutine(DataSaver.Instance.GetTexture(idcurr));
        }
        CreatingCurrencies.Instance.Convert();


        HandleUI.Instance.CurrenciesPanel.GetComponent<CanvasGroup>().alpha = 0;
       // HandleUI.Instance.CurrenciesPanel.SetActive(false);
    }
}
