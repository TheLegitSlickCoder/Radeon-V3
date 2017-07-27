using System;
using System.IO;
using System.Windows.Forms;

/*
 * UI Controls:
 * title: Displays the title.
 * cmd: Args / command input.
 * log: Logger.
 */

namespace Radeon_V3
{
    public partial class Form1 : Form
    {
        //Class Variables:
        private string desktop;

        //Class Imports:
        FileManager fm = new FileManager();

        public Form1()
        {
            InitializeComponent();

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.desktop = desktopPath;

            fm.createFile(desktop + "\\LastCommand.log");
        }

        //Time Update:
        private void timeUpdate_Tick(object sender, EventArgs e)
        {
            title.Text = "Radeon V3 - " + DateTime.Now.ToString();
        }

        //Logger:
        private void logger(string text)
        {
            log.AppendText(text + "\n");
        }

        //When a key is pressed on the 'cmd' control:
        private void cmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string command = cmd.Text;

                //Special code for 'clear' command:
                if (command == "cls" || command == "Cls" || command == "CLS")
                {
                    log.Text = "";
                    return;
                }

                //Special code for 'exit' command:
                if (command == "exit" || command == "Exit" || command == "EXIT")
                {
                    this.Close();
                    return;
                }

                //Execute Command:
                fm.execute(command + " > " + this.desktop + "\\LastCommand.log");

                //Read and display:
                StreamReader sr = new StreamReader(this.desktop + "\\LastCommand.log");
                string contents = "";

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    contents = contents + line + "\n";
                }

                sr.Dispose();

                this.logger(contents);
            }
        }
    }
}