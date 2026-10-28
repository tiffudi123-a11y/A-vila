using UnityEngine;

public class GameTimer : MonoBehaviour
{
	float timer = 0;
	int ultimoSegundo = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      	timer += Time.deltaTime;

        int segundos = (int)timer;

        if (segundos != ultimoSegundo)
        {
            ultimoSegundo = segundos;
            Debug.Log($"{segundos / 60:00}:{segundos % 60:00}");
        }
    }
}
