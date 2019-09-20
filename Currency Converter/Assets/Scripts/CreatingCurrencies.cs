using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using UnityEngine.UI;

public class CreatingCurrencies : MonoBehaviour
{
    public static CreatingCurrencies Instance { get; set; }


    string from; // string value of the current currency for the from field
    float amount;
    public Text AmountWritten; // we get the input from the user and save it
    public Text output;
    public Text error;
    string to;// string value of the current currency for the to field
    JSONObject json;
    string url;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GetData();
    }

    // Update is called once per frame
    void Update()
    {
        from = starter.Instance.currIdfrom.text;
        to = starter.Instance.currIdTo.text;
        url = "https://free.currconv.com/api/v7/convert?q=" + from + "_" + to + "&compact=ultra&apiKey=f5ae8cca8c72299b9084";

        if (json != null)
        {
          //error.gameObject.SetActive(false);
            amount = float.Parse(AmountWritten.text);
            if (from + "_" + to == null)
            {
                output.text = "";
            }
            else
            {

                output.text = (json.GetNumber(from + "_" + to) * amount).ToString("F4");
            }
        }
        else
        {
            output.text = "Api Not Responding";
            //error.gameObject.SetActive(true);
        }
    }


    public void GetData()
    {

        // we will get what the user wants to convert and to what they want to convert it to
        // we need a coroutine to make sure we wait for resuklts
        from = starter.Instance.currIdfrom.text;
        to = starter.Instance.currIdTo.text;

        url = "https://free.currconv.com/api/v7/convert?q=" + from + "_" + to + "&compact=ultra&apiKey=f5ae8cca8c72299b9084";
       
        WWW www = new WWW(url);
        StartCoroutine("GetdataEnum", www);

    }
    IEnumerator GetdataEnum(WWW www)
    {
        // this coroutines makes sure we get a result back from the api
        yield return www;
        if (www.error == null)
        {
            string servicedata = www.text;

            json = JSONObject.Parse(servicedata);

        }

    }

    public void Convert()
    {

        GetData();
    }
    public void switchCurrs()
    {

        // this function is made for the switch button to switch places of the 
        // currencies from and to 

        // saving temp variables to switch the vales of the currency id and currency name
        string temp = starter.Instance.currIdfrom.text;
        string temp2 = starter.Instance.currIdTo.text;

        starter.Instance.currIdfrom.text = temp2;
        starter.Instance.currIdTo.text = temp;



        // changing currency name and switching them by calling the dictionary of all the dictionary
        // data we got from the Api
        starter.Instance.currnamefrom.text = DataSaver.Instance.allresults[temp2];
        starter.Instance.currnameTo.text = DataSaver.Instance.allresults[temp];


        // getting the cporrect flag texture from our project foldure
        var texture2 = Resources.Load<Texture2D>("Textures/" + starter.Instance.currIdfrom.text[0] + starter.Instance.currIdfrom.text[1]);
        starter.Instance.imgfrom.GetComponent<RawImage>().texture = texture2;

        var texture3 = Resources.Load<Texture2D>("Textures/" + starter.Instance.currIdTo.text[0] + starter.Instance.currIdTo.text[1]);
        starter.Instance.imgTo.GetComponent<RawImage>().texture = texture3;
        GetData();

    }

}
