using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;



public class Connect : MonoBehaviour {

    void Start()
    {
        print("Started sphere import...\n");

        StartCoroutine(DownloadSpheres());
    }

    void ExtractSpheres(string json)
    {
        
       JSONObject jo = new JSONObject(json);
       foreach (JSONObject item in jo.list)
       {
           print("Wartosc : " + item);
       }


    }
    IEnumerator DownloadSpheres()
    {
        // Pull down the JSON from our web-service

        WWWForm form = new WWWForm();
        form.AddField("code", "11111");
        form.AddField("type", "1");
        form.AddField("uid", "2");

		WWW w = new WWW("http://superbakusie.pl/connect/update_product.php", form);


        yield return w;

        print("Waiting for sphere definitions\n");

        // Add a wait to make sure we have the definitions

        yield return new WaitForSeconds(1f);

        print("Received sphere definitions\n");

        // Extract the spheres from our JSON results

       ExtractSpheres(w.text);
       print(w.text);
    }
}
