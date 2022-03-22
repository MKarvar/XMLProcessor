using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace XMLProcessor.Client
{
    class Program
    {
        Dictionary<string, int> tags = new Dictionary<string, int>();
        public static object threadLock = new object();
        private int _threadCount = 0;
        static async Task Main(string[] args)
        {
            Program currentClass = new Program();
            Console.WriteLine("Please enter the tag names seperated by ',':");
            currentClass.ReadTags();
            Console.WriteLine("Please enter the path: ");
            await currentClass.ReadFile();
        }

        private void ReadTags()
        {
            try
            {
                string input = Console.ReadLine();
                tags = input.Split(',').ToDictionary(t => t, c => 0);

            }
            catch (Exception)
            {
                Console.WriteLine("Oops! Something Wrong happened!");
            }
        }

        private async Task ReadFile()
        {
            try
            {
                string input = Console.ReadLine();
                XmlDocument doc = new XmlDocument();
                doc.Load(input);
                await ProcessFile(doc);
                Console.ReadLine();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("That file does not exist!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory does not exist!");
            }
            catch (IOException)
            {
                Console.WriteLine("Oops! Something Wrong happened!");
            }
        }

        private async Task ProcessFile(XmlDocument doc)
        {
            XmlNode rootNode = doc.DocumentElement;
            await ProcessNode(rootNode);
        }

        private async Task ProcessNode(XmlNode node)
        {
            try
            {
                if (node.NodeType == XmlNodeType.Text && tags.ContainsKey(node.ParentNode.Name))
                {
                    string parentNodeName = node.ParentNode.Name;
                    new Thread(async () => await ProcessNodeContent(parentNodeName, node.Value)).Start();
                    _threadCount++;

                }
                else if (tags.ContainsKey(node.Name))
                {
                    tags[node.Name]++;
                    Console.WriteLine($"{tags[node.Name]} tag {node.Name} is found.");
                }

                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode child in children)
                {
                    await ProcessNode(child);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async Task ProcessNodeContent(string nodeName, string nodeContent)
        {
            XMLProcessCaller processor = new XMLProcessCaller();
            string errorMessage = await processor.Process(nodeName, nodeContent);
            if (!string.IsNullOrEmpty(errorMessage))
                Console.WriteLine(errorMessage);
            lock (threadLock)
            {
                _threadCount--;
                if (_threadCount == 0)
                    Console.WriteLine($"********************* END OF THE PROCESS *********************");
            }
        }
    }
}
