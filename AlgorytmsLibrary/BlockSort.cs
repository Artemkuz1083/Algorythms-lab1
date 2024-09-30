using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmsLibrary
{
    public class BlockSort : IResercheable
    {
        public BlockSort(int size, string name) : base(size, name)
        {
        }

        public override void Run(int[] array, int value)
        {
            List<int> result = BlockSortMethod(array.ToList(), 5);
        }

        private List<int> BlockSortMethod(List<int> arr, int blockSize)
        {
            List<List<int>> blocks = new List<List<int>>();
            // Divide the input array into blocks of size blockSize
            for (int i = 0; i < arr.Count; i += blockSize)
            {
                List<int> block = new List<int>();

                for (int j = i; j < i + blockSize && j < arr.Count; j++)
                {
                    block.Add(arr[j]);
                }

                // Sort each block and append it to the list of sorted blocks
                block.Sort();
                blocks.Add(block);
            }

            // Merge the sorted blocks into a single sorted list
            List<int> result = new List<int>();
            while (blocks.Any())
            {
                // Find the smallest element in the first block of each sorted block
                int minIdx = 0;
                for (int i = 1; i < blocks.Count; i++)
                {
                    if (blocks[i][0] < blocks[minIdx][0])
                    {
                        minIdx = i;
                    }
                }

                // Remove the smallest element and append it to the result list
                result.Add(blocks[minIdx][0]);
                blocks[minIdx].RemoveAt(0);

                // If the block is now empty, remove it from the list of sorted blocks
                if (!blocks[minIdx].Any())
                {
                    blocks.RemoveAt(minIdx);
                }
            }

            return result;
        }
    }
}
