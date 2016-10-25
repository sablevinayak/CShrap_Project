using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace Zee
{
    public partial class Form1 : Form
    {
        Boolean state = true;
        Choices list = new Choices();
        SpeechSynthesizer s=new SpeechSynthesizer();
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
        
        public Form1()
        
        {
            s.SelectVoiceByHints(VoiceGender.Female);
            s.Speak("Hello, My name is zee");
            //s.Speak("open google");
            list.Add(new String[]{"hello zee", "how are you", "time","whats up?","whats today","open bing","wake","sleep"});
            Grammar gr = new Grammar(new GrammarBuilder(list));

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeachRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }
            
            InitializeComponent();
        }

        public void say(string h)
        {
            s.Speak(h);
        }

        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string r = e.Result.Text;

            if (r == "wake")
            {
                state = true;
                say("Woked up");
            }

            if(r=="sleep")
            {
                state = false;
                say("Slept");
            }

            if (state = true)
            {

                if (r == "hello zee")
                {
                    say("hi sir");
                }

                if (r == "whats up?")
                {
                    say("Great sir, what about you?");
                }

                if (r == "how are you")
                {
                    say("great,what about you?");
                }
                if (r == "time")
                {
                    say(DateTime.Now.ToString("hh mm"));
                }

                if (r == "whats today")
                {
                    say(DateTime.Now.ToString("dd M yyyy"));
                }
                if (r == "open bing")
                {
                    Process.Start("htpp://google.com");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
