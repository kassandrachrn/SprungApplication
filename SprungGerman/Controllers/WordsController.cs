using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SprungGerman.Models;
using SprungGermanData.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SprungGerman.Controllers
{
    public class WordsController : Controller
    {
        private IWords _words;

        public WordsController(IWords words)
        {
            _words = words;
        }

        public IActionResult Index()
        {

            var listModel = _words.GetAll();

            var wordModel = listModel.Select(result => new WordsViewModel
            {
                Id = result.Id,
                EnglishVersion = result.EnglishVersion,
                GermanVersion = result.GermanVersion
            });

            var model = new WordsListViewModel()
            {
                Words = wordModel
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var wordModel = _words.GetWordById(id);

            var model = new WordsViewModel()
            {
                Id = wordModel.Id,
                EnglishVersion = wordModel.EnglishVersion,
                GermanVersion = wordModel.GermanVersion
            };

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetWord(WordsViewModel model)
        {

            string getGerman = "https://api.pons.com/v1/dictionary?q=Menschen&l=deen";
            WebRequest getDictioGerman = WebRequest.Create(getGerman);
            getDictioGerman.Headers.Add("X-Secret:a0dbd97d06ca34460a0790b1f3c2d020991070fe0099052bf1aba4ac9fd7c0a1");

            string jsonString = "";
            using (WebResponse response = getDictioGerman.GetResponse())
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonString = reader.ReadToEnd();
            }

            JArray json = JArray.Parse(jsonString);
            if (json.Count > 0)
            {
                JToken tokenEnglish;
                JToken tokenGerman;

                if (json[0]["lang"].Equals("en"))
                {
                    tokenEnglish = json[0]["hits"][0]["roms"][0]["arabs"][0]["translations"][0]["target"];
                    model.EnglishVersion = (string)tokenEnglish;

                    tokenGerman = json[0]["hits"][0]["roms"][0]["arabs"][0]["translations"][0]["source"];
                    model.GermanVersion = (string)tokenGerman;
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult GetWordG(string text, string targetLanguageCode, string sourceLanguageCode,
        TranslationModel model, WordsViewModel modelWord)
        {

            string path = "C:\\Users\\kassandra\\kass\\SprungTrials\\SprungGerman\\SprungGerman-161453e8b170.json";
            string result = "";
            using (StreamReader r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                result = jobj.ToString();
            }

            var credential = GoogleCredential.FromJson(result);

            TranslationClient client = TranslationClient.Create(credential);
            var response = client.TranslateText(text, "de", "en", TranslationModel.Base);
            modelWord.EnglishVersion = text;
            modelWord.GermanVersion = response.TranslatedText;

            return View(modelWord);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpeech(WordsViewModel model) {

            HttpWebRequest webRequest =
                (HttpWebRequest)WebRequest.Create("https://speech.platform.bing.com/synthesize");

            model.Token = await GetTokenAsync();

            webRequest.Headers.Add("Authorization", "Bearer " + model.Token);
            webRequest.Headers.Add("X-Microsoft-OutputFormat", "audio-16khz-32kbitrate-mono-mp3");
            webRequest.ContentType = "application/ssml+xml";
            webRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), webRequest);
            
            return View(model);
        }

        [HttpPost]
        public async Task<string> GetTokenAsync() {

            string token;

            HttpWebRequest webRequest =
                (HttpWebRequest)WebRequest.Create("https://api.cognitive.microsoft.com/sts/v1.0/issueToken");

            webRequest.Headers.Add("Ocp-Apim-Subscription-Key", "5690875106354a989957691e5644c440");
            webRequest.ContentLength = 0;
            webRequest.ContentType = "text/plain";

            WebResponse response = await webRequest.GetResponseAsync();
            token = response.GetResponseStream().ToString();

            return token;
        }

        void GetRequestStreamCallback(IAsyncResult callbackResult)
        {
            HttpWebRequest webRequest = (HttpWebRequest)callbackResult.AsyncState;
            Stream postStream = webRequest.EndGetRequestStream(callbackResult);

            string requestBody = "<speak version='1.0' xml:lang='de-DE'><voice xml:lang='de-DE'" +
                " xml:gender='Female' name='Microsoft Server Speech Text to Speech Voice (de-DE, Hedda)'>" 
                + "Menschen sind gut" + "</voice></speak>";

            byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);

            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();

            webRequest.BeginGetResponse(new AsyncCallback(GetResponseStreamCallback), webRequest);
        }

        void GetResponseStreamCallback(IAsyncResult callbackResult)
        {
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = httpWebStreamReader.ReadToEnd();
                Debug.WriteLine(result);
            }
        }
    }
}
