using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility  {

	public static T[] ShuffleArray<T> (T[] array, int seed) {
		System.Random prng = new System.Random(seed);

		for (int i = 0; i < array.Length - 1; i++) {
			int randomIndex = prng.Next(i, array.Length);
			T tempItem = array[randomIndex];
			array[randomIndex] = array[i];
			array[i] = tempItem;
		}

		return array;
	}

	public static List<T> ShuffleList<T> (List<T> list, int seed) {
		System.Random prng = new System.Random(seed);

		for (int i = 0; i < list.Count - 1; i++) {
			int randomIndex = prng.Next(i, list.Count);
			T tempItem = list[randomIndex];
			list[randomIndex] = list[i];
			list[i] = tempItem;
		}

		return list;
	}

	public static List<T> ShuffleList<T> (List<T> list) {
		System.Random prng = new System.Random();

		for (int i = 0; i < list.Count - 1; i++) {
			int randomIndex = prng.Next(i, list.Count);
			T tempItem = list[randomIndex];
			list[randomIndex] = list[i];
			list[i] = tempItem;
		}

		return list;
	}

		
	public static float Choose(float[] probs) {
		float total = 0;
		foreach (float elem in probs) {
			total += elem;
		}

		float randomPoint = Random.value * total;
		
		for (int i = 0; i < probs.Length; i++) {
			if (randomPoint < probs[i]) {
				return i;
			} else {
				randomPoint -= probs[i];
			}
		}
		return probs.Length - 1;
	}
}
