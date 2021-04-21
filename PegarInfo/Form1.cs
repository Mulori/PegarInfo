using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace PegarInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
       
        public static string GetComponent(string hwclass, string syntax)
        {
            var retorno = "";

            var get = new ManagementObjectSearcher("root\\CIMV2","SELECT * FROM " + hwclass);
            ManagementObjectCollection bios = get.Get();


            foreach (ManagementObject obj in bios)
            {
                if(syntax == "Model")
                {
                    retorno += Convert.ToString(obj[syntax]) + " | ";
                }
                else
                {
                    retorno += Convert.ToString(obj[syntax]);
                }
                
            }

            return retorno;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("PROCESSADOR: " + GetComponent("Win32_Processor", "Name"));
            listBox1.Items.Add("VOLTAGEM: " + GetComponent("Win32_Processor", "CurrentVoltage") + "V");
            listBox1.Items.Add("NUCLEOS: " + GetComponent("Win32_Processor", "Characteristics"));
            listBox1.Items.Add("VELOCIDADE CLOCK: " + GetComponent("Win32_Processor", "CurrentClockSpeed"));
            listBox1.Items.Add("HD/SSD: " + GetComponent("CIM_DiskDrive", "Model"));
            listBox1.Items.Add("TOTAL RAM: " + (long.Parse(GetComponent("CIM_PhysicalMemory", "Capacity")) / 1000000) + " MB");
            listBox1.Items.Add("FREQUENCIA RAM: " + GetComponent("CIM_PhysicalMemory", "Speed") + " MHz");
            listBox1.Items.Add("SERIAL RAM: " + GetComponent("CIM_PhysicalMemory", "SerialNumber"));
            listBox1.Items.Add("PLACA DE VIDEO: " + GetComponent("CIM_PCVideoController", "Name"));
            listBox1.Items.Add("TOTAL VRAM: " + (long.Parse(GetComponent("CIM_PCVideoController", "AdapterRAM")) / 1000000) + " MB");
            listBox1.Items.Add("teste: " + GetComponent("CIM_LogicalDisk", "FreeSpace"));
        }
    }
}
