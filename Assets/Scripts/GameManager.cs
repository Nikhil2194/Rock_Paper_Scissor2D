using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
   

    [SerializeField] GameObject ChooseObject, GamePlayGameObject, StartGameAnimObject, spawnPointGameObjects, RetryButton;              //UI GameObjects
    [SerializeField] GameObject paperPrefab, scissorPrefab, rockPrefab;               //GamePlay GameObjects
    [SerializeField] GameObject[] handSprites;
    [SerializeField] Transform botSpawnPoint, playerSpawnPoint;
    [SerializeField] TMP_Text resultText;
    public List<GameObject> selectedGameObjectsList = new List<GameObject>();



    public void ComputeSelection()
    {
        int randIndex = Random.Range(0, handSprites.Length);
        GameObject temppObje =  Instantiate(handSprites[randIndex], botSpawnPoint.position, Quaternion.Euler(0,0,90));
        selectedGameObjectsList.Add(temppObje);
        temppObje.transform.SetParent(botSpawnPoint);
    }





    public void ScissorButton()
    {
        GameObject tempObj =  Instantiate(handSprites[0], playerSpawnPoint.position, Quaternion.Euler(0,0,-90));
        selectedGameObjectsList.Add(tempObj);
        tempObj.transform.SetParent(playerSpawnPoint);
        ComputeSelection();
        StartCoroutine(ShowFinalObjects());
    }

    public void PaperButton()
    {
        GameObject tempObj = Instantiate(handSprites[1], playerSpawnPoint.position, Quaternion.Euler(0, 0, -90));
        tempObj.transform.SetParent(playerSpawnPoint);
        selectedGameObjectsList.Add(tempObj);
        ComputeSelection();
        StartCoroutine(ShowFinalObjects());

    }

    public void RockButton()
    {
        GameObject tempObj = Instantiate(handSprites[2], playerSpawnPoint.position, Quaternion.Euler(0, 0, -90));
        tempObj.transform.SetParent(playerSpawnPoint);
        selectedGameObjectsList.Add(tempObj);
        ComputeSelection();
        StartCoroutine(ShowFinalObjects());

    }


    IEnumerator ShowFinalObjects()
    {
        StartGameAnimObject.SetActive(true);
        ChooseObject.SetActive(false);
        yield return new WaitForSeconds(1);
        FindMatches();
        StartGameAnimObject.SetActive(false);
        spawnPointGameObjects.SetActive(true);
        GamePlayGameObject.SetActive(true);
        RetryButton.SetActive(true);

    }


    public void FindMatches()                           // Function to check which is won
    {
 
        GameObject playerSelection = selectedGameObjectsList[0];
        GameObject computerSelection = selectedGameObjectsList[1];

        string playerTag = playerSelection.tag;
        string computerTag = computerSelection.tag;

        Debug.Log("Player Tag = " + playerTag + "   Computer Tag = " + computerTag);

        if (playerTag == computerTag)
            resultText.text = "Its a draw";

        else if ((playerTag == "Paper" && computerTag == "Rock") || (playerTag == "Rock" && computerTag == "Scissors") || (playerTag == "Scissors" && computerTag == "Paper"))
        {
            resultText.text = "Player Wins";
        }

        
        else
        {
            resultText.text = "Computer Wins";    
        }
           
    } 

    public void RetryButtonFunc()
    {
        ChooseObject.SetActive(true);
        spawnPointGameObjects.SetActive(false);
        GamePlayGameObject.SetActive(false);
        ClearAndDestroyGameObjects();
    }


    public void ClearAndDestroyGameObjects()
    {
        // Iterate over the list of game objects
        foreach (GameObject obj in selectedGameObjectsList)
        {
            // Destroy each game object
            Destroy(obj);
        }

        // Clear the list
        selectedGameObjectsList.Clear();
    }
}
