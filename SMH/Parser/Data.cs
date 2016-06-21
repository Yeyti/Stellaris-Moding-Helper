using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMH.Parser
{
    static class Data{
        public static List<Tokien> gameData;
        public static List<Tokien> modData;

        public static string[] gameFiles;
        public static string[] modFiles;


        public static void loadData(){
            Console.BufferHeight= 1024;
            gameFiles = Directory.EnumerateFiles(Cfg.ActiveProfile.GamePath+"\\common",".", SearchOption.AllDirectories).ToArray();
            int i = 0;
            foreach (var VARIABLE in gameFiles){
                Console.WriteLine(VARIABLE);
                int j = File.ReadAllLines(VARIABLE).Length;
                Console.WriteLine(j);
                i +=j;
            }
            Console.WriteLine("_____________________________");
            Console.WriteLine("строк: " + i);
            Console.WriteLine("файлов: "+gameFiles.Length);
            Console.WriteLine("Строк на файл: "+i/gameFiles.Length);
        }

    }
}
