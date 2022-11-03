using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using KModkit;
using System.Linq;
using System.Text;

public class DCYPHER : MonoBehaviour {
    public KMSelectable[] letters;
    public TextMesh[] texts;
    public Color locked;
    public Color initial;
    public KMBombInfo bomb;
    public KMBombModule module;
    public KMAudio sound;
    public TextMesh playfairText;
    public TextMesh caesarText;
    string playfairKey = "AS";
    int caesarKey;
    string[] wordList = new string[] { "ABSOLUTE", "ABSTRACT", "ACADEMIC", "ACCEPTED", "ACCIDENT", "ACCURACY", "ACCURATE", "ACHIEVED", "ACQUIRED", "ACTIVITY", "ACTUALLY", "ADDITION", "ADEQUATE", "ADJACENT", "ADJUSTED", "ADVANCED", "ADVISORY", "ADVOCATE", "AFFECTED", "AIRCRAFT", "ALLIANCE", "ALTHOUGH", "ALUMINUM", "ANALYSIS", "ANNOUNCE", "ANYTHING", "ANYWHERE", "APPARENT", "APPENDIX", "APPROACH", "APPROVAL", "ARGUMENT", "ARTISTIC", "ASSEMBLY", "ASSUMING", "ATHLETIC", "ATTACHED", "ATTITUDE", "ATTORNEY", "AUDIENCE", "AUTONOMY", "AVIATION", "BACHELOR", "BACTERIA", "BASEBALL", "BATHROOM", "BECOMING", "BENJAMIN", "BIRTHDAY", "BOUNDARY", "BREAKING", "BREEDING", "BUILDING", "BULLETIN", "BUSINESS", "CALENDAR", "CAMPAIGN", "CAPACITY", "CASUALTY", "CATCHING", "CATEGORY", "CATHOLIC", "CAUTIOUS", "CELLULAR", "CEREMONY", "CHAIRMAN", "CHAMPION", "CHEMICAL", "CHILDREN", "CIRCULAR", "CIVILIAN", "CLEARING", "CLINICAL", "CLOTHING", "COLLAPSE", "COLONIAL", "COLORFUL", "COMMENCE", "COMMERCE", "COMPLAIN", "COMPLETE", "COMPOSED", "COMPOUND", "COMPRISE", "COMPUTER", "CONCLUDE", "CONCRETE", "CONFLICT", "CONFUSED", "CONGRESS", "CONSIDER", "CONSTANT", "CONSUMER", "CONTINUE", "CONTRACT", "CONTRARY", "CONTRAST", "CONVINCE", "CORRIDOR", "COVERAGE", "COVERING", "CREATION", "CREATIVE", "CRIMINAL", "CRITICAL", "CROSSING", "CULTURAL", "CURRENCY", "CUSTOMER", "DATABASE", "DAUGHTER", "DAYLIGHT", "DEADLINE", "DECIDING", "DECISION", "DECREASE", "DEFERRED", "DEFINITE", "DELICATE", "DELIVERY", "DESCRIBE", "DESIGNER", "DETAILED", "DIABETES", "DIALOGUE", "DIAMETER", "DIRECTLY", "DIRECTOR", "DISABLED", "DISASTER", "DISCLOSE", "DISCOUNT", "DISCOVER", "DISORDER", "DISPOSAL", "DISTANCE", "DISTINCT", "DISTRICT", "DIVIDEND", "DIVISION", "DOCTRINE", "DOCUMENT", "DOMESTIC", "DOMINANT", "DOMINATE", "DOUBTFUL", "DRAMATIC", "DRESSING", "DROPPING", "DURATION", "DYNAMICS", "EARNINGS", "ECONOMIC", "EDUCATED", "EFFICACY", "EIGHTEEN", "ELECTION", "ELECTRIC", "ELIGIBLE", "EMERGING", "EMPHASIS", "EMPLOYEE", "ENDEAVOR", "ENGAGING", "ENGINEER", "ENORMOUS", "ENTIRELY", "ENTRANCE", "ENVELOPE", "EQUALITY", "EQUATION", "ESTIMATE", "EVALUATE", "EVENTUAL", "EVERYDAY", "EVERYONE", "EVIDENCE", "EXCHANGE", "EXCITING", "EXERCISE", "EXPLICIT", "EXPOSURE", "EXTENDED", "EXTERNAL", "FACILITY", "FAMILIAR", "FEATURED", "FEEDBACK", "FESTIVAL", "FINISHED", "FIREWALL", "FLAGSHIP", "FLEXIBLE", "FLOATING", "FOOTBALL", "FOOTHILL", "FORECAST", "FOREMOST", "FORMERLY", "FOURTEEN", "FRACTION", "FRANKLIN", "FREQUENT", "FRIENDLY", "FRONTIER", "FUNCTION", "GENERATE", "GENEROUS", "GENOMICS", "GOODWILL", "GOVERNOR", "GRADUATE", "GRAPHICS", "GRATEFUL", "GUARDIAN", "GUIDANCE", "HANDLING", "HARDWARE", "HERITAGE", "HIGHLAND", "HISTORIC", "HOMELESS", "HOMEPAGE", "HOSPITAL", "HUMANITY", "IDENTIFY", "IDENTITY", "IDEOLOGY", "IMPERIAL", "INCIDENT", "INCLUDED", "INCREASE", "INDICATE", "INDIRECT", "INDUSTRY", "INFORMAL", "INFORMED", "INHERENT", "INITIATE", "INNOCENT", "INSPIRED", "INSTANCE", "INTEGRAL", "INTENDED", "INTERACT", "INTEREST", "INTERIOR", "INTERNAL", "INTERVAL", "INTIMATE", "INTRANET", "INVASION", "INVOLVED", "ISOLATED", "JUDGMENT", "JUDICIAL", "JUNCTION", "KEYBOARD", "LANDLORD", "LANGUAGE", "LAUGHTER", "LEARNING", "LEVERAGE", "LIFETIME", "LIGHTING", "LIKEWISE", "LIMITING", "LITERARY", "LOCATION", "MAGAZINE", "MAGNETIC", "MAINTAIN", "MAJORITY", "MARGINAL", "MARRIAGE", "MATERIAL", "MATURITY", "MAXIMIZE", "MEANTIME", "MEASURED", "MEDICINE", "MEDIEVAL", "MEMORIAL", "MERCHANT", "MIDNIGHT", "MILITARY", "MINIMIZE", "MINISTER", "MINISTRY", "MINORITY", "MOBILITY", "MODELING", "MODERATE", "MOMENTUM", "MONETARY", "MOREOVER", "MORTGAGE", "MOUNTAIN", "MOUNTING", "MOVEMENT", "MULTIPLE", "NATIONAL", "NEGATIVE", "NINETEEN", "NORTHERN", "NOTEBOOK", "NUMEROUS", "OBSERVER", "OCCASION", "OFFERING", "OFFICIAL", "OFFSHORE", "OPERATOR", "OPPONENT", "OPPOSITE", "OPTIMISM", "OPTIONAL", "ORDINARY", "ORGANIZE", "ORIGINAL", "OVERCOME", "OVERHEAD", "OVERSEAS", "OVERVIEW", "PAINTING", "PARALLEL", "PARENTAL", "PATENTED", "PATIENCE", "PEACEFUL", "PERIODIC", "PERSONAL", "PERSUADE", "PETITION", "PHYSICAL", "PIPELINE", "PLATFORM", "PLEASANT", "PLEASURE", "POLITICS", "PORTABLE", "PORTRAIT", "POSITION", "POSITIVE", "POSSIBLE", "POWERFUL", "PRACTICE", "PRECIOUS", "PREGNANT", "PRESENCE", "PRESERVE", "PRESSING", "PRESSURE", "PREVIOUS", "PRINCESS", "PRINTING", "PRIORITY", "PROBABLE", "PROBABLY", "PRODUCER", "PROFOUND", "PROGRESS", "PROPERTY", "PROPOSAL", "PROSPECT", "PROTOCOL", "PROVIDED", "PROVIDER", "PROVINCE", "PUBLICLY", "PURCHASE", "PURSUANT", "QUANTITY", "QUESTION", "RATIONAL", "REACTION", "RECEIVED", "RECEIVER", "RECOVERY", "REGIONAL", "REGISTER", "RELATION", "RELATIVE", "RELEVANT", "RELIABLE", "RELIANCE", "RELIGION", "REMEMBER", "RENOWNED", "REPEATED", "REPORTER", "REPUBLIC", "REQUIRED", "RESEARCH", "RESERVED", "RESIDENT", "RESIGNED", "RESOURCE", "RESPONSE", "RESTRICT", "REVISION", "RIGOROUS", "ROMANTIC", "SAMPLING", "SCENARIO", "SCHEDULE", "SCRUTINY", "SEASONAL", "SECONDLY", "SECURITY", "SENSIBLE", "SENTENCE", "SEPARATE", "SEQUENCE", "SERGEANT", "SHIPPING", "SHORTAGE", "SHOULDER", "SIMPLIFY", "SITUATED", "SLIGHTLY", "SOFTWARE", "SOLUTION", "SOMEBODY", "SOMEWHAT", "SOUTHERN", "SPEAKING", "SPECIFIC", "SPECTRUM", "SPORTING", "STANDARD", "STANDING", "STANDOUT", "STERLING", "STRAIGHT", "STRATEGY", "STRENGTH", "STRIKING", "STRUGGLE", "STUNNING", "SUBURBAN", "SUITABLE", "SUPERIOR", "SUPPOSED", "SURGICAL", "SURPRISE", "SURVIVAL", "SWEEPING", "SWIMMING", "SYMBOLIC", "SYMPATHY", "SYNDROME", "TACTICAL", "TAILORED", "TAKEOVER", "TANGIBLE", "TAXATION", "TAXPAYER", "TEACHING", "TENDENCY", "TERMINAL", "TERRIBLE", "THINKING", "THIRTEEN", "THOROUGH", "THOUSAND", "TOGETHER", "TOMORROW", "TOUCHING", "TRACKING", "TRAINING", "TRANSFER", "TRAVELED", "TREASURY", "TRIANGLE", "TROPICAL", "TURNOVER", "ULTIMATE", "UMBRELLA", "UNIVERSE", "UNLAWFUL", "UNLIKELY", "VALUABLE", "VARIABLE", "VERTICAL", "VICTORIA", "VIOLENCE", "VOLATILE", "WARRANTY", "WEAKNESS", "WEIGHTED", "WHATEVER", "WHENEVER", "WHEREVER", "WILDLIFE", "WIRELESS", "WITHDRAW", "WOODLAND", "WORKSHOP", "YOURSELF" };
    string[] alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
      "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    string startingWord;
    string answerWord;
    int stageCounter = 1;
    bool breakCondition = false;
    bool TwitchPlaysActive;
    static int moduleIDCounter = 1;
    int moduleID; public struct Cell
    {
        public char character;
        public int X;
        public int Y;

        public Cell(char _character, int _X, int _Y)
        {
            this.character = _character;
            this.X = _X;
            this.Y = _Y;
        }
    }
        void Awake()
    {
        moduleID = moduleIDCounter++;
        foreach (KMSelectable letter in letters)
        {
            KMSelectable pressedLetter = letter;
            letter.OnInteract += delegate () { pressLetter(pressedLetter); return false; };
            letter.OnInteractEnded += delegate () { releaseLetter(pressedLetter); };
        }
    }
    // Use this for initialization
    void Start() {
        char[] alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray();
        caesarKey = UnityEngine.Random.Range(1, 26);
        caesarText.text = caesarKey.ToString();
        playfairKey = "";
        playfairKey += alphabet[UnityEngine.Random.Range(0, 25)];
        playfairKey += alphabet[UnityEngine.Random.Range(0, 25)];
        playfairKey += alphabet[UnityEngine.Random.Range(0, 25)];
        playfairKey += alphabet[UnityEngine.Random.Range(0, 25)];
        playfairKey += alphabet[UnityEngine.Random.Range(0, 25)];
        playfairText.text = playfairKey;
        answerWord = wordList[UnityEngine.Random.Range(0, 500)];
        startingWord = CaesarCipher(PlayfairCipher(playfairKey, answerWord), caesarKey);
        Debug.LogFormat("[D-CIPHER #{0}] The encrypted word is {1}. ", moduleID, startingWord);
        Debug.LogFormat("[D-CIPHER #{0}] The answer word is {1}. ", moduleID, answerWord);
        Debug.LogFormat("[D-CIPHER #{0}] The Caesar key is {1}. ", moduleID, caesarKey);
        Debug.LogFormat("[D-CIPHER #{0}] The Playfair key is {1}. ", moduleID, playfairKey);
        int textCounter = 0;
        foreach (TextMesh text in texts) {
            text.color = initial;
            text.text = startingWord.ToCharArray()[textCounter].ToString();
            textCounter++;
        }
    }

