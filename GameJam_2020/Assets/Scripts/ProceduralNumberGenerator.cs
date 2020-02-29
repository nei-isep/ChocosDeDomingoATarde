using UnityEngine;
using System.Collections;

public class ProceduralNumberGenerator {

    static System.Random random = new System.Random();

	public static int GetNextNumber() {
        return random.Next(1,5);
	}
}
