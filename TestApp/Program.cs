using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            C6502 c = new C6502();
            // immediate:
            c.Memory[0x00] = 0xA9;
            c.Memory[0x01] = 0xFF;
            // absolute (load value from memory @ address 0x16A0)
            c.Memory[0x16A0] = 0x13;
            c.Memory[0x02] = 0xAD;
            c.Memory[0x03] = 0xA0;
            c.Memory[0x04] = 0x16;
            // zero page
            c.Memory[0xFC] = 0x14;
            c.Memory[0x05] = 0xA5;
            c.Memory[0x06] = 0xFC;

            // Load X immediate
            c.Memory[0x07] = 0xA2;
            c.Memory[0x08] = 0x06;

            // Pre-Indexed Indirect Addressing
            c.Memory[0x46] = 0x05;
            c.Memory[0x47] = 0x20;
            c.Memory[0x2005] = 0xFF;
            c.Memory[0x09] = 0xA1;
            c.Memory[0x0A] = 0x46;

            // Load Y immediate
            c.Memory[0x0B] = 0xA0;
            c.Memory[0x0C] = 0x04;

            // Post-Indexed Indirect Addressing
            c.Memory[0x48] = 0x19;
            c.Memory[0x49] = 0x32;
            c.Memory[0x3219] = 0xCF;
            c.Memory[0x0D] = 0xB1;
            c.Memory[0x0E] = 0x48;

            // Zero Page Indexed Addressing
            c.Memory[0x0F] = 0xA2;
            c.Memory[0x10] = 0xDF;

            c.Memory[0xDF] = 0xFE;
            c.Memory[0x11] = 0xB5;
            c.Memory[0x12] = 0x00;

            // Absolute X addresing
            c.Memory[0x13] = 0xA2;
            c.Memory[0x14] = 0xFF;

            c.Memory[0x10FF] = 0xFB;
            c.Memory[0x15] = 0xBD;
            c.Memory[0x16] = 0x00;
            c.Memory[0x17] = 0x10;

            // Absolute Y addressing
            c.Memory[0x18] = 0xA0;
            c.Memory[0x19] = 0xFF;

            c.Memory[0x11FF] = 0xFD;
            c.Memory[0x1A] = 0xB9;
            c.Memory[0x1B] = 0x00;
            c.Memory[0x1C] = 0x11;



            Console.WriteLine("Loading FF into A using Immediate Addressing");
            c.Step();
            Console.Write(c.ToString());
            Console.WriteLine("Loading 13 into A using absolute addressing");
            c.Step();
            Console.Write(c.ToString());
            Console.WriteLine("Loading 14 into A using Zero Page Addressing");
            c.Step();
            Console.Write(c.ToString());
            
            Console.WriteLine("Loading 06 into X using Immediate Addressing");
            c.Step();
            Console.Write(c.ToString());

            Console.WriteLine("Loading FF into A using Pre-Indexed Indirect Addressing");
            c.Step();
            Console.Write(c.ToString());

            Console.WriteLine("Loading 04 into Y using Immediate Addressing");
            c.Step();
            Console.Write(c.ToString());

            Console.WriteLine("Loading CF into A using Post-Indexed Indirect Addressing");
            c.Step();
            Console.Write(c.ToString());

            Console.WriteLine("Loading FE into A using Zero-Page Indexed Addressing");
            c.Step();
            c.Step();
            Console.Write(c.ToString());

            Console.WriteLine("Loading FB into A using Absolute X Addressing");
            c.Step();
            c.Step();
            Console.Write(c.ToString());

            Console.WriteLine("Loading FD into A using Absolute Y Addressing");
            c.Step();
            c.Step();
            Console.Write(c.ToString());
            Console.ReadKey();
        }
    }
}
