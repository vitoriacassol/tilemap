using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public GameObject bloco;
    public List<GameObject> parede = new List<GameObject>();


    void Start()
    {
        Load("TileMap.txt");
        //bloco1.transform.position = new Vector3(0, 0, 0);
        //Instantiate(bloco1, new Vector3(2, 0, 0), Quaternion.identity);
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

                line = theReader.ReadLine();
                if (line != null)
                {
                    string[] bloco = line.Split(new string[] { " " }, System.StringSplitOptions.None);
                    for (int linha = 0; linha < numeroLinhas; linha++)
                    {
                        for (int coluna = 0; coluna < numeroColunas; coluna++)
                        {
                            parede.Add(new GameObject());
                            parede[coluna + linha].transform.position = new Vector3(coluna * parede[0].GetComponent<Collider>().bounds.size.x, 0, linha * parede[0].GetComponent<Collider>().bounds.size.z);
                            if (bloco[coluna + linha] == "1")
                            {
                                Instantiate(parede[coluna + linha], parede[coluna + linha].transform.position, Quaternion.identity);
                            }
                        }
                        line = theReader.ReadLine();
                    }
                }
            }
            theReader.Close();
            return true;
        }

    }
}
