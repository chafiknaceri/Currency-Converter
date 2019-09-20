using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using System;
using UnityEngine.UI;

public class GettingCurr : MonoBehaviour

{
    public Text Result;
    public Text AmountWritten;
    public Text output;
    string url;
    string symbolsUrl;
    //CurrencyPrice curr;
    float amount = 10;
    string from = "USD";
    string to = "EUR";
    JSONObject json;
    JSONObject json2;
    public Dropdown drops;
    public Dropdown drops2;
    Dictionary<string, string> allresults = new Dictionary<string, string>();
    public Text fromCurr;
    public Text toCurr;
    int times = 0;
    bool clicked = false;
    int timeClicks = 0;

    List<string> symbols = new List<string>();
    //Boomlagoon.JSON.JSONArray symbolsMate;
    // Start is called before the first frame update
    void Start()
    {


        AmountWritten.text = 1.ToString();
        from = fromCurr.text;
        to = toCurr.text;
        url = "https://free.currconv.com/api/v7/convert?q="+from+"_"+to+"&compact=ultra&apiKey=f5ae8cca8c72299b9084";
        symbolsUrl = "https://free.currconv.com/api/v7/currencies?apiKey=f5ae8cca8c72299b9084";
        //curr = new CurrencyPrice();
        GetData();



    }


     public void  GetData()
    {
         from = fromCurr.text;
         to = toCurr.text;
        url = "https://free.currconv.com/api/v7/convert?q=" + from + "_" + to + "&compact=ultra&apiKey=f5ae8cca8c72299b9084";
        symbolsUrl = "https://free.currconv.com/api/v7/currencies?apiKey=f5ae8cca8c72299b9084";
        WWW www = new WWW(url);
        StartCoroutine("GetdataEnum", www);
        WWW www2 = new WWW(symbolsUrl);
        StartCoroutine("GetdataEnum2", www2);
        if(timeClicks >= 1)
        {
            clicked = true;
        }
        timeClicks += 1;

    }

    IEnumerator GetdataEnum(WWW www)
    {
        yield return www;
        if(www.error == null)
        {
            string servicedata = www.text;
           
            json = JSONObject.Parse(servicedata);

        }

    }
    IEnumerator GetdataEnum2(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            string servicedata = www.text;

            json2 = JSONObject.Parse(servicedata);

            //print(json2.GetValue("results").Obj.ContainsKey("EUR"));

            //KeyValuePair<string, JSONValue> myDict = myMate;
            //print(myMate.GetType());
            //json2.GetValue("results").Obj.GetObject("ALL");
            if(times == 0)
            {
                var myMate = json2.GetValue("results").Array;
                print(json2.GetValue("results").Obj);
                foreach (KeyValuePair<string, JSONValue> kiwe in json2.GetValue("results").Obj)
                {

                    //print(kiwe.Value.Obj.GetValue("currencyName"));
                    allresults.Add(kiwe.Key, kiwe.Value.Obj.GetValue("currencyName").ToString());

                    symbols.Add(kiwe.Key);


                }
                symbols.Sort();
                drops.ClearOptions();
                drops2.ClearOptions();
                drops.AddOptions(symbols);
                drops2.AddOptions(symbols);
                times++;
                print(allresults["DZD"]);
            }
        

        }

    }
    private void Update()
    {
        //GetData();
        if (clicked)
        {
            amount = float.Parse(AmountWritten.text);
            if (output.text == null)
            {
                output.text = "";
            }
            else
            {

                output.text = amount.ToString() + " " + fromCurr.text + "\n=\n" + (json.GetNumber(from + "_" + to) * amount).ToString("F4") + " " + toCurr.text;
            }
        }
        else
        {
            output.text = "";
        }



    }


    public void Convert()
    {
        //Result.text = (json.GetNumber(from + "_" + to) * amount).ToString();
    }
}
