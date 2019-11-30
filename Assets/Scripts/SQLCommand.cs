using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SQLCommand : MonoBehaviour
{

    public InputField inpSQL;
    public Text txtResult;

    public void ExecuteCommand() {
        StartCoroutine("SendToPHP");
    }

    IEnumerator SendToPHP() {

        WWWForm form = new WWWForm();

        form.AddField("sqlStatement", inpSQL.text);
        UnityWebRequest www = UnityWebRequest.Post("http://dipolo.000webhostapp.com/dbScript.php", form);
        
        yield return www.SendWebRequest();
        
        if (www.isNetworkError || www.isHttpError) {
            txtResult.text = "Error : " + www.error;
        } else {
            txtResult.text = www.downloadHandler.text;
        }

    }

    void Start() {
        inpSQL.text = "SELECT 'Word_EN' From 'Word'";
    }

    void Update() {
    }

}
