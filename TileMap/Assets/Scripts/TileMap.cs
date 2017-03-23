using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public GameObject bloco;
    private List<GameObject> parede = new List<GameObject>();
    [SerializeField]
    private Vector3 offset;

    void Start()
    {
        Load("TileMap.txt");
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("olala");
        }
    }
    private bool Load(string fileName)
    {
        string line;
        StreamReader theReader = new StreamReader(fileName, Encoding.Default);

        using (theReader)
        {
            line = theReader.ReadLine();
            if (line != null)
            {
                string[] splitString = line.Split(new string[] { " " }, System.StringSplitOptions.None);
                Debug.Log(splitString[0]);
                Debug.Log(splitString[1]);
                int numeroColunas = int.Parse(splitString[0]);
                int numeroLinhas = int.Parse(splitString[1]);

                if (line != null)
                {
                    for (int linha = 0; linha < numeroLinhas; linha++)
                    {
                        line = theReader.ReadLine();
                        string[] blocos = line.Split(new string[] { " " }, System.StringSplitOptions.None);
                        for (int coluna = 0; coluna < numeroColunas; coluna++)
                        {                            
                            //parede.Add(Instantiate(bloco, new Vector3(coluna * bloco.GetComponent<Collider>().bounds.size.x, 0, linha * bloco.GetComponent<Collider>().bounds.size.z), Quaternion.identity));
                            //parede[coluna + linha].transform.position = new Vector3(coluna * parede[0].GetComponent<Collider>().bounds.size.x, 0, linha * parede[0].GetComponent<Collider>().bounds.size.z);
                            if (blocos[coluna] == "1")
                            {
                                parede.Add(Instantiate(bloco));
                                parede[coluna + linha * numeroColunas].SetActive(true);
                                Debug.Log(bloco.GetComponent<MeshCollider>().sharedMesh.bounds.size);
                                parede[coluna + linha*numeroColunas].transform.position = new Vector3(coluna * bloco.GetComponent<MeshCollider>().sharedMesh.bounds.size.x*2.0f, 0, linha * bloco.GetComponent<MeshCollider>().sharedMesh.bounds.size.z*2.0f);
                                //Instantiate(parede[coluna + linha], parede[coluna + linha].transform.position, Quaternion.identity);
                            }
                            else
                            {
                                parede.Add(null);
                            }
                        }
                    }
                }
            }
            theReader.Close();
            return true;
        }

    }
}
