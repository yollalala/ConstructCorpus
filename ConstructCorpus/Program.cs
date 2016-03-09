using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructCorpus
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirLocationDistinct = @"D:\data_all_terbaru\data_location_v2_cleaned_distinct_v2.txt";
            string dirCluster = @"D:\data_location_cluster.txt";

            string dirDocument = @"D:\data_all_terbaru\data_document_v2-5_cleaned.txt";
            string dirLocation = @"D:\data_all_terbaru\data_location_v2_cleaned.txt";
            string dirCorpus = @"D:\output_corpus\corpus_v1\";

            // get dictionary of location and its cluster number
            Dictionary<string, string> dLocationCluster = Constructor.getDictionaryLocationCluster(dirLocationDistinct, dirCluster);

            // construct region corpuses!
            Constructor.ConstructCorpus(dirDocument, dirLocation, dirCorpus, dLocationCluster);

            Console.WriteLine("Selesai!");
            Console.ReadLine();
        }
    }
}
