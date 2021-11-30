using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tizenegyedikhet.Entities;

namespace tizenegyedikhet
{
    public partial class Form1 : Form
    {
        Random rng = new Random(1234);
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:\Users\Benedek\Downloads\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Users\Benedek\Downloads\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Users\Benedek\Downloads\halál.csv");
        }
        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }
        public List<BirthProbability> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbability> population = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),                     
                        NbrOfChildren = int.Parse(line[1]),
                        BProbability = double.Parse(line[2])
                    });
                }
            }

            return population;
        }
        public List<DeathProbability> GetDeathProbabilities(string csvpath)
        {
            List<DeathProbability> population = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new DeathProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        DProbability = double.Parse(line[2])
                    });
                }
            }

            return population;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //dolgok dolgok
        }
    }
}
