using UnityEngine;
using UnityEngine.UI;
public class SkillDisplay : MonoBehaviour
{
    public int frameCount;
    public Transform skillTemplate;
    public Transform skillSlots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DrawFrames();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DrawFrames()
    {
        float imageWidth = skillTemplate.GetComponent<RectTransform>().rect.width;
        float startX = 0;
        Vector3 spawnPosition = new Vector3 (0, 0, 0);
        if (frameCount % 2 == 0)
        {
            startX = imageWidth * ((frameCount / 2) - 1) + (imageWidth / 2);
            startX *= -1;
            for (int i = 0; i < frameCount; i++)
            {
                spawnPosition = new Vector3 ((startX + imageWidth * i), 0f, 0f);
                var thisSlot = Instantiate(skillTemplate, spawnPosition, Quaternion.identity, skillSlots);
                thisSlot.localPosition = spawnPosition;
            }
            //offset by -0.5x image width and draw frameCount amounts of images starting from -.5 incrementing by width each time
        }
        else
        {
            startX = imageWidth * ((frameCount / 2));
            startX *= -1;
            for (int i = 0; i < frameCount; i++)
            {
                spawnPosition = new Vector3((startX + imageWidth * i), 0f, 0f);
                var thisSlot = Instantiate(skillTemplate, spawnPosition, Quaternion.identity, skillSlots);
                thisSlot.localPosition = spawnPosition;
            }
            //frameCount/2 and iterate over frameCount incrementing position by width
        }

    }
    void ChangeIcon()
    {

    }
    void RollCooldown()
    {
        //access the skill holder
        //get said skill's cooldown value (probably through scriptable objects
        //get turn said skill's cooldown timer and actual timer and convert it into percentage
        //turn it into a fill amount or sth
    }
}
