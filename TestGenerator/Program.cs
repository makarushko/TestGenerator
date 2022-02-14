﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToFolder = "C:\\Users\\Anna\\RiderProjects\\TestGenerator\\MainPart\\Files";
            var pathToGenerated = @"C:\Users\Anna\RiderProjects\TestGenerator\GeneratedTests\GeneratedFiles";

            if (!Directory.Exists(pathToFolder))
            {
                Console.WriteLine($"Couldn't find directory {pathToFolder}");
                return;
            }
            if (!Directory.Exists(pathToGenerated))
            {
                Directory.CreateDirectory(pathToGenerated);
            }

            var allFiles = Directory.GetFiles(pathToFolder);

            var files = from file in allFiles
                where file.Substring(file.Length - 3) == ".cs"
                select file;

            Task task =  new Pipeline().Generate(files, pathToGenerated,new TestGeneratorLib.TestGenerator());
            task.Wait();
            //Thread.Sleep(2000);
            Console.WriteLine("end.");
        }
    }
}