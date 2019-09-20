using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandleUI : MonoBehaviour
{
    public static HandleUI Instance { get; set; }
    public GameObject CurrenciesPanel;
    public GameObject fromlogo;
    public GameObject tologo;

    public Text date;
    public int currButton = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
  

    }

    public void openCurrencies()
    {
       // button that opens the currencies panel and i have two of these 
       // functions to know  if it is a from currency or a To Currency 


        // if currbutton is  1 on the button script we will update the currency of the From
        currButton = 1;

        // at start the all currencies panel is transparent that is why when this button is clicked
        // we set it to opaque
        CurrenciesPanel.GetComponent<CanvasGroup>().alpha = 1;
    }
    public void openCurrencieto()
    {
        //if currbutton is 1 on the button script we will update the currency of the To
        currButton = 2;
        CurrenciesPanel.GetComponent<CanvasGroup>().alpha = 1;
    }
    private void Update()
    {
        date.text = "Rates of " + System.DateTime.Now.ToLongDateString();
 
        if(DataSaver.Instance.allresults.Keys.Count == 0)
        {
            CurrenciesPanel.GetComponent<CanvasGroup>().alpha = 0;
        }

        if (DataSaver.Instance.images.Count >= 1)
        {
            //fromlogo.gameObject.GetComponent<RawImage>().texture = DataSaver.Instance.images[0];
            //tologo.gameObject.GetComponent<RawImage>().texture = DataSaver.Instance.images[1];
        }

        if (CurrenciesPanel.GetComponent<CanvasGroup>().alpha == 0)
        {
            CurrenciesPanel.GetComponent<CanvasGroup>().interactable = false;
            CurrenciesPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else
        {
            CurrenciesPanel.GetComponent<CanvasGroup>().interactable = true;
            CurrenciesPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
