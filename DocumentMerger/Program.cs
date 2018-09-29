using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            String firstFile;
            String secondFile;
            String newFile;
            String firstContent = "";
            String secondContent = "";
            String newContent = "";
            int charCount;
            bool loopCheck = true;
            String answerString = "";

            while(loopCheck){
                Console.WriteLine("Document Merger");
                Console.WriteLine();
                Console.WriteLine("What is the name of the first file?: ");
                firstFile = Console.ReadLine();
                while(!File.Exists(firstFile)){
                    Console.WriteLine("File not found. Please try another file: ");
                    firstFile = Console.ReadLine();
                }
                Console.WriteLine("What is the name of the second file?: ");
                secondFile = Console.ReadLine();
                while(!File.Exists(secondFile)){
                    Console.WriteLine("File not found. Please try another file: ");
                    secondFile = Console.ReadLine();
                }

                string extension = System.IO.Path.GetExtension(firstFile);
                string result = firstFile.Substring(0, firstFile.Length - extension.Length);

                string extension2 = System.IO.Path.GetExtension(secondFile);
                string result2 = secondFile.Substring(0, secondFile.Length - extension.Length);

                newFile = result + result2 + ".txt";

            
                try
                {
                    firstContent = System.IO.File.ReadAllText(firstFile);
                    secondContent = System.IO.File.ReadAllText(secondFile);
                
                    newContent = firstContent + secondContent;

                    using (StreamWriter sw = new StreamWriter(newFile))
                    {
                        sw.WriteLine(newContent);
                    }

                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                    //Environment.Exit;
                }

                charCount = newContent.Length;

                Console.WriteLine(newFile + " was successfully saved. The document contains " +charCount+" characters.");

                while(loopCheck){
                    Console.WriteLine("Would you like to merge two more files? Please answer 'Yes' or 'No': ");
                    answerString = Console.ReadLine();
                    if(answerString == "No"){
                        loopCheck = false;
                    } else if (answerString == "Yes"){
                        break;
                    }
                }
            }
        }
    }
}
