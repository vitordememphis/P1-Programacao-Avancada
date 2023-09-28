using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    public Coin[] coinTypes;

    public MeshRenderer coinMeshRenderer;


    int value;
    int timeLimit;

    float time = 0;


    // Start is called before the first frame update
    void Awake()
    {
        SelectType();
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > timeLimit)
        {
            DestroyCoin();
        }

        if(GameManager.instance.timer <= 0)
        {
            DestroyCoin();
        }
    }


    void SelectType()
    {
        int coinType = Random.Range(0, 2);

        coinMeshRenderer.material = coinTypes[coinType].coinMaterial;
        value = coinTypes[coinType].coinValue;
        timeLimit = coinTypes[coinType].coinTime;
    }


    void DestroyCoin()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube" || other.tag == "Sphere" || other.tag == "Capsule") 
        {
            GameManager.instance.score = GameManager.instance.score + value;
            DestroyCoin();
        }
    }
}
