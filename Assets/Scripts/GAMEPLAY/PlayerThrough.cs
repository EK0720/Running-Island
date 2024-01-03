using UnityEngine;

public class PlayerThrough : MonoBehaviour
{
    private bool isCrossing = false;

    void Update()
    {
        // Kiểm tra nếu người chơi đang đi xuyên
        if (isCrossing)
        {
            // Logic để cho phép người chơi đi qua các vật thể
            Collider[] obstacles = Physics.OverlapBox(transform.position, transform.localScale / 2f);
            foreach (Collider obstacle in obstacles)
            {
                if (obstacle.CompareTag("OBS"))
                {
                    // Tắt collider của vật thể
                    obstacle.enabled = false;
                }
            }
        }
        else
        {
            // Logic để ngăn chặn người chơi đi qua các vật thể
            Collider[] obstacles = Physics.OverlapBox(transform.position, transform.localScale / 2f);
            foreach (Collider obstacle in obstacles)
            {
                if (obstacle.CompareTag("OBS"))
                {
                    // Bật collider của vật thể
                    obstacle.enabled = true;
                }
            }
        }
    }

    // Gọi từ script của button khi người chơi nhấp vào để bắt đầu đi xuyên
    public void StartCrossing(float crossTime)
    {
        StartCoroutine(CrossingTimer(crossTime)); // Đi xuyên trong thời gian crossTime
    }

    // Gọi từ script của item khi kết thúc đi xuyên
    public void EndCrossing()
    {
        isCrossing = false;
    }

    private System.Collections.IEnumerator CrossingTimer(float crossTime)
    {
        isCrossing = true;
        yield return new WaitForSeconds(crossTime);
        EndCrossing();
    }
}