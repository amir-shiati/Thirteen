using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class HintManager : MonoBehaviour {
    public GameObject Hint;
    public List<GameObject> Answres;
    private List<GameObject> HintsGenerated = new List<GameObject>();
    private int Counter = 0;
    public void GiveHint()
    {
        if (SceneManager1.scenM.HintLeft > 0 && Counter < Answres.Count)
        {
            GameObject hint = Instantiate(Hint);
            hint.transform.SetParent(Answres[Counter].transform.GetChild(0).transform);
            for (int i = 0; i < HintsGenerated.Count; i++)
            {
                if (hint.transform.parent == HintsGenerated[i].transform.parent)
                {
                   Destroy(HintsGenerated[i].gameObject);
                    HintsGenerated.RemoveAt(i);
                    break;
                }
            }
            hint.transform.localPosition = new Vector2(-1.082f, 0.77f);
            Counter++;
            hint.transform.GetChild(0).GetComponent<TextMesh>().text = Counter.ToString();
            SceneManager1.scenM.HintLeft -= 1;
            SaveGame.Save<int>("Hint", SceneManager1.scenM.HintLeft);
            HintsGenerated.Add(hint);
            updatehinttext();
        }
    }
    void updatehinttext()
    {
        transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = SceneManager1.scenM.HintLeft.ToString();
    }
}
