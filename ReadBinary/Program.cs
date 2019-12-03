using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadBinary
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ReadingBinary("C:\\Users\\HP\\Desktop\\data.bin");
        }

        private static void ReadingBinary(string path) {
            //FileStream fs = new FileStream(path, FileMode.Open);
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open))) {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    int id = (byte)br.ReadInt32();
                    float temperature = br.ReadSingle();
                    float humidity = br.ReadSingle();
                    int battery = (byte)br.ReadInt32();
                    int timestamp = br.ReadInt32();
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp).ToLocalTime();
                    string formattedDate = dt.ToString("dd-MM-yyyy HH:mm");
                    int trash = br.ReadInt32();

                    Console.WriteLine("Sensor ID = " + id);
                    Console.WriteLine("Tenperature = " + temperature);
                    Console.WriteLine("Humidity = " + humidity);
                    Console.WriteLine("Batery = " + battery);
                    Console.WriteLine("Data = " + formattedDate + "\n");
                }  
            }
        }

        //Converter para XML
        //Enviar para BD 
        //Criar API na BD
        //Enviar dados para APP

    }
}
