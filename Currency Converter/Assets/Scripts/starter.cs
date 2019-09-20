using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class starter : MonoBehaviour
{
    public static starter Instance { get; set; }

    // get the Panel UI that has all the currencies which is set to not visible
    // only when user clicks to change currency that the allcurrencies willl show up
    public GameObject allCurrencies;

    // storing the prefab for the currencies so that we can instantiate them under the all
    // currencies panel and setting some properties to the object
    public GameObject CurrPrefab;


    // this holds the image game object of the from and the to currency
    public GameObject imgfrom;
    public GameObject imgTo;


    public Text currIdfrom;
    public Text currnamefrom;

    public Text currIdTo;
    public Text currnameTo;

   public List<string> currsInOrder = new List<string>();
    // Start is called before the first frame update


    private void Awake()
    {
        Instance = this;

    }


    void Start()
    {


        // at start choosing what flag corrsponds to the flag
        var texture2 = Resources.Load<Texture2D>("Textures/" + currIdfrom.text[0] + currIdfrom.text[1]);
        imgfrom.GetComponent<RawImage>().texture = texture2;

        var texture3 = Resources.Load<Texture2D>("Textures/" + currIdTo.text[0] + currIdTo.text[1]);
        imgTo.GetComponent<RawImage>().texture = texture3;



        // we will sort the results from the api of the currencies in a sorted version of the keys
        // to make sure we get the currencies in Order
        currsInOrder = DataSaver.Instance.allresults.Keys.ToList();
        currsInOrder.Sort();
        for(int i = 0; i< currsInOrder.Count; i++)
        {
                GameObject obj = Instantiate(CurrPrefab,  Vector3.zero , Quaternion.identity);

                obj.transform.SetParent(allCurrencies.transform);
                obj.GetComponent<buttonClick>().idNum = i;
                obj.transform.GetChild(0).GetComponent<Text>().text = DataSaver.Instance.allresults[currsInOrder[i]]; 
                obj.transform.GetChild(1).GetComponentInChildren<Text>().text = currsInOrder[i];
                obj.GetComponent<buttonClick>().currentId = currsInOrder[i];
                obj.GetComponent<buttonClick>().currentCurrencyName = DataSaver.Instance.allresults[currsInOrder[i]];
        

        }

       

    }



}
