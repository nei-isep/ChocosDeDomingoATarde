using UnityEngine;
using System.Collections;

public class ProceduralNumberGenerator {

    static System.Random random = new System.Random();

	public static int currentPosition = 0;
	public const string key = "123424123342421432233144441212334432121223344";

	public static int GetNextNumber() {
        return random.Next(1,5);
	}
}
