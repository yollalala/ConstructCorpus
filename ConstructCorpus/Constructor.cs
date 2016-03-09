using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructCorpus
{
    class Constructor
    {
        public static void ConstructCorpus(string dirDocument, string dirLocation, string dirCorpus, Dictionary<string, string> dLocationcluster)
        {
            // read all lines for documents, location, cluster
            string[] documents = DataController.readFileToArray(dirDocument);
            string[] locations = DataController.readFileToArray(dirLocation);
            for (int i = 0; i < documents.Length; i++)
            {
                string cluster = dLocationcluster[locations[i].ToLower()];

                // add document to where its belong
                DataController.addToFile(dirCorpus + "data_document_cluster_" + cluster + ".txt", documents[i]);

                // add location based document cluster
                DataController.addToFile(dirCorpus + "data_location_cluster_" + cluster + ".txt", locations[i].ToLower());

                // add line number in all document file
                DataController.addToFile(dirCorpus + "data_line_number_cluster_" + cluster + ".txt", (i+1).ToString());

            }
        }

        // get list pair of location and cluster
        public static Dictionary<string, string> getDictionaryLocationCluster(string dirLocationDistinct, string dirCluster)
        {
            Dictionary<string, string> dLocationCluster = new Dictionary<string, string>();
            string[] location = DataController.readFileToArray(dirLocationDistinct);
            string[] cluster = DataController.readFileToArray(dirCluster);

            // save location and cluster pair in dictionary
            for (int i = 0; i < location.Length; i++)
            {
                dLocationCluster.Add(location[i], cluster[i]);
            }

            return dLocationCluster;
        }
    }
}
