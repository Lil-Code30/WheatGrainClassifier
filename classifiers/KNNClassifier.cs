using WheatGrainClassifier.models;
using WheatGrainClassifier.services;

namespace WheatGrainClassifier.classifiers
{
    public class KNNClassifier
    {
        private int k;
        private IDistanceMetric distanceMetric;
        private List<WheatGrain> trainingWheatGrains;


        public KNNClassifier(int k, IDistanceMetric metric, List<WheatGrain> trainingWheatGrains)
        {
            this.k = k;
            this.trainingWheatGrains = trainingWheatGrains;
            distanceMetric = metric;

        }

        public string predict(WheatGrain sample)
        {
            List<Neighbor> KNearestNeighbors = findKNearestNeighbors(sample);

            var votes = new Dictionary<GrainType, int>();

            foreach (Neighbor voisin in KNearestNeighbors)
            {
                GrainType classe = voisin.WheatGrain.Variety;

                if (votes.ContainsKey(classe))
                    votes[classe]++;
                else
                    votes[classe] = 1;
            }


            GrainType prediction = votes.OrderByDescending(x => x.Value).First().Key;

            return prediction.ToString();
        }

        private List<Neighbor> findKNearestNeighbors(WheatGrain sample)
        {
            List<Neighbor> allNeighbors = new List<Neighbor>();

            foreach (WheatGrain trainGrain in trainingWheatGrains)
            {
                double d = distanceMetric.Calculate(sample, trainGrain);
                allNeighbors.Add(new Neighbor { WheatGrain = trainGrain, Distance = d });
            }
            
            // allNeighbors = allNeighbors.OrderBy(x => x.Distance).ToList();
            Sorter.QuickSort(allNeighbors);

            foreach (Neighbor neighbor in allNeighbors)
            {
                Console.WriteLine($"{neighbor.WheatGrain.Variety}: {neighbor.Distance}");
            }

            return allNeighbors.Take(k).ToList();
        }
    }
}
