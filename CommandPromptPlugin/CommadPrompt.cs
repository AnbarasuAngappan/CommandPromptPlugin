using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.AddIn;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Drawing.Printing;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Documents;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using Spire;
using Spire.Pdf;

namespace CommandPromptPlugin
{
    [AddIn("CommadPrompt")]
    public class CommadPrompt
    {

        public static string ExecuteCommandPrompt(string Command)
        {
            #region            
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.UseShellExecute = false;
            //startInfo.RedirectStandardOutput = true;
            //startInfo.FileName = "CMD.exe";
            //startInfo.Arguments = "dir";
            //process.StartInfo = startInfo;
            //process.Start();
            //string output = process.StandardOutput.ReadToEnd();
            ////MessageBox.Show(output);
            //process.WaitForExit();


            //ProcessStartInfo ProcessInfo;
            //Process Process;
            //ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
            //ProcessInfo.CreateNoWindow = true;
            //ProcessInfo.UseShellExecute = true;
            //ProcessInfo.WorkingDirectory = "C:/Windows/system32";
            //Process = Process.Start(ProcessInfo);
            #endregion
            try
            {
                ProcessStartInfo ProcessInfo;
                Process Process;
                if (Command != null && Command.Length > 0)
                {
                    ProcessInfo = new ProcessStartInfo("cmd.exe");
                    ProcessInfo.RedirectStandardInput = true;
                    ProcessInfo.RedirectStandardOutput = true;
                    ProcessInfo.UseShellExecute = false;
                    Process = Process.Start(ProcessInfo);
                    Process.StandardInput.WriteLine(Command);
                    Process.StandardInput.WriteLine("exit");
                    string standardOutput = Process.StandardOutput.ReadToEnd();
                    return standardOutput;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public static void DisconnectCommandPrompt()
        {
            try
            {
                Process[] RDPprocess = Process.GetProcessesByName("cmd");
                if (RDPprocess != null && RDPprocess.Length > 0)
                {
                    int RDPId = RDPprocess[0].Id;
                    Process process = Process.GetProcessById(RDPId);
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SystemEnviroinment(string EnviroinmentIndex, out string MachineName, out string UserName, out string UserDomain,
                                                  out string SystemDirectory, out bool Is64BitOperatingSystem)
        {          

            MachineName = UserName = UserDomain = SystemDirectory  = null;
            Is64BitOperatingSystem = false;

            int[] numbers = EnviroinmentIndex.Split(',').Select(n => int.Parse(n)).ToArray();

            foreach (var item in numbers)
            {
                switch (item)
                {
                    case 0:
                       MachineName =  Environment.MachineName;
                        break;
                    case 1:
                        UserName = Environment.UserName;
                        break;
                    case 2:
                        UserDomain = Environment.UserDomainName;
                        break;
                    case 3:
                        SystemDirectory = Environment.SystemDirectory;
                        break;
                    case 4:
                        Is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
                        break;                    
                    default:
                        MachineName = null;
                        UserName = null;
                        UserDomain = null;
                        SystemDirectory = null;
                        Is64BitOperatingSystem = false;
                        break;
                }
            }        
                 
        }   

        public void PrintPDF(string PDFFilePath)
        {
            PdfDocument doc = new PdfDocument();           
            doc.LoadFromFile(PDFFilePath);
#pragma warning disable CS0618 // Type or member is obsolete
            doc.PrintDocument.Print();
#pragma warning restore CS0618 // Type or member is obsolete         
           
        }     
    }    
}
