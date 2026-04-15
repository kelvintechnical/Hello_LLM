using Microsoft.Extensions.Configuration;

// 1. Load API Key from user secrets
// Reads my API Key from Windows user secrets store and stores it in a string variable
// compared to load_dotenv(override=True) in Python 
// Python needs the load_dotenv to get the API Key from the .env file, but Windows
// loads it from the system environmental variables.

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = config["OPENAI_API_KEY"] 
    ?? throw new InvalidOperationException("OPENAI_API_KEY is not set.");

// 2. Create the chat client
// The client is the object that makes the API call to OpenAI.
// creates an instance of the openAI chat client, telling it which model to use and which API key
// to authenticate the API call.
// comparative to Client = OpenAI() in Python which automatically reads 
// the OPENAI_API_KEY from the environment

OpenAI.Chat.ChatClient client = new(model: "gpt-4o-mini", apiKey: apiKey);

// 3. Build the message array
// creates an array of chat messages with one user message inside it
// Compared to Python P1:
// pythonmessages=[
//     {"role": "user", "content": "Say hello..."}
// ]

OpenAI.Chat.ChatMessage[] messages = {
    new OpenAI.Chat.UserChatMessage("Hello, how are you on this fine day?")
};

// 4. Make the API call
// Makes the API call to OpenAI's servers
// and waits for the response
// Compared to Python P1:
// response = client.chat.completions.create(model=..., messages=...)
// Python's version is synchronous — it blocks until the response arrives.
// C# defaults to async — it awaits without blocking the thread. 
// Same HTTP call underneath, different threading model.

OpenAI.Chat.ChatCompletion response = await client.CompleteChatAsync(messages);

// 5. Print the response
Console.WriteLine(response.Content[0].Text);