using WheatGrainClassifier.models;

namespace WheatGrainClassifier.services
{
    public class Sorter
    {

        public static void InsertionSort(List<Neighbor> neighbors)
        {
            for (int i = 1; i < neighbors.Count; i++)
            {
                var key = neighbors[i];
                int j = i - 1;
                while (j >= 0 && neighbors[j].Distance > key.Distance)
                    neighbors[j + 1] = neighbors[j--];
                neighbors[j + 1] = key;
            }

        }
    }
}
