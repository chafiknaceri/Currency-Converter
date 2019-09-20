using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using Unity.Collections;
using System.Collections.Generic;

public class stringsdata : MonoBehaviour
{
    //074fa593f94f2648eadf29503fa61dd3
    private const string url = "https://free.currconv.com/api/v7/convert?q=EUR_PHP&compact=ultra&apiKey=f5ae8cca8c72299b9084";
    public Text message;
    string[] strings;
    float amount = 10f;
    Dictionary<string, string> dict = new Dictionary<string, string>();


    public void Request()
    {
        WWW request = new WWW(url);
        StartCoroutine(OnResponse(request));


    }
    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
        message.text= req.text;
        strings = req.text.Split(':');

        dict.Add(strings[0], strings[1]);

    }
    private void Update()
    {
       // float answer = float.Parse(dict[strings[0]],System.Globalization.NumberStyles.Float) * amount;


        print(dict[strings[0]]);
        //print(answer);
    }


}


