using System;
using System.IO.Ports;

namespace ComPortRead
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
            // Espera um pouco para a resposta chegar
            System.Threading.Thread.Sleep(1000);  // Ajuste o tempo conforme a necessidade e a velocidade da resposta do seu dispositivo

            if (port.BytesToRead > 0)
            {
                string response = port.ReadExisting();  // Lê os dados disponíveis enviados pelo dispositivo
                Console.WriteLine("Dados recebidos:");
                Console.WriteLine(response);
            }
            else
            {
                Console.WriteLine("Nenhuma resposta recebida.");
            }
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
