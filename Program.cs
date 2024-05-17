using System;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace ComBalanca.NET
{
    class Program
    {
        static SerialPort port;

        static void Main(string[] args)
        {   
            string tecla = Console.ReadLine();
            Console.WriteLine("Digite");
            while (tecla != "0")
            {
                InitializePort();
                SolicitarPeso();
                ReadResponse();
                ClosePort();
                tecla = Console.ReadLine();
            }
        }

        static void InitializePort()
        {
            port = new SerialPort("COM8")  // Substitua "COM8" pela sua porta
            {
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };
            port.Open();
        }

        protected static void SolicitarPeso()
        {
            Console.WriteLine("Enviando comando para solicitar peso...");
            port.DiscardInBuffer(); 
            port.DiscardOutBuffer();
            port.Write(new byte[] { 0x05 }, 0, 1); 
        }

        static void ReadResponse()
        {
            Thread.Sleep(700); 

            if (port.BytesToRead > 0)
            {
                string response = port.ReadExisting();

                Console.WriteLine("Dados recebidos:");
                Console.WriteLine(response);

                decimal peso = ConvertToDecimal(response);
                string formattedWeight = FormatWeight(peso);

                Console.WriteLine($"Peso formatado: {formattedWeight} kg");
            }
            else
            {
                Console.WriteLine("Nenhuma resposta recebida.");
            }
        }

        static decimal ConvertToDecimal(string data)
        {
            string cleanData = Regex.Replace(data, "[^0-9]", "");
            int numericData = int.Parse(cleanData);
            return numericData / 1000m;
        }

        static string FormatWeight(decimal weight)
        {
            return weight.ToString("N3", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
        }

        static void ClosePort()
        {
            if (port.IsOpen)
            {
                port.Close();
            }
        }
    }
}
