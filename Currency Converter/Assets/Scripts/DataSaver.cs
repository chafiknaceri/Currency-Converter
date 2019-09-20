using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Linq;

public class DataSaver : MonoBehaviour
{

    public static DataSaver Instance { get; set; }

    public Dictionary<string, string> allresults = new Dictionary<string, string>();

    public string symbolsUrl;
    public JSONObject json2;
    public List<Texture> images = new List<Texture>();

    string urlImages;
    public List<string> currsInOrder = new List<string>();


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        symbolsUrl = "https://free.currconv.com/api/v7/currencies?apiKey=f5ae8cca8c72299b9084";
    }
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(DataSaver.Instance.GetTexture("dz"));
       

       
    }
    public void GetData()
    {
        //from = fromCurr.text;
        //to = toCurr.text;
        //url = "https://free.currconv.com/api/v7/convert?q=" + from + "_" + to + "&compact=ultra&apiKey=f5ae8cca8c72299b9084";
        symbolsUrl = "https://free.currconv.com/api/v7/currencies?apiKey=f5ae8cca8c72299b9084";
        //WWW www = new WWW(url);
        //StartCoroutine("GetdataEnum", www);
        WWW www2 = new WWW(symbolsUrl);

        // main function to get all the possible currencies from our API
        StartCoroutine("GetdataEnum2", www2);



        



    }

    IEnumerator GetdataEnum2(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            string servicedata = www.text;

            json2 = JSONObject.Parse(servicedata);

 

            var myMate = json2.GetValue("results").Array;
            print(json2.GetValue("results").Obj);


                // Looping through the result we get and creating a dictionary of strings
                // to store key pair values of id and currency name
               foreach (KeyValuePair<string, JSONValue> kiwe in json2.GetValue("results").Obj)
                {

                    allresults.Add(kiwe.Key, kiwe.Value.Obj.GetValue("currencyName").ToString());

                }
               
            }

        SceneManager.LoadScene("CurrencyConv");
        }


    public IEnumerator GetTexture(string id)
    {

        // using this to wait before loading screen in case the api did not get the data just yet
        GetData();
        yield return new WaitForSecondsRealtime(3f);
        currsInOrder = allresults.Keys.ToList();
        currsInOrder.Sort();



    
        //yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("CurrencyConv");
    }


}
