using System;
using System.Collections.Generic;
using System.IO;
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

        private static Dictionary<string, string> getLocationLabel(string directory)
        {
            Dictionary<string, string> dLocationLabel = new Dictionary<string, string>();

            string line = "";
            System.IO.StreamReader file = new System.IO.StreamReader(directory);
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split('\t');
                dLocationLabel.Add(lineSplit[1], lineSplit[0]);
            }

            return dLocationLabel;
        }

        public static Dictionary<string, string> getLocationName(string directory)
        {
            string line = "";
            string no = "0";
            Dictionary<string, string> dLocationName = new Dictionary<string, string>();
            System.IO.StreamReader file = new System.IO.StreamReader(directory);
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split('\t');
                if (no == lineSplit[0])      // still in same no
                {
                    // do nothing
                }
                else    // different no, save the location, then make new dictionary
                {
                    // save location in dictionary
                    dLocationName.Add(lineSplit[0], lineSplit[1]);
                    no = lineSplit[0];
                }
            }

            return dLocationName;
        }

        public static void writeDocumentBasedLocationAndTopic(string dirDocument, string dirLocation, string dirNoDocument, string dirTopicGroup, string homeDirectory)
        {
            Dictionary<string, string> dNoTopicGroup = getNoDocumentAndTopicGroup(dirNoDocument, dirTopicGroup);

            // read each line of data_location
            string line = "";
            System.IO.StreamReader file = new System.IO.StreamReader(dirLocation);
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split('\t');

                string noTopic = dNoTopicGroup[lineSplit[0]];
                string nameFolder = string.Join("_", lineSplit[1].Split(' '));

                int noDocument = Int32.Parse(lineSplit[0]);
                string text = System.IO.File.ReadLines(dirDocument).Skip(noDocument - 1).Take(1).First();

                // add document to specified folder
                DataController.addToFile(homeDirectory + nameFolder + @"\topik_" + noTopic + @"\data_document.txt", text);
            }
        }

        public static void makeDirectoryLocation(string homeDirectory, string dirLocationLabel)
        {
            Dictionary<string, string> dLocationName = getLocationName(dirLocationLabel);

            foreach(string location in dLocationName.Values)
            {
                string nameFolder = string.Join("_", location.Split(' '));
                Directory.CreateDirectory(@homeDirectory + nameFolder);
            }
        }

        public static void insertNumberLineDocument(string directory)
        {
            List<string> lines = System.IO.File.ReadAllLines(directory).ToList();
            int numberLine = lines.Count();
            lines.Insert(0, numberLine.ToString());

            string[] newLines = lines.ToArray();

            System.IO.File.WriteAllLines(directory, newLines);
        }

        public static void insertNumberLineDocumentAll(string homeDirectory, string dirLocationLabel, int numberOfTopic)
        {
            Dictionary<string, string> dLocationName = getLocationName(dirLocationLabel);

            foreach (string location in dLocationName.Values)
            {
                string nameFolder = string.Join("_", location.Split(' '));

                for (int i = 0; i < numberOfTopic; i++)
                {
                    string directory = homeDirectory + nameFolder + @"\topik_" + i.ToString() + @"\data_document.txt";
                    if(File.Exists(directory))
                    {
                        insertNumberLineDocument(directory);
                    }
                }
            }
        }

        public static void writeNoDocumentBasedLocation(string dirLocation, string homeDirectory)
        {
            // read file dirLocation per line
            string line = "";
            System.IO.StreamReader file = new System.IO.StreamReader(dirLocation);
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split('\t');
                string nameFolder = string.Join("_", lineSplit[1].Split(' '));
                DataController.addToFile(homeDirectory + nameFolder + @"\data_no_document.txt", lineSplit[0]);
            }
        }

        public static void makeDirectoryTopicGroup(string homeDirectory, string dirLocationLabel, int numberOfTopic)
        {
            Dictionary<string, string> dLocationName = getLocationName(dirLocationLabel);

            foreach(string location in dLocationName.Values)
            {
                string nameFolder = string.Join("_", location.Split(' '));

                for (int i = 0; i < numberOfTopic; i++)
                {
                    Directory.CreateDirectory(homeDirectory + nameFolder + @"\topik_" + i.ToString());
                }
            }
        }

        public static void writeGroupTopicDocument(string dirTheta, string output)
        {
            string line = "";
            System.IO.StreamReader file = new System.IO.StreamReader(dirTheta);
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                double[] topicDistribution = Array.ConvertAll(lineSplit, Double.Parse);
                double max = (from td in topicDistribution where td == topicDistribution.Max() select td).First();

                int index = Array.FindIndex(topicDistribution, row => row == max);

                DataController.addToFile(output, index.ToString());
            }
        }

        public static void renameDirectory(string homeDirectory, string dirLocationLabel, string dirFormer, string dirLatter)
        {
            Dictionary<string, string> dLocationName = getLocationName(dirLocationLabel);

            foreach (string location in dLocationName.Values)
            {
                string nameFolder = string.Join("_", location.Split(' '));
                Directory.Move(homeDirectory + nameFolder + dirFormer, @homeDirectory + nameFolder + dirLatter);
            }
        }

        // combine no document and topic group
        public static Dictionary<string, string> getNoDocumentAndTopicGroup(string dirNoDocument, string dirTopicGroup)
        {
            Dictionary<string, string> dNoTopicGroup = new Dictionary<string, string>();
            for (int i = 1; i <= 9806; i++)
            {
                // read no document and topic group for that document
                string no = System.IO.File.ReadLines(dirNoDocument).Skip(i - 1).Take(1).First();
                string topicGroup = System.IO.File.ReadLines(dirTopicGroup).Skip(i - 1).Take(1).First();

                // save no document and topic group in dictionary
                dNoTopicGroup.Add(no, topicGroup);
            }

            return dNoTopicGroup;
        }
    }
}
