using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public class GameManager : MonoBehaviour
{
    public const string DefaultName = "Manager";
    private static GameManager instance;
    private static DataManager dataManager;

    public static GameManager Instance { get { return instance; } }
    public static DataManager Data {  get { return dataManager; } }

    private void Awake()
    {
        if (instance != null)   // 게임매니저 스크립트(this)를 하나만 제외하고 모두 삭제시킴
        {
            Destroy(this);
            return;
        }

        // 씬 전환상태에서도 게임오브젝트가 사라지지 않게 많들어주는 방식
        DontDestroyOnLoad(this);

        instance = this;
        InitManagers();
    }

    private void OnDestroy()
    {
        if(instance == this)
            instance = null;
    }


    private void InitManagers()
    {
        // DataManager Init
        GameObject dataObj = new GameObject() { name = "DataManager" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<DataManager>();
    }
}
