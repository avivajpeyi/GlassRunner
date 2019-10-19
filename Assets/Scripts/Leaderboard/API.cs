using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class API : MonoBehaviour
{

    public Text getResponseText;

    private string privateCOD = "z49AkLsNOu3i5Y3D";
    private string publicCOD = "0y4vmgqcNmuZruxo";
    private string adminCOD = "y35iNYukAy8SPt3U";

    private string query = "uid={0}&val={1}&txt={2}";
    private  string postURL = "https://plassion.com/setrec.php?cod={0}&" ;
    private  string getURL = "https://plassion.com/getrec.php?cod={0}&qty=10";


    public InputField nameField;
    public InputField scoreField;
    public InputField uidField;
    
    public void Start()
    {
        postURL=string.Format(postURL, privateCOD) + query;
        getURL=string.Format(getURL, publicCOD);
    }

    public void GetRequest()
    {
        Debug.Log("GET start");
        WWW request = new WWW(getURL);
        StartCoroutine(GetResponse(request));
    }

    private IEnumerator GetResponse(WWW req)
    {
        yield return req;
        getResponseText.text = req.text;
        Debug.Log("GET complete");
    }


    public void PostRequest()
    {
        Debug.Log("POST start");

        Debug.Log(postURL);

        int score = 0;
        Int32.TryParse(scoreField.text.ToString(), out score);
        string name = nameField.text.ToString();
        int uid = 0;
        Int32.TryParse(uidField.text.ToString(), out uid);
        
        Debug.Log(score + name + uid);
            
        string currentQeury = string.Format(
            postURL,
            uid, name, score
        );
        
        WWW request = new WWW(currentQeury);
        StartCoroutine(PostResponse(request));
    }
    
    private IEnumerator PostResponse(WWW req)
    {
        yield return req;
        string postText = req.text;
        Debug.Log("POST complete: "+postText);
    }
    
}