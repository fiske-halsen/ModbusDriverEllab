using System;
using EasyModbus;
namespace ModbustProro
{
    class Program
    {
        static void Main(string[] args)
        {

           ModbusClient e = new ModbusClient();

            e.Connect("10.8.4.160", 502);

            // Register col is col -1 
             e.WriteSingleRegister(1, 12);

            // 3 for enable alarms, 1 for disable
             e.WriteSingleRegister(3009, 3);
             e.WriteSingleRegister(3011, 3);

            //e.WriteSingleRegister(31, 30000);

            //bool[] readCoils = e.ReadCoils(30, 1);
            int[] readHoldingRegisters = e.ReadHoldingRegisters(3008, 5);    //Read 10 Holding Registers from Server, starting with Address 1

            // Console Output
            //for (int i = 0; i < readCoils.Length; i++)
            //  Console.WriteLine("Value of Coil " + (9 + i + 1) + " " + readCoils[i].ToString());
            //var  tester = ConvertRegistersToInt(readHoldingRegisters);

            
            for (int i = 0; i < readHoldingRegisters.Length; i++)
                Console.WriteLine("Value of HoldingRegister " + (i + 1) + " " + readHoldingRegisters[i].ToString());
            
           //var tester = ConvertRegistersToString(readHoldingRegisters, 0, 0);

           // Console.WriteLine(tester);


            e.Disconnect();                                                //Disconnect from Server
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        public static Int32 ConvertRegistersToInt(int[] registers)
        {
            if (registers.Length != 2)
                throw new ArgumentException("Input Array length invalid - Array langth must be '2'");
            int highRegister = registers[1];
            int lowRegister = registers[0];
            byte[] highRegisterBytes = BitConverter.GetBytes(highRegister);
            byte[] lowRegisterBytes = BitConverter.GetBytes(lowRegister);
            byte[] doubleBytes = {
                                    lowRegisterBytes[0],
                                    lowRegisterBytes[1],
                                    highRegisterBytes[0],
                                    highRegisterBytes[1]
                                };
            return BitConverter.ToInt32(doubleBytes, 0);
        }
        public static string ConvertRegistersToString(int[] registers, int offset, int stringLength)
        {
            byte[] result = new byte[stringLength];
            byte[] registerResult = new byte[2];

            for (int i = 0; i < stringLength / 2; i++)
            {
                registerResult = BitConverter.GetBytes(registers[offset + i]);
                result[i * 2] = registerResult[0];
                result[i * 2 + 1] = registerResult[1];
            }
            return System.Text.Encoding.Default.GetString(result);
        }
    }




}
