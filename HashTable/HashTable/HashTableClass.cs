using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class HashTableClass
    {
        #region 私有域

        //array of reference to inplement the hash table
        private string[] HTable;

        //array indicating the status of a position in the hash table
        private int[] indexStatusList;

        //number of items in the hash table
        private int length;

        //maximum size of the hash table
        private int HTSize;

        #endregion

        #region 公共属性

        public int Length
        {
            get { return length; }
        }

        public int MaxHTSize
        {
            get { return HTSize; }
        }

        #endregion

        #region 构造方法

        public HashTableClass()
        {
            HTable = new string[101];
            indexStatusList = new int[101];

            length = 0;
            HTSize = 101;
        }

        public HashTableClass(int size)
        {
            if (!isPrimeNumber(size))
                return;

            HTable = new string[size];
            indexStatusList = new int[size];

            length = 0;
            HTSize = size;
        }

        #endregion

        #region 私有方法

        private bool isPrimeNumber(int Integer)
        {
            if (Integer < 0)
                throw new Exception("The Integer must be more than 0");

            if (0 <= Integer && Integer <= 3)
                return true;

            if (Integer > 3 && Integer % 2 > 0 && Integer % 3 > 0)
                return true;

            return false;
        }

        private int hashMethod(string insertKey)
        {
            int sum = 0;

            for (int j = 0; j < insertKey.Length; j++)
                sum = sum + (int)(insertKey[j]);

            return (sum % HTSize);
        }//end hashMethod

        private int GetIndex(int hashIndex, string rec)
        {
            int pCount;
            int inc;

            pCount = 0;
            inc = 1;

            while (indexStatusList[hashIndex] == 1
                && !HTable[hashIndex].Equals(rec)
                && pCount < HTSize / 2)
            {
                pCount++;
                hashIndex = (hashIndex + inc) % HTSize;
                inc = inc + 2;
            }

            return hashIndex;
        }

        #endregion

        #region 公共方法

        public bool search(string rec)
        {
            int hashIndex = hashMethod(rec);

            hashIndex = GetIndex(hashIndex,rec);

            return ((indexStatusList[hashIndex] == 1
                        && HTable[hashIndex].Equals(rec)));
        }//end search

        public void insert(string rec)
        {
            int hashIndex = hashMethod(rec);

            hashIndex = GetIndex(hashIndex,rec);

            if (indexStatusList[hashIndex] != 1)
            {
                HTable[hashIndex] = rec;
                indexStatusList[hashIndex] = 1;
                length++;
            }
            else
            {
                if (HTable[hashIndex].Equals(rec))
                    throw new Exception("Error:No duplicates are allowed.");
                else
                    throw new Exception("Error:The Table is full.Unable to resolve the collision.");
            }
        }//end insert

        public void remove(string rec)
        {
            int hashIndex = hashMethod(rec);

            hashIndex = GetIndex(hashIndex,rec);

            if (indexStatusList[hashIndex] == 1 &&
               HTable[hashIndex].Equals(rec))
            {
                indexStatusList[hashIndex] = 0;
                HTable[hashIndex] = null;
                length--;
            }
            else
                throw new Exception("Cannot remove the rec");
        }

        public bool isItemAtEqual(string rec)
        {
            int hashIndex = hashMethod(rec);

            return (indexStatusList[hashIndex] == 1 &&
                       HTable[hashIndex].Equals(rec));
        }

        public string retrieve(int hashIndex)
        {
            return HTable[hashIndex];
        }

        public void print()
        {
            for (int i = 0; i < indexStatusList.Length; i++)
            {
                if (indexStatusList[i] == 1)
                    Console.WriteLine(HTable[i]);
            }
        }

        #endregion
    }   
}
