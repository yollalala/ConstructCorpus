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
            // insert line number
            string homeDirectory = @"D:\output_corpus_real\5_topik\";
            string dirLocationLabel = @"D:\daftar_kota_kab_all_label_v2.txt";
            int numberOfTopic = 5;

            Constructor.insertNumberLineDocumentAll(homeDirectory, dirLocationLabel, numberOfTopic);

            //// write document based location and topic
            //string dirDocument = @"E:\output_real\data_complete\data_document_v2-6_cleaned.txt";
            //string dirLocation = @"D:\data_location_real_max.txt";
            //string dirNoDocument = @"D:\data_line_number_document.txt";
            //string dirTopicGroup = @"D:\data_group_topic_document_5_topik.txt";
            //string homeDirectory = @"D:\output_corpus_real\5_topik\";

            //Constructor.writeDocumentBasedLocationAndTopic(dirDocument, dirLocation, dirNoDocument, dirTopicGroup, homeDirectory);

            //// rename directory topik_10 to topik_0
            //string homeDirectory = @"D:\output_corpus_real\10_topik\";
            //string dirLocationLabel = @"D:\daftar_kota_kab_all_label_v2.txt";
            //string dirFormer = @"\topik_10";
            //string dirLatter = @"\topik_0";

            //Constructor.renameDirectory(homeDirectory, dirLocationLabel, dirFormer, dirLatter);

            //// check convert string to double
            //string text = "0.0446428571428571";
            //double textDouble = Double.Parse(text);

            //Console.WriteLine(textDouble);

            //// check group topic
            //string dirTheta = @"E:\output_LDA\data_cleaned_v2-6-1\5_topik\model-final.theta";
            //string output = @"D:\data_group_topic_document_5_topik.txt";

            //Constructor.writeGroupTopicDocument(dirTheta, output);

            //// make topic directory each location folder
            //string homeDirectory = @"D:\output_corpus_real\5_topik\";
            //string dirLocationLabel = @"D:\daftar_kota_kab_all_label_v2.txt";

            //Constructor.makeDirectoryTopicGroup(homeDirectory, dirLocationLabel, 5);

            //// write no document based location
            //string dirLocation = @"D:\data_location_real_max.txt";
            //string homeDirectory = @"D:\output_corpus_real\5_topik\";

            //Constructor.writeNoDocumentBasedLocation(dirLocation, homeDirectory);

            //// get locationName
            //string directory = @"D:\daftar_kota_kab_all_label_v2.txt";

            //Console.WriteLine(Constructor.getLocationName(directory).Count());

            //// make all dir location
            //string homeDirectory = @"D:\output_corpus_real\5_topik\";
            //string dirLocationLabel = @"D:\daftar_kota_kab_all_label_v2.txt";

            //Constructor.makeDirectoryLocation(homeDirectory, dirLocationLabel);

            //// check insert line
            //string directory = @"D:\data_document_cluster_5.txt";
            //Constructor.insertNumberLineDocument(directory);

            //// check readalllines (insert number of line)
            //string directory = @"D:\daftar_kota_kab.txt";
            //string[] lines = System.IO.File.ReadAllLines(directory);
            //string[] newLines = new string[lines.Count() + 1];
            //newLines[0] = lines.Count().ToString();
            
            //for (int i = 1; i <= lines.Count(); i++)
            //{
            //    newLines[i] = lines[i - 1];
            //}

            //System.IO.File.WriteAllLines(@"D:\daftar_kota_kab_test.txt", newLines);

            //string dirLocationDistinct = @"D:\data_all_terbaru\03-13-2016\data_location_v2_cleaned_distinct_v2.txt";
            //string dirCluster = @"D:\data_location_cluster.txt";

            //string dirDocument = @"D:\data_all_terbaru\03-13-2016\data_document_v2-6_cleaned.txt";
            //string dirLocation = @"D:\data_all_terbaru\03-13-2016\data_location_v2_cleaned.txt";
            //string dirCorpus = @"D:\output_corpus\03-26_eps_2.5_minpts_3_v2-6\";

            //// get dictionary of location and its cluster number
            //Dictionary<string, string> dLocationCluster = Constructor.getDictionaryLocationCluster(dirLocationDistinct, dirCluster);

            //// construct region corpuses!
            //Constructor.ConstructCorpus(dirDocument, dirLocation, dirCorpus, dLocationCluster);

            Console.WriteLine("Selesai!");
            Console.ReadLine();
        }
    }
}
