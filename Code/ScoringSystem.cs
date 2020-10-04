using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{

    public GameObject scoreText;
    public GameObject speedText;
    public GameObject propulsionText;
    public GameObject propulsionDesc;
    public static int theScore;
 //   public static float theSpeed;
    public static float simSpeed;
    public static int propStage = 0;



    void Update()
    {

        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
        speedText.GetComponent<Text>().text = "Speed: " + (Pilot.speed * 100) + " m/s";

        simSpeed = Pilot.speed * 100;

        if (simSpeed < 2000)
        {
            propulsionText.GetComponent<Text>().text = "Propulsion: STANDARD";
            propulsionDesc.GetComponent<Text>().text = "Hmm... we do not seem to be going fast enough. Maybe we" +
                                                       " can collect some of the orbs to upgrade the tech on our robot.";
        }
        else if (simSpeed > 2000 && simSpeed <= 3000)
        {
            propStage = 1;
            propulsionText.GetComponent<Text>().text = "Propulsion: CHEMICAL ROCKET";
            propulsionDesc.GetComponent<Text>().text = "Chemical rockets are powered by exothermic reduction-oxidation " + 
                                                       "reactions of the propellant. Maximum speed of this rocket can reach 4,900 m/s";
        }
        else if (simSpeed > 3000)
        {
            propStage = 2;
            propulsionText.GetComponent<Text>().text = "Propulsion: ELECTROTHERMAL ROCKET";
            propulsionDesc.GetComponent<Text>().text = "Electrothermal rockets heat the propellant and utilise thermal dynamics" +
                                                       " to propel itself. There are different electrothermal thruster designs, including" +
                                                       " Resistojet and Arcjet Thrusters.";
        }
    }

}
