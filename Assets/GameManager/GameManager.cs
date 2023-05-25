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
        if (instance != null)   // ���ӸŴ��� ��ũ��Ʈ(this)�� �ϳ��� �����ϰ� ��� ������Ŵ
        {
            Destroy(this);
            return;
        }

        // �� ��ȯ���¿����� ���ӿ�����Ʈ�� ������� �ʰ� ������ִ� ���
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
