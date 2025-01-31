using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Azure.Core;
using Azure.AI.Language.Conversations;
using Azure;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Speech.Demo;
using static Speech.Demo.IntentResponseController;
//using Azure.Identity;

// This example requires environment variables named "COGNITIVE_SERVICE_KEY " and "SPEECH_REGION"
//string speechKey = Environment.GetEnvironmentVariable("COGNITIVE_SERVICE_KEY");
//string speechRegion = Environment.GetEnvironmentVariable("SPEECH_REGION");
string speechKey = "440095e447ac4b6f8acf9f8a726304f6";
string speechRegion = "eastus";

Uri endpoint = new Uri("https://lucaslanguageresource.cognitiveservices.azure.com/");
AzureKeyCredential credential = new AzureKeyCredential("4a35c926e6174165a93e8108feb872b0"); // Não é o certo, mas como está local o projeto, só vamo

bool jarvisJaFoiAcionado = false;

string recognizedText;

async Task OutputSpeechRecognitionResult(SpeechRecognitionResult speechRecognitionResult, SpeechConfig speechConfig)
{
    // Setta a voz e linguagem
    speechConfig.SpeechSynthesisVoiceName = "pt-BR-AntonioNeural";

    switch (speechRecognitionResult.Reason)
    {
        case ResultReason.RecognizedSpeech:
            #region NLP
            // Instanciação do Client, que é como se fosse a base, a engine do processso
            ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);

            #region criação_data_JSON
            string projectName = "NLPProject";
            string deploymentName = "MyDeploy";

            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = speechRecognitionResult.Text,
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName,
                    deploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };
            #endregion

            // Realiza a análise do texto e guarda a resposta JSON em um objeto "Response"
            Response response = client.AnalyzeConversation(RequestContent.Create(data));

            // Pega o JSON do resultado
            JsonDocument result = JsonDocument.Parse(response.ContentStream);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

            #endregion
            using (var speechSynthesizer = new SpeechSynthesizer(speechConfig))
            {
                string voice_speech;
                string textoSemJarvis = speechRecognitionResult.Text.ToLower().Replace("jarvis", "");


                switch (conversationPrediction.GetProperty("topIntent").GetString())
                {
                    case "HorarioAtual":
                        IntentResponse intentResponse = GetAResponse(conversationPrediction.GetProperty("topIntent").GetString()!);

                        voice_speech = intentResponse.Phrase;
                        Console.WriteLine(intentResponse.Phrase);

                        /*
                        // Get text from the console and synthesize to the default speaker.
                        voice_speech = $"Agora são {DateTime.Now.ToShortTimeString()}";

                        Console.WriteLine(DateTime.Now.ToShortTimeString());
                        */
                        break;
                    case "Pesquisa":
                        // Pesquisa no ChatGpt

                        /*
                        var openAIApiClient = new OpenAIApiClient("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");
                        var requestResponse = openAIApiClient.SendPrompt(recognizedText, "davinci");

                        Console.WriteLine(requestResponse);
                        voice_speech = "FOI";*/

                        var openAIApiClient = new OpenAIApiClient("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");
                        var requestResponse = await openAIApiClient.SendPrompt(textoSemJarvis, "gpt-3.5-turbo");
                        Console.WriteLine("Resposta: " + requestResponse);
                        voice_speech = requestResponse;
                        break;
                    case "None":
                        // Get text from the console and synthesize to the default speaker.
                        //voice_speech = $"Não tenho comandos definidos para responder!";

                        /*
                        openAIApiClient = new OpenAIApiClient("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");
                        requestResponse = openAIApiClient.SendPrompt(recognizedText, "davinci");

                        Console.WriteLine(requestResponse);
                        voice_speech = "FOI";*/

                        openAIApiClient = new OpenAIApiClient("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");
                        requestResponse = await openAIApiClient.SendPrompt(textoSemJarvis, "gpt-3.5-turbo");
                        Console.WriteLine("Resposta: " + requestResponse);
                        voice_speech = requestResponse;
                        break;
                    case "Saudacoes":
                        // Get text from the console and synthesize to the default speaker.
                        voice_speech = $"Olá, como vai?";
                        Console.WriteLine("Olá, como vai?");

                        break;
                    default:
                        voice_speech = $"Houve algúm erro!";
                        break;
                }
                var speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(voice_speech); // Fala o texto escrito
            }
            break;
        case ResultReason.NoMatch:
            Console.WriteLine($"NOMATCH: Speech could not be recognized.");
            break;
        case ResultReason.Canceled:
            var cancellation = CancellationDetails.FromResult(speechRecognitionResult);
            Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

            if (cancellation.Reason == CancellationReason.Error)
            {
                Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
            }
            break;
    }
    Console.Clear();
}






// Inserido as configurações e autenticações
var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
speechConfig.SpeechRecognitionLanguage = "pt-BR";

// Setando o reconhecimento do microfone e áudio
using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);
SpeechRecognitionResult? speechRecognitionResult;

// Recebendo o áudio e retornando o método OutputSpeechRecognitionResult
do
{
    // Reconhece o que diz no microfone
    Console.WriteLine("Fale em seu microfone.");
    Console.Beep(1000, 200);

    // Continuará ouvindo o mic enquanto não chamar "Jarvis" ou ele já não tiver sido chamado
    do
    {
        speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();
        Console.WriteLine("Texto captado: " + speechRecognitionResult.Text);
    } while (!speechRecognitionResult.Text.Contains("jarvis") && !speechRecognitionResult.Text.Contains("Jarvis") && jarvisJaFoiAcionado == false);

    // Informa ao sistema que o Jarvis já foi acionado dentro de um intervalo especificado pelo dev em outra parte do código
    jarvisJaFoiAcionado = true;

    Console.Clear();
    Console.WriteLine("Texto captado: " + speechRecognitionResult.Text);
    recognizedText = speechRecognitionResult.Text;

    // Trata o que o texto dito para condição
    #region Tratamento_do_camando_dito_para_condição

    // Tira todos os espaços e coloca o texto em minúsculo
    string textoTratado = Regex.Replace(speechRecognitionResult.Text.ToLower(), @"\s", "");
    Console.BackgroundColor = ConsoleColor.Blue;
    //Console.WriteLine("Texto sem espaços: " + textoTratado);

    // Tira todas as pontuações exceto o (.)
    textoTratado = Regex.Replace(textoTratado, @"[\p{P}-[.]]", "");
    Console.BackgroundColor = ConsoleColor.Green;
    //Console.WriteLine("Texto sem espaços e pontuações: " + textoTratado);

    // Tira o ponto final
    textoTratado = textoTratado.TrimEnd('.');
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine("Texto final: " + textoTratado);
    #endregion

    Console.ResetColor();

    // Se apenas chamar o sistema(Jarvis), pedirá o comando
    if (textoTratado == "jarvis")
    {
        Console.Clear();
        Console.WriteLine("Pois não!");
        speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();
        //Console.Clear();
        Console.WriteLine("Processando informação!");
        await OutputSpeechRecognitionResult(speechRecognitionResult, speechConfig);
    } // Se chamar o sistema(Jarvis), já com o comando, não pedirá o comando
    else if (speechRecognitionResult.Text.Contains("Jarvis") || speechRecognitionResult.Text.Contains("jarvis") || jarvisJaFoiAcionado)
    {
        Console.Clear();
        Console.WriteLine("Processando informação...");
        await OutputSpeechRecognitionResult(speechRecognitionResult, speechConfig);
    }

} while (!speechRecognitionResult.Text.Contains("Tchau"));