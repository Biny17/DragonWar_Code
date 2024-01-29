using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts {
    public static class Extensions {
        public static List<T> sample<T>(this List<T> list, int n = 1) {
            List<T> result = new List<T>();
            for (int i = 0; i < n; i++) {
                result.Add(list[Random.Range(0, list.Count)]);
            }
            return result;
            }
        public static T pickOne<T>(this List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                throw new System.InvalidOperationException("Cannot sample from an empty list.");
            }
            return list[Random.Range(0, list.Count)];
        }

        public static List<T> choice<T>(this List<T> list, int n) {
            if (list.Count == 0 || n <= 0) {
                return new List<T>();
            }

            List<T> shuffledList = new List<T>(list);
            int listCount = shuffledList.Count;

            for (int i = 0; i < listCount; i++) {
                int j = Random.Range(i, listCount);
                T temp = shuffledList[i];
                shuffledList[i] = shuffledList[j];
                shuffledList[j] = temp;
            }

            if (n > listCount) {
                return shuffledList;
            }

            return shuffledList.GetRange(0, n);
        }

        public static List<T> shuffle<T>(this List<T> list) {
            if (list.Count == 0) {
                return new List<T>();
            }

            List<T> shuffledList = new List<T>(list);
            int listCount = shuffledList.Count;

            for (int i = 0; i < listCount; i++) {
                int j = Random.Range(i, listCount);
                T temp = shuffledList[i];
                shuffledList[i] = shuffledList[j];
                shuffledList[j] = temp;
            }
            return shuffledList;
        }
    }
}