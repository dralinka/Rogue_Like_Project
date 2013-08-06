using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
            Notes notes = new Notes();
            notes.LoadFromFile(@"C:\Users\makiesewetter\Desktop\Melodie.txt");
            notes.Play();

            //Notes play = new PlayTask();
 */




namespace ConsoleApplication2
{
    public enum NoteDuration { Full, Half, Quater, Eighth, Sixteenth }

    public class PlayTask
    {
        public int Frequency;
        public int Duration;

        public PlayTask(int frequency, int duration)
        {
            Frequency = frequency;
            Duration = duration;
        }
    }

    public class Notes
    {
        public const int Pause = 0;
        public const int C3 = 130;
        public const int Cis3 = 138;
        public const int D3 = 146;
        public const int Dis3 = 155;
        public const int E3 = 164;
        public const int F3 = 174;
        public const int Fis3 = 185;
        public const int G3 = 196;
        public const int Gis3 = 207;
        public const int A3 = 220;
        public const int Ais3 = 233;
        public const int B3 = 246;
        public const int C4 = 261;
        public const int Cis4 = 277;
        public const int D4 = 293;
        public const int Dis4 = 311;
        public const int E4 = 329;
        public const int F4 = 349;
        public const int Fis4 = 369;
        public const int G4 = 392;
        public const int Gis4 = 415;
        public const int A4 = 440;
        public const int Ais4 = 466;
        public const int B4 = 493;
        public const int C5 = 523;
        public const int Cis5 = 554;
        public const int D5 = 587;
        public const int Dis5 = 622;
        public const int E5 = 659;
        public const int F5 = 698;
        public const int Fis5 = 739;
        public const int G5 = 830;
        public const int Gis5 = 880;
        public const int A5 = 932;
        public const int Ais5 = 987;
        public const int B5 = 1046;
        public const int C6 = 1108;
        public const int Cis6 = 1174;
        public const int D6 = 1244;
        public const int Dis6 = 1318;
        public const int E6 = 1396;
        public const int F6 = 1396;
        public const int Fis6 = 1479;
        public const int G6 = 1567;
        public const int Gis6 = 1661;
        public const int A6 = 1760;
        public const int Ais6 = 1864;
        public const int B6 = 1975;
        public const int C7 = 2093;
        public const int Cis7 = 2217;
        public const int D7 = 2349;
        public const int Dis7 = 2489;
        public const int E7 = 2637;
        public const int F7 = 2793;
        public const int Fis7 = 2959;
        public const int G7 = 3135;
        public const int Gis7 = 3322;
        public const int A7 = 3520;
        public const int Ais7 = 3729;
        public const int B7 = 3951;

        public int BPM = 120;

        public float DefaultLength = 1;

        public Dictionary<string, int> Lookup;

        public List<PlayTask> Song;

        public Notes()
        {
            Lookup = new Dictionary<string, int>();
            Song = new List<PlayTask>();
            FillDictionary();
        }

        public void Play()
        {
            foreach (PlayTask task in Song)
            {
                if (task.Frequency == 0)
                    System.Threading.Thread.Sleep(task.Duration);
                else
                    Console.Beep(task.Frequency, task.Duration);
            }
        }

        public void LoadFromFile(string Filename)
        {
            string Content = "";
            // Load file stuff
            using (TextReader reader = File.OpenText(@"C:\Users\makiesewetter\Desktop\Melodie.txt"))
            {
                Content = reader.ReadToEnd();
                //Console.WriteLine(text.Length);
                //Console.WriteLine(text);
            }
            Console.Write(Content);
            Parse(Content);
        }

        public void Parse(string ABCText)
        {
            Song.Clear();

            // voodoo happens here                       
            ABCText.Replace(@"|", string.Empty);
            string[] task = ABCText.Split(' ');

            for (int i = 0; i < task.Length; i++)
            {
                Song.Add(new PlayTask(Lookup[task[i]], GetNoteDuration(NoteDuration.Quater)));
            }
        }

        public int GetNoteDuration(NoteDuration duration)
        {
            switch (duration)
            {
                case NoteDuration.Full:
                    return (int) (Full * DefaultLength);
                case NoteDuration.Half:
                    return (int) (Half * DefaultLength);
                case NoteDuration.Quater:
                    return (int) (Quarter * DefaultLength);
                case NoteDuration.Eighth:
                    return (int) (Eigth * DefaultLength);
                case NoteDuration.Sixteenth:
                    return (int)(Sixteenth * DefaultLength);
                default:
                    return 0;
            }
        }

        public int Full
        {
            get
            { return (int) ((60f / BPM) * 1000f); }
        }
        public int Half
        {
            get { return Full / 2; }
        }
        public int Quarter
        {
            get { return Full / 4; }
        }
        public int Eigth
        {
            get { return Full / 8; }
        }
        public int Sixteenth
        {
            get { return Full / 16; }
        }

        private void FillDictionary()
        {
            Lookup.Add("C,,", C3);
            Lookup.Add("^C,,", Cis3);
            Lookup.Add("D,,", D3);
            Lookup.Add("^D,,", Dis3);
            Lookup.Add("E,,", E3);
            Lookup.Add("F,,", F3);
            Lookup.Add("^F,,", Fis3);
            Lookup.Add("G,,", G3);
            Lookup.Add("^G,,", Gis3);
            Lookup.Add("A,,", A3);
            Lookup.Add("^A,,", Ais3);
            Lookup.Add("B,,", B3); 
                Lookup.Add("C,", C4);
                Lookup.Add("^C,", Cis4);
                Lookup.Add("D,", D4);
                Lookup.Add("^D,", Dis4);
                Lookup.Add("E,", E4);
                Lookup.Add("F,", F4);
                Lookup.Add("^F,", Fis4);
                Lookup.Add("G,", G4);
                Lookup.Add("^G,", Gis4);
                Lookup.Add("A,", A4);
                Lookup.Add("^A,", Ais4);
                Lookup.Add("B,", B4);
                    Lookup.Add("C", C5);
                    Lookup.Add("^C", Cis5);
                    Lookup.Add("D", D5);
                    Lookup.Add("^D", Dis5);
                    Lookup.Add("E", E5);
                    Lookup.Add("F", F5);
                    Lookup.Add("^F", Fis5);
                    Lookup.Add("G", G5);
                    Lookup.Add("^G", Gis5);
                    Lookup.Add("A", A5);
                    Lookup.Add("^A", Ais5);
                    Lookup.Add("B", B5);
                        Lookup.Add("C'", C6);
                        Lookup.Add("^C'", Cis6);
                        Lookup.Add("D'", D6);
                        Lookup.Add("^D'", Dis6);
                        Lookup.Add("E'", E6);
                        Lookup.Add("F'", F6);
                        Lookup.Add("^F'", Fis6);
                        Lookup.Add("G'", G6);
                        Lookup.Add("^G'", Gis6);
                        Lookup.Add("A'", A6);
                        Lookup.Add("^A'", Ais6);
                        Lookup.Add("B'", B6);
                            Lookup.Add("C''", C7);
                            Lookup.Add("^C''", Cis7);
                            Lookup.Add("D''", D7);
                            Lookup.Add("^D''", Dis7);
                            Lookup.Add("E''", E7);
                            Lookup.Add("F''", F7);
                            Lookup.Add("^F''", Fis7);
                            Lookup.Add("G''", G7);
                            Lookup.Add("^G''", Gis7);
                            Lookup.Add("A''", A7);
                            Lookup.Add("^A''", Ais7);
                            Lookup.Add("B''", B7);


                            Lookup.Add("z", Pause);


           // Lookup.Add("/2" , 
            
       
            



            
        }
    }
}