    // Update is called once per frame
    // Update is called once per frame
    void pressLetter(KMSelectable letter)
    {
        if (letter.GetComponentInChildren<TextMesh>().color.g > 0.6)
        {
            StopAllCoroutines();
            StartCoroutine(cycleLetters(letter.GetComponentInChildren<TextMesh>()));
        }
    }
    void releaseLetter(KMSelectable letter)
    {
        if (letter.GetComponentInChildren<TextMesh>().color.g > 0.6)
        {
            StopAllCoroutines();
            breakCondition = true;
            letter.GetComponentInChildren<TextMesh>().color = locked;
            sound.PlaySoundAtTransform("StageSound", transform);
            stageCounter++;
            if (stageCounter == 9)
            {
                checkSolution();
            }
        }
    }
    void checkSolution()
    {

        string loggingWord = "";
        foreach (TextMesh text in texts)
        {
            loggingWord = loggingWord + text.text;
        }
        Debug.LogFormat("[D-CIPHER #{0}] You submitted {1}. ", moduleID, loggingWord);
        if (loggingWord == answerWord)
        {
            module.HandlePass();
            sound.PlaySoundAtTransform("SolveSound", transform);
            Debug.LogFormat("[D-CIPHER #{0}] That was correct. Module solved. ", moduleID);
        }
        else
        {
            module.HandleStrike();
            Debug.LogFormat("[D-CIPHER #{0}] That was incorrect. Strike! ", moduleID);
            foreach (TextMesh text in texts)
            {
                text.color = initial;
            }
            stageCounter = 1;
            string playfairKey = "AS";
            Start();
        }
    }
    IEnumerator cycleLetters(TextMesh letter)
    {

        breakCondition = false;
        int textIndex = 0;
        List<string> textOptions = new List<string> { };
        string candidateLetter;
        textOptions.Add(answerWord[Array.IndexOf<TextMesh>(texts, letter)].ToString());
        for (int i = 0; i < 5; i++)
        {
            do
            {
                candidateLetter = alphabet[UnityEngine.Random.Range(0, 26)];
            } while (textOptions.Contains(candidateLetter));
            textOptions.Add(candidateLetter);
        };
        if (TwitchPlaysActive) { textOptions = alphabet.ToList().Shuffle(); }
        else { textOptions = textOptions.Shuffle(); }

        while (true)
        {
            if (breakCondition)
            {
                break;
            }
            letter.text = textOptions[textIndex];

            ++textIndex;

            if (textIndex >= textOptions.Count())
                textIndex = 0;
            if (TwitchPlaysActive)
            {
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }

    }
    public string PlayfairCipher(string keyWord, string plainText)
    {
        //Debug.LogFormat("[Playfair #{2}] PlayfairCipher started – Encrypting text {1} with key {0}", keyWord, plainText, _moduleId);
        //Define alphabet
        //There is no J in the alphabet, I is used instead!
        char[] alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray();

        //region Adjust Key
        keyWord = keyWord.Trim();
        keyWord = keyWord.Replace(" ", "");
        keyWord = keyWord.Replace("J", "I");
        keyWord = keyWord.ToUpper();

        StringBuilder keyString = new StringBuilder();

        foreach (char c in keyWord)
        {
            if (!keyString.ToString().Contains(c))
            {
                keyString.Append(c);
                alphabet = alphabet.Where(val => val != c).ToArray();
            }
        }
        //endregion

        plainText = adjustText(plainText);

        //If the Length of the plain text is odd add X
        if ((plainText.Length % 2 > 0))
        {
            plainText += "X";
        }

        List<string> plainTextEdited = new List<string>();

        //Split plain text into pairs
        for (int i = 0; i < plainText.Length; i += 2)
        {
            //If a pair of chars contains the same letters replace one of them with X
            if (plainText[i].ToString() == plainText[i + 1].ToString())
            {
                plainTextEdited.Add(plainText[i].ToString() + 'X');
            }
            else
            {
                plainTextEdited.Add(plainText[i].ToString() + plainText[i + 1].ToString());
            }
        }
        //endregion



        //region Create 5 x 5 matrix
        List<Cell> matrix = new List<Cell>();

        int keyIDCounter = 0;
        int alphabetIDCounter = 0;

        //Fill the matrix. First with the key characters then with the alphabet
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (keyIDCounter < keyString.Length)
                {

                    Cell cell = new Cell(keyString[keyIDCounter], x, y);
                    matrix.Add(cell);
                    keyIDCounter++;
                }
                else
                {
                    Cell cell = new Cell(alphabet[alphabetIDCounter], x, y);
                    matrix.Add(cell);
                    alphabetIDCounter++;

                }


            }
        }
        //endregion



        //region Write cipher

        StringBuilder cipher = new StringBuilder();

        foreach (string pair in plainTextEdited)
        {

            int indexA = matrix.FindIndex(c => c.character == pair[0]);
            Cell a = matrix[indexA];

            int indexB = matrix.FindIndex(c => c.character == pair[1]);
            Cell b = matrix[indexB];

            //Write cipher
            if (a.X == b.X)
            {
                cipher.Append(matrix[matrix.FindIndex(c => c.Y == (a.Y + 1) % 5 && c.X == a.X)].character);
                cipher.Append(matrix[matrix.FindIndex(c => c.Y == (b.Y + 1) % 5 && c.X == b.X)].character);
            }
            else if (a.Y == b.Y)
            {
                cipher.Append(matrix[matrix.FindIndex(c => c.Y == a.Y && c.X == (a.X + 1) % 5)].character);
                cipher.Append(matrix[matrix.FindIndex(c => c.Y == b.Y % 5 && c.X == (b.X + 1) % 5)].character);
            }
            else
            {
                cipher.Append(matrix[matrix.FindIndex(c => c.X == a.X && c.Y == b.Y)].character);
                cipher.Append(matrix[matrix.FindIndex(c => c.X == b.X % 5 && c.Y == a.Y)].character);
            }


        }
        //endregion
        //Debug.LogFormat ("[Playfair #{1}] – {0}", cipher.ToString(), _moduleId);
        return cipher.ToString();
    }


    //Make key Array
    private void baseKeyArray(string baseKey)
    {
        string baseKeyArray = baseKey;

        char[] baseCharArray = baseKeyArray.ToCharArray();

        foreach (var baseKeyArrayChar in baseCharArray)
        {
            //Debug.LogFormat ("[Playfair #{0}] Base Key Array: {1}", _moduleId, baseKeyArrayChar);
        }


    }

    //Remove Spaces, replace "J" with "I" and make UPPERCASE
    private static string adjustText(string text)
    {
        text = text.Trim();
        text = text.Replace(" ", "");
        text = text.Replace("J", "I");
        text = text.ToUpper();

        return text;
    }

    //If Text to Encrypt length is odd add "X"
    protected void checkOdd(string text)
    {
        //bool wasOdd = false;
        if ((text.Length % 2 > 0))
        {
            text += "X";
            //wasOdd = true;
        }

        //Debug.LogFormat("[Playfair #{0}] Was the Text Odd?: {1}", _moduleId, wasOdd);

        getPairs(text);
    }

    //Split text into PAIRS
    private void getPairs(string textToPairs)
    {
        List<string> textEdit = new List<string>();
        for (int i = 0; i < textToPairs.Length; i += 2)
        {
            if (textToPairs[i].ToString() == textToPairs[i + 1].ToString())
            {
                textEdit.Add(textToPairs[i].ToString() + 'X');
            }
            else
            {
                textEdit.Add(textToPairs[i].ToString() + textToPairs[i + 1].ToString());
            }
        }

    }
    string CaesarCipher(string plaintext, int key)
    {
        string encryptedPuzzle = "";
        foreach (char c in plaintext)
        {
            string convertedChar = c.ToString();
            convertedChar = alphabet[(Array.IndexOf(alphabet, convertedChar) + key) % 26];
                encryptedPuzzle = encryptedPuzzle + convertedChar;
            
        }
        return encryptedPuzzle;
    }
