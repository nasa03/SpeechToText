using System;
using System.Windows.Forms;
using System.Speech.Recognition;   // add a Reference to System.Speech dll in Solution Explorer.


namespace SpeechToText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine myvoice = new SpeechRecognitionEngine();
            Grammar dictationGrammar = new DictationGrammar();
            myvoice.LoadGrammar(dictationGrammar);
            try
            {
                myvoice.SetInputToDefaultAudioDevice();
                RecognitionResult result = myvoice.Recognize();
                textBox1.AppendText(result.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("No audio input device is present or active. Connect a microphone and try again.");
            }
            finally
            {
                myvoice.UnloadAllGrammars();
            }
        }
    }
}
