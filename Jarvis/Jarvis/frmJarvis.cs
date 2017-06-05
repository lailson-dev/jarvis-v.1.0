using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Speech.Recognition; //Namespace do projeto

namespace Jarvis
{
    public partial class frmJarvis : Form
    {
        private SpeechRecognitionEngine engine; //Engine de reconhecimento
        private bool IsJarvisListening = true;
        private frmSelectVoice selectVoice = null;

        public frmJarvis()
        {
            InitializeComponent();
        }

        private void LoadSpeech()
        {
            try
            {
                engine = new SpeechRecognitionEngine();
                engine.SetInputToDefaultAudioDevice(); //Entrada de microfone

                //Parte da gramática
                Choices c_commandsOfSystem = new Choices();
                c_commandsOfSystem.Add(GrammarRules.WhatTimeIS.ToArray()); //Que horas são?
                c_commandsOfSystem.Add(GrammarRules.WhatDateIs.ToArray()); //Que data é hoje?
                c_commandsOfSystem.Add(GrammarRules.JarvisStartListening.ToArray()); //Chama o jarvis
                c_commandsOfSystem.Add(GrammarRules.JarvisStopListening.ToArray()); //Para o jarvis
                c_commandsOfSystem.Add(GrammarRules.MinimizeWindow.ToArray());//Minimizar a janela
                c_commandsOfSystem.Add(GrammarRules.NormalWindow.ToArray());//Janela em tamanho normal
                c_commandsOfSystem.Add(GrammarRules.ChangeVoice.ToArray());//Altera a voz

                GrammarBuilder gb_commandsOfSystem = new GrammarBuilder();
                gb_commandsOfSystem.Append(c_commandsOfSystem);

                Grammar g_commandsOfSystem = new Grammar(gb_commandsOfSystem);
                g_commandsOfSystem.Name = "sys";

                //Carregamento da gramática
                //engine.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(words))));
                engine.LoadGrammar(g_commandsOfSystem);

                //Evento do reconhecimento
                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);
                //Nível do audio
                engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(audioLevel);
                engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(rej);

                //Inicia o reconhecimento
                engine.RecognizeAsync(RecognizeMode.Multiple);

                Speaker.Speak("Estou carregando os arquivos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no LoadSpeech" + ex.Message);
            }
        }

        private void frmJarvis_Load(object sender, EventArgs e)
        {
            LoadSpeech();
        }

        //Método chamado quando algo é reconhecido
        private void rec(object s, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text; //String reconhecida
            float conf = e.Result.Confidence; //Confiança

            if (conf > 0.35f)
            {
                this.label1.ForeColor = Color.ForestGreen;
                this.label1.Text = "Reconhecido: " + speech;

                if (GrammarRules.JarvisStopListening.Any(x => x == speech))
                {
                    IsJarvisListening = false;
                    Speaker.Speak("Você que manda patrão.");
                }
                else
                {
                    IsJarvisListening = true;
                    Speaker.Speak("Diga ai patrão.");
                }

                if (IsJarvisListening == true)
                {
                    switch (e.Result.Grammar.Name)
                    {
                        case "sys":
                            // Se speech(a fala) for igual a que horas são, ou o que estiver escrito na lista
                            if (GrammarRules.WhatTimeIS.Any(x => x == speech))
                                Runner.WhatTimeIs();
                            else if (GrammarRules.WhatDateIs.Any(x => x == speech))
                                Runner.WhatDateIs();
                            else if (GrammarRules.MinimizeWindow.Any(x => x == speech))
                                MinimizeWindow();
                            else if (GrammarRules.NormalWindow.Any(x => x == speech))
                                NormalWindow();
                            else if (GrammarRules.ChangeVoice.Any(x => x == speech))
                            {
                                if (selectVoice == null || selectVoice.IsDisposed == true)
                                    selectVoice = new frmSelectVoice();
                                selectVoice.Show();
                            }
                            break;
                    }
                }
            }
        }

        //Método do nível de áudio
        private void audioLevel(object s, AudioLevelUpdatedEventArgs e)
        {
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = e.AudioLevel;
        }

        private void rej(object s, SpeechRecognitionRejectedEventArgs e)
        {
            this.label1.ForeColor = Color.Red;
        }

        private void MinimizeWindow()
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
                Speaker.Speak("Minimizando a janela", "Como quiser", "Feito", "Você que manda meu patrão.");
            }
            else
            {
                Speaker.Speak("A já está minimizada.", "Já minimizei a janela", "Já fiz isso");
            }
        }

        private void NormalWindow()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                Speaker.Speak("Na tela", "Feito");
            }
            else
                Speaker.Speak("A janela já está em tamanho normal", "Já fiz isso", "Isso já foi feito");
        }
    }
}