#pragma warning disable 414
    private string TwitchHelpMessage = "use e.g. '!{0} submit ABCDEFGH' to submit the answer word.";
#pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {
        command = command.ToLowerInvariant();
        string validcmds = "abcdefghijklmnopqrstuvwxyz ";
        string[] commandArray = command.Split(' ');
        if (commandArray.Length != 2 || commandArray[0] != "submit" || commandArray[1].Length != letters.Length)
        {
            yield return "sendtochaterror @{0}, invalid command.";
            yield break;
        }
        else
        {
            for (int i = 0; i < command.Length; i++)
            {
                if (!validcmds.Contains(command[i]))
                {
                    yield return "sendtochaterror Invalid command.";
                    yield break;
                }
            }
            for (int i = 0; i < letters.Length; i++)
            {
                yield return null;
                letters[i].OnInteract();
                while (letters[i].GetComponentInChildren<TextMesh>().text != commandArray[1][i].ToString().ToUpperInvariant())
                {
                    yield return null;
                }
                letters[i].OnInteractEnded();
            }
        }
    }
    IEnumerator TwitchHandleForcedSolve()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            yield return null;
            letters[i].OnInteract();
            while (letters[i].GetComponentInChildren<TextMesh>().text != answerWord[i].ToString())
            {
                yield return null;
            }
            letters[i].OnInteractEnded();
        }
    }

}
