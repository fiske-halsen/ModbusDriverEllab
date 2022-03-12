
using System;

namespace Modbus
{
    class Program
    {
        static void Main(string[] args)
        {
            
                //Ip-Address and Port of Modbus-TCP-Server
          //  modbusClient.Connect();                                                    //Connect to Server
           /* modbusClient.WriteMultipleCoils(4, new bool[] { true, true, true, true, true, true, true, true, true, true });    //Write Coils starting with Address 5
            bool[] readCoils = modbusClient.ReadCoils(9, 10);                        //Read 10 Coils from Server, starting with address 10
            int[] readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 10);    //Read 10 Holding Registers from Server, starting with Address 1

            // Console Output
            for (int i = 0; i < readCoils.Length; i++)
                Console.WriteLine("Value of Coil " + (9 + i + 1) + " " + readCoils[i].ToString());

            for (int i = 0; i < readHoldingRegisters.Length; i++)
                Console.WriteLine("Value of HoldingRegister " + (i + 1) + " " + readHoldingRegisters[i].ToString());
            modbusClient.Disconnect();                                                //Disconnect from Server
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);*/
        }
    }
}
