using UnityEngine.InputSystem;
using UnityEngine;



public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerOnePrefab; 

 public void SpawnPlayerOne()
 {
    PlayerInput.Instantiate(prefab: playerOnePrefab, playerIndex: 0 , controlScheme: "Player1", pairWithDevice: Keyboard.current, splitScreenIndex: 0);
 }


    void Start()
    {
        SpawnPlayerOne();
    }

    // Update is called once per frame

}