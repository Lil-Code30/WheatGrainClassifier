using WheatGrainClassifier.models;

namespace WheatGrainClassifier.services
{
    public class Sorter
    {
        public static void QuickSort(List<Neighbor> neighbors)
        {
            if (neighbors.Count == 0)
            {
                return;
            }
            
            QuickSort(neighbors, 0, neighbors.Count - 1);
        }

        private static void QuickSort(List<Neighbor> neighbors, int left, int right)
        {
            if(left < right)
            {
                int partitionIndex = Partition(neighbors, left, right);
                QuickSort(neighbors, left, partitionIndex - 1);
                QuickSort(neighbors, partitionIndex + 1, right);
            }
        }

        private static int Partition(List<Neighbor> neighbors, int left, int right)
        {
            Neighbor pivot = neighbors[right];
            int lowestIndex = left;
            Neighbor temp;

            for(int index = left; index <= right - 1; index++)
            {
                if (neighbors[index].Distance <= pivot.Distance)
                {
                    temp = neighbors[lowestIndex];
                    neighbors[lowestIndex] = neighbors[index];
                    neighbors[index]= temp;

                    lowestIndex++;
                }
            }

            temp = neighbors[lowestIndex];
            neighbors[lowestIndex]= neighbors[right];
            neighbors[right] = temp;

            return lowestIndex;
        } 
    }
}
