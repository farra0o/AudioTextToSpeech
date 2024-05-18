using System;
using System.Collections.Generic;
using System.Media;
using System.Speech.Synthesis;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Utils;
using System.IO;
using System.Diagnostics;

namespace AudioTextToSpeech
{
    public partial class Form1 : Form
    {
        private List<Usuario> usuarios = new List<Usuario>();

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();


        string AtendiendoSonido = Environment.CurrentDirectory + "\\SonidosMP3\\Usuario.mp3";
        

        string Sala = Environment.CurrentDirectory + "\\SonidosMP3\\Ventana.mp3";
        public Form1()
        {
            InitializeComponent();
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

     

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(nombre))
            {
                Usuario nuevoUsuario = new Usuario(nombre);
                usuarios.Add(nuevoUsuario);
                ActualizarListaUsuarios();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un nombre válido.");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void ActualizarListaUsuarios()
        {
            listBox1.Items.Clear();
            foreach (Usuario usuario in usuarios)
            {
                listBox1.Items.Add(usuario.Nombre +" " + usuario.Numero);
                
            }
            
        }
         
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LLamaUsuario();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuarios.Clear();
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            usuarios.RemoveAt(0);
            listBox1.Items.RemoveAt(0);
            LLamaUsuario();
        }


        public void LLamaUsuario()
        {
            string nombre = usuarios[0].Nombre;
            label4.Text = nombre;

            Random rnd = new Random();
            int ventana = rnd.Next(1, 6);

            label6.Text = ventana.ToString();
            Console.WriteLine(AtendiendoSonido);


            if (System.IO.File.Exists(AtendiendoSonido))
            {
                // Crear un reproductor de audio
                var readerNombre = new Mp3FileReader(AtendiendoSonido);
                var outputDevice = new WaveOutEvent();

                outputDevice.Volume = 1;
                outputDevice.Init(readerNombre);
                outputDevice.Play();

                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(100);
                }

                synthesizer.Speak(nombre);
                System.Threading.Thread.Sleep(1000);


                var readerSala = new Mp3FileReader(Sala);
                var outputDevice2 = new WaveOutEvent();

                outputDevice2.Volume = 1;
                outputDevice2.Init(readerSala);
                outputDevice2.Play();

                while (outputDevice2.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(100);
                }

                synthesizer.Speak(ventana.ToString());
            }

            else
            {
                MessageBox.Show("El archivo MP3 no se encontró en la ruta especificada.");
            }
        }
    }
}