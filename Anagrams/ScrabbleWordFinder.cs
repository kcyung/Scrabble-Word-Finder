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

namespace Anagrams
{
    public partial class ScrabbleWordFinder : Form
    {
        // Dictionary with the key to hold every word, and value to hold a dictionary with the char and char count
        Dictionary<string, Dictionary<char, int>> masterDictionary = new Dictionary<string, Dictionary<char, int>>();

        // Dictionary with the point value for every character/tile available
        Dictionary<char, int> Point = new Dictionary<char, int>();

        // Dictionary with the potential words and point value
        Dictionary<string, int> Results = new Dictionary<string, int>();


        public ScrabbleWordFinder()
        {
            InitializeComponent();
        }

        // Upon loading program, read from file and intialize dictionaries
        private void WordSearch_Load(object sender, EventArgs e)
        {
            // Read all words from text file and load it into master dictionary
            try
            {
                StreamReader sr = new StreamReader("words.txt");
                while (!sr.EndOfStream)
                {
                    string word = sr.ReadLine().Trim().ToLower();

                    // Skip possible duplicates due to ToLower function
                    if (!masterDictionary.ContainsKey(word))
                        masterDictionary.Add(word, CharCounter(word));
                }
            }
            catch (Exception error)
            { Console.WriteLine("Can not read file: " + error); }

            // Scrabble point values (all set to 1 and then adjusted)
            for (char c = 'a'; c < 'z' + 1; ++c)
                Point.Add(c, 1);

            Point['d'] = Point['g'] = 2;
            Point['b'] = Point['c'] = Point['m'] = Point['p'] = 3;
            Point['f'] = Point['h'] = Point['v'] = Point['w'] = Point['y'] = 4;
            Point['k'] = 5;
            Point['j'] = Point['x'] = 8;
            Point['z'] = 10;

            // Used '?' for blank spaces
            Point.Add('?', 0);
        }

        // Creates a dictionary from a string input with char of every letter as key, and the count as value
        private Dictionary<char, int> CharCounter (string s)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dictionary.ContainsKey(c))
                    ++dictionary[c];
                else
                    dictionary.Add(c, 1);
            }

            return dictionary;
        }

        // Event handler that sorts possible words by highest point value
        private void UI_BTN_Points_Click(object sender, EventArgs e)
        {
            // Get user input and update possible results
            UpdateResultList();
            
            // Order results by point value and publish to list box
            Results = Results.OrderByDescending(o => o.Value).ToDictionary(o => o.Key, o => o.Value);
            foreach (KeyValuePair<string, int> kvp in Results)
                UI_LB_Words.Items.Add(string.Format("{0:d3}: {1}", kvp.Value, kvp.Key));
        }

        // Event handler to sort possible words in order from longest word length
        private void UI_BTN_Length_Click(object sender, EventArgs e)
        {
            // Get user input and update possible result
            UpdateResultList();

            // Order results by word length and publish to list box
            Results = Results.OrderByDescending(o => o.Key.Length).ThenByDescending(o => o.Value).
                ToDictionary(o => o.Key, o => o.Value);
            foreach (KeyValuePair<string, int> kvp in Results)
                UI_LB_Words.Items.Add(string.Format("{0:d3}: {1}", kvp.Value, kvp.Key));
        }

        // Checks user input, and updates master list of possilbe results
        private void UpdateResultList()
        {
            // Clear all previous results
            UI_LB_Words.Items.Clear();

            // Receive user input as a string in lower case ordered by char
            string userString = string.Concat(UI_TB_Input.Text.Trim().ToLower().OrderBy(o => o));

            if (userString.Length < 2)
            {
                UI_LB_Words.Items.Add("You must enter at least two tiles");
                return;
            }

            // Check to ensure all characters are a letter or a '?' for a blank square
            foreach (char c in userString)
                if (!char.IsLetter(c) && (c != '?'))
                {
                    UI_LB_Words.Items.Add("You may only use letters and/or a '?' for a blank");
                    return;
                }

            // Make a list of words to reduce searches
            List<string> copy = new List<string>(masterDictionary.Keys);
            copy.RemoveAll(o => o.Length < 2 || o.Length > userString.Length);

            // Dictionary to hold possible words and point values
            Dictionary<string, int> matches = new Dictionary<string, int>();

            // Dictionary of character and count of user input string
            Dictionary<char, int> userDict = CharCounter(userString);

            // Check if there are more than two blank spaces entered - invalid
            if (userString.Length > 2 && userDict.ContainsKey('?') && userDict['?'] > 2)
            {
                UI_LB_Words.Items.Clear();
                UI_LB_Words.Items.Add("You may only have a maximum of two blank spaces [?]");
                return;
            }

            // ***** Valid User Input - Generate possible results with their point values ***** //
            // Iterate through all words at least two characters to length of input
            foreach (string word in copy)
            {
                bool possibleMatch = true;

                // Dictionary of current word in with kvp <char, char - count> 
                Dictionary<char, int> wordDict = masterDictionary[word];

                int Blanks = userDict.ContainsKey('?') ? userDict['?'] : 0;
                int PointsForBlanks = 0;

                // Iterate through each kvp pair for the current word
                foreach (KeyValuePair<char, int> kvp in wordDict)
                {
                    if (!userDict.ContainsKey(kvp.Key))
                    {
                        Blanks -= wordDict[kvp.Key];
                        PointsForBlanks += Point[kvp.Key] * wordDict[kvp.Key];
                    }
                    // char exists in the user input; but word requires more characters
                    else if (userDict[kvp.Key] < wordDict[kvp.Key])
                    {
                        Blanks -= wordDict[kvp.Key] - userDict[kvp.Key];
                        PointsForBlanks += Point[kvp.Key] * (wordDict[kvp.Key] - userDict[kvp.Key]);
                    }
                    // Can not possibly make this word from user tiles, skip this word
                    if (Blanks < 0)
                    {
                        possibleMatch = false;
                        break;
                    }
                }

                if (possibleMatch)
                    matches.Add(word, word.Sum(o => Point[o]) - PointsForBlanks);
            }

            Results = new Dictionary<string,int>(matches);
        }
    }
}
