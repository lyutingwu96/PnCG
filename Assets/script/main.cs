using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;

public class main : MonoBehaviour
{
    UnityEngine.UI.Text GirlName;
    UnityEngine.UI.Text GirlLevel;

    // Use this for initialization
    void Start()
    {
        GirlName = GameObject.Find("GirlName").transform.Find("Text").GetComponent<UnityEngine.UI.Text>();
        GirlLevel = GameObject.Find("GirlLevel").transform.Find("Text").GetComponent<UnityEngine.UI.Text>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddJson()
    {
        //如果資料有誤的話跑提示
        if (GirlName.text == "" || GirlLevel.text == "")
        {
            UnityEditor.EditorUtility.DisplayDialog("System", "確認是否資料有異常??", "Ok");
            return;
        }
        //讀取檔案myJson.json內的資料，命名為 myPlayer
        playerState myPlayer = LoadJson();

        //新增資料至 myPlayer
        myPlayer.GirlName.Add(GirlName.text);
        myPlayer.GirlLevel.Add(int.Parse(GirlLevel.text));

        //將myPlayer轉換成json格式的字串
        string saveString = JsonUtility.ToJson(myPlayer);

        //將字串saveString存到硬碟中
        StreamWriter file = new StreamWriter(Application.dataPath + "/Resources/myJson.json");
        file.Write(saveString);
        file.Close();

        //提示玩家以新增資料
        UnityEditor.EditorUtility.DisplayDialog("System", "已新增資料", "Ok");


    }

    public void searchGirlLevel()
    {
        string searchName = GameObject.Find("searchName").transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text;
        //讀取檔案myJson.json內的資料，命名為 myPlayer
        playerState myPlayer = LoadJson();
        for (var i = 0; i < myPlayer.GirlName.Count; i++)
        {
            if (myPlayer.GirlName[i] == searchName)
            {
                UnityEditor.EditorUtility.DisplayDialog("System", searchName + " 's Level Is " + myPlayer.GirlLevel[i], "Ok");
            }
        }
    }


    private playerState LoadJson()
    {
        //讀取json檔案並轉存成文字格式
        StreamReader file = new StreamReader(Application.dataPath + "/Resources/myJson.json");
        string loadJson = file.ReadToEnd();
        file.Close();

        //新增一個物件類型為playerState的變數 loadData
        playerState loadData = new playerState();

        //使用JsonUtillty的FromJson方法將存文字轉成Json
        loadData = JsonUtility.FromJson<playerState>(loadJson);

        return loadData;
    }
    public class playerState
    {
        public List<string> GirlName = new List<string>();
        public List<int> GirlLevel = new List<int>();
        public playerState() { }

        public playerState(string name, int level)
        {
            GirlName.Add(name);
            GirlLevel.Add(level);
        }
    }
}
#endif